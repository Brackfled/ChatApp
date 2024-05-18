using Application.Features.ChatUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ChatUsers.Queries.GetById;

public class GetByIdChatUserQuery : IRequest<GetByIdChatUserResponse>
{
    public Guid Id { get; set; }

    public class GetByIdChatUserQueryHandler : IRequestHandler<GetByIdChatUserQuery, GetByIdChatUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly ChatUserBusinessRules _chatUserBusinessRules;

        public GetByIdChatUserQueryHandler(IMapper mapper, IChatUserRepository chatUserRepository, ChatUserBusinessRules chatUserBusinessRules)
        {
            _mapper = mapper;
            _chatUserRepository = chatUserRepository;
            _chatUserBusinessRules = chatUserBusinessRules;
        }

        public async Task<GetByIdChatUserResponse> Handle(GetByIdChatUserQuery request, CancellationToken cancellationToken)
        {
            ChatUser? chatUser = await _chatUserRepository.GetAsync(predicate: cu => cu.Id == request.Id, cancellationToken: cancellationToken);
            await _chatUserBusinessRules.ChatUserShouldExistWhenSelected(chatUser);

            GetByIdChatUserResponse response = _mapper.Map<GetByIdChatUserResponse>(chatUser);
            return response;
        }
    }
}