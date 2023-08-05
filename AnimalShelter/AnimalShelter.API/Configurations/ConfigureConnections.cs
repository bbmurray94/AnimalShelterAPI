using AnimalShelter.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration) 
        {
            string connection = String.Empty;
            connection = configuration.GetConnectionString("testDb");
            services.AddDbContext<AnimalShelterContext>(options => options.UseMySQL(connection));

            return services;
        }
    }
}
