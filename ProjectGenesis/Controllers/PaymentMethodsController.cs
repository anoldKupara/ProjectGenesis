using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using ProjectGenesis.Models.Entities;
using ProjectGenesis.Models.ViewModels.PaymentMethods;

namespace ProjectGenesis.Controllers
{
    public class PaymentMethodsController : Controller
    {
        private readonly ProjectGenesisDbContext _projectGenesisDbContext;
        public PaymentMethodsController(ProjectGenesisDbContext projectGenesisDbContext)
        {
            _projectGenesisDbContext = projectGenesisDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var paymentMethods = await _projectGenesisDbContext.PaymentMethods.ToListAsync();

            return View(paymentMethods);
        }

        [HttpGet]
        public async Task<IActionResult> CreatePaymentMethod()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentMethod(AddPaymentMethodViewModel addPaymentMethodViewModel)
        {
            if (ModelState.IsValid)
            {
                var paymentMethod = new PaymentMethod
                {
                    Name = addPaymentMethodViewModel.Name,
                    Currency = addPaymentMethodViewModel.Currency
                };

                _projectGenesisDbContext.PaymentMethods.Add(paymentMethod);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(addPaymentMethodViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditPaymentMethod(Guid id)
        {
            var paymentMethod = await _projectGenesisDbContext.PaymentMethods.FindAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            var editPaymentMethodViewModel = new EditPaymentMethodViewModel
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Name,
                Currency = paymentMethod.Currency
            };

            return View(editPaymentMethodViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPaymentMethod(EditPaymentMethodViewModel editPaymentMethodViewModel)
        {
            if (ModelState.IsValid)
            {
                var paymentMethod = await _projectGenesisDbContext.PaymentMethods.FindAsync(editPaymentMethodViewModel.Id);

                if (paymentMethod == null)
                {
                    return NotFound();
                }

                paymentMethod.Name = editPaymentMethodViewModel.Name;
                paymentMethod.Currency = editPaymentMethodViewModel.Currency;

                _projectGenesisDbContext.PaymentMethods.Update(paymentMethod);
                await _projectGenesisDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(editPaymentMethodViewModel);
        }
    }
}
