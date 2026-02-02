using dotnet_store.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Services;

public interface ICartService
{
    string GetCustomerId();
    Task<Cart> GetCartAsync(string customerId);
    Task AddToCartAsync(int urunId, int miktar = 1);
    Task RemoveItemAsync(int urunId, int miktar = 1);
    Task TransferCookieCartToUser(string username);
}

public class CartService : ICartService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CartService(DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;

    }
    public async Task AddToCartAsync(int urunId, int miktar = 1)
    {
        var cart = await GetCartAsync(GetCustomerId());

        var urun = await _context.Urunler.FirstOrDefaultAsync(urun => urun.Id == urunId);

        if (urun != null)
        {
            cart.AddItem(urun, miktar);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<Cart> GetCartAsync(string custId)
    {
        var cart = await _context.Carts
                    .Include(cart => cart.CartItems)
                    .ThenInclude(cartItem => cartItem.Urun)
                    .Where(cart => cart.CustomerId == custId)
                    .FirstOrDefaultAsync();

        if (cart == null)
        {
            var customerId = _httpContextAccessor.HttpContext?.User.Identity?.Name;

            if (string.IsNullOrEmpty(customerId))
            {
                customerId = Guid.NewGuid().ToString();

                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(1),
                    IsEssential = true,
                };

                _httpContextAccessor.HttpContext?.Response.Cookies.Append("customerId", customerId, cookieOptions);
            }

            cart = new Cart { CustomerId = customerId };
            _context.Carts.Add(cart);
        }

        return cart;
    }
    public string GetCustomerId()
    {
        var context = _httpContextAccessor.HttpContext;
        return context?.User.Identity?.Name ?? context?.Request.Cookies["customerId"]!;
    }
    public async Task RemoveItemAsync(int urunId, int miktar = 1)
    {
        var cart = await GetCartAsync(GetCustomerId());

        var urun = await _context.Urunler.FirstOrDefaultAsync(urun => urun.Id == urunId);
        if (urun != null)
        {
            cart.DeleteItem(urunId, miktar);
            await _context.SaveChangesAsync();
        }
    }
    public async Task TransferCookieCartToUser(string username)
    {
        var userCart = await GetCartAsync(username);

        var cookieCart = await GetCartAsync(_httpContextAccessor.HttpContext?.Request.Cookies["customerId"]!);

        foreach (var item in cookieCart?.CartItems!)
        {
            var addedItem = userCart?.CartItems.Where(i => i.UrunId == item.UrunId).FirstOrDefault();

            // Ürün daha önce eklendiyse
            if (addedItem != null)
            {
                addedItem.Miktar += item.Miktar;
            }
            else
            {
                userCart?.CartItems.Add(new CartItem { UrunId = item.UrunId, Miktar = item.Miktar });
            }
        }
        _context.Carts.Remove(cookieCart);

        await _context.SaveChangesAsync();
    }
}