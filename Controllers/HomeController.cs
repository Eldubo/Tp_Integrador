using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;
using Newtonsoft.Json;


namespace PrimerProyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Trabajador> trabajadores = new List<Trabajador>();

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

        [HttpPost]
        public IActionResult Index(string tipoPaseo, string ciudad)
        {
            trabajadores = BD.BuscarTrabajadoresConCaracteristicas(tipoPaseo, ciudad);

            HttpContext.Session.SetString("Trabajadores", JsonConvert.SerializeObject(trabajadores));
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
            var trabajadoresJson = HttpContext.Session.GetString("Trabajadores");
            if (trabajadoresJson != null)
            {
                ViewBag.Trabajadores = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Trabajador>>(trabajadoresJson);
            }
            else
            {
                ViewBag.Trabajadores = new List<Trabajador>();
            }
            return View();
        }
    }
}
