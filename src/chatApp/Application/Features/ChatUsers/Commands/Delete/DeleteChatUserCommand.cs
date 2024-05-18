using Application.Features.ChatUsers.Constants;
using Application.Features.ChatUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ChatUsers.Commands.Delete;

public class DeleteChatUserCommand : IRequest<DeletedChatUserResponse>
{
    public Guid Id { get; set; }

    public class DeleteChatUserCommandHandler : IRequestHandler<DeleteChatUserCommand, DeletedChatUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly ChatUserBusinessRules _chatUserBusinessRules;

        public DeleteChatUserCommandHandler(IMapper mapper, IChatUserRepository chatUserRepository,
                                         ChatUserBusinessRules chatUserBusinessRules)
        {
            _mapper = mapper;
            _chatUserRepository = chatUserRepository;
            _chatUserBusinessRules = chatUserBusinessRules;
        }

        public async Task<DeletedChatUserResponse> Handle(DeleteChatUserCommand request, CancellationToken cancellationToken)
        {
            ChatUser? chatUser = await _chatUserRepository.GetAsync(predicate: cu => cu.Id == request.Id, cancellationToken: cancellationToken);
            await _chatUserBusinessRules.ChatUserShouldExistWhenSelected(chatUser);

            await _chatUserRepository.DeleteAsync(chatUser!);

            DeletedChatUserResponse response = _mapper.Map<DeletedChatUserResponse>(chatUser);
            return response;
        }
    }
}