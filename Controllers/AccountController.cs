using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;
using System.Security.Cryptography;
using System.Text;

namespace PrimerProyecto.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AccountController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string contraseña)
    {
        string hashedPassword = HashPassword(contraseña);
        var usuarioEncontrado = BD.BuscarPersona(username, hashedPassword);

        if (usuarioEncontrado != null)
        {
            return RedirectToAction("Bienvenida");
        }

        ViewBag.Error = "Contraseña incorrecta";
        return View();
    }

    public IActionResult Register()
    {
        var model = new Usuarios();
        return View(model);
    }

    [HttpPost]
    public IActionResult Register(Usuarios usuario)
    {
        usuario.Contraseña = HashPassword(usuario.Contraseña);

        var usuarioEncontrado = BD.BuscarPersona(usuario.UserName, usuario.Contraseña);
        if (usuarioEncontrado == null)
        {
            BD.AñadirUsuario(usuario);
            return RedirectToAction("Login");
        }

        ViewBag.Error = "El usuario ya existe.";
        return View(usuario);
    }

    public IActionResult CambiarContraseña(Usuarios usuario, string nuevaContraseña)
    {
        ViewBag.Mensaje = "";
        string hashedPassword = HashPassword(usuario.Contraseña);
        var usuarioEncontrado = BD.BuscarPersona(usuario.UserName, hashedPassword);

        if (usuarioEncontrado != null)
        {
            string nuevaContraseñaHasheada = HashPassword(nuevaContraseña);
            BD.CambiarContraseña(usuario.UserName, nuevaContraseñaHasheada);
            ViewBag.Mensaje = "La contraseña fue cambiada con éxito";
        }
        else
        {
            ViewBag.Mensaje = "Usuario no encontrado";
        }
        return View();
    }

    public IActionResult Bienvenida()
    {
        return View();
    }

    public IActionResult RecuperarContraseña()
    {
        return View();
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder result = new StringBuilder();
            foreach (byte b in hash)
                result.Append(b.ToString("x2"));

            return result.ToString();
        }
    }
}
