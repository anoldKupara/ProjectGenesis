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
    }
}
