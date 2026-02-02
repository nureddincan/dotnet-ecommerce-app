using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class CartController : Controller
{
    private readonly DataContext _context;

    public CartController(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionResult> Index()
    {
        var cart = await GetCartAsync();

        return View(cart);
    }

    [HttpPost]
    public async Task<ActionResult> AddtoCart(int urunId, int miktar = 1)
    {
        var cart = await GetCartAsync();

        var urun = await _context.Urunler.FirstOrDefaultAsync(urun => urun.Id == urunId);

        if (urun != null)
        {
            cart.AddItem(urun, miktar);
        }
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    public async Task<ActionResult> RemoveItem(int urunId, int miktar)
    {
        var cart = await GetCartAsync();

        var urun = await _context.Urunler.FirstOrDefaultAsync(urun => urun.Id == urunId);
        if (urun != null)
        {
            cart.DeleteItem(urunId, miktar);
            await _context.SaveChangesAsync();
        }


        return RedirectToAction("Index", "Cart");
    }

    private async Task<Cart> GetCartAsync()
    {
        var customerId = User.Identity?.Name ?? Request.Cookies["customerId"];

        // 2.Seviye Nagivation Property
        var cart = await _context.Carts
                    .Include(cart => cart.CartItems)
                    .ThenInclude(cartItem => cartItem.Urun)
                    .Where(cart => cart.CustomerId == customerId)
                    .FirstOrDefaultAsync();

        if (cart == null)
        {
            customerId = User.Identity?.Name;

            if (string.IsNullOrEmpty(customerId))
            {
                customerId = Guid.NewGuid().ToString();

                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(1),
                    IsEssential = true,
                };

                Response.Cookies.Append("customerId", customerId, cookieOptions);
            }

            cart = new Cart { CustomerId = customerId };
            _context.Carts.Add(cart);
            // await _context.SaveChangesAsync();
        }

        return cart;
    }
}