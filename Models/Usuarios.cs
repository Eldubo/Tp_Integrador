using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public string Contraseña { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Apellido {get;set; }
    public int DNI {get;set; }
    public DateTime Fnac {get;set; }

    public Usuario() {}

    public Usuario(string nombre, DateTime Fnac, string mail, string tel, int dni, string apellido, string pass)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Contraseña = pass;
        this.Nombre = nombre;
        this.Email = mail;
        this.Telefono = tel;
        this.DNI = dni;
    }
}