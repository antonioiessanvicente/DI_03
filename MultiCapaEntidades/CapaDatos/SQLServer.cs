using System;
 
namespace AccesoDatos
{
    public class SqlServer : CDatos
    {
       
 
        public override sealed string CadenaConexion
        {
            get
            {
                if (MCadenaConexion.Length == 0)
                {
                    if (MBase.Length != 0 && MServidor.Length != 0)
                    {
                        var sCadena = new System.Text.StringBuilder("");
                        sCadena.Append("data source=<SERVIDOR>;");
                        sCadena.Append("initial catalog=<BASE>;");
                        sCadena.Append("user id=<USER>;");
                        sCadena.Append("password=<PASSWORD>;");
                        sCadena.Append("persist security info=True;");
                        sCadena.Append("user id=sa;packet size=4096");
                        sCadena.Replace("<SERVIDOR>", Servidor);
                        sCadena.Replace("<BASE>", Base);
                        sCadena.Replace("<USER>", Usuario);
                        sCadena.Replace("<PASSWORD>", Password);
                        MCadenaConexion = sCadena.ToString();
                        return MCadenaConexion;
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase DatosSQLServer");
                }
                return MCadenaConexion;
 
            }// end get
            set
            { MCadenaConexion = value; } // end set
        }// end CadenaConexion
 
        protected override System.Data.IDbCommand ComandoSql(string comandoSql)
        {
            var com = new System.Data.SqlClient.SqlCommand(comandoSql, (System.Data.SqlClient.SqlConnection)Conexion, (System.Data.SqlClient.SqlTransaction)MTransaccion);
            return com;
        }// end Comando
 
        /* 
         * Luego implementaremos CrearConexion, donde simplemente se devuelve una nueva instancia del 
         * objeto Conexión de SqlClient, utilizando la cadena de conexión del objeto.
         */
        protected override System.Data.IDbConnection CrearConexion(string cadenaConexion)
        { return new System.Data.SqlClient.SqlConnection(cadenaConexion); }
 
 
        //Finalmente, es el turno de definir CrearDataAdapter, el cual aprovecha el método Comando para crear el comando necesario.
        protected override System.Data.IDataAdapter CrearDataAdapterSql(string comandoSql)
        {
            var da = new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)ComandoSql(comandoSql));
            return da;
        } // end CrearDataAdapterSql
 
        /*
         * Definiremos dos constructores especializados, uno que reciba como argumentos los valores de Nombre del Servidor 
         * y de base de datos que son necesarios para acceder a datos, y otro que admita directamente la cadena de conexión completa.
         * Los constructores se definen como procedimientos públicos de nombre New.
         */
        public SqlServer()
        {
            Base = "";
            Servidor = "";
            Usuario = "";
            Password = "";
        }// end DatosSQLServer
 
 
        public SqlServer(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }// end DatosSQLServer
 
        public SqlServer(string servidor, string @base)
        {
            Base = @base;
            Servidor = servidor;
        }// end DatosSQLServer
 
        public SqlServer(string servidor, string @base, string usuario, string password)
        {
            Base = @base;
            Servidor = servidor;
            Usuario = usuario;
            Password = password;
        }// end DatosSQLServer

    }// end class DatosSQLServer
}