using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using Server.Application.Common.Behaviors;
using Server.Application.Services;
using Server.Domain.Common;
using Server.Domain.Contracts;
using Server.Domain.Entities;

namespace Server.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        services.AddScoped(_ => new UserSession("Anonymous", "Anonymous"));
        
        services.AddScoped<IAuthentication, AuthenticationService>();
        services.AddScoped<IPasswordEncrypter, PasswordEncrypterService>();
    }
}
