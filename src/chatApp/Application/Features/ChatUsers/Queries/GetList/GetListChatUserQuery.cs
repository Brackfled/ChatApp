using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ChatUsers.Queries.GetList;

public class GetListChatUserQuery : IRequest<GetListResponse<GetListChatUserListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListChatUserQueryHandler : IRequestHandler<GetListChatUserQuery, GetListResponse<GetListChatUserListItemDto>>
    {
        private readonly IChatUserRepository _chatUserRepository;
        private readonly IMapper _mapper;

        public GetListChatUserQueryHandler(IChatUserRepository chatUserRepository, IMapper mapper)
        {
            _chatUserRepository = chatUserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListChatUserListItemDto>> Handle(GetListChatUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ChatUser> chatUsers = await _chatUserRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListChatUserListItemDto> response = _mapper.Map<GetListResponse<GetListChatUserListItemDto>>(chatUsers);
            return response;
        }
    }
}