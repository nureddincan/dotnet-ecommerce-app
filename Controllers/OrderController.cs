using dotnet_store.Models;
using dotnet_store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

[Authorize]
public class OrderController : Controller
{
    private ICartService _cartService;
    private readonly DataContext _context;

    public OrderController(ICartService cartService, DataContext context)
    {
        _cartService = cartService;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> Checkout()
    {
        ViewBag.Cart = await _cartService.GetCartAsync(User.Identity?.Name!);
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Checkout(OrderCreateModel model)
    {
        var customerId = User.Identity?.Name!;
        var cart = await _cartService.GetCartAsync(customerId!);

        if (cart.CartItems.Count == 0)
        {
            ModelState.AddModelError("", "Sepetinizde ürün yok");
        }

        if (ModelState.IsValid)
        {
            var order = new Order
            {
                AdSoyad = model.AdSoyad,
                TelNo = model.TelNo,
                Address = model.Address,
                City = model.City,
                PostCode = model.PostCode,
                OrderNote = model.OrderNote,
                OrderDate = DateTime.Now,
                TotalPrice = cart.Toplam(),
                CustomerId = customerId,
                OrderItems = cart.CartItems.Select(cartItem => new OrderItem
                {
                    UrunId = cartItem.UrunId,
                    Price = cartItem.Urun.Fiyat,
                    Count = cartItem.Miktar,
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return RedirectToAction("Completed", new { orderId = order.Id });
        }

        ViewBag.Cart = cart;
        return View(model);
    }

    public ActionResult Completed(string orderId)
    {
        return View("Completed", orderId);
    }
}