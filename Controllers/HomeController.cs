using Microsoft.AspNetCore.Mvc;
using dotnet_store.Models;

namespace dotnet_store.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        List<Urun> urunler = _context.Urunler.Where(urun => urun.AktifMi && urun.Anasayfa).ToList();
        ViewData["Kategoriler"] = _context.Kategoriler.ToList();
        return View(urunler);
    }
}