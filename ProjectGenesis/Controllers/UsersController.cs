using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;

namespace ProjectGenesis.Controllers
{
    public class UsersController : Controller
    {
        private readonly ProjectGenesisDbContext _genesisDbContext;
        public UsersController(ProjectGenesisDbContext genesisDbContext)
        {
            _genesisDbContext = genesisDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _genesisDbContext.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {            
            return View();
        }

        [HttpPost]
        public async
    }
}
