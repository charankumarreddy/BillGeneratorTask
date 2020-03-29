using BillGeneratorTask.Core.Models;
using BillGeneratorTask.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Infrastructure.Repositories.Interfaces
{
   public interface IItemRepository : IRepository<Item>
    {
        IList<ItemsViewModel> GetAllWithCategory();
        ItemsViewModel GetWithCategory(int id);
    }
}
