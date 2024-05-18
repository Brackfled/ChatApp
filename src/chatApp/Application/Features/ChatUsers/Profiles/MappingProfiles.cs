using Application.Features.ChatUsers.Commands.Create;
using Application.Features.ChatUsers.Commands.Delete;
using Application.Features.ChatUsers.Commands.Update;
using Application.Features.ChatUsers.Queries.GetById;
using Application.Features.ChatUsers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.ChatUsers.Queries.GetListByUserId;

namespace Application.Features.ChatUsers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ChatUser, CreateChatUserCommand>().ReverseMap();
        CreateMap<ChatUser, CreatedChatUserResponse>().ReverseMap();
        CreateMap<ChatUser, UpdateChatUserCommand>().ReverseMap();
        CreateMap<ChatUser, UpdatedChatUserResponse>().ReverseMap();
        CreateMap<ChatUser, DeleteChatUserCommand>().ReverseMap();
        CreateMap<ChatUser, DeletedChatUserResponse>().ReverseMap();
        CreateMap<ChatUser, GetByIdChatUserResponse>().ReverseMap();
        CreateMap<ChatUser, GetListChatUserListItemDto>().ReverseMap();
        CreateMap<IPaginate<ChatUser>, GetListResponse<GetListChatUserListItemDto>>().ReverseMap();

        CreateMap<ChatUser, GetListByUserIdChatUserListItemDto>()
            .ForMember(destinationMember: cu => cu.UserFirstName, memberOptions: opt => opt.MapFrom(cu => cu.User.FirstName))
            .ForMember(destinationMember: cu => cu.UserLastName, memberOptions: opt => opt.MapFrom(cu => cu.User.LastName))
            .ForMember(destinationMember: cu => cu.UserEmail, memberOptions: opt => opt.MapFrom(cu => cu.User.Email))
            .ForMember(destinationMember: cu => cu.UserConnectionId, memberOptions: opt => opt.MapFrom(cu => cu.User.ConnectionId))
            .ForMember(destinationMember: cu => cu.ChatName, memberOptions: opt => opt.MapFrom(cu => cu.Chat.Name))
            .ForMember(destinationMember: cu => cu.ChatDescription, memberOptions: opt => opt.MapFrom(cu => cu.Chat.Description))
            .ForMember(destinationMember: cu => cu.ChatMessages, memberOptions: opt => opt.MapFrom(cu => cu.Chat.Messages))
            .ReverseMap();
        CreateMap<IPaginate<ChatUser>, GetListResponse<GetListByUserIdChatUserListItemDto>>().ReverseMap();
    }
}