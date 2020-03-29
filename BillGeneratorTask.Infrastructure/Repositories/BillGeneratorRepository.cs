using BillGeneratorTask.Core.Models;
using BillGeneratorTask.Core.ViewModel;
using BillGeneratorTask.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillGeneratorTask.Infrastructure.Repositories
{
    public class BillGeneratorRepository : Repository<BillGenerator>, IBillGeneratorRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public BillGeneratorRepository(ApplicationDbContext context) : base(context)
        { }

        public List<BillGeneratorViewModel> GetBillList()
        {
            List<BillGeneratorViewModel> billList = (from bill in _appContext.BillGenerators
                                                     join item in _appContext.Items
                                                     on bill.ItemId equals item.Id
                                                     join category in _appContext.ItemCategores on item.ItemCategoryId equals category.Id
                                                     select new BillGeneratorViewModel
                                                     {
                                                         ItemId = item.Id,
                                                         ItemName = item.Name,
                                                         Price = item.Price,
                                                         Discount = category.Discount,
                                                         ItemCategoryId = category.Id,
                                                         ItemCategoryName = category.Name,
                                                         ItemCount = bill.Count
                                                     }).ToList();

            return billList;
        }

        public void AddBill(int itemId, int count)
        {
            var billItem = _appContext.BillGenerators.Where(p => p.ItemId == itemId).FirstOrDefault();
            if (billItem == null)
            {
                _appContext.BillGenerators.Add(new BillGenerator() { ItemId = itemId, Count = count });
            }
            else
            {
                billItem.Count += count;
                _appContext.Update(billItem);
            }
            _appContext.SaveChanges();

        }

        public void DeleteBill(int itemId)
        {
            _appContext.BillGenerators.Remove(_appContext.BillGenerators.FirstOrDefault(p => p.ItemId == itemId));
            _appContext.SaveChanges();
        }
    }
}
