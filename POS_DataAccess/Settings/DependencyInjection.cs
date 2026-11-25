using Microsoft.Extensions.DependencyInjection;
using POS_DataAccess.Interfaces;
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
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<ISaleItemsRepository, SaleItemsRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IProductBatchRepository, ProductBatchRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();

            return services;
        }
    }

}
