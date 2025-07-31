using FortressAuth.Domain.Interfaces;
using FortressAuth.Infraestructure.Data;
using FortressAuth.Infraestructure.Security;
using Microsoft.EntityFrameworkCore;

namespace FortressAuth
{
    public static class WebApiStartup
    {
        public static IServiceCollection WebApiRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers();

            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();



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

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IPasswordHasher, BcryptPasswordHasher>();

            return serviceCollection;
        }
    }
}
