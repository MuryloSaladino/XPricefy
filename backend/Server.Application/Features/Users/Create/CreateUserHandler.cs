using AutoMapper;
using MediatR;
using Server.Application.Repository;
using Server.Application.Repository.Users;
using Server.Domain.Contracts;
using Server.Domain.Entities;

namespace Server.Application.Features.Users.Create;

public sealed class CreateUserHandler(
    IPasswordEncrypter encrypter,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IPasswordEncrypter encrypter = encrypter;
    private readonly IUserRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateUserResponse> Handle(
        CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        user.Password = encrypter.Hash(user);
        userRepository.Create(user);
        
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateUserResponse>(user);
    }
}