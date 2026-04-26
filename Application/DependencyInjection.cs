using Application.Factory;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<RatingService>();
            services.AddSingleton<WeightsStore>();
            services.AddSingleton<DefaultsFactory>();
            return services;
        }
    }
}
