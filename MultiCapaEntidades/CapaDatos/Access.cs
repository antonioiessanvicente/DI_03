using System;
using System.Data;
using System.Data.OleDb;

namespace AccesoDatos
{
    public sealed class Access : CDatos
    {

        public override string CadenaConexion
        {
            get
            {
                if (MCadenaConexion.Length == 0)
                {
                    if (MServidor.Length != 0)
                    {
                        var sCadena = new System.Text.StringBuilder("");
                        sCadena.Append("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=True;");
                        sCadena.Append("Data Source=|DataDirectory|\\<SERVIDOR>;");
                        sCadena.Replace("<SERVIDOR>", Servidor);
                        sCadena.Replace("<BASE>", Base);
                        sCadena.Replace("<USER>", Usuario);
                        sCadena.Replace("<PASSWORD>", Password);
                        MCadenaConexion = sCadena.ToString();
                        return MCadenaConexion;
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase Access.");
                }
                return MCadenaConexion;

            }// end get
            set
            { MCadenaConexion = value; } // end set
        }

        protected override IDbCommand ComandoSql(string comandoSql)
        {
            var com = new OleDbCommand(comandoSql, (OleDbConnection)Conexion);
            return com;
        }

        protected override IDbConnection CrearConexion(string cadenaConexion)
        { return new OleDbConnection(cadenaConexion); }

        protected override IDataAdapter CrearDataAdapterSql(string comandoSql)
        {
            var da = new OleDbDataAdapter((OleDbCommand)ComandoSql(comandoSql));
            return da;
        } 

        public Access()
        {
            Base = "";
            Servidor = "";
            Usuario = "";
            Password = "";
        }
        public Access(string servidor)
        {
            Servidor = servidor;
        }

    }
}
