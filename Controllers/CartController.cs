using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
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

    [HttpPost]
    public async Task<ActionResult> AddtoCart(int urunId, int miktar = 1)
    {
        var customerId = User.Identity?.Name;

        var cart = await _context.Carts
                    .Include(cart => cart.CartItems)
                    .Where(cart => cart.CustomerId == customerId)
                    .FirstOrDefaultAsync();

        if (cart == null)
        {
            cart = new Cart { CustomerId = customerId! };
            _context.Carts.Add(cart);
        }

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
}