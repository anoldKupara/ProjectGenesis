using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Vaccines;

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

        [HttpGet]
        public async Task<IActionResult> CreateVaccine()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVaccine(AddVaccineViewModel addVaccineViewModel)
        {
            if (ModelState.IsValid)
            {
                var vaccine = new Vaccine
                {
                    Name = addVaccineViewModel.Name,
                    Description = addVaccineViewModel.Description,
                    Purpose = addVaccineViewModel.Purpose,
                    Alternative = addVaccineViewModel.Alternative,
                    ExpiryDate = addVaccineViewModel.ExpiryDate,
                    Quantity = addVaccineViewModel.Quantity,
                    Amount = addVaccineViewModel.Amount,
                    Currency = addVaccineViewModel.Currency
                };

                _projectGenesisDbContext.Vaccines.Add(vaccine);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addVaccineViewModel);
        }
    }
}
