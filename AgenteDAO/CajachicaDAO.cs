using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace AgenteDAO
{
    public class CajachicaDAO : ICajachica,IDisposable
    {
        string cnx = Helper.CadenaConexion();
        public int Agregar(Cajachica cajachica)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_registrarcajachica", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pfecha", cajachica.fechahapertura);
                    cmd.Parameters.AddWithValue("pmonto", cajachica.montoapertura);
                    cmd.Parameters.AddWithValue("pidcajero", cajachica.idcajero);

                    cmd.Parameters.Add("idcaja", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    int idcaja = 0;

                    int rpta = cmd.ExecuteNonQuery();

                    if (rpta > 0)
                    {
                        idcaja = Convert.ToInt32(cmd.Parameters["idcaja"].Value);
                    }
                    return idcaja;

                }

            }
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }

        public DataTable Buscar()
        {
          

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_buscarcajaactiva", cn))
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

        public DataTable Saldocierre()
        {


            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_saldocierre", cn))
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

        public DataTable Operacionescierre()
        {


            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_operacionescierre", cn))
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

        public DataTable Resumenpormediocierre()
        {


            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_cierrepormedios", cn))
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

        public int Cierre(Cajachica cajachica)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_Cierrecaja", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pobservacion", cajachica.observacion);
                    cmd.Parameters.AddWithValue("pefectivo", cajachica.efectivo);

                    cmd.Parameters.Add("pidcaja", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    int idcaja = 0;

                    int rpta = cmd.ExecuteNonQuery();

                    if (rpta > 0)
                    {
                        idcaja = Convert.ToInt32(cmd.Parameters["pidcaja"].Value);
                    }
                  
                                                                       

                   
                    return idcaja;

                }

            }
        }

        public DataTable Imprimircierre(int idcajachica)
        {


            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_imprimircierre", cn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("pidcaja", idcajachica);

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
        // ~CajachicaDAO() {
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
