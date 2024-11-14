using System.ComponentModel.DataAnnotations;

public class Trabajador
{
    public string Nombre {get;set;}
    public DateTime Fnac {get;set;}
    public int DNI {get;set;}
    public string Mail {get;set;}
    public int Telefono {get;set;}
    public string CVUAlias {get;set;}
    public bool Paseo {get;set;}
    public bool Cuidado {get;set;}
    public string Ciudad {get;set;}
    public string Contraseña {get;set;}

    public Trabajador() {}

    public Trabajador(string nombre, DateTime fnac, int dni, string mail, int telefono, string cvu, bool paseo, bool cuidado, string ciudad, string contraseña)
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