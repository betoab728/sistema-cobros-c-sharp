using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Interfaces
{
   public interface ICajero
    {
        int Agregar(Cajero cajero);
        int Editar(Cajero cajero);
        int Anular(Cajero cajero);
        DataTable Buscar(Cajero cajero);
        DataTable Listar();
    }
}
