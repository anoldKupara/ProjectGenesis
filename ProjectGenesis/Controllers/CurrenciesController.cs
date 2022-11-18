using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Currencies;

namespace ProjectGenesis.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public CurrenciesController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currencies = await _projectGenesisDbContext.Currencies.ToListAsync();
            return View(currencies);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCurrency()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency(AddCurrencyViewModel addCurrencyViewModel)
        {
            if (ModelState.IsValid)
            {
                var currency = new Currency
                {
                    Name = addCurrencyViewModel.Name,
                    Symbol = addCurrencyViewModel.Symbol
                };

                _projectGenesisDbContext.Currencies.Add(currency);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addCurrencyViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditCurrency(Guid id)
        {
            var currency = await _projectGenesisDbContext.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            var editCurrencyViewModel = new EditCurrencyViewModel
            {
                Id = currency.Id,
                Name = currency.Name,
                Symbol = currency.Symbol
            };

            return View(editCurrencyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCurrency(EditCurrencyViewModel editCurrencyViewModel)
        {
            if (ModelState.IsValid)
            {
                var currency = await _projectGenesisDbContext.Currencies.FindAsync(editCurrencyViewModel.Id);
                if (currency == null)
                {
                    return NotFound();
                }

                currency.Name = editCurrencyViewModel.Name;
                currency.Symbol = editCurrencyViewModel.Symbol;

                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editCurrencyViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCurrency(Guid? id)
        {
            var currency = await _projectGenesisDbContext.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(currency);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCurrency(Guid id)
        {
            var currency = await _projectGenesisDbContext.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            _projectGenesisDbContext.Currencies.Remove(currency);
            await _projectGenesisDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
