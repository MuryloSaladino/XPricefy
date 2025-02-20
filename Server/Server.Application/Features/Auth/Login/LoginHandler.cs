using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Repository.Users;
using Server.Domain.Contracts;

namespace Server.Application.Features.Auth.Login;

public sealed class LoginHandler(
    IPasswordEncrypter encrypter,
    IUserRepository userRepository,
    IAuthenticationService authentication
) : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IPasswordEncrypter encrypter = encrypter;
    private readonly IUserRepository userRepository = userRepository;
    private readonly IAuthenticationService authentication = authentication;

    public async Task<LoginResponse> Handle(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsername(request.Username, cancellationToken)
            ?? throw new AppException("User not found", 404);
        
        if(!encrypter.Matches(user, request.Password)) 
            throw new AppException("Credentials do not match", 401);
        
        var token = authentication.GenerateUserToken(user.Id.ToString(), user.Username);

        return new LoginResponse(token);
    }
}