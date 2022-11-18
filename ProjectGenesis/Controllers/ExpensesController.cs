using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;

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
    }
}
