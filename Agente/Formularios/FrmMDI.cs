using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgenteBLL;

namespace Agente.Formularios
{
    public partial class FrmMDI : Form
    {
        public FrmMDI()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          

            if (Cajaactiva())
            {
                FrmNuevaOpe ope = new FrmNuevaOpe();
                ope.MdiParent = this;
                ope.Show();

            }
            else
            {
               

                MessageBox.Show("No hay una caja activa");
            }
        }

      

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBancos bancos = new FrmBancos();
            bancos.MdiParent = this;
            bancos.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias cat = new FrmCategorias();
            cat.MdiParent = this;
            cat.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOperaciones oper = new FrmOperaciones();
            oper.MdiParent = this;
            oper.Show();
        }

        private void cajerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmcajeros cajero = new Frmcajeros();
            cajero.MdiParent = this;
            cajero.Show();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if (Cajaactiva())
            {
                MessageBox.Show("Ya existe una caja activa");
            }
            else
            {
                FrmApertura cajero = new FrmApertura();
                cajero.MdiParent = this;
                cajero.Show();
            }

           
        }


        private bool Cajaactiva()
        {
            bool caja = false;

            using (CajachicaBLL db=new CajachicaBLL())
            {
                try
                {
                    DataTable dt = db.Buscar();
                    if (dt.Rows.Count>0)
                    {
                        caja = true;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            return caja;
        }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            Buscarcaja();
        }

        private void Buscarcaja()
        {
            using (CajachicaBLL db=new CajachicaBLL())
            {
                DataTable caja = db.Buscar();

                if (caja.Rows.Count>0)
                {
                    statusStrip1.BackColor = Color.LightGreen;
                    lblestado.Text = "ABIERTO";

                }
                else
                {
                    statusStrip1.BackColor = Color.Red;
                    lblestado.Text = "CERRADO";

                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (Cajaactiva())
            {

                FrmCierre cajero = new FrmCierre();
                cajero.MdiParent = this;
                cajero.Show();
            }
            else
            {
                MessageBox.Show("No hay una caja activa");
            }

        }

        private void mediosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedios medios = new FrmMedios();
            medios.MdiParent = this;
            medios.Show();
        }

        private void cierresDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
