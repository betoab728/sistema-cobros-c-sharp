using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
   public interface IBanco
    {
        int Agregar(Banco banco);
        int Editar(Banco banco);
        int Anular(Banco banco);
        DataTable Listar();
    }
}
