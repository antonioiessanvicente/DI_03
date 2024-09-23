using System.Data;
using AccesoDatos;

namespace CapaDatos
{
   public class Contacto
    {
        public string Telefono {get; set;}
        public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Observaciones {get; set;}

        public Contacto()
        {
            Telefono = "";
            Nombre = "";
            Direccion = "";
            Observaciones = "";
        }
        public static DataTable Listado()
        {
            // Ejemplo para SQLITE
            DataTable tabla;
            Conexion.IniciarSesionSQLite("Tfnos.s3db");
            //Conexion.IniciarSesionAccess("tfnos.accdb"); // Ejemplo para Access
            tabla = Conexion.BDatos.ObtenerDataTableSql("Select * from Telefonos");
            Conexion.FinalizarSesion();
            return tabla;


        }
    }
}
