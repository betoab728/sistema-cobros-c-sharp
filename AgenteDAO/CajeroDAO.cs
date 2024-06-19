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
   public class CajeroDAO : ICajero,IDisposable
    {

        string cnx = Helper.CadenaConexion();
        public int Agregar(Cajero cajero)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_registrarcajero", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pdni", cajero.dni);
                    cmd.Parameters.AddWithValue("pnombre", cajero.nombre);
                    cmd.Parameters.AddWithValue("pclave", cajero.contraseña);

                    int idbanco = 0;

                    idbanco = cmd.ExecuteNonQuery();

                    return idbanco;

                }

            }
        }

        public int Anular(Cajero cajero)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_anularcajero", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("pidcajero", cajero.idcajero);


                    return cmd.ExecuteNonQuery();



                }

            }
        }

        public DataTable Buscar(Cajero cajero)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_buscarcajero", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pclave", cajero.contraseña);
                    cmd.Parameters.AddWithValue("pdni", cajero.dni);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int Editar(Cajero cajero)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_editarcajero", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidcajero", cajero.idcajero);
                    cmd.Parameters.AddWithValue("pdni", cajero.dni);
                    cmd.Parameters.AddWithValue("pnombre", cajero.nombre);
                    cmd.Parameters.AddWithValue("pcontraseña", cajero.contraseña);

                    return cmd.ExecuteNonQuery();



                }

            }
        }

        public DataTable Listar()
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_ListarCajeros", cn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
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
        // ~CajeroDAO() {
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
