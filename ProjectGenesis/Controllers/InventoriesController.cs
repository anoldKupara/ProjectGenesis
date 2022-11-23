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

        [HttpGet]
        public async Task<IActionResult> EditInventory(Guid id)
        {
            var inventory = await _projectGenesisDbContext.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            var editInventoryViewModel = new EditInventoryViewModel
            {
                ItemName = inventory.ItemName,
                Purpose = inventory.Purpose,
                Quantity = inventory.Quantity,
                Amount = inventory.Amount,
                Currency = inventory.Currency,
                ExpiryDate = inventory.ExpiryDate
            };

            return View(editInventoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditInventory(Guid id, EditInventoryViewModel editInventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var inventory = await _projectGenesisDbContext.Inventories.FindAsync(id);

                if (inventory == null)
                {
                    return NotFound();
                }

                inventory.ItemName = editInventoryViewModel.ItemName;
                inventory.Purpose = editInventoryViewModel.Purpose;
                inventory.Quantity = editInventoryViewModel.Quantity;
                inventory.Amount = editInventoryViewModel.Amount;
                inventory.Currency = editInventoryViewModel.Currency;
                inventory.ExpiryDate = editInventoryViewModel.ExpiryDate;

                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editInventoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInventory(Guid? id)
        {
            var inventory = await _projectGenesisDbContext.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            var inventory = await _projectGenesisDbContext.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            _projectGenesisDbContext.Inventories.Remove(inventory);
            await _projectGenesisDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
