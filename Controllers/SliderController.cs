using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

[Authorize(Roles = "Admin")]
public class SliderController : Controller
{
    private readonly DataContext _context;
    public SliderController(DataContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        List<SliderGetModel> sliderlar = _context.Sliderlar.Select(slider => new SliderGetModel
        {
            Id = slider.Id,
            Baslik = slider.Baslik,
            Resim = slider.Resim,
            Index = slider.Index,
            AktifMi = slider.AktifMi
        }).ToList();
        return View(sliderlar);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(SliderCreateModel model)
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

            Slider yeniSlider = new Slider
            {
                Baslik = model.Baslik,
                Aciklama = model.Aciklama,
                Resim = fileName,
                Index = model.Index,
                AktifMi = model.AktifMi
            };

            _context.Sliderlar.Add(yeniSlider);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        SliderEditModel slider = _context.Sliderlar.Select(slider => new SliderEditModel
        {
            Id = slider.Id,
            Baslik = slider.Baslik,
            Aciklama = slider.Aciklama,
            ResimAdi = slider.Resim,
            Index = slider.Index,
            AktifMi = slider.AktifMi
        }).FirstOrDefault(slider => slider.Id == id)!;

        return View(slider);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(int id, SliderEditModel model)
    {
        if (id != model.Id)
        {
            return RedirectToAction("Index");
        }

        if (ModelState.IsValid)
        {
            Slider? slider = _context.Sliderlar.FirstOrDefault(slider => slider.Id == id);

            if (slider != null)
            {
                if (model.Resim != null)
                {
                    var fileName = Path.GetRandomFileName() + ".jpg";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Resim!.CopyToAsync(stream);
                    }

                    slider.Resim = fileName;
                }

                slider.Id = model.Id;
                slider.Baslik = model.Baslik;
                slider.Aciklama = model.Aciklama;
                slider.Index = model.Index;
                slider.AktifMi = model.AktifMi;

                _context.SaveChanges();

                TempData["Mesaj"] = $"{slider.Baslik} isimli slider güncellendi.";

                return RedirectToAction("Index");
            }
        }

        return View(model);
    }

    [HttpGet]
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("index");
        }

        Slider? slider = _context.Sliderlar.FirstOrDefault(slider => slider.Id == id);

        if (slider != null)
        {
            return View(slider);
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

        Slider? slider = _context.Sliderlar.FirstOrDefault(slider => slider.Id == id);

        if (slider != null)
        {
            _context.Sliderlar.Remove(slider);
            _context.SaveChanges();

            TempData["Mesaj"] = $"{slider.Baslik} adlı slider silindi.";
        }

        return RedirectToAction("index");
    }
}