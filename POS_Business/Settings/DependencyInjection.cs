using Microsoft.Extensions.DependencyInjection;
using POS_Business.interfaceis;
using POS_Business.Services;

namespace POS_Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            POS_DataAccess.DependencyInjection.AddDataAccess(services);
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductBatchesService, ProductBatchesService>();
            return services;
        }
    }
}