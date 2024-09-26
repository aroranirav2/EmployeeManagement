using APICommonServices.CustomExceptionMiddleware;
using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace APICommonServices.Extensions
{
    public static class ProgramExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ExceptionMiddleware>();
    }
}
