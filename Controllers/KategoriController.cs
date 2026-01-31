using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

public class KategoriController : Controller
{
    private readonly DataContext _context;

    public KategoriController(DataContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        List<KategoriGetModel> kategoriler = _context.Kategoriler.Select(kategori => new KategoriGetModel
        {
            Id = kategori.Id,
            Ad = kategori.Ad,
            Url = kategori.Url,
            UrunSayisi = kategori.Uruns.Count
        }).ToList();
        return View(kategoriler);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(KategoriCreateModel model)
    {
        if (ModelState.IsValid) 
        {
            Kategori yeniKategori = new Kategori
            {
                Ad = model.Ad,
                Url = model.Url
            };

            _context.Kategoriler.Add(yeniKategori);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        KategoriEditModel kategori = _context.Kategoriler.Select(i => new KategoriEditModel
        {
            Id = i.Id,
            Ad = i.Ad,
            Url = i.Url
        }).FirstOrDefault(i => i.Id == id)!;
        return View(kategori);
    }

    [HttpPost]
    public ActionResult Edit(int id, KategoriEditModel model)
    {
        if (id != model.Id)
        {
            return RedirectToAction("Index");
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        Kategori? entity = _context.Kategoriler.FirstOrDefault(kategori => kategori.Id == model.Id);
        if (entity != null)
        {
            entity.Ad = model.Ad;
            entity.Url = model.Url;

            _context.SaveChanges();

            TempData["Mesaj"] = $"{entity.Ad} güncellendi.";

            return RedirectToAction("Index");
        }

        return View(model);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("index");
        }

        Kategori? kategori = _context.Kategoriler.FirstOrDefault(i => i.Id == id);

        if (kategori != null)
        {
            return View(kategori);
        }

        return RedirectToAction("index");
    }

    [HttpPost]
    public ActionResult DeleteConfirm(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("index");
        }

        Kategori? kategori = _context.Kategoriler.FirstOrDefault(i => i.Id == id);

        if (kategori != null)
        {
            _context.Kategoriler.Remove(kategori);
            _context.SaveChanges();

            TempData["Mesaj"] = $"{kategori.Ad} adlı kategori silindi.";
        }

        return RedirectToAction("index");
    }
}


