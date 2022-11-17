using Microsoft.AspNetCore.Mvc;
using ProjectGenesis.Data;

namespace ProjectGenesis.Controllers
{
    public class BirdCategoriesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDb;

        public BirdCategoriesController(ProjectGenesisDbContext projectGenesisDb)
        {
            _projectGenesisDb = projectGenesisDb;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
