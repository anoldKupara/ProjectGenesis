using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;

namespace ProjectGenesis.Controllers
{
    public class FeedsController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public FeedsController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var feeds = await _projectGenesisDbContext.Feeds.ToListAsync();
            return View(feeds);
        }
    }
}
