using FluentValidation;
using FortressAuth.Application.Interfaces.Security;
using FortressAuth.Application.Interfaces.Services;
using FortressAuth.Application.Services;
using FortressAuth.Application.Validators.User;
using FortressAuth.Domain.Interfaces;
using FortressAuth.Infraestructure.Data;
using FortressAuth.Infraestructure.Data.Repositories;
using FortressAuth.Infraestructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace FortressAuth
{
    public static class WebApiStartup
    {
        public static IServiceCollection WebApiRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(configureOptions =>
            {
                configureOptions.AddPolicy("USER", policy => policy.RequireRole("USER", "ADMIN"));
                configureOptions.AddPolicy("ADMIN", policy => policy.RequireRole("ADMIN"));
            });

            serviceCollection.AddControllers();

            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "FortressAuth API",
                        Version = "v1"
                    });

                setupAction.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.\r\n\r\n Enter 'Bearer'[space] and then your token in the text input below. \r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                setupAction.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference()
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });

            return serviceCollection;
        }

        public static IServiceCollection InfraestructureRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<SqlServerDbContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var stringConnection = configuration.GetConnectionString("SqlServer");

                dbContextOptionsBuilder.UseSqlServer(stringConnection);
            });

            serviceCollection.AddScoped<IJwtService, JwtService>();

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IRefreshTokenUserRepository, RefreshTokenUserRepository>();

            serviceCollection.AddScoped<IPasswordHasher, BcryptPasswordHasher>();

            return serviceCollection;
        }


        public static IServiceCollection ApplicationRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IAuthService, AuthService>();

            serviceCollection.AddAutoMapper(configAction =>
            {
                configAction.AddMaps(AppDomain.CurrentDomain.Load("FortressAuth.Application"));
            });

            serviceCollection.AddValidatorsFromAssemblyContaining<CreateUserDTOValidator>();

            return serviceCollection;
        }
    }
}
