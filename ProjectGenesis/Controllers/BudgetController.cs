using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
