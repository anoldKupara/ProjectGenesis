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

        [HttpGet]
        public async Task<IActionResult> EditExpense(Guid id)
        {
            var expense = await _projectGenesisDbContext.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            var editExpenseViewModel = new EditExpenseViewModel
            {
                Id = expense.Id,
                Name = expense.Name,
                Purpose = expense.Purpose,
                SourceOfFund = expense.SourceOfFund,
                ExpenseDate = expense.ExpenseDate,
                Amount = expense.Amount,
                Currency = expense.Currency
            };

            return View(editExpenseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditExpense(EditExpenseViewModel editExpenseViewModel)
        {
            if (ModelState.IsValid)
            {
                var expense = await _projectGenesisDbContext.Expenses.FindAsync(editExpenseViewModel.Id);
                if (expense == null)
                {
                    return NotFound();
                }

                expense.Name = editExpenseViewModel.Name;
                expense.Purpose = editExpenseViewModel.Purpose;
                expense.SourceOfFund = editExpenseViewModel.SourceOfFund;
                expense.ExpenseDate = editExpenseViewModel.ExpenseDate;
                expense.Amount = editExpenseViewModel.Amount;
                expense.Currency = editExpenseViewModel.Currency;

                _projectGenesisDbContext.Expenses.Update(expense);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editExpenseViewModel);
        }

        
        [HttpGet]
        public async Task<IActionResult> DeleteExpense(Guid? id)
        {
            var expense = await _projectGenesisDbContext.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            var expense = await _projectGenesisDbContext.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _projectGenesisDbContext.Expenses.Remove(expense);
            await _projectGenesisDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
