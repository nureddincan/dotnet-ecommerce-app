using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

// Bütün action metotlarına bir kimlik doğrulama özellik eklendi. 
[Authorize]
public class AdminController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}

