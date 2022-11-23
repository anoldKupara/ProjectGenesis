using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
