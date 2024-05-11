using Application.Features.Chats.Constants;
using Application.Features.Chats.Constants;
using Application.Features.Chats.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Chats.Constants.ChatsOperationClaims;

namespace Application.Features.Chats.Commands.Delete;

public class DeleteChatCommand : IRequest<DeletedChatResponse>, ISecuredRequest, ICacheRemoverRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ChatsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetChats"];

    public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand, DeletedChatResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChatRepository _chatRepository;
        private readonly ChatBusinessRules _chatBusinessRules;

        public DeleteChatCommandHandler(IMapper mapper, IChatRepository chatRepository,
                                         ChatBusinessRules chatBusinessRules)
        {
            _mapper = mapper;
            _chatRepository = chatRepository;
            _chatBusinessRules = chatBusinessRules;
        }

        public async Task<DeletedChatResponse> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            Chat? chat = await _chatRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _chatBusinessRules.ChatShouldExistWhenSelected(chat);

            await _chatRepository.DeleteAsync(chat!);

            DeletedChatResponse response = _mapper.Map<DeletedChatResponse>(chat);
            return response;
        }
    }
}