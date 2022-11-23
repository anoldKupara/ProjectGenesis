using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Sales;

namespace ProjectGenesis.Controllers
{
    public class SalesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public SalesController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sales = await _projectGenesisDbContext.Sales.ToListAsync();
            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSale()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(AddSaleViewModel addSaleViewModel)
        {
            if (ModelState.IsValid)
            {
                var sale = new Sale
                {
                    ItemPurchased = addSaleViewModel.ItemPurchased,
                    Quantity = addSaleViewModel.Quantity,
                    Price = addSaleViewModel.Price,
                    PaymentMethod = addSaleViewModel.PaymentMethod,
                    DateOfPurchase = addSaleViewModel.DateOfPurchase
                };

                _projectGenesisDbContext.Sales.Add(sale);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addSaleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditSale(Guid id)
        {
            var sale = await _projectGenesisDbContext.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            var editSaleViewModel = new EditSaleViewModel
            {
                Id = sale.Id,
                ItemPurchased = sale.ItemPurchased,
                Quantity = sale.Quantity,
                Price = sale.Price,
                PaymentMethod = sale.PaymentMethod,
                DateOfPurchase = sale.DateOfPurchase
            };

            return View(editSaleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditSale(EditSaleViewModel editSaleViewModel)
        {
            if (ModelState.IsValid)
            {
                var sale = await _projectGenesisDbContext.Sales.FindAsync(editSaleViewModel.Id);
                if (sale == null)
                {
                    return NotFound();
                }

                sale.ItemPurchased = editSaleViewModel.ItemPurchased;
                sale.Quantity = editSaleViewModel.Quantity;
                sale.Price = editSaleViewModel.Price;
                sale.PaymentMethod = editSaleViewModel.PaymentMethod;
                sale.DateOfPurchase = editSaleViewModel.DateOfPurchase;

                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editSaleViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteSale(Guid? id)
        {
            var sale = await _projectGenesisDbContext.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSale(Guid id)
        {
            var sale = await _projectGenesisDbContext.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _projectGenesisDbContext.Sales.Remove(sale);
            await _projectGenesisDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
