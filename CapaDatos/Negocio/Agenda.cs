using System.Data;
using System.Collections.Generic;
using CapaDatos;

namespace CapaNegocio
{
    public class Agenda
    {
        private List<Contacto> contactos {get; set;}

        public Agenda()
        {
            contactos = new List<Contacto>();
        }

        public DataTable ListadoTelefonico()
        {
            return CapaDatos.Contacto.Listado();
        }

    }
}
