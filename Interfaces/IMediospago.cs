using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Interfaces
{
  public   interface IMediospago
    {
        int Agregar(Mediospago mediospago);
        int Editar(Mediospago mediospago);
        DataTable Listar();
    }
}
