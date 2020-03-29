using BillGeneratorTask.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillGeneratorTask.Infrastructure
{
    public interface ISeedData
    {
        void Initialise();
    }

    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        //private readonly IWebHostEnvironment _hostingEnvironment;

        public SeedData(
            ApplicationDbContext context,
            ILogger<SeedData> logger
            //IWebHostEnvironment hostingEnvironment
            )
        {
            _context = context;
            _logger = logger;
            //_hostingEnvironment = hostingEnvironment;
        }

        public void Initialise()
        {
            _context.Database.Migrate();
            AddItemCategoryData();
            AddItemdData();
            AddBillGenerateData();

        }

       

        private void AddItemCategoryData()
        {
            if (!_context.ItemCategores.Any())
            {
                List<ItemCategory> itemCategories = new List<ItemCategory>() {
            new ItemCategory(){ Name="Medicine",Discount=5},
            new ItemCategory(){Name="Grocery ",Discount=10}
            };
                _context.ItemCategores.AddRange(itemCategories);

                _context.SaveChanges();
            }
        }

        private void AddItemdData()
        {
            if (!_context.Items.Any())
            {
                List<Item> items = new List<Item>() {
                    new Item(){ Name="Cooking Oil",ItemCategoryId=2,Price=100.00 },
                    new Item(){Name="Rice ",ItemCategoryId=2,Price=50.00},
                    new Item(){ Name="Medicine 1",ItemCategoryId=1,Price=10.00 },
                    new Item(){Name="Medicine 2",ItemCategoryId=1,Price=250.00 }
                    };
                _context.Items.AddRange(items);
                _context.SaveChanges();
            }
        }

        private void AddBillGenerateData()
        {
            if (!_context.BillGenerators.Any())
            {
                List<BillGenerator> billGenerators = new List<BillGenerator>()
                {
                    new BillGenerator{ ItemId =1,Count=2},
                    new BillGenerator{ ItemId=2 ,Count=3},
                    new BillGenerator{ ItemId=3,Count=2},
                    new BillGenerator{ ItemId=4,Count=5}
                };

                _context.BillGenerators.AddRange(billGenerators);
                _context.SaveChanges();
            }
        }
    }
}
