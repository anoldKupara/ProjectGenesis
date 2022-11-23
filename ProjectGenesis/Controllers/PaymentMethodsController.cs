using Microsoft.AspNetCore.Mvc;
using ProjectGenesis.Data;

namespace ProjectGenesis.Controllers
{
    public class PaymentMethodsController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;
        public PaymentMethodsController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
