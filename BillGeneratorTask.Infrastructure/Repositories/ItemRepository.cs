using BillGeneratorTask.Core.Models;
using BillGeneratorTask.Core.ViewModel;
using BillGeneratorTask.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillGeneratorTask.Infrastructure.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public ItemRepository(ApplicationDbContext context) : base(context)
        { }

        public IList<ItemsViewModel> GetAllWithCategory()
        {
            IList<ItemsViewModel> itemsViewModels = new List<ItemsViewModel>();
            var items = _appContext.Items.Include(p => p.ItemCategory).ToList();
            foreach (var item in items)
            {
                itemsViewModels.Add(new ItemsViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryId = item.ItemCategoryId,
                    CategoryName = item.ItemCategory.Name,
                    Price = item.Price
                });
            }
            return itemsViewModels;
        }

        public ItemsViewModel GetWithCategory(int id)
        {
            var item = _appContext.Items.Include(p => p.ItemCategory).FirstOrDefault(p=>p.Id ==id);
            if(item!= null)
            {
                ItemsViewModel itemsViewModel = new ItemsViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryId = item.ItemCategoryId,
                    CategoryName = item.ItemCategory.Name,
                    Price = item.Price

                };
            return itemsViewModel;
            }
            return null; 
        }
    }
}
