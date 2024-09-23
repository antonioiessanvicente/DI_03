using Oracle.ManagedDataAccess.Client;
using System;

namespace AccesoDatos
{
    public class OracleConexion : CDatos
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

                        //sCadena = "User ID=MUNDIAL; Password=1234; " +
                        //"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521)) " +
                        //"(CONNECT_DATA = (SERVICE_NAME = xe)))"

                        sCadena.Append("User ID=<USER>; ");
                        sCadena.Append("Password=<PASSWORD>;");
                        sCadena.Append("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)");
                        sCadena.Append("(HOST=<SERVIDOR>)");
                        sCadena.Append("(PORT=<PORT>))");
                        sCadena.Append("(CONNECT_DATA = (SERVICE_NAME = <BASEDATOS>)))");
                        sCadena.Replace("<SERVIDOR>", Servidor);
                        sCadena.Replace("<BASEDATOS>", Base);
                        sCadena.Replace("<USER>", Usuario);
                        sCadena.Replace("<PASSWORD>", Password);
                        sCadena.Replace("<PORT>", Puerto);
                        MCadenaConexion = sCadena.ToString();
                        return MCadenaConexion;
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase OracleConexion");
                }
                return MCadenaConexion;
 
            }// end get
            set
            { MCadenaConexion = value; } // end set
        }// end CadenaConexion
 
        protected override System.Data.IDbCommand ComandoSql(string comandoSql)
        {
            var com = new OracleCommand(comandoSql, (OracleConnection)Conexion);
            return com;
        }// end Comando
 
        /* 
         * Luego implementaremos CrearConexion, donde simplemente se devuelve una nueva instancia del 
         * objeto Conexión de SqlClient, utilizando la cadena de conexión del objeto.
         */
        protected override System.Data.IDbConnection CrearConexion(string cadenaConexion)
        { return new OracleConnection(cadenaConexion); }
 
 
        //Finalmente, es el turno de definir CrearDataAdapter, el cual aprovecha el método Comando para crear el comando necesario.
        protected override System.Data.IDataAdapter CrearDataAdapterSql(string comandoSql)
        {
            var da = new OracleDataAdapter((OracleCommand)ComandoSql(comandoSql));
            return da;
        } // end CrearDataAdapterSql
 
        /*
         * Definiremos dos constructores especializados, uno que reciba como argumentos los valores de Nombre del Servidor 
         * y de base de datos que son necesarios para acceder a datos, y otro que admita directamente la cadena de conexión completa.
         * Los constructores se definen como procedimientos públicos de nombre New.
         */
        public OracleConexion()
        {
            Base = "";
            Servidor = "";
            Usuario = "";
            Password = "";
        }// end OracleConexion


        public OracleConexion(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }// end OracleConexion

        public OracleConexion(string servidor, string @base)
        {
            Base = @base;
            Servidor = servidor;
        }// end OracleConexion

        public OracleConexion(string servidor, string @base, string puerto, string usuario, string password)
        {
            Base = @base;
            Servidor = servidor;
            Usuario = usuario;
            Password = password;
            Puerto = puerto;

        }// end OracleConexion

    }// end class DatosSQLServer
}