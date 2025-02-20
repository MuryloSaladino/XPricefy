using AutoMapper;
using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Repository.Users;

namespace Server.Application.Features.Users.Find;

public sealed class FindUserHandler(
    IUserRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUserRequest, FindUserResponse>
{
    private readonly IUserRepository userRepository = userRepository;
    private readonly IMapper mapper = mapper;

    public async Task<FindUserResponse> Handle(FindUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Get(Guid.Parse(request.Id), cancellationToken)
            ?? throw new AppException("User not found", 404);

        return mapper.Map<FindUserResponse>(user);
    }
}