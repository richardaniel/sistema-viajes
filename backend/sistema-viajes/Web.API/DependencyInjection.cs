using FluentValidation;
using Web.API.Extensions;

namespace Web.API;
public static class Dependencyinjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
       
        return services;
    }
}