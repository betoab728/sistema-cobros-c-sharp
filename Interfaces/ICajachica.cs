using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;


namespace Interfaces
{
  public  interface ICajachica
    {
        int Agregar(Cajachica cajachica);
        int Cierre(Cajachica cajachica);
         DataTable Listar();
        DataTable Buscar();
        DataTable Saldocierre();
        DataTable Operacionescierre();
        DataTable Resumenpormediocierre();
        DataTable Imprimircierre(int idcajachica);
    }

}
