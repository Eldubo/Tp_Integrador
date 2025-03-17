using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;
using System.Security.Cryptography;
using System.Text;

namespace PrimerProyecto.Controllers;
public class AccountController : Controller
{
    private Usuario usuario;
    private readonly ILogger<HomeController> _logger;

    public AccountController(ILogger<HomeController> logger)
    {
        _logger = logger;
        usuario = new Usuario();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string mail, string contraseña)
    {
        string hashedPassword = HashPassword(contraseña);
        usuario = BD.BuscarUsuario(mail, hashedPassword);
    
        if (usuario != null)
        {
            HttpContext.Session.SetInt32("UserId", usuario.IdUsuario);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Contraseña incorrecta";
        return View();
    }

    public IActionResult Register()
    {
        var model = new Usuario();
        return View(model);
    }
    public IActionResult RegistroPersonal(){
        var model = new Trabajador();
        return View(model);

    }
    [HttpPost]
public IActionResult RegistroPersonal(Trabajador tj)
{
    tj.Contraseña = HashPassword(tj.Contraseña);

    tj.Paseo = !string.IsNullOrEmpty(tj.Paseo) && tj.Paseo == "true" ? "true" : "false";
    tj.Cuidado = !string.IsNullOrEmpty(tj.Cuidado) && tj.Cuidado == "true" ? "true" : "false";

    var trabajadorencontrado = BD.BuscarTrabajador(tj.Mail, tj.Contraseña);

    if (trabajadorencontrado == null)
    {
        BD.AñadirTrabajador(tj);
        return RedirectToAction("Login");
    }
    ViewBag.Error = "El trabajador ya existe.";
    return View(tj);
}

    [HttpPost]
    public IActionResult Register(Usuario usuario)
    {
        usuario.Contraseña = HashPassword(usuario.Contraseña);

        var usuarioEncontrado = BD.BuscarUsuario(usuario.Email, usuario.Contraseña);
        if (usuarioEncontrado == null)
        {
            BD.AñadirUsuario(usuario);
            return RedirectToAction("Login");
        }

        ViewBag.Error = "El usuario ya existe.";
        return View(usuario);
    }
    public IActionResult CambiarContraseña(){
        return View();
    }
[HttpPost]
    public IActionResult CambiarContraseña(string Email, string nuevaContraseña, string Contraseña)
{
    ViewBag.Mensaje = "";
    string hashedPassword = HashPassword(Contraseña);
    var usuarioEncontrado = BD.BuscarUsuario(Email, hashedPassword);

    if (usuarioEncontrado != null)
    {
        string nuevaContraseñaHasheada = HashPassword(nuevaContraseña);
        BD.CambiarContraseña(Email, nuevaContraseñaHasheada);
        ViewBag.Mensaje = "La contraseña fue cambiada con éxito";
        ViewBag.MensajeTipo = "mensaje-exito";
    }
    else
    {
        ViewBag.Mensaje = "Usuario no encontrado";
        ViewBag.MensajeTipo = "mensaje-error";
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
public IActionResult añadirMascotaAUsuario (){
    return View();
}
    [HttpPost]
public IActionResult añadirMascotaAUsuario(Perro perro)
{
    int idUsuario = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
    bool result = BD.AgregarMascota(idUsuario, perro);
    if (result == false)
    {
        ViewBag.Mensaje = "Tu mascota no se pudo añadir con éxito";
    }
    return View();
}

    private string HashPassword(string password)
{
    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
    
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hashBytes = sha256.ComputeHash(passwordBytes);
        
        StringBuilder result = new StringBuilder();
        foreach (byte b in hashBytes)
            result.Append(b.ToString("x2"));

        return result.ToString();
    }
}

}
