using Application.Features.Chats.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Chats.Constants.ChatsOperationClaims;

namespace Application.Features.Chats.Queries.GetList;

public class GetListChatQuery : IRequest<GetListResponse<GetListChatListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListChats({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetChats";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListChatQueryHandler : IRequestHandler<GetListChatQuery, GetListResponse<GetListChatListItemDto>>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public GetListChatQueryHandler(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListChatListItemDto>> Handle(GetListChatQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Chat> chats = await _chatRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListChatListItemDto> response = _mapper.Map<GetListResponse<GetListChatListItemDto>>(chats);
            return response;
        }
    }
}