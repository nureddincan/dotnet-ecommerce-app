using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;


[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
    private RoleManager<AppRole> _roleManager;
    private UserManager<AppUser> _userManager;

    public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public ActionResult Index()
    {
        return View(_roleManager.Roles);
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
            var result = await _roleManager.CreateAsync(role);

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

    [HttpGet]
    public async Task<ActionResult> Edit(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);

        if (role != null)
        {
            return View(new RoleEditModel { Id = role.Id, RoleAdi = role.Name! });
        }
        {
            @TempData["Mesaj"] = "Düzenlemek istediğiniz rol bulunamadı.";

            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Edit(string id, RoleEditModel model)
    {
        if (ModelState.IsValid && id == model.Id.ToString())
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                role.Name = model.RoleAdi;

                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    @TempData["Mesaj"] = $"{model.RoleAdi} adlı rol {role.Name} olarak güncellendi.";

                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);
    }

    [HttpGet]
    public async Task<ActionResult> Delete(string? id)
    {
        if (id == null)
        {
            return RedirectToAction("index");
        }

        var role = await _roleManager.FindByIdAsync(id);

        if (role != null)
        {
            ViewBag.Users = await _userManager.GetUsersInRoleAsync(role.Name!);
            return View(role);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> DeleteConfirm(string? id)
    {
        if (id == null)
        {
            return RedirectToAction("index");
        }

        var roleDel = await _roleManager.FindByIdAsync(id);

        if (roleDel != null)
        {
            var result = await _roleManager.DeleteAsync(roleDel);

            if (result.Succeeded)
            {
                @TempData["Mesaj"] = $"{roleDel.Name} adlı rol silindi.";
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return RedirectToAction("index");
    }
}