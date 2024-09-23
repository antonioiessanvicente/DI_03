using System.Collections.Generic;
using CapaDatosBasico;
using System;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace Negocio
{
    /// <summary>
    /// Esta clase nos generará las reglas de negocio y la gestión de una Agenda Personal, dónde uno de los elementos son los teléfonos de los contactos.
    /// </summary>

    public class Agenda
    {
        private List<Contacto> contactos;

        public Agenda()
        {
            contactos = new List<Contacto>();
        }
        /// <summary>
        /// Tendrá una regla de negocio que no nos permitirá tener más de 3 telefonos en la agenda.
        /// </summary>
        /// <param name="pTelefono"></param>
        /// <param name="pNombre"></param>
        public void InsertarAgenda(string pNombre, string pTelefono)
        {
            // Implementación de la regla de negocio.
            if (contactos.Count > 3)
            {
                throw new ArgumentException("ERR-0004:No se pueden almacenar más de 3 contactos.");
            }
            else
            {
                contactos.Add(new Contacto(pNombre, pTelefono));
            }
        }



        /// <summary>
        /// Transforma la Ilist en un DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable ListadoTelefonico()
        {
            Contacto c = new Contacto();
            return c.Listado().ToDataTable();

        }
    }

    /// <summary>
    /// Extensión para convertir una IList en un DataTable
    /// </summary>
public static class IListExtensions
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            // Crear las columnas del DataTable
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Agregar las filas al DataTable
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }


}
