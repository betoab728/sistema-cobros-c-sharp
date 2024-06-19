using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using AgenteDAO;
using System.Data;
namespace AgenteBLL
{
    public class CajachicaBLL : ICajachica,IDisposable
    {
        CajachicaDAO db = new CajachicaDAO();
        public int Agregar(Cajachica cajachica)
        {
           return db.Agregar(cajachica);
        }

        public DataTable Buscar()
        {
           return db.Buscar();
        }

        public DataTable Listar()
        {
           return db.Listar();
        }

        public DataTable Saldocierre()
        {
            return db.Saldocierre();
        }

      

        public DataTable Resumenpormediocierre()
        {
            return db.Resumenpormediocierre();
        }

        public DataTable Operacionescierre()
        {
            return db.Operacionescierre();
        }

        public int Cierre(Cajachica cajachica)
        {
            return db.Cierre(cajachica);
        }

        public DataTable Imprimircierre(int idcajachica)
        {
            return db.Imprimircierre(idcajachica);
        }
        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~CajachicaBLL() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
