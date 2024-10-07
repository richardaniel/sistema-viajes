using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Apllication.Data;
using Domain.Primitives;
using Domain.Customers;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Users;
using Domain.Trips;
using Domain.Transporters;
using Domain.Branches;
using Domain.CollaboratorBranches;
using Domain.TripCollaborators;

namespace Infrastructure;

public static class DependencyInjection{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services ,IConfiguration configuration){
      
        services.AddPersistence(configuration);


        services.AddAuthentication(options=>{
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })

         .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]))
            };
        });
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration){
        
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataBase")));
        
        services.AddScoped<IApplicationDbContext>(sp=>
            sp.GetRequiredService<ApplicationDbContext>());
        
        services.AddScoped<IUnitOfWork>(sp=>
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ICustomerRepository,CustomerRepository>();

       
        services.AddScoped<IUserRepository,UserRepository>();

        services.AddScoped<ITripRepository,TripRepository>();

        services.AddScoped<ITransporterRepository,TransporterRepository>();

        services.AddScoped<IBranchRepository,BranchRepository>();

        services.AddScoped<ICollaboratorBranchRepository,CollaboratorBranchRepository>();

        services.AddScoped<ITripCollaboratorRepository,TripCollaboratorRepository>();

        return services;
    }
}