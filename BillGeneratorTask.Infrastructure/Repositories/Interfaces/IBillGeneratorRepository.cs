using BillGeneratorTask.Core.Models;
using BillGeneratorTask.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Infrastructure.Repositories.Interfaces
{
    public interface IBillGeneratorRepository : IRepository<BillGenerator>
    {
        List<BillGeneratorViewModel> GetBillList();
        void AddBill(int itemId, int count);
        void DeleteBill(int itemId);
    }
}
