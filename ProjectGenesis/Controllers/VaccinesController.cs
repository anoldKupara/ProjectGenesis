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

        [HttpGet]
        public async Task<IActionResult> EditVaccine(Guid id)
        {
            var vaccine = await _projectGenesisDbContext.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }

            var editVaccineViewModel = new EditVaccineViewModel
            {
                Name = vaccine.Name,
                Description = vaccine.Description,
                Purpose = vaccine.Purpose,
                Alternative = vaccine.Alternative,
                ExpiryDate = vaccine.ExpiryDate,
                Quantity = vaccine.Quantity,
                Amount = vaccine.Amount,
                Currency = vaccine.Currency
            };

            return View(editVaccineViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditVaccine(Guid id, EditVaccineViewModel editVaccineViewModel)
        {
            if (ModelState.IsValid)
            {
                var vaccine = await _projectGenesisDbContext.Vaccines.FindAsync(id);
                if (vaccine == null)
                {
                    return NotFound();
                }

                vaccine.Name = editVaccineViewModel.Name;
                vaccine.Description = editVaccineViewModel.Description;
                vaccine.Purpose = editVaccineViewModel.Purpose;
                vaccine.Alternative = editVaccineViewModel.Alternative;
                vaccine.ExpiryDate = editVaccineViewModel.ExpiryDate;
                vaccine.Quantity = editVaccineViewModel.Quantity;
                vaccine.Amount = editVaccineViewModel.Amount;
                vaccine.Currency = editVaccineViewModel.Currency;

                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editVaccineViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVaccine(Guid? id)
        {
            var vaccine = await _projectGenesisDbContext.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVaccine(Guid id)
        {
            var vaccine = await _projectGenesisDbContext.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }

            _projectGenesisDbContext.Vaccines.Remove(vaccine);
            await _projectGenesisDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
