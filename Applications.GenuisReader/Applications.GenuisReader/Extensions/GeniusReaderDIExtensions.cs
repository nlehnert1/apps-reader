using Applications.GenuisReader;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sieve.Services;

namespace GeniusReader.WebApp.Extensions
{
    public static class GeniusReaderDIExtensions
    {
        public static void AddServiceDI(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddScoped<ISieveProcessor, SieveProcessor>();
        }
    }
}
