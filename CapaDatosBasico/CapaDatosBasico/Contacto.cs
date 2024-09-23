using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatosBasico
{

 public class Contacto
    {
        // Atributos de la clase
        private string nombre; // String 12 PK
        private string telefono; // String 30 

        //Para manejar la clase ADO
        //Este atributo quiero que sea privado, para manejarlo siempre desde la clase País, por lo tanto no creo propiedad.
        private ContactoADO ADO;


        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                if (value.Length <= 0 || value.Length > 12)
                {
                    throw new ArgumentException("ERR-0001: El teléfono debe contener valor y no superar los 12 caracteres");
                }
                telefono = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                
                if (value.Length > 30)
                {
                    throw new ArgumentException("ERR-0002: El nombre no debe de exceder de 30 caracteres");
                }
                nombre = value;
            }
        }

        public Contacto()
        {
            Nombre = "Sin nombre";
            Telefono = "0";
            ADO = new ContactoADO();
        }

        public Contacto(string pNombre, string pTelefono)
        {
            int resultado = 0;
            Nombre = pNombre;
            Telefono = pTelefono;
            ADO = new ContactoADO();

            resultado = ADO.Insertar(String.Format("INSERT INTO telefonos (nombre, telefono) VALUES ('{0}','{1}')" , pNombre,pTelefono));

            //Válido para BBDD que devuelven el número de filas insertadas.
           //if (resultado == 0)
           //     {
           //     //Hay un error
           //     throw new ArgumentException("Err:0003 - No se ha podido insertar el contacto en la base de datos");
           //    }
           // else
           // {
           //   // TODO OK.   
           // }
        
        }

        public IList<Contacto> Listado()
        {
            IList<Contacto> tabla;
            ADO = new ContactoADO();
            tabla =ADO.Listado("Select * from Telefonos");
            return tabla;
        }
    }
  
}
