using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;

namespace ProjectGenesis.Controllers
{
    public class VaccinesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public VaccinesController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vaccines = await _projectGenesisDbContext.Vaccines.ToListAsync();
            return View(vaccines);
        }   
    }
}
