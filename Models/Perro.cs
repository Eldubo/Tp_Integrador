using System.ComponentModel.DataAnnotations;

public class Perro
{
    public string Nombre {get;set;}
    public DateTime Fnac {get;set;}

    public Perro() {}

    public Perro(string nombre, DateTime fnac)
    {
        this.Nombre = nombre;
        this.Fnac = fnac;
    }
}