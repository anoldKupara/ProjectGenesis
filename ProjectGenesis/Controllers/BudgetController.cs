using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Budgets;

namespace ProjectGenesis.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public BudgetController(ProjectGenesisDbContext projectGenesisDbContext)
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

    }
}
