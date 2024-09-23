using System;
using System.Data.SQLite;

namespace AccesoDatos
{
    public class SQLite : CDatos
    {
        public override sealed string CadenaConexion
        {
            get
            {
                if (MCadenaConexion.Length == 0)
                {
                    if (MServidor.Length != 0)
                    {
                     var sCadena = new System.Text.StringBuilder("");
                     sCadena.Append("data source=<SERVIDOR>;");
                     sCadena.Replace("<SERVIDOR>", Servidor);
                     MCadenaConexion = sCadena.ToString();
                     return MCadenaConexion;
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase SQLite");
                }
                return MCadenaConexion;
            }// end get
            set
            { MCadenaConexion = value; } // end set
        }// end CadenaConexion

        protected override System.Data.IDbCommand ComandoSql(string comandoSql)
        {
            var com = new System.Data.SQLite.SQLiteCommand(comandoSql, (System.Data.SQLite.SQLiteConnection)Conexion, (System.Data.SQLite.SQLiteTransaction)MTransaccion);
            return com;
        }// end Comando

        /* 
         * Luego implementaremos CrearConexion, donde simplemente se devuelve una nueva instancia del 
         * objeto Conexión de SQLite, utilizando la cadena de conexión del objeto.
         */
        protected override System.Data.IDbConnection CrearConexion(string cadenaConexion)
        { return new SQLiteConnection(cadenaConexion); }


        //Finalmente, es el turno de definir CrearDataAdapter, el cual aprovecha el método Comando para crear el comando necesario.
        protected override System.Data.IDataAdapter CrearDataAdapterSql(string comandoSql)
        {
            var da = new System.Data.SQLite.SQLiteDataAdapter((System.Data.SQLite.SQLiteCommand)ComandoSql(comandoSql));
            return da;
        } // end CrearDataAdapterSql

        /*
         * Definiremos dos constructores especializados, uno que reciba como argumentos los valores de Nombre del Servidor 
         * y de base de datos que son necesarios para acceder a datos, y otro que admita directamente la cadena de conexión completa.
         * Los constructores se definen como procedimientos públicos de nombre New.
         */
        public SQLite()
        {
            Base = "";
            Servidor = "";
            Usuario = "";
            Password = "";
        }// end DatosSQLServer


        public SQLite(string servidor)
        {
            Servidor = servidor;
        }// end DatosSQLServer

    }// end class DatosSQLServer
}
