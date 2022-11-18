using Microsoft.AspNetCore.Mvc;
using ProjectGenesis.Data;

namespace ProjectGenesis.Controllers
{
    public class CurrenciesController : Controller
    {
        public CurrenciesController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
