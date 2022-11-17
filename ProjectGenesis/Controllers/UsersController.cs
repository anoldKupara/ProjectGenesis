using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.Users;

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
        public async Task<IActionResult> CreateUser(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = addUserViewModel.Name,
                    Surname = addUserViewModel.Surname,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password,
                    DateOfBirth = addUserViewModel.DateOfBirth
                };
                _genesisDbContext.Users.Add(user);
                await _genesisDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(Guid id)
        {
            var user = await _genesisDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var editUserViewModel = new EditUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _genesisDbContext.Users.FindAsync(editUserViewModel.Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.Name = editUserViewModel.Name;
                user.Surname = editUserViewModel.Surname;
                user.Email = editUserViewModel.Email;
                user.Password = editUserViewModel.Password;
                user.DateOfBirth = editUserViewModel.DateOfBirth;
                await _genesisDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(Guid? id)
        {
            var user = await _genesisDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _genesisDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _genesisDbContext.Users.Remove(user);
            await _genesisDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
