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
  public class OperacionDAO : IOperacion,IDisposable
    {
        string cnx = Helper.CadenaConexion();
        public int Agregar(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_rgistraroperacion", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pnumero", operacion.numero_operacion);
                    cmd.Parameters.AddWithValue("porigen", operacion.cuenta_origen);
                    cmd.Parameters.AddWithValue("pdestino", operacion.cuenta_destino);
                    cmd.Parameters.AddWithValue("pnombre", operacion.nombre_destino);
                    cmd.Parameters.AddWithValue("pmonto", operacion.monto);
                    cmd.Parameters.AddWithValue("pidcat", operacion.idcategoria);
                    cmd.Parameters.AddWithValue("pidbanco", operacion.idbanco);
                    cmd.Parameters.AddWithValue("pfecha", operacion.fecha);
                    cmd.Parameters.AddWithValue("ptipo", operacion.tipo);
                    cmd.Parameters.AddWithValue("pidmedio", operacion.idmedio);
                    cmd.Parameters.AddWithValue("pdescripcion", operacion.descripcionpago);

                    cmd.Parameters.AddWithValue("precibo", operacion.recibo);
                    cmd.Parameters.AddWithValue("pdeuda", operacion.deuda);
                    cmd.Parameters.AddWithValue("pmora", operacion.mora);
                    cmd.Parameters.AddWithValue("pvcmto", operacion.vcmto);

                    cmd.Parameters.Add("pidope", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    int idoperacion = 0;

                   int rpta  = cmd.ExecuteNonQuery();

                    if (rpta > 0)
                    {
                        idoperacion = Convert.ToInt32(cmd.Parameters["pidope"].Value);
                    }
                    return idoperacion;

                }

            }
        }

        public int Anular(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_anularoperacion", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidope", operacion.idoperacion);
                  


                    int rpta = cmd.ExecuteNonQuery();

                   
                    return rpta;

                }

            }
        }

        public DataTable Buscar(Operacion operacion,int tipo )
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_Buscaroperacion", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ptipo", tipo);
                    cmd.Parameters.AddWithValue("pfecha", operacion.fecha);
                    cmd.Parameters.AddWithValue("pnumop", operacion.numero_operacion);
                    cmd.Parameters.AddWithValue("pbanco", operacion.nombre_destino);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }

        public DataTable Imprimir(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_imprimirticket", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidope", operacion.idoperacion);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        return dt;
                    }
                }
            }

        }

        public DataTable ImprimirPago(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_ImprimirPago", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidope", operacion.idoperacion);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        return dt;
                    }
                }
            }

        }

        public DataTable ImprimirPagos(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_ImprmirPagos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidope", operacion.idoperacion);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        return dt;
                    }
                }
            }

        }

        public DataTable ImprimirPagostarjeta(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_imprimirpagostarjeta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidope", operacion.idoperacion);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        return dt;
                    }
                }
            }

        }

        public int Agregardeposito(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_resgistardeposito", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pnumero", operacion.numero_operacion);
                    cmd.Parameters.AddWithValue("porigen", operacion.cuenta_origen);
                    cmd.Parameters.AddWithValue("pdestino", operacion.cuenta_destino);
                    cmd.Parameters.AddWithValue("pnombre", operacion.titular);
                    cmd.Parameters.AddWithValue("pmonto", operacion.monto);
                    cmd.Parameters.AddWithValue("pidcat", operacion.idcategoria);
                    cmd.Parameters.AddWithValue("pidbanco", operacion.idbanco);
                    cmd.Parameters.AddWithValue("pfecha", operacion.fecha);
                    cmd.Parameters.AddWithValue("pidmedio", operacion.idmedio);
                

                    cmd.Parameters.Add("pidope", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    int idoperacion = 0;

                    int rpta = cmd.ExecuteNonQuery();

                    if (rpta > 0)
                    {
                        idoperacion = Convert.ToInt32(cmd.Parameters["pidope"].Value);
                    }
                    return idoperacion;

                }

            }
        }

        public int Agregarpagos(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_registrarpagos", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pnumero", operacion.numero_operacion);
                    
                   
                    cmd.Parameters.AddWithValue("pmonto", operacion.monto);
                    cmd.Parameters.AddWithValue("pidcat", operacion.idcategoria);
                    cmd.Parameters.AddWithValue("pidbanco", operacion.idbanco);
                    cmd.Parameters.AddWithValue("pfecha", operacion.fecha);
                   
                    cmd.Parameters.AddWithValue("pidmedio", operacion.idmedio);

                    cmd.Parameters.AddWithValue("pempresa", operacion.pagosempresa);
                    cmd.Parameters.AddWithValue("pcategoria", operacion.pagoscategoria);
                    cmd.Parameters.AddWithValue("pservicio", operacion.pagosservicio);
                    cmd.Parameters.AddWithValue("pcodigo", operacion.pagoscodigo);
                    cmd.Parameters.AddWithValue("ptitular", operacion.titular);

                    cmd.Parameters.AddWithValue("precibo", operacion.recibo);
                    cmd.Parameters.AddWithValue("pdeuda", operacion.deuda);
                    cmd.Parameters.AddWithValue("pmora", operacion.mora);
                    cmd.Parameters.AddWithValue("pvcmto", operacion.vcmto);


                    cmd.Parameters.Add("pidope", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    int idoperacion = 0;

                    int rpta = cmd.ExecuteNonQuery();

                    if (rpta > 0)
                    {
                        idoperacion = Convert.ToInt32(cmd.Parameters["pidope"].Value);
                    }
                    return idoperacion;

                }

            }
        }
        public int Agregarpagostarjeta(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_registrarpagotarjeta", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pnumero", operacion.numero_operacion);
                  
                    cmd.Parameters.AddWithValue("pmonto", operacion.monto);
                    cmd.Parameters.AddWithValue("pidcat", operacion.idcategoria);
                    cmd.Parameters.AddWithValue("pidbanco", operacion.idbanco);
                    cmd.Parameters.AddWithValue("pfecha", operacion.fecha);
                  
                    cmd.Parameters.AddWithValue("pidmedio", operacion.idmedio);


                    cmd.Parameters.AddWithValue("pdestino", operacion.tarjetadestino);
                    cmd.Parameters.AddWithValue("ptitular", operacion.titular);
                    cmd.Parameters.AddWithValue("ptarjeta", operacion.tarjetacredito);
                    cmd.Parameters.AddWithValue("pmontotarjeta", operacion.montotarjeta);


                    cmd.Parameters.Add("pidope", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    int idoperacion = 0;

                    int rpta = cmd.ExecuteNonQuery();

                    if (rpta > 0)
                    {
                        idoperacion = Convert.ToInt32(cmd.Parameters["pidope"].Value);
                    }
                    return idoperacion;

                }

            }
        }
        public int Agregargiro(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_registrargiros", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pnumero", operacion.numero_operacion);
                 
                   
                    cmd.Parameters.AddWithValue("pmonto", operacion.monto);
                    cmd.Parameters.AddWithValue("pidcat", operacion.idcategoria);
                    cmd.Parameters.AddWithValue("pidbanco", operacion.idbanco);
                    cmd.Parameters.AddWithValue("pfecha", operacion.fecha);
                  
                    cmd.Parameters.AddWithValue("pidmedio", operacion.idmedio);

                    cmd.Parameters.AddWithValue("pgiromonto", operacion.giromonto);
                    cmd.Parameters.AddWithValue("pgirocomision", operacion.girocomision);
                    cmd.Parameters.AddWithValue("pgirodocumento", operacion.girodocumento);
                    cmd.Parameters.AddWithValue("pgirobeneficiario", operacion.girobeneficiario);
                    cmd.Parameters.AddWithValue("pgiroclave", operacion.giroclave);



                    cmd.Parameters.Add("pidope", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    int idoperacion = 0;

                    int rpta = cmd.ExecuteNonQuery();

                    if (rpta > 0)
                    {
                        idoperacion = Convert.ToInt32(cmd.Parameters["pidope"].Value);
                    }
                    return idoperacion;

                }

            }
        }


        public DataTable ImprimirGiros(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_imprimirgiros", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidope", operacion.idoperacion);

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
        // ~OperacionDAO() {
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
