﻿using AnimalShelter.Data.Interfaces;
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
            services.AddScoped<IActivitiesBackend, ActivitiesBackend>()
                .AddScoped<IActivitiesExchange, ActivitiesExchange>();
            services.AddScoped<IBoardBackend, BoardBackend>()
                .AddScoped<IBoardExchange, BoardExchange>();
            services.AddScoped<IUsersBackend, UsersBackend>()
                .AddScoped<IUsersExchange, UsersExchange>()
                .AddScoped<IUserRolesExchange, UserRolesExchange>();
        }
    }
}
