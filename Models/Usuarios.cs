using System.ComponentModel.DataAnnotations;

public class Usuarios
{
        public string UserName { get; set; }
    public string Contraseña { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Usuarios() {}

    public Usuarios(string user, string pass, string name, string mail, string tel)
    {
        UserName = user;
        Contraseña = pass;
        Nombre = name;
        Email = mail;
        Telefono = tel;
    }
}
