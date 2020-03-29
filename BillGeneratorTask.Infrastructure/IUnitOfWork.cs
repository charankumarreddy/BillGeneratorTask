using BillGeneratorTask.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Infrastructure
{
    public interface IUnitOfWork
    {
        IItemRepository ItemRepository { get; }
        IItemCategoryRepository ItemCategoryRepository { get; }

        IBillGeneratorRepository BillGeneratorRepository { get; }

        int SaveChanges();
    }
}
