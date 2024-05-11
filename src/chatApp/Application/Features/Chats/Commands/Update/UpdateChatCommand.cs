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

namespace Application.Features.Chats.Commands.Update;

public class UpdateChatCommand : IRequest<UpdatedChatResponse>, ISecuredRequest, ICacheRemoverRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, ChatsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetChats"];

    public class UpdateChatCommandHandler : IRequestHandler<UpdateChatCommand, UpdatedChatResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChatRepository _chatRepository;
        private readonly ChatBusinessRules _chatBusinessRules;

        public UpdateChatCommandHandler(IMapper mapper, IChatRepository chatRepository,
                                         ChatBusinessRules chatBusinessRules)
        {
            _mapper = mapper;
            _chatRepository = chatRepository;
            _chatBusinessRules = chatBusinessRules;
        }

        public async Task<UpdatedChatResponse> Handle(UpdateChatCommand request, CancellationToken cancellationToken)
        {
            Chat? chat = await _chatRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _chatBusinessRules.ChatShouldExistWhenSelected(chat);
            chat = _mapper.Map(request, chat);

            await _chatRepository.UpdateAsync(chat!);

            UpdatedChatResponse response = _mapper.Map<UpdatedChatResponse>(chat);
            return response;
        }
    }
}