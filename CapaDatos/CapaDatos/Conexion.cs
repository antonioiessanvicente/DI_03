using System;

namespace AccesoDatos
{
    public class Conexion
    {
        /// <summary>
        /// Clase para instanciar la conexión a la base de datos.
        /// Elegimos la base de datos a la que conectarnos instanciando la clase correspondiente.
        /// </summary>
        public static CDatos BDatos;

        public static bool IniciarSesion(string nombreServidor, string baseDatos, string puerto, string usuario, string password)
        {
            BDatos = new OracleConexion(nombreServidor, baseDatos, puerto, usuario, password);
            return BDatos.Autentificar();
        } //fin inicializa sesion


        // iniciar sesión contra un SQLServer
        public static bool IniciarSesion(string nombreServidor, string baseDatos, string usuario, string password)
        {
            BDatos = new SqlServer(nombreServidor, baseDatos, usuario, password);
            return BDatos.Autentificar();
        } //fin inicializa sesion

        //Iniciar sesión contra un SQLite
        public static bool IniciarSesionSQLite(string baseDatos)
        {
            BDatos = new SQLite(baseDatos);
            return BDatos.Autentificar();
        }

        public static bool IniciarSesionAccess(string baseDatos)
        {
            //Iniciar sesión contra un Acess
            BDatos = new Access(baseDatos);
            return BDatos.Autentificar();
        }

        public static void FinalizarSesion()
        {
            BDatos.CerrarConexion();
        } //fin FinalizaSesion
    }
}