using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using MySql.Data.MySqlClient;


namespace AgenteDAO
{
    public class CategoriaDAO : ICategoria,IDisposable
    {
        string cnx = Helper.CadenaConexion();
        public int Agregar(Categoria categoria)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_registrarcategoria", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pnombre", categoria.nombre);

                    int idcat = 0;

                    idcat = cmd.ExecuteNonQuery();

                    return idcat;

                }

            }
        }

        public int Editar(Categoria categoria)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_editarcategoria", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pnombre", categoria.nombre);
                    cmd.Parameters.AddWithValue("pidcat", categoria.idcategoria);


                    return cmd.ExecuteNonQuery();



                }

            }
        }

        public int Anular(Categoria categoria)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_anularcategoria", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
             
                    cmd.Parameters.AddWithValue("pidcat", categoria.idcategoria);


                    return cmd.ExecuteNonQuery();



                }

            }
        }

        public DataTable Listar()
        {
            using( MySqlConnection cn=new MySqlConnection(cnx) )
            {
             
                using (MySqlCommand cmd=new MySqlCommand("sp_ListarCategorias", cn))
                {
                    using (MySqlDataAdapter da=new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        return dt;
                    }
                }
            }
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
        // ~CategoriaDAO() {
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
