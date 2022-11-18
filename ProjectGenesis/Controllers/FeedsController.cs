using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
