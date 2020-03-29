using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BillGeneratorTask.Core.Models;
using BillGeneratorTask.Infrastructure;
using BillGeneratorTask.Core.ViewModel;

namespace BillGeneratorTask.Controllers
{
    public class BillGeneratorController : Controller
    {
        private readonly IUnitOfWork _uow;

        public BillGeneratorController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: BillGenerator
        public IActionResult Index()
        {
            ViewData["items"] = new SelectList(_uow.ItemRepository.GetAll(), "Id", "Name");
            TotalBillViewModel totalBillViewModel = new TotalBillViewModel();
            totalBillViewModel.BillGeneratorViewModels = _uow.BillGeneratorRepository.GetBillList();
            calculateTotal(totalBillViewModel.BillGeneratorViewModels, ref totalBillViewModel);
            return View(totalBillViewModel);
        }

        // GET: BillGenerator/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var billGenerator = await _context.BillGenerators
            //    .Include(b => b.Item)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (billGenerator == null)
            //{
            //    return NotFound();
            //}

            return View();
        }


        private void calculateTotal(List<BillGeneratorViewModel> billGeneratorViewModels, ref TotalBillViewModel totalBillViewModel)
        {
            double totalItems = 0;
            double totalDiscount = 0;
            double totalGST = 0;
            double grandTotal = 0;
            foreach (var item in billGeneratorViewModels)
            {
                totalItems += item.ItemCount;
                totalDiscount += item.TotalDiscountPerItems;
                totalGST += item.TotalGSTPerItems;
                grandTotal += item.ItemTotal;
            }

            totalBillViewModel.ItemsCount = totalItems;
            totalBillViewModel.TotalDiscount = totalDiscount;
            totalBillViewModel.TotalGST = totalGST;
            totalBillViewModel.GrandTotal = grandTotal;

        }



        // POST: BillGenerator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ItemId,Count")] BillGenerator billGenerator)
        {
            if (ModelState.IsValid)
            {
                _uow.BillGeneratorRepository.AddBill(billGenerator.ItemId, billGenerator.Count);
                return RedirectToAction(nameof(Index));
            }
            return View(billGenerator);
        }


        // POST: BillGenerator/Delete/5
        [HttpGet, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _uow.BillGeneratorRepository.DeleteBill(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
