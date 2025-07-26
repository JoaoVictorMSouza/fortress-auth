using FortressAuth.Infraestructure.Data;
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

            serviceCollection.AddDbContext<SqlServerDbContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var stringConnection = configuration.GetConnectionString("SqlServer");

                dbContextOptionsBuilder.UseSqlServer(stringConnection);
            });

            return serviceCollection;
        }
    }
}
