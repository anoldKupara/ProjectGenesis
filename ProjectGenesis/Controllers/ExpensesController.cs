using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Expenses;

namespace ProjectGenesis.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public ExpensesController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _projectGenesisDbContext.Expenses.ToListAsync();
            return View(expenses);
        }

        [HttpGet]
        public async Task<IActionResult> CreateExpense()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(AddExpenseViewModel addExpenseViewModel)
        {
            if (ModelState.IsValid)
            {
                var expense = new Expense
                {
                    Name = addExpenseViewModel.Name,
                    Purpose = addExpenseViewModel.Purpose,
                    SourceOfFund = addExpenseViewModel.SourceOfFund,
                    ExpenseDate = addExpenseViewModel.ExpenseDate,
                    Amount = addExpenseViewModel.Amount,
                    Currency = addExpenseViewModel.Currency
                };

                _projectGenesisDbContext.Expenses.Add(expense);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addExpenseViewModel);
        }
    }
}
