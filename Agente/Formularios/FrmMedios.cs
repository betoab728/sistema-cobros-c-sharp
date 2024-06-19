using AgenteBLL;
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
    public partial class FrmMedios : Form
    {
        public FrmMedios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegmedios medio = new FrmRegmedios();
            medio.accion = "agregar";
            medio.ShowDialog();

            ListarMedios();
        }

        private void FrmMedios_Load(object sender, EventArgs e)
        {
            ListarMedios();
        }


        private void ListarMedios()
        {
            using (MediospagoBLL db = new MediospagoBLL())
            {
                try
                {

                    dtgmedios.DataSource = db.Listar();

                    dtgmedios.Columns["idmedio"].Visible = false;
                    dtgmedios.Columns["NOMBRE"].Width = 300;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgmedios.Rows.Count > 0)
            {
                FrmRegmedios medio = new FrmRegmedios();

                int idmedio = Convert.ToInt32(dtgmedios.CurrentRow.Cells["idmedio"].Value);
                medio.lblidmedio.Text = idmedio.ToString();
                medio.accion = "modificar";
                medio.txtnombre.Text = dtgmedios.CurrentRow.Cells["NOMBRE"].Value.ToString();
                medio.ShowDialog();

                ListarMedios();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
