using electronic_component.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electronic_component.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId.Value);
            if (customer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new ProfileViewModel
            {
                FullName = customer.FullName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileViewModel model)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId.Value);
            if (customer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            customer.FullName = model.FullName;
            customer.Phone = model.Phone;
            customer.Address = model.Address;

            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                if (string.IsNullOrWhiteSpace(model.CurrentPassword))
                {
                    ViewBag.Error = "Vui lòng nhập mật khẩu hiện tại.";
                    return View(model);
                }

                if (customer.Password != model.CurrentPassword)
                {
                    ViewBag.Error = "Mật khẩu hiện tại không đúng.";
                    return View(model);
                }

                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    ViewBag.Error = "Mật khẩu mới nhập lại không khớp.";
                    return View(model);
                }

                customer.Password = model.NewPassword;
            }

            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("CustomerName", customer.FullName);

            ViewBag.Success = "Cập nhật thông tin thành công.";
            return View(model);
        }
    }
}