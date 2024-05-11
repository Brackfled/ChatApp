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
using Application.Services.Hubs;

namespace Application.Features.Chats.Commands.Create;

public class CreateChatCommand : IRequest<CreatedChatResponse>, ISecuredRequest, ICacheRemoverRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, ChatsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetChats"];

    public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, CreatedChatResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChatRepository _chatRepository;
        private readonly ChatBusinessRules _chatBusinessRules;

        public CreateChatCommandHandler(IMapper mapper, IChatRepository chatRepository,
                                         ChatBusinessRules chatBusinessRules)
        {
            _mapper = mapper;
            _chatRepository = chatRepository;
            _chatBusinessRules = chatBusinessRules;
        }

        public async Task<CreatedChatResponse> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            Chat chat = _mapper.Map<Chat>(request);

            await _chatRepository.AddAsync(chat);

            CreatedChatResponse response = _mapper.Map<CreatedChatResponse>(chat);
            return response;
        }
    }
}