using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            
            if (userId.HasValue)
            {
                // Si el usuario está logueado, obtenemos su información
                var usuario = BD.BuscarPersonaPorId(userId.Value);
                ViewBag.User = usuario;
            }
            else
            {
                // Si el usuario no está logueado, ViewBag.User queda null
                ViewBag.User = null;
            }

            return View();
        }
}
