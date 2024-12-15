//using Contracts;
//using LoggerService;

//namespace EmployeeManagement.API.Extensions
//{
//    public static class ServiceExtensions
//    {
//        const string AppSettingsOrigins = "AppSettingsOrigins";
//        public static void ConfigureCors(this IServiceCollection services)
//        {
//            services.AddCors(options =>
//            {
//                options.AddPolicy(name: AppSettingsOrigins,
//                    policiyBuilder =>
//                    {
//                        policiyBuilder.WithOrigins(builder.Configuration["CorsSettings:AllowedClients"].ToString())
//                        .AllowCredentials()
//                        .AllowAnyHeader()
//                        .AllowAnyMethod();
//                    });
//            });
//        }
//        public static void ConfigureLoggerService(this IServiceCollection services)
//        {
//            services.AddSingleton<ILoggerManager, LoggerManager>();
//        }
//        public static void Configure
//    }
//}
