using dotnet_store.Models;
using dotnet_store.Services;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

[Authorize]
public class OrderController : Controller
{
    private ICartService _cartService;
    private IConfiguration _configuration;
    private readonly DataContext _context;

    public OrderController(ICartService cartService, DataContext context, IConfiguration configuration)
    {
        _cartService = cartService;
        _context = context;
        _configuration = configuration;
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Index()
    {
        return View(_context.Orders.ToList());
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Details(int id)
    {
        var order = _context.Orders
                    .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Urun)
                    .FirstOrDefault(order => order.Id == id);

        return View(order);
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
                OrderItems = cart.CartItems.Select(cartItem => new Models.OrderItem
                {
                    UrunId = cartItem.UrunId,
                    Price = cartItem.Urun.Fiyat,
                    Count = cartItem.Miktar,
                }).ToList()
            };

            var payment = await ProccessPayment(model, cart);

            if (payment.Status == "success")
            {
                _context.Orders.Add(order);
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();

                return RedirectToAction("Completed", new { orderId = order.Id });
            }
            else
            {
                ModelState.AddModelError("", payment.ErrorMessage);
            }
        }

        ViewBag.Cart = cart;
        return View(model);
    }

    public ActionResult Completed(string orderId)
    {
        return View("Completed", orderId);
    }

    public async Task<ActionResult> OrderList()
    {
        var customerId = User.Identity?.Name!;
        var orders = await _context.Orders
                    .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Urun)
                    .Where(order => order.CustomerId == customerId)
                    .ToListAsync();
        return View(orders);
    }

    private async Task<Payment> ProccessPayment(OrderCreateModel model, Cart cart)
    {
        Options options = new Options();
        options.ApiKey = _configuration["PaymentAPI:APIKey"];
        options.SecretKey = _configuration["PaymentAPI:SecretKey"];
        options.BaseUrl = "https://sandbox-api.iyzipay.com";

        CreatePaymentRequest request = new CreatePaymentRequest();
        request.Locale = Locale.TR.ToString();
        request.ConversationId = Guid.NewGuid().ToString();
        request.Price = cart.AraToplam().ToString();
        request.PaidPrice = cart.Toplam().ToString();
        request.Currency = Currency.TRY.ToString();
        request.Installment = 1;
        request.BasketId = "B67832";
        request.PaymentChannel = PaymentChannel.WEB.ToString();
        request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

        PaymentCard paymentCard = new PaymentCard();
        paymentCard.CardHolderName = model.CartName;
        paymentCard.CardNumber = model.CartNumber;
        paymentCard.ExpireMonth = model.CartExpirationMonth;
        paymentCard.ExpireYear = model.CartExpirationYear;
        paymentCard.Cvc = model.CartCVV;
        paymentCard.RegisterCard = 0;
        request.PaymentCard = paymentCard;

        Buyer buyer = new Buyer();
        buyer.Id = model.Id.ToString();
        buyer.Name = model.AdSoyad;
        buyer.Surname = "Doe";
        buyer.GsmNumber = model.TelNo;
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = model.City;
        buyer.Country = "Turkey";
        buyer.ZipCode = model.PostCode;
        request.Buyer = buyer;

        Address shippingAddress = new Address();
        shippingAddress.ContactName = model.AdSoyad;
        shippingAddress.City = model.City;
        shippingAddress.Country = "Turkey";
        shippingAddress.Description = model.Address;
        shippingAddress.ZipCode = model.PostCode;
        request.ShippingAddress = shippingAddress;
        request.BillingAddress = shippingAddress;

        // Address billingAddress = new Address();
        // billingAddress.ContactName = "Jane Doe";
        // billingAddress.City = "Istanbul";
        // billingAddress.Country = "Turkey";
        // billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        // billingAddress.ZipCode = "34742";
        // request.BillingAddress = billingAddress;


        List<BasketItem> basketItems = new List<BasketItem>();

        foreach (var cartItem in cart.CartItems)
        {
            BasketItem basketItem = new BasketItem();
            basketItem.Id = cartItem.Id.ToString();
            basketItem.Name = cartItem.Urun.Ad;
            basketItem.Category1 = "Telefon";
            basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            basketItem.Price = cartItem.Urun.Fiyat.ToString();

            basketItems.Add(basketItem);
        }

        request.BasketItems = basketItems;

        return await Payment.Create(request, options);
    }
}