using BusinessLogic;
using DataAccess;
using DbService;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer.Service
{
    public static class ModularService
    {
        #region AddServices

        public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContextService(builder);
            services.AddBusinessLogicServices();
            services.AddDataAccessService();
            services.AddJsonServices();

            return services;
        }

        #endregion

        #region AddDbContextService
        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient);
            return services;
        }
        #endregion

        #region AddBusinessLogicServices
        private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<BL_Blog>();
            return services;
        }
        #endregion

        #region AddDataAccessService
        private static IServiceCollection AddDataAccessService(this IServiceCollection services)
        {
            services.AddScoped<DA_Blog>();
            return services;
        }

        #endregion

        #region AddJsonServices
        private static IServiceCollection AddJsonServices(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            return services;
        }

        #endregion




    }
}
