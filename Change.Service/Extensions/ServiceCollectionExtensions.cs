using Change.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Change.Service.Extensions
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IMachineService, MachineService>();
            services.AddScoped<IAppStoreAccountService, AppStoreAccountService>();
        }
    }
}
