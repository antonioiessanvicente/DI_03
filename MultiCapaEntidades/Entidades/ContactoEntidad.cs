namespace Entidades
{
    public class ContactoEntidad
    {

        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }

        public ContactoEntidad()
        {
            Telefono = "";
            Nombre = "";
            Direccion = "";
            Observaciones = "";
        }
    }
}
