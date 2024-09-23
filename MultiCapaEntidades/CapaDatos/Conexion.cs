namespace AccesoDatos
{
    public class Conexion
    {
        public static CDatos BDatos;
        // iniciar sesi�n contra un SQLServer
        public static bool IniciarSesion(string nombreServidor, string baseDatos, string usuario, string password)
        {
            BDatos = new SqlServer(nombreServidor, baseDatos, usuario, password);
            return BDatos.Autentificar();
        } //fin inicializa sesion

        //Iniciar sesi�n contra un SQLite
        public static bool IniciarSesionSQLite(string baseDatos)
        {
            BDatos = new SQLite(baseDatos);
            return BDatos.Autentificar();
        }

        public static bool IniciarSesionAccess(string baseDatos)
        {
            //Iniciar sesi�n contra un Acess
            BDatos = new Access(baseDatos);
            return BDatos.Autentificar();
        }

        public static bool IniciarSesionAccess()
        {
            //Iniciar sesi�n contra un Acess
            BDatos = new Access("tfnos.accdb");
            return BDatos.Autentificar();
        }

        public static void FinalizarSesion()
        {
            BDatos.CerrarConexion();
        } //fin FinalizaSesion
    }
}