using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Operacion
    {
        public int idoperacion { get; set; }
        public string numero_operacion { get; set; }
        public string cuenta_origen { get; set; }
        public string cuenta_destino { get; set; }
        public string nombre_destino { get; set; }
        public double monto { get; set; }
        public int idcategoria { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hora { get; set; }
        public DateTime registro { get; set; }
        public int estado { get; set; }
        public int idbanco { get; set; }
        public int tipo { get; set; }
        public int idcajachica { get; set; }
        public int idmedio { get; set; }
        public string descripcionpago { get; set; }
        public string titular { get; set; }
        public string tarjetadestino { get; set; }
        public string tarjetacredito { get; set; }
        public double montotarjeta { get; set; }
        public string pagosempresa { get; set; }
        public string pagoscategoria { get; set; }
        public string pagosservicio { get; set; }
        public string pagoscodigo { get; set; }
        public double giromonto { get; set; }
        public double girocomision { get; set; }
        public string girodocumento { get; set; }
        public string girobeneficiario { get; set; }
        public string giroclave { get; set; }
        public string recibo { get; set; }
        public string deuda { get; set; }
        public string mora { get; set; }
        public string vcmto { get; set; }

    }
}
