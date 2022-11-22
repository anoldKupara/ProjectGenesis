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

        [HttpGet]
        public async Task<IActionResult> EditFeed(Guid id)
        {
            var feed = await _projectGenesisDbContext.Feeds.FindAsync(id);
            if (feed == null)
            {
                return NotFound();
            }

            var editFeedViewModel = new EditFeedViewModel
            {
                Id = feed.Id,
                Name = feed.Name,
                Purpose = feed.Purpose,
                DateOfPurchase = feed.DateOfPurchase,
                DateOfExpiry = feed.DateOfExpiry,
                Amount = feed.Amount,
                Currency = feed.Currency,
                Supplier = feed.Supplier,
                Quantity = feed.Quantity
            };

            return View(editFeedViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditFeed(EditFeedViewModel editFeedViewModel)
        {
            if (ModelState.IsValid)
            {
                var feed = await _projectGenesisDbContext.Feeds.FindAsync(editFeedViewModel.Id);
                if (feed == null)
                {
                    return NotFound();
                }

                feed.Name = editFeedViewModel.Name;
                feed.Purpose = editFeedViewModel.Purpose;
                feed.DateOfPurchase = editFeedViewModel.DateOfPurchase;
                feed.DateOfExpiry = editFeedViewModel.DateOfExpiry;
                feed.Amount = editFeedViewModel.Amount;
                feed.Currency = editFeedViewModel.Currency;
                feed.Supplier = editFeedViewModel.Supplier;
                feed.Quantity = editFeedViewModel.Quantity;

                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editFeedViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFeed(Guid? id)
        {
            var feed = await _projectGenesisDbContext.Feeds.FindAsync(id);
            if (feed == null)
            {
                return NotFound();
            }

            return View(feed);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFeed(Guid id)
        {
            var feed = await _projectGenesisDbContext.Feeds.FindAsync(id);
            if (feed == null)
            {
                return NotFound();
            }

            _projectGenesisDbContext.Feeds.Remove(feed);
            await _projectGenesisDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
