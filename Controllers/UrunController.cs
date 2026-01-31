using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotnet_store.Controllers;

public class UrunController : Controller
{
    private readonly DataContext _context;
    public UrunController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult Index(int? kategori)
    {
        var query = _context.Urunler.AsQueryable();

        if (kategori != null)
        {
            query = query.Where(i => i.KategoriId == kategori);
        }

        var urunler = query.Select(urun => new UrunGetModel
        {
            Id = urun.Id,
            Ad = urun.Ad,
            Fiyat = urun.Fiyat,
            AktifMi = urun.AktifMi,
            Anasayfa = urun.Anasayfa,
            KategoriAdi = urun.Kategori.Ad,
            Resim = urun.Resim
        }).ToList();

        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "Id", "Ad", kategori);

        return View(urunler);
    }

    public ActionResult List(string url, string q)
    {
        var query = _context.Urunler.Where(i => i.AktifMi); // Queryable
        if (!string.IsNullOrEmpty(url))
        {
            query = query.Where(urun => urun.Kategori.Url == url);
        }

        if (!string.IsNullOrEmpty(q))
        {
            query = query.Where(urun => urun.Ad.ToLower().Contains(q.ToLower()));
            ViewData["q"] = q;
        }
        return View(query.ToList());
    }
    public ActionResult Details(int id)
    {
        Urun? urun = _context.Urunler.Find(id);

        if (urun == null)
        {
            return RedirectToAction("Index", "Home");
        }
        ViewData["BenzerUrunler"] = _context.Urunler
        .Where(benzerUrun => benzerUrun.AktifMi && benzerUrun.Kategori.Id == urun.KategoriId && benzerUrun.Id != id)
        .Take(4)
        .ToList();

        return View(urun);
    }

    [HttpGet]
    public ActionResult Create()
    {
        ViewBag.Kategoriler = _context.Kategoriler.ToList();
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(UrunCreateModel model)
    {
        if (model.Resim == null || model.Resim.Length == 0)
        {
            ModelState.AddModelError("Resim", "Resim zorunludur.");
        }

        if (ModelState.IsValid)
        {
            var fileName = Path.GetRandomFileName() + ".jpg";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.Resim!.CopyToAsync(stream);
            }

            Urun yeniUrun = new Urun
            {
                Ad = model.Ad,
                Aciklama = model.Aciklama,
                Fiyat = model.Fiyat ?? 0,
                AktifMi = model.AktifMi,
                Anasayfa = model.Anasayfa,
                KategoriId = (int)model.KategoriId!,
                Resim = fileName
            };
            _context.Urunler.Add(yeniUrun);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        ViewBag.Kategoriler = _context.Kategoriler.ToList();
        return View(model);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        ViewBag.Kategoriler = _context.Kategoriler.ToList();

        UrunEditModel entity = _context.Urunler.Select(urun => new UrunEditModel
        {
            Id = urun.Id,
            Ad = urun.Ad,
            Aciklama = urun.Aciklama,
            Fiyat = urun.Fiyat,
            AktifMi = urun.AktifMi,
            Anasayfa = urun.Anasayfa,
            KategoriId = urun.KategoriId,
            ResimAdi = urun.Resim
        }).FirstOrDefault(urun => urun.Id == id)!;
        return View(entity);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(int id, UrunEditModel model)
    {
        if (id != model.Id)
        {
            return RedirectToAction("Index");
        }

        if (ModelState.IsValid)
        {
            Urun? entity = _context.Urunler.FirstOrDefault(urun => urun.Id == model.Id);

            if (entity != null)
            {
                if (model.Resim != null)
                {
                    var fileName = Path.GetRandomFileName() + ".jpg";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Resim!.CopyToAsync(stream);
                    }

                    entity.Resim = fileName;
                }

                entity.Id = model.Id;
                entity.Ad = model.Ad;
                entity.Aciklama = model.Aciklama;
                entity.Fiyat = model.Fiyat ?? 0;
                entity.AktifMi = model.AktifMi;
                entity.Anasayfa = model.Anasayfa;
                entity.KategoriId = (int)model.KategoriId!;

                _context.SaveChanges();

                TempData["Mesaj"] = $"{entity.Ad} güncellendi.";

                return RedirectToAction("Index");
            }
        }

        ViewBag.Kategoriler = _context.Kategoriler.ToList();
        return View(model);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("index");
        }

        Urun? urun = _context.Urunler.FirstOrDefault(i => i.Id == id);

        if (urun != null)
        {
            return View(urun);
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

        Urun? urun = _context.Urunler.FirstOrDefault(i => i.Id == id);

        if (urun != null)
        {
            _context.Urunler.Remove(urun);
            _context.SaveChanges();

            TempData["Mesaj"] = $"{urun.Ad} adlı ürün silindi.";
        }

        return RedirectToAction("index");
    }
}
