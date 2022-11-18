using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.BirdCategories;

namespace ProjectGenesis.Controllers
{
    public class BirdCategoriesController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDb;

        public BirdCategoriesController(ProjectGenesisDbContext projectGenesisDb)
        {
            _projectGenesisDb = projectGenesisDb;
        }
        public async Task<IActionResult> Index()
        {
            var birdCategories = await _projectGenesisDb.BirdCategories.ToListAsync();
            return View(birdCategories);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBirdCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBirdCategory(AddBirdCategoryViewModel addBirdCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var birdCategory = new BirdCategory
                {
                    Name = addBirdCategoryViewModel.Name,
                    Purpose = addBirdCategoryViewModel.Purpose,
                    Breed = addBirdCategoryViewModel.Breed
                };

                _projectGenesisDb.BirdCategories.Add(birdCategory);
                await _projectGenesisDb.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addBirdCategoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditBirdCategory(Guid id)
        {
            var birdCategory = await _projectGenesisDb.BirdCategories.FindAsync(id);
            if (birdCategory == null)
            {
                return NotFound();
            }

            var editBirdCategoryViewModel = new EditBirdCategoryViewModel
            {
                Id = birdCategory.Id,
                Name = birdCategory.Name,
                Purpose = birdCategory.Purpose,
                Breed = birdCategory.Breed
            };

            return View(editBirdCategoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditBirdCategory(EditBirdCategoryViewModel editBirdCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var birdCategory = await _projectGenesisDb.BirdCategories.FindAsync(editBirdCategoryViewModel.Id);
                if (birdCategory == null)
                {
                    return NotFound();
                }

                birdCategory.Name = editBirdCategoryViewModel.Name;
                birdCategory.Purpose = editBirdCategoryViewModel.Purpose;
                birdCategory.Breed = editBirdCategoryViewModel.Breed;

                await _projectGenesisDb.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editBirdCategoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBirdCategory(Guid? id)
        {
            var birdCategory = await _projectGenesisDb.BirdCategories.FindAsync(id);
            if (birdCategory == null)
            {
                return NotFound();
            }

            return View(birdCategory);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBirdCategory(Guid id)
        {
            var birdCategory = await _projectGenesisDb.BirdCategories.FindAsync(id);
            if (birdCategory == null)
            {
                return NotFound();
            }

            _projectGenesisDb.BirdCategories.Remove(birdCategory);
            await _projectGenesisDb.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
