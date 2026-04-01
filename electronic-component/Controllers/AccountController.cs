using electronic_component.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electronic_component.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == model.Email && c.Password == model.Password);

            if (customer == null)
            {
                ViewBag.Error = "Email hoặc mật khẩu không đúng";
                return View(model);
            }

            HttpContext.Session.SetInt32("CustomerId", customer.Id);
            HttpContext.Session.SetString("CustomerName", customer.FullName);
            HttpContext.Session.SetString("CustomerEmail", customer.Email);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetInt32("CustomerId") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var checkEmail = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == model.Email);

            if (checkEmail != null)
            {
                ViewBag.Error = "Email này đã được sử dụng";
                return View(model);
            }

            var customer = new Customer
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone,
                Address = model.Address
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("CustomerId", customer.Id);
            HttpContext.Session.SetString("CustomerName", customer.FullName);
            HttpContext.Session.SetString("CustomerEmail", customer.Email);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}