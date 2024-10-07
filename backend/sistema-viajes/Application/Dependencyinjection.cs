
using Application.Users;
using Applications;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Dependencyinjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });

        services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

        services.AddScoped<IHashPassword, HashPasswordService>();
        
        return services;
    }
}
      