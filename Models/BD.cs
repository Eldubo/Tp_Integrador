using Dapper;
using System.Data.SqlClient;
public class BD
{
    private static string conexion = @"Server=localhost;Database=Login;Trusted_Connection=True;";

    public static void AñadirUsuario(Usuarios usuario)
    {
        string sql = "INSERT INTO Usuarios (Username, Contraseña, Nombre, Email, Telefono) VALUES (@pUsername, @pContraseña, @pNombre, @pEmail, @pTelefono)";
        using (SqlConnection db = new SqlConnection(conexion))
        {
            db.Execute(sql, new
            {
                pUsername = usuario.UserName,
                pContraseña = usuario.Contraseña,
                pNombre = usuario.Nombre,
                pEmail = usuario.Email,
                pTelefono = usuario.Telefono
            });
        }
    }

    public static Usuarios BuscarPersona(string userName, string password)
    {
        Usuarios usuario = null;
        using (SqlConnection db = new SqlConnection(conexion))
        {
            string sql = "SELECT * FROM Usuarios WHERE Username = @pUsername AND Contraseña = @pPassword";
            usuario = db.QueryFirstOrDefault<Usuarios>(sql, new { pUsername = userName, pPassword = password });
        }
        return usuario;
    }
    public static void CambiarContraseña(string userName, string nuevaContraseña)
    {
        string sql = "UPDATE Usuarios SET Contraseña = @pNuevaContraseña WHERE Username = @pUsername";
        using (SqlConnection db = new SqlConnection(conexion))
        {
            db.Execute(sql, new { pNuevaContraseña = nuevaContraseña, pUsername = userName });
        }
    }
   
}
