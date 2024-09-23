using Modelos;
using Microsoft.EntityFrameworkCore;

namespace DatosEEF
{
    public class ConactoADO : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed;

        public ConactoADO()
        {
            // Flag: Has Dispose already been called?
            disposed = false;
        }

        // Utilizando el contexto para manejar el CRUD
        // Se crea de forma estática (static) para ilustrar su uso.
       static public IList<Contacto> Listar()
        {
            using (var context = new EEFContext())
            {
                // Return the list of data from the database
                var data = context.Telefonos.ToList();
                return data;
            }
        }

        public Contacto Listar(String ID)
        {
            using (var _context = new EEFContext())
            {
                var query = from st in _context.Telefonos
                            where st.Ntelefono == ID
                            select st;

                var telefono = query.FirstOrDefault<Contacto>();
                return telefono;
            }
            
        }

        public void Insertar(Contacto dato)
        {
            using (var context = new EEFContext())
            {
                var std = new Contacto()
                {
                    Ntelefono = dato.Ntelefono,
                    Nombre = dato.Nombre,
                    Direccion = dato.Direccion,
                    Observaciones = dato.Observaciones

                };
                context.Telefonos.Add(std);

                // save the changes
                context.SaveChanges();
            }
        }

        public void Actualizar(String ID, Contacto modificado)
        {
            using (var context = new EEFContext())
            {

                // Use of lambda expression to access
                // particular record from a database
                var dato = context.Telefonos.FirstOrDefault(x => x.Ntelefono == ID);

                // Checking if any such record exist
                if (dato != null)
                {
                    dato.Ntelefono = modificado.Ntelefono;
                    dato.Nombre = modificado.Nombre;
                    dato.Direccion = modificado.Direccion;
                    dato.Observaciones = modificado.Observaciones;

                    context.SaveChanges();
                }
                else
                { 
                    // Si no lo encunetra
                }
            }
        }

        public void Borrar(string ID)
        {
            using (var context = new EEFContext())
            {
                var data = context.Telefonos.FirstOrDefault(x => x.Ntelefono == ID);
                if (data != null)
                {
                    context.Telefonos.Remove(data);
                    context.SaveChanges();
                }
                else
                {
                    // Si no lo encunetra
                }
            }
        }

        // Replicar las funcionalidades anteriores,
        // utilizando los estados de entidad para manejar el CRUD
        // https://learn.microsoft.com/es-es/ef/ef6/saving/change-tracking/entity-state?redirectedfrom=MSDN

        public void Insertar2(Contacto dato)
        {
            using (var context = new EEFContext())
            {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        // El Telefono modificado contiene los datos modificados, y Entry busca por la Clave Primaria
        public void Actualizar2(Contacto modificado)
        {
            using (var context = new EEFContext())
            {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar2(Contacto dato)
        {
            using (var context = new EEFContext())
            {
                context.Entry(dato).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        
        
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
   
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //Liberar recursos no manejados como ficheros, conexiones a bd, etc.
            }

            disposed = true;
        }
    }

}
