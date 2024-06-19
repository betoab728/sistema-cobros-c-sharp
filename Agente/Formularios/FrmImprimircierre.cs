using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agente.Formularios
{
    public partial class FrmImprimircierre : Form
    {
        public FrmImprimircierre()
        {
            InitializeComponent();
        }

        private void FrmImprimircierre_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
