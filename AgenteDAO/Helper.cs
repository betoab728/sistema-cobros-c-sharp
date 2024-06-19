using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenteDAO
{
    public static class Helper
    {
        public static string CadenaConexion()
        {
            return AgenteDAO.Properties.Settings.Default.cnx;
        }

    }
}
