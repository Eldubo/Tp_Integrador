using Dapper;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public class BD
{
    private static string conexion = @"Server=localhost;Database=Huellitas;Trusted_Connection=True;";

    public static void AñadirUsuario(Usuario usuario)
    {
        string sql = "INSERT INTO Usuario (Contraseña, Nombre, Email, Telefono, DNI, Apellido, Fnac) VALUES (@pContraseña, @pNombre, @pEmail, @pTelefono, @pdni, @papellido, @pfnac)";
        using (SqlConnection db = new SqlConnection(conexion))
        {
            db.Execute(sql, new
            {
                pContraseña = usuario.Contraseña,
                pNombre = usuario.Nombre,
                pEmail = usuario.Email,
                pTelefono = usuario.Telefono,
                pdni = usuario.DNI,
                papellido = usuario.Apellido,
                pfnac = usuario.Fnac
            });
        }
    }

    public static Usuario BuscarPersona(string mail, string password)
    {
        Usuario usuario = null;
        using (SqlConnection db = new SqlConnection(conexion))
        {
            string sql = "SELECT * FROM Usuario WHERE Email = @pmail AND Contraseña = @pPassword";
            usuario = db.QueryFirstOrDefault<Usuario>(sql, new { pmail = mail, pPassword = password });
        }
        return usuario;
    }

    public static void CambiarContraseña(string mail, string nuevaContraseña)
    {
        string sql = "UPDATE Usuario SET Contraseña = @pNuevaContraseña WHERE Email = @pMail";
        using (SqlConnection db = new SqlConnection(conexion))
        {
            db.Execute(sql, new { pNuevaContraseña = nuevaContraseña, pMail = mail });
        }
    }
}
