using System.ComponentModel.DataAnnotations;

public class Trabajador
{
    [Key]
    public int ID { get; set; }

    public string Nombre { get; set; }

    public DateTime Fnac { get; set; }

    public int DNI { get; set; }

    public string Mail { get; set; }

    public int Telefono { get; set; }

    public string CVUAlias { get; set; }

    // Cambiar de bool a string? para manejar los valores "true" o null
    public string? Paseo { get; set; }

    public string? Cuidado { get; set; }

    public string Ciudad { get; set; }

    public string Contraseña { get; set; }

    // Constructor vacío
    public Trabajador() {}

    // Constructor con parámetros para inicializar el objeto
    public Trabajador(string nombre, DateTime fnac, int dni, string mail, int telefono, string cvu, string? paseo, string? cuidado, string ciudad, string contraseña)
    {
        this.Nombre = nombre;
        this.Fnac = fnac;
        this.DNI = dni;
        this.Mail = mail;
        this.Telefono = telefono;
        this.CVUAlias = cvu;
        this.Paseo = paseo;
        this.Cuidado = cuidado;
        this.Ciudad = ciudad;
        this.Contraseña = contraseña;
    }
}
