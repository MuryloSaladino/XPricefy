using AutoMapper;
using Server.Domain.Entities;

namespace Server.Application.Features.Users.Find;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<User, FindUserResponse>();
    }
}