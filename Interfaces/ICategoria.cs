using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Interfaces
{
   public interface ICategoria
    {
        int Agregar(Categoria categoria);
        int Editar(Categoria categoria);
        int Anular(Categoria categoria);
        DataTable Listar();
    }
}
