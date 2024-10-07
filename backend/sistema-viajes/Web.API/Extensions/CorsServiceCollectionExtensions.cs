using Microsoft.Extensions.DependencyInjection;

namespace Web.API.Extensions
{
    public static class CorsServiceCollectionExtensions
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin() // Cambiar esto según la configuración
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
