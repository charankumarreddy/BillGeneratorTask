using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BillGeneratorTask.Core.Models
{
    public class ItemCategory : Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Discount { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
