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
    public IActionResult Login(string mail, string contraseña)
    {
        string hashedPassword = HashPassword(contraseña);
        var usuarioEncontrado = BD.BuscarUsuario(mail, hashedPassword);
    
        if (usuarioEncontrado != null)
        {
            HttpContext.Session.SetInt32("UserId", usuarioEncontrado.Id);
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
    string result = BD.AgregarMascota(idUsuario, perro);
    if (result == null)
    {
        ViewBag.Mensaje = "Tu mascota no se pudo añadir con éxito";
    }
    else
    {
        ViewBag.Mensaje = result;
    }
    return View();
}

    private string HashPassword(string password)
{
    // Generar un salt aleatorio
    byte[] saltBytes = new byte[16];
    using (var rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(saltBytes);
    }
    
    // Combinar el salt con la contraseña
    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
    byte[] passwordWithSaltBytes = new byte[saltBytes.Length + passwordBytes.Length];
    Buffer.BlockCopy(saltBytes, 0, passwordWithSaltBytes, 0, saltBytes.Length);
    Buffer.BlockCopy(passwordBytes, 0, passwordWithSaltBytes, saltBytes.Length, passwordBytes.Length);

    // Calcular el hash del resultado
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hashBytes = sha256.ComputeHash(passwordWithSaltBytes);
        
        // Concatenar el salt y el hash en una sola cadena
        StringBuilder result = new StringBuilder();
        foreach (byte b in saltBytes)
            result.Append(b.ToString("x2"));
        
        foreach (byte b in hashBytes)
            result.Append(b.ToString("x2"));

        return result.ToString();
    }
}
}
