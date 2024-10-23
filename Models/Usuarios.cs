using System.ComponentModel.DataAnnotations;

public class Usuarios
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
    public string Contraseña { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "El número de teléfono no es válido")]
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
