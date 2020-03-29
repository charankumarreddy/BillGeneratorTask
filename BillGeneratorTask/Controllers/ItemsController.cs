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
    public class ItemsController : Controller
    {

        private readonly IUnitOfWork _uow;

        public ItemsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Items
        public IActionResult Index()
        {
            var items = _uow.ItemRepository.GetAllWithCategory();
            return View(items);
        }

        // GET: Items/Details/5
        public IActionResult Details(int id)
        {
            var item = _uow.ItemRepository.GetWithCategory(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["ItemCategoryId"] = new SelectList(_uow.ItemCategoryRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ItemCategoryId,Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _uow.ItemRepository.Add(item);
                _uow.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemCategoryId"] = new SelectList(_uow.ItemCategoryRepository.GetAll(), "Id", "Name", item.ItemCategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public IActionResult Edit(int id)
        {
            var item =  _uow.ItemRepository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ItemCategoryId"] = new SelectList(_uow.ItemCategoryRepository.GetAll(), "Id", "Name", item.ItemCategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ItemCategoryId,Price")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ItemRepository.Update(item);
                     _uow.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            ViewData["ItemCategoryId"] = new SelectList(_uow.ItemCategoryRepository.GetAll(), "Id", "Name", item.ItemCategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public IActionResult Delete(int id)
        {
            var item = _uow.ItemRepository.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _uow.ItemRepository.Get(id);
            _uow.ItemRepository.Remove(item);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _uow.ItemRepository.Get(id) == null ? false : true;
        }
    }
}
