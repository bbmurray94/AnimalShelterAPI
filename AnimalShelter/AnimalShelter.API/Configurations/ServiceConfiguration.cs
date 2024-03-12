using AnimalShelter.Data.Interfaces;
using AnimalShelter.Data.Backends;
using AnimalShelter.API.Exchange;

namespace AnimalShelter.API.Configurations
{
    public static class ServiceConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDogsBackend, DogsBackend>()
                .AddScoped<IDogsExchange, DogsExchange>();
            services.AddScoped<IWalkersBackend, WalkersBackend>()
                .AddScoped<IWalkersExchange, WalkersExchange>();
        }
    }
}
