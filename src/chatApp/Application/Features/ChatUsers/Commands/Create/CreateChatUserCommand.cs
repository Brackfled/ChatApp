using Application.Features.ChatUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ChatUsers.Commands.Create;

public class CreateChatUserCommand : IRequest<CreatedChatUserResponse>
{
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
    public User User { get; set; }
    public Chat Chat { get; set; }

    public class CreateChatUserCommandHandler : IRequestHandler<CreateChatUserCommand, CreatedChatUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly ChatUserBusinessRules _chatUserBusinessRules;

        public CreateChatUserCommandHandler(IMapper mapper, IChatUserRepository chatUserRepository,
                                         ChatUserBusinessRules chatUserBusinessRules)
        {
            _mapper = mapper;
            _chatUserRepository = chatUserRepository;
            _chatUserBusinessRules = chatUserBusinessRules;
        }

        public async Task<CreatedChatUserResponse> Handle(CreateChatUserCommand request, CancellationToken cancellationToken)
        {
            ChatUser chatUser = _mapper.Map<ChatUser>(request);

            await _chatUserRepository.AddAsync(chatUser);

            CreatedChatUserResponse response = _mapper.Map<CreatedChatUserResponse>(chatUser);
            return response;
        }
    }
}