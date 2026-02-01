using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

[Authorize]
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

        var addedItem = cart.CartItems.Where(i => i.UrunId == urunId).FirstOrDefault();

        // Ürün daha önce eklendiyse
        if (addedItem != null)
        {
            addedItem.Miktar += miktar;
        }
        // İlk defa ekleniyorsa
        else
        {
            cart.CartItems.Add(new CartItem
            {
                UrunId = urunId,
                Miktar = miktar,
            });
        }

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

    private async Task<Cart> GetCartAsync()
    {
        var customerId = User.Identity?.Name;
        // 2.Seviye Nagivation Property
        var cart = await _context.Carts
                    .Include(cart => cart.CartItems)
                    .ThenInclude(cartItem => cartItem.Urun)
                    .Where(cart => cart.CustomerId == customerId)
                    .FirstOrDefaultAsync();

        if (cart == null)
        {
            cart = new Cart { CustomerId = customerId! };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        return cart;
    }
}