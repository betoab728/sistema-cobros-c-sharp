using AgenteBLL;
using Entidades;
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
    public partial class Frmcajeros : Form
    {
        public Frmcajeros()
        {
            InitializeComponent();
        }

        private void Frmcajeros_Load(object sender, EventArgs e)
        {
            ListarCajeros();
        }

        private void ListarCajeros()
        {
            using (CajeroBLL db = new CajeroBLL())
            {
                try
                {

                    dtgcajeros.DataSource = db.Listar();

                    dtgcajeros.Columns["idcajero"].Visible = false;
                    dtgcajeros.Columns["CONTRASENIA"].Visible = false;

                    dtgcajeros.Columns["NOMBRE"].Width = 300;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegcajero cajero = new frmRegcajero();
            cajero.accion = "agregar";
            cajero.ShowDialog();

            ListarCajeros();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgcajeros.Rows.Count > 0)
            {
                frmRegcajero cajero = new frmRegcajero();

                int idcajero = Convert.ToInt32(dtgcajeros.CurrentRow.Cells["idcajero"].Value);
                cajero.lblidcajero.Text = idcajero.ToString();
                cajero.accion = "modificar";
                cajero.txtnombre.Text = dtgcajeros.CurrentRow.Cells["NOMBRE"].Value.ToString();
                cajero.txtdni.Text = dtgcajeros.CurrentRow.Cells["DNI"].Value.ToString();
                cajero.txtclave.Text = dtgcajeros.CurrentRow.Cells["CONTRASENIA"].Value.ToString();

                cajero.ShowDialog();

                ListarCajeros();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" ¿Esta seguro de anular el cajero?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (CajeroBLL db = new CajeroBLL())
                {
                    try
                    {
                        Cajero cajero = new Cajero();
                        cajero.idcajero = Convert.ToInt32(dtgcajeros.CurrentRow.Cells["idcajero"].Value);

                        if (db.Anular(cajero) > 0)
                        {
                            MessageBox.Show("Cajero anulado");
                            ListarCajeros();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
