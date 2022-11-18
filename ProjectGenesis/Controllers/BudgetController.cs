using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;

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
        
        
    }
}
