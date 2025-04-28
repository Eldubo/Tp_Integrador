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

    public static Usuario BuscarUsuario(string mail, string password)
    {
        Usuario usuario = null;
        using (SqlConnection db = new SqlConnection(conexion))
        {
            string sql = "SELECT * FROM Usuario WHERE Email = @pmail AND Contraseña = @pPassword";
            usuario = db.QueryFirstOrDefault<Usuario>(sql, new { pmail = mail, pPassword = password });
        }
        return usuario;
    }
    public static Trabajador BuscarTrabajador(string mail, string password)
    {
        Trabajador trabajador = null;
        using (SqlConnection db = new SqlConnection(conexion))
        {
            string sql = "SELECT * FROM Trabajador WHERE Mail = @pmail AND Contraseña = @pPassword";
            trabajador = db.QueryFirstOrDefault<Trabajador>(sql, new { pmail = mail, pPassword = password });
        }
        return trabajador;
    }

    public static void CambiarContraseña(string mail, string nuevaContraseña)
    {
        string sql = "UPDATE Usuario SET Contraseña = @pNuevaContraseña WHERE Email = @pMail";
        using (SqlConnection db = new SqlConnection(conexion))
        {
            db.Execute(sql, new { pNuevaContraseña = nuevaContraseña, pMail = mail });
        }
    }

    public static bool AgregarMascota(int? id, Perro perro)
    {
        bool result = false;
        string sql = "INSERT INTO Perro (Nombre, Fnac, IdUsuario) VALUES (@pNombre, @pFnac, @pIdUsuario)";
        using (SqlConnection db = new SqlConnection(conexion))
        {
            db.Execute(sql, new
            {
                pNombre = perro.Nombre,
                pFnac = perro.Fnac,
                pIdUsuario = id
            });
            result = true;
        }
        return result;
    }
    public static Usuario BuscarPersonaPorId(int id)
    {
        Usuario usuario = null;
        using (SqlConnection db = new SqlConnection(conexion))
        {
            string sql = "SELECT * FROM Usuario WHERE IdUsuario = @pId";
            usuario = db.QueryFirstOrDefault<Usuario>(sql, new { pId = id });
        }
        return usuario;
    }

    public static void AñadirTrabajador(Trabajador trabajador)
    {
        string sql = "INSERT INTO Trabajador (DNI, Nombre, Mail, Telefono, Fnac, CVUAlias, Paseo, Cuidado, Ciudad, Contraseña) VALUES (@pdni, @pNombre, @pMail, @pTelefono, @pFnac, @pcvualias, @pPaseo, @pCuidado, @pCiudad, @pContraseña)";
        using (SqlConnection db = new SqlConnection(conexion))
        {
            db.Execute(sql, new
            {
                pdni = trabajador.DNI,
                pNombre = trabajador.Nombre,
                pMail = trabajador.Mail,
                pTelefono = trabajador.Telefono,
                pFnac = trabajador.Fnac,
                pcvualias = trabajador.CVUAlias,
                pPaseo = trabajador.Paseo,
                pCuidado = trabajador.Cuidado,
                pCiudad = trabajador.Ciudad,
                pContraseña = trabajador.Contraseña
            });
        }
    }

    public static List<Trabajador> BuscarTrabajadoresConCaracteristicas(string tipo, string ciudad)
    {
        List<Trabajador> trabajadores = new List<Trabajador>();
        string sql = "SELECT * FROM Trabajador WHERE Ciudad = @pCiudad";

        if (tipo?.ToLower() == "paseo")
        {
            sql += " AND Paseo = 'TRUE'"; 
        }
        else if (tipo?.ToLower() == "cuidado")
        {
            sql += " AND Cuidado = 'TRUE'";
        }
        using (SqlConnection db = new SqlConnection(conexion))
        {
            trabajadores = db.Query<Trabajador>(sql, new { pCiudad = ciudad }).ToList();
        }

        Console.WriteLine($"Trabajadores encontrados: {trabajadores.Count}");

        return trabajadores;
    }




}