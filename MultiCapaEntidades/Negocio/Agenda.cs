using CapaDatos;
using Entidades;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class Agenda
    {
        private List<ContactoEntidad> Contactos {get; set;}

        public Agenda()
        {
            Contactos = new List<ContactoEntidad>();
        }

        public List<ContactoEntidad> ListadoTelefonico()
        {
            return CapaDatos.ContactoADO.Listado();
        }

        public int GuardarContacto(ContactoEntidad c)
        {
            return CapaDatos.ContactoADO.Guardar(c);
        }

    }
}
