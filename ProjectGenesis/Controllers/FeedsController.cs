using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Feeds;

namespace ProjectGenesis.Controllers
{
    public class FeedsController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;

        public FeedsController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var feeds = await _projectGenesisDbContext.Feeds.ToListAsync();
            return View(feeds);
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeed()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeed(AddFeedViewModel addFeedViewModel)
        {
            if (ModelState.IsValid)
            {
                var feed = new Feed
                {
                    Name = addFeedViewModel.Name,
                    Purpose = addFeedViewModel.Purpose,
                    DateOfPurchase = addFeedViewModel.DateOfPurchase,
                    DateOfExpiry = addFeedViewModel.DateOfExpiry,
                    Amount = addFeedViewModel.Amount,
                    Currency = addFeedViewModel.Currency,
                    Supplier = addFeedViewModel.Supplier,
                    Quantity = addFeedViewModel.Quantity
                };

                _projectGenesisDbContext.Feeds.Add(feed);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addFeedViewModel);
        }


    }
}
