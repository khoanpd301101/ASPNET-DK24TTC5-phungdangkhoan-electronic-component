using electronic_component.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electronic_component.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId.Value);
            var cartItems = await _context.Carts
                .Include(c => c.Product)
                .Where(c => c.CustomerId == customerId.Value)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            ViewBag.CartItems = cartItems;
            ViewBag.Total = cartItems.Sum(x => (x.Product != null ? x.Product.Price : 0) * x.Quantity);

            var model = new CheckoutViewModel
            {
                FullName = customer?.FullName ?? "",
                PhoneNumber = customer?.Phone ?? "",
                ShippingAddress = customer?.Address ?? ""
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItems = await _context.Carts
                .Include(c => c.Product)
                .Where(c => c.CustomerId == customerId.Value)
                .ToListAsync();

            if (!cartItems.Any())
            {
                ModelState.AddModelError("", "Giỏ hàng đang trống.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.CartItems = cartItems;
                ViewBag.Total = cartItems.Sum(x => (x.Product != null ? x.Product.Price : 0) * x.Quantity);
                return View(model);
            }

            var totalAmount = cartItems.Sum(x => (x.Product != null ? x.Product.Price : 0) * x.Quantity);

            var order = new Order
            {
                CustomerId = customerId.Value,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                Status = "Pending",
                ShippingAddress = model.ShippingAddress,
                PhoneNumber = model.PhoneNumber,
                Note = model.Note
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var item in cartItems)
            {
                _context.OrderDetails.Add(new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product?.Price ?? 0
                });
            }

            await _context.SaveChangesAsync();

            var cartIds = cartItems.Select(x => x.CartId).ToList();

            var cartsToDelete = await _context.Carts
                .Where(c => cartIds.Contains(c.CartId))
                .ToListAsync();

            _context.Carts.RemoveRange(cartsToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success", new { id = order.Id });
        }
        public async Task<IActionResult> Success(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public async Task<IActionResult> Index()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var orders = await _context.Orders
                .Where(o => o.CustomerId == customerId.Value)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var order = await _context.Orders
                .Include(o => o.OrderDetails!)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == id && o.CustomerId == customerId.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}