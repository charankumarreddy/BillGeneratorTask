using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Core.ViewModel
{
    public class BillGeneratorViewModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategoryName { get; set; }
        public int ItemCategoryId { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public int ItemCount { get; set; }


        public double TotalDiscountPerItems
        {
            get
            {
                return (Price * ItemCount) * Discount / 100;
            }
        }

        public double TotalGSTPerItems
        {
            get
            {
                return ((Price * ItemCount)-TotalDiscountPerItems) * 11 / 100;
            }
        }

        public double ItemTotal
        {
            get
            {
                return (Price * ItemCount) - TotalDiscountPerItems + TotalGSTPerItems;
            }
        }

    }
}
