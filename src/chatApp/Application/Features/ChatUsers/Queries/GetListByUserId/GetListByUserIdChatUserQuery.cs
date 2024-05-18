using Application.Features.Users.Rules;
using Application.Services.ChatUsers;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ChatUsers.Queries.GetListByUserId;
public class GetListByUserIdChatUserQuery: IRequest<GetListResponse<GetListByUserIdChatUserListItemDto>>
{
    public Guid UserId { get; set; }

    public class GetListByUserIdChatUserQueryHandler: IRequestHandler<GetListByUserIdChatUserQuery, GetListResponse<GetListByUserIdChatUserListItemDto>>
    {
        private readonly IChatUserService _chatUserService;
        private readonly IUserService _userService;
        private readonly UserBusinessRules _userBusinessRules;
        private IMapper _mapper;

        public GetListByUserIdChatUserQueryHandler(IChatUserService chatUserService, IUserService userService, UserBusinessRules userBusinessRules, IMapper mapper)
        {
            _chatUserService = chatUserService;
            _userService = userService;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByUserIdChatUserListItemDto>> Handle(GetListByUserIdChatUserQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(u => u.Id.Equals(request.UserId));
            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

            IPaginate<ChatUser>? chatUsers = await _chatUserService.GetListAsync(
                    predicate: cu => cu.UserId.Equals(request.UserId),
                    include: cu => cu.Include(cu => cu.User).Include(cu => cu.Chat),
                    index:0,
                    size:1000,
                    cancellationToken:cancellationToken
                );

            GetListResponse<GetListByUserIdChatUserListItemDto> response = _mapper.Map<GetListResponse<GetListByUserIdChatUserListItemDto>>(chatUsers);
            return response;
        }
    }
}
