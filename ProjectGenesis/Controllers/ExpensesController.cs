using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
