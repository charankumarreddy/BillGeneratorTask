using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Core.ViewModel
{
    public class ItemsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
