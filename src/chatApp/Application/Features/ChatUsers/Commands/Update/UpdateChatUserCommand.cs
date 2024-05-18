using Application.Features.ChatUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ChatUsers.Commands.Update;

public class UpdateChatUserCommand : IRequest<UpdatedChatUserResponse>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
    public User User { get; set; }
    public Chat Chat { get; set; }

    public class UpdateChatUserCommandHandler : IRequestHandler<UpdateChatUserCommand, UpdatedChatUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly ChatUserBusinessRules _chatUserBusinessRules;

        public UpdateChatUserCommandHandler(IMapper mapper, IChatUserRepository chatUserRepository,
                                         ChatUserBusinessRules chatUserBusinessRules)
        {
            _mapper = mapper;
            _chatUserRepository = chatUserRepository;
            _chatUserBusinessRules = chatUserBusinessRules;
        }

        public async Task<UpdatedChatUserResponse> Handle(UpdateChatUserCommand request, CancellationToken cancellationToken)
        {
            ChatUser? chatUser = await _chatUserRepository.GetAsync(predicate: cu => cu.Id == request.Id, cancellationToken: cancellationToken);
            await _chatUserBusinessRules.ChatUserShouldExistWhenSelected(chatUser);
            chatUser = _mapper.Map(request, chatUser);

            await _chatUserRepository.UpdateAsync(chatUser!);

            UpdatedChatUserResponse response = _mapper.Map<UpdatedChatUserResponse>(chatUser);
            return response;
        }
    }
}