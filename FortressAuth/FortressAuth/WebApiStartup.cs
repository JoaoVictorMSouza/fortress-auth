namespace FortressAuth
{
    public static class WebApiStartup
    {
        public static IServiceCollection WebApiRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();

            return serviceCollection;
        }
    }
}
