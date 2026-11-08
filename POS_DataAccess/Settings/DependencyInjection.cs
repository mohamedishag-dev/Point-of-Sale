using POS_DataAccess.interfaceis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using FxResources.Microsoft.Extensions.DependencyInjection;
using POS_DataAccess.Repositories;

namespace POS_DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISaleItemsRepository, SaleItemsRepository>();
            services.AddScoped<IProductBatchesRepository, ProductBatchesRepository>();
            return services;
        }
    }

}
