using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Core.Models
{
    public class BillGenerator: Entity
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
    }
}
