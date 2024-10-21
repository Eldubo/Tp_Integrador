using Dapper;
using System.Data.SqlClient;
public class BD{
private static string conexion = @"Server=localhost;Database=Login;Trusted_Connection=True;";
public static void añadirUsuario(Usuarios usuario){
    string sql = "INSERT INTO Usuarios(Username, Contraseña, Nombre, Email, Telefono) VALUES (@pUsername, @pContraseña, @pNombre, @pEmail, @pTelefono)";
    using(SqlConnection db = new SqlConnection(conexion)){
        db.Execute(sql, new{pUsername = usuario.UserName, pContraseña = usuario.Contraseña, pNombre = usuario.Nombre, pEmail = usuario.Email, pTelefono = usuario.Telefono});
    }
}
public static void BuscarPersona(string UserName, string password){
    Usuarios usuario = null;
    using(SqlConnection db = new SqlConnection(conexion)){
        string sql = "SELECT * FROM Usuarios WHERE UserName = @pUsername AND Contraseña = @pPassword";
        usuario = db.QueryFirstOrDefault<Usuarios>(sql, new{ pUsername = UserName, pPassword = password});
    }
}


}