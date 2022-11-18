using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Budgets;

namespace ProjectGenesis.Controllers
{
    public class BudgetsController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public BudgetsController(ProjectGenesisDbContext projectGenesisDbContext)
        {
           _projectGenesisDbContext = projectGenesisDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var budgets = await _projectGenesisDbContext.Budgets.ToListAsync();
            return View(budgets);
            
        }

        [HttpGet]
        public async Task<IActionResult> CreateBudget()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBudget(AddBudgetViewModel addBudgetViewModel)
        {
            if (ModelState.IsValid)
            {
                var budget = new Budget
                {
                    Name = addBudgetViewModel.Name,
                    Purpose = addBudgetViewModel.Purpose,
                    SourceOfFund = addBudgetViewModel.SourceOfFund,
                    ProjectStartDate = addBudgetViewModel.ProjectStartDate,
                    ProjectEndDate = addBudgetViewModel.ProjectEndDate,
                    Amount = addBudgetViewModel.Amount,
                    Currency = addBudgetViewModel.Currency
                };

                _projectGenesisDbContext.Budgets.Add(budget);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addBudgetViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditBudget(Guid id)
        {
            var budget = await _projectGenesisDbContext.Budgets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }

            var editBudgetViewModel = new EditBudgetViewModel
            {
                Name = budget.Name,
                Purpose = budget.Purpose,
                SourceOfFund = budget.SourceOfFund,
                ProjectStartDate = budget.ProjectStartDate,
                ProjectEndDate = budget.ProjectEndDate,
                Amount = budget.Amount,
                Currency = budget.Currency
            };

            return View(editBudgetViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditBudget(Guid id, EditBudgetViewModel editBudgetViewModel)
        {
            if (ModelState.IsValid)
            {
                var budget = await _projectGenesisDbContext.Budgets.FindAsync(id);
                if (budget == null)
                {
                    return NotFound();
                }

                budget.Name = editBudgetViewModel.Name;
                budget.Purpose = editBudgetViewModel.Purpose;
                budget.SourceOfFund = editBudgetViewModel.SourceOfFund;
                budget.ProjectStartDate = editBudgetViewModel.ProjectStartDate;
                budget.ProjectEndDate = editBudgetViewModel.ProjectEndDate;
                budget.Amount = editBudgetViewModel.Amount;
                budget.Currency = editBudgetViewModel.Currency;

                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editBudgetViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBudget(Guid? id)
        {
            var budget = await _projectGenesisDbContext.Budgets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBudget(Guid id)
        {
            var budget = await _projectGenesisDbContext.Budgets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }

            _projectGenesisDbContext.Budgets.Remove(budget);
            await _projectGenesisDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
