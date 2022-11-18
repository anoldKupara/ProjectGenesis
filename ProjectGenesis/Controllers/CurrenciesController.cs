using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;

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
    }
}
