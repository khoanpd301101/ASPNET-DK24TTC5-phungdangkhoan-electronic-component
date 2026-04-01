using electronic_component.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electronic_component.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
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

            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.CustomerId == customerId.Value && c.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                _context.Carts.Add(new Cart
                {
                    CustomerId = customerId.Value,
                    ProductId = productId,
                    Quantity = quantity
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Increase(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.CartId == id && c.CustomerId == customerId.Value);

            if (cartItem == null)
            {
                return RedirectToAction("Index");
            }

            cartItem.Quantity += 1;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Decrease(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.CartId == id && c.CustomerId == customerId.Value);

            if (cartItem == null)
            {
                return RedirectToAction("Index");
            }

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
            }
            else
            {
                _context.Carts.Remove(cartItem);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.CartId == id && c.CustomerId == customerId.Value);

            if (cartItem == null)
            {
                return RedirectToAction("Index");
            }

            _context.Carts.Remove(cartItem);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}