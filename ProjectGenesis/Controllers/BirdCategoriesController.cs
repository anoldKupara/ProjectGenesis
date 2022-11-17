using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
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
