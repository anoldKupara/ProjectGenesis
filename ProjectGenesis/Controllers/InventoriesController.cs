using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Inventories;

namespace ProjectGenesis.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public InventoriesController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var inventories = await _projectGenesisDbContext.Inventories.ToListAsync();

            return View(inventories);
        }

        [HttpGet]
        public async Task<IActionResult> CreateInventory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventory(AddInventoryViewModel addInventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var inventory = new Inventory
                {
                    ItemName = addInventoryViewModel.ItemName,
                    Purpose = addInventoryViewModel.Purpose,
                    Quantity = addInventoryViewModel.Quantity,
                    Amount = addInventoryViewModel.Amount,
                    Currency = addInventoryViewModel.Currency,
                    ExpiryDate = addInventoryViewModel.ExpiryDate
                };

                _projectGenesisDbContext.Inventories.Add(inventory);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addInventoryViewModel);
        }
    }
}
