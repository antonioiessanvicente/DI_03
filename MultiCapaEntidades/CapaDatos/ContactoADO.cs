using System.Data;
using AccesoDatos;
using Entidades;
using System.Collections.Generic;

namespace CapaDatos
{
   public class ContactoADO
    {
       
        public static List<ContactoEntidad> Listado()
        {
            List<ContactoEntidad> Lista = new List<ContactoEntidad>();
            IDataReader reader;

            Conexion.IniciarSesionAccess("tfnos.accdb");
            
            //Conexion.IniciarSesionSQLite("Tfnos.s3db");
            reader = Conexion.BDatos.ObtenerDataReaderSql(comandoSql: "Select nombre, telefono, direccion, observaciones from telefonos");

            while(reader.Read())
            {
                Lista.Add(CargarContacto(reader));
            }

            Conexion.FinalizarSesion();
            return Lista;
        }

        private static ContactoEntidad CargarContacto(IDataReader reader)
        {
            ContactoEntidad contacto = new ContactoEntidad
            {
                Nombre = reader.GetString(0),
                Telefono = reader.GetString(1),
                Direccion = reader.GetString(2),
                Observaciones = reader.GetString(3)
            };

            return contacto;

        }

        public static int Guardar(ContactoEntidad c)
        {
            string sql = "";
            int filas = 0;

            Conexion.IniciarSesionAccess("tfnos.accdb");
            //Conexion.IniciarSesionSQLite("Tfnos.s3db");
            sql = @"INSERT INTO telefonos
                    (nombre, direccion, telefono, observaciones)
                    VALUES('"+c.Nombre+"','"+c.Direccion+"','"+c.Telefono+"','"+c.Observaciones+"')";

            filas = Conexion.BDatos.EjecutarSql(sql);

            Conexion.FinalizarSesion();
            return filas;
        }
    }
}
