using BillGeneratorTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Core.ViewModel
{
    public class TotalBillViewModel
    {
        public List<BillGeneratorViewModel> BillGeneratorViewModels { get; set; } = new List<BillGeneratorViewModel>();
        public BillGenerator BillGenerator { get; set; } = new BillGenerator();
        public double TotalDiscount { get; set; }

        public double TotalGST { get; set; }

        public double GrandTotal { get; set; }
        public object ItemsCount { get; set; }
    }
}
