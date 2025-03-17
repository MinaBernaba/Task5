using BooksProject.Data.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksProject.Data
{
    public static class DataDependencies
    {
        public static IServiceCollection RegisterDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JWT"));
            return services;
        }
    }
}
