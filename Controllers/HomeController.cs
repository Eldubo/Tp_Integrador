using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers
{
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
                var usuario = BD.BuscarPersonaPorId(userId.Value);
                ViewBag.User = usuario;
            }
            else
            {
                ViewBag.User = null;
            }

            return View();
        }
        public IActionResult Perfil(){
            int? userId = HttpContext.Session.GetInt32("UserId");
            var usuario = BD.BuscarPersonaPorId(userId.Value);
            ViewBag.User = usuario;
            return View();
        }
    }
}
