using BillGeneratorTask.Infrastructure.Repositories;
using BillGeneratorTask.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {


        private ApplicationDbContext _context;
        private IItemRepository _items;
        private IItemCategoryRepository _itemCategories;
        private IBillGeneratorRepository _billGenerator;
       
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IItemCategoryRepository ItemCategoryRepository
        {
            get
            {
                if (_itemCategories == null)
                    _itemCategories = new ItemCategoryRepository(_context);

                return _itemCategories;
            }
        }

        public IItemRepository ItemRepository
        {
            get
            {
                if (_items == null)
                    _items = new ItemRepository(_context);

                return _items;
            }
        }

        public IBillGeneratorRepository BillGeneratorRepository
        {
            get
            {
                if (_billGenerator == null)
                    _billGenerator = new BillGeneratorRepository(_context);

                return _billGenerator;
            }
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
