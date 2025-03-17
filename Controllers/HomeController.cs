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

        public static List<Trabajador> trabajadores = new List<Trabajador>();

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

        [HttpPost]
        public IActionResult Index(string tipoPaseo, string ciudad)
        {
            trabajadores = BD.BuscarTrabajadoresConCaracteristicas(tipoPaseo, ciudad);
            return RedirectToAction("verPaseadores");
        }

        public IActionResult Perfil()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var usuario = BD.BuscarPersonaPorId(userId.Value);
            ViewBag.User = usuario;
            return View();
        }

        public IActionResult verPaseadores()
        {
            ViewBag.Trabajadores = trabajadores;
            return View(trabajadores);
        }
    }
}
