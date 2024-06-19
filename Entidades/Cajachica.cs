using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public  class Cajachica
    {
        public int idcajachica { get; set; }
        public DateTime fechahapertura { get; set; }
        public DateTime fechacierre { get; set; }
        public double montoapertura { get; set; }
        public double efectivo { get; set; }
        public int estado { get; set; }
        public int idcajero { get; set; }
        public string  observacion { get; set; }

    }
}
