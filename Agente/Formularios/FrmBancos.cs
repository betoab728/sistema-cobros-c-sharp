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
using Entidades;

namespace Agente.Formularios
{
    public partial class FrmBancos : Form
    {
        public FrmBancos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegBanco banco = new FrmRegBanco();
            banco.accion = "agregar";
            banco.ShowDialog();

            ListarBancos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgbancos.Rows.Count>0)
            {
                FrmRegBanco banco = new FrmRegBanco();

                int idbanco = Convert.ToInt32(dtgbancos.CurrentRow.Cells["idbanco"].Value);
                banco.lblidbanco.Text = idbanco.ToString();
                banco.accion = "modificar";
                banco.txtnombre.Text = dtgbancos.CurrentRow.Cells["NOMBRE"].Value.ToString();
                banco.ShowDialog();

                ListarBancos();

            }
          
        }

        private void FrmBancos_Load(object sender, EventArgs e)
        {
            ListarBancos();
        }

        private void ListarBancos()
        {
            using (BancosBLL db = new BancosBLL())
            {
                try
                {
                   
                    dtgbancos.DataSource = db.Listar();

                    dtgbancos.Columns["idbanco"].Visible = false;
                    dtgbancos.Columns["NOMBRE"].Width = 300;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" ¿Esta seguro de anular el banco?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (BancosBLL db = new BancosBLL())
                {
                    try
                    {
                        Banco banco = new Banco();
                        banco.idbanco = Convert.ToInt32(dtgbancos.CurrentRow.Cells["idbanco"].Value);

                        if (db.Anular(banco) > 0)
                        {
                            MessageBox.Show("Banco anulado");
                            ListarBancos();
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
