using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BillGeneratorTask.Core.Models;
using BillGeneratorTask.Infrastructure;

namespace BillGeneratorTask.Controllers
{
    public class ItemCategoriesController : Controller
    {
        private readonly IUnitOfWork _uow;

        public ItemCategoriesController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        // GET: ItemCategories
        public IActionResult Index()
        {
            return View(_uow.ItemCategoryRepository.GetAll());
        }

        // GET: ItemCategories/Details/5
        public IActionResult Details(int id)
        {

            var itemCategory = _uow.ItemCategoryRepository.Get(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // GET: ItemCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Discount")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                _uow.ItemCategoryRepository.Add(itemCategory);
                _uow.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(itemCategory);
        }

        // GET: ItemCategories/Edit/5
        public IActionResult Edit(int id)
        {

            var itemCategory = _uow.ItemCategoryRepository.Get(id);
            if (itemCategory == null)
            {
                return NotFound();
            }
            return View(itemCategory);
        }

        // POST: ItemCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Discount")] ItemCategory itemCategory)
        {
            if (id != itemCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ItemCategoryRepository.Update(itemCategory);
                    _uow.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCategoryExists(itemCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemCategory);
        }

        // GET: ItemCategories/Delete/5
        public IActionResult Delete(int id)
        {
            var itemCategory = _uow.ItemCategoryRepository.Get(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // POST: ItemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var itemCategory =  _uow.ItemCategoryRepository.Get(id);
            _uow.ItemCategoryRepository.Remove(itemCategory);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCategoryExists(int id)
        {
            return _uow.ItemCategoryRepository.Get(id) == null ? false :true;
        }
    }
}
