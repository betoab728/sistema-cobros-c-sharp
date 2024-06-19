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
    public class OperacionBLL : IOperacion,IDisposable
    {
        OperacionDAO db = new OperacionDAO();
        public int Agregar(Operacion operacion)
        {
            return db.Agregar(operacion);
        }

        public int Anular(Operacion operacion)
        {
            return db.Anular(operacion);
        }

        public DataTable Buscar(Operacion operacion, int tipo)
        {
          return db.Buscar(operacion,tipo);
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }

        public DataTable Imprimir(Operacion operacion)
        {
            return db.Imprimir(operacion);
        }
        public DataTable ImprimirPago(Operacion operacion)
        {
            return db.ImprimirPago(operacion);
        }

        public int Agregardeposito(Operacion operacion)
        {
            return db.Agregardeposito(operacion);
        }
public int Agregarpagos(Operacion operacion)
        {
            return db.Agregarpagos(operacion);
        }
  public int Agregarpagostarjeta(Operacion operacion)
        {
            return db.Agregarpagostarjeta(operacion);
        }
 public int Agregargiro(Operacion operacion)
        {
            return db.Agregargiro(operacion);
        }

   public      DataTable ImprimirPagos(Operacion operacion)
        {
            return db.ImprimirPagos(operacion);
        }

        public DataTable ImprimirPagostarjeta(Operacion operacion)
        {
            return db.ImprimirPagostarjeta(operacion);
        }
        public DataTable ImprimirGiros(Operacion operacion)
        {
            return db.ImprimirGiros(operacion);
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
        // ~OperacionBLL() {
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
