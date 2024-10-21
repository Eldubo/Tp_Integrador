using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AccountController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

[HttpPost]
public IActionResult Login(Usuarios usuario)
{
    if (ModelState.IsValid)
    {
        var usuarioEncontrado = BD.BuscarPersona(usuario.UserName, usuario.Contraseña);
        if (usuarioEncontrado != null)
        {
            // Aquí podrías establecer la sesión del usuario o redirigirlo a otra página
            return RedirectToAction("Index", "Home");
        }
        ViewBag.Error = "Nombre de usuario o contraseña incorrectos.";
    }
    return View(usuario);
}
}
