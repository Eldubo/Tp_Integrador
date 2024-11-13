using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key] // Anotación opcional para indicar que esta es la clave primaria
    public int Id { get; set; } // Propiedad para el ID autogenerado

    public string Contraseña { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Apellido { get; set; }
    public int DNI { get; set; }
    public DateTime Fnac { get; set; }

    public Usuario() {}

    public Usuario(string nombre, DateTime Fnac, string mail, string tel, int dni, string apellido, string pass)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Contraseña = pass;
        this.Email = mail;
        this.Telefono = tel;
        this.DNI = dni;
    }
}
