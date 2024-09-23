using DatosEEF;
using Modelos;
using System.Collections.Generic;

namespace NegocioEEF 
{
    public class Agenda : IDisposable
    {
        private List<Contacto> Telefonos { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed;

        public Agenda()
        {
            Telefonos = new List<Contacto>();
            // Flag: Has Dispose already been called?
            disposed = false;
        }
        static public IList<Contacto> ListadoTelefonico()
        {            
            return DatosEEF.ConactoADO.Listar();
        }
        public void GuardarContacto(Contacto t1)
        {
            using (ConactoADO tado = new ConactoADO())
            {
                tado.Insertar(t1);
            }
        }
        public void GuardarContacto2(Contacto t1)
        {
            using (ConactoADO tado = new ConactoADO())
            {
                tado.Insertar2(t1);
            }
        }
        public void ActualizarContacto(Contacto t1)
        {
            using (ConactoADO tado = new ConactoADO())
            {
                tado.Actualizar(t1.Ntelefono,t1);
            }
        }
        public void ActualizarContacto2(Contacto t1)
        {
                using (ConactoADO tado = new ConactoADO())
                {
                    tado.Actualizar2(t1);
                }
        }
        public void BorrarContacto(string t1)
        {
            using (ConactoADO tado = new ConactoADO())
            {
                tado.Borrar(t1);
            }
        }
        public void BorrarContacto2(Contacto t1)
        {
                using (ConactoADO tado = new ConactoADO())
                {
                    tado.Borrar2(t1);
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
