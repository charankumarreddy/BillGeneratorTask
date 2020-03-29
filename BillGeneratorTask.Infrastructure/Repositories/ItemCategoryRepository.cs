using BillGeneratorTask.Core.Models;
using BillGeneratorTask.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Infrastructure.Repositories
{
    class ItemCategoryRepository : Repository<ItemCategory>, IItemCategoryRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public ItemCategoryRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
