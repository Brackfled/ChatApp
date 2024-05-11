using Application.Features.Chats.Commands.Create;
using Application.Features.Chats.Commands.Delete;
using Application.Features.Chats.Commands.Update;
using Application.Features.Chats.Queries.GetById;
using Application.Features.Chats.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Chats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Chat, CreateChatCommand>().ReverseMap();
        CreateMap<Chat, CreatedChatResponse>().ReverseMap();
        CreateMap<Chat, UpdateChatCommand>().ReverseMap();
        CreateMap<Chat, UpdatedChatResponse>().ReverseMap();
        CreateMap<Chat, DeleteChatCommand>().ReverseMap();
        CreateMap<Chat, DeletedChatResponse>().ReverseMap();
        CreateMap<Chat, GetByIdChatResponse>().ReverseMap();
        CreateMap<Chat, GetListChatListItemDto>().ReverseMap();
        CreateMap<IPaginate<Chat>, GetListResponse<GetListChatListItemDto>>().ReverseMap();
    }
}