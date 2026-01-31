using dotnet_store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

public class RoleController : Controller
{

    private RoleManager<AppRole> _roleManagar;

    public RoleController(RoleManager<AppRole> roleManager)
    {
        _roleManagar = roleManager;
    }
    public ActionResult Index()
    {
        return View(_roleManagar.Roles);
    }

    [HttpGet]

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(RoleCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var role = new AppRole { Name = model.RoleAdi };
            var result = await _roleManagar.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }
}

