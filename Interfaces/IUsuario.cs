using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Interfaces
{
  public  interface IUsuario
    {

        int Agregar(Usuario usuario);
        int Editar(Usuario usuario);
        DataTable Listar();
        DataTable Buscar(int idusuario, string pass);
    }
}
