using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;

namespace ProjectGenesis.Controllers
{
    public class SalesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public SalesController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sales = await _projectGenesisDbContext.Sales.ToListAsync();
            return View(sales);
        }
    }
}
