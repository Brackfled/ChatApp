using Application.Features.Chats.Constants;
using Application.Features.Chats.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Chats.Constants.ChatsOperationClaims;

namespace Application.Features.Chats.Queries.GetById;

public class GetByIdChatQuery : IRequest<GetByIdChatResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdChatQueryHandler : IRequestHandler<GetByIdChatQuery, GetByIdChatResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChatRepository _chatRepository;
        private readonly ChatBusinessRules _chatBusinessRules;

        public GetByIdChatQueryHandler(IMapper mapper, IChatRepository chatRepository, ChatBusinessRules chatBusinessRules)
        {
            _mapper = mapper;
            _chatRepository = chatRepository;
            _chatBusinessRules = chatBusinessRules;
        }

        public async Task<GetByIdChatResponse> Handle(GetByIdChatQuery request, CancellationToken cancellationToken)
        {
            Chat? chat = await _chatRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _chatBusinessRules.ChatShouldExistWhenSelected(chat);

            GetByIdChatResponse response = _mapper.Map<GetByIdChatResponse>(chat);
            return response;
        }
    }
}