using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;

namespace ProjectGenesis.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public InventoriesController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var inventories = await _projectGenesisDbContext.Inventories.ToListAsync();

            return View(inventories);
        }
    }
}
