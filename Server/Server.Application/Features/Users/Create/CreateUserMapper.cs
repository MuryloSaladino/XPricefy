using AutoMapper;
using Server.Domain.Entities;

namespace Server.Application.Features.Users.Create;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}