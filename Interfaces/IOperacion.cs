using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
   public interface IOperacion
    {
        int Agregar(Operacion operacion);
        int Anular(Operacion operacion);
        DataTable Listar();
        DataTable Buscar(Operacion operacion, int tipo);
        DataTable Imprimir(Operacion operacion);

        DataTable ImprimirPago(Operacion operacion);
        int Agregardeposito(Operacion operacion);
        int Agregarpagos(Operacion operacion);
        int Agregarpagostarjeta(Operacion operacion);
        int Agregargiro(Operacion operacion);
        DataTable ImprimirPagos(Operacion operacion);
        DataTable ImprimirPagostarjeta(Operacion operacion);
        DataTable ImprimirGiros(Operacion operacion);
    }
}
