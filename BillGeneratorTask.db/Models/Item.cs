using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillGeneratorTask.Core.Models
{
    public class Item : Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        [Required]
        public Double Price { get; set; }
        public ItemCategory ItemCategory { get; set; }
    }
}
