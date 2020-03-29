using BillGeneratorTask.Infrastructure.Repositories;
using BillGeneratorTask.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Infrastructure
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddInfrastructurServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ApplicationDbContext>();
            services.AddTransient<ISeedData, SeedData>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemCategoryRepository, ItemCategoryRepository>();

            return services;
        }
    }
}
