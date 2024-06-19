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
using Entidades;
namespace Agente.Formularios
{
    public partial class FrmApertura : Form
    {
        SoloNumeros validar = new SoloNumeros();
        public FrmApertura()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtdni.Text.Length==0)
            {
                MessageBox.Show("ingrese el dni");
                return;
            }

            if (txtclave.Text.Length == 0)
            {
                MessageBox.Show("ingrese la contraseña");
                return;
            }

            using (CajeroBLL db =new CajeroBLL())
            {
                try
                {
                    Cajero cajero = new Cajero();
                    cajero.dni = txtdni.Text;
                    cajero.contraseña = txtclave.Text;



                    DataTable dt = db.Buscar(cajero);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Trabajador no encontrado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {

                            lblidtrabajador.Text = row["idcajero"].ToString();
                            txtcajero.Text = row["nombre"].ToString();

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void FrmApertura_Load(object sender, EventArgs e)
        {

        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validar.Solonumeros(Convert.ToInt32(e.KeyChar), txtmonto);
        }

        private void txtmonto_Leave(object sender, EventArgs e)
        {
            if (txtmonto.Text.Length > 0)
            {
                double monto = 0;
                monto = Convert.ToDouble(txtmonto.Text);
                txtmonto.Text = string.Format("{0:0.00}", monto);

            }
        }

        private void txtmonto_Click(object sender, EventArgs e)
        {
            txtmonto.SelectAll();
        }

        private void txtmonto_Enter(object sender, EventArgs e)
        {
            txtmonto.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblidtrabajador.Text.Equals("0"))
            {
                MessageBox.Show("Primero busque un cajero");
                return;
            }

            if (txtmonto.Text.Length==0)
            {
                MessageBox.Show("Ingrese un monto");
                return;
            }

            DialogResult dialogResult = MessageBox.Show(" ¿Esta seguro de Iniciar la caja?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Grabar();
            }


        }

        private void Grabar()
        {

            using (CajachicaBLL db = new CajachicaBLL())
            {


              

                try
                {
                    Cajachica cajachica = new Cajachica();

                    cajachica.idcajero = Convert.ToInt32(lblidtrabajador.Text);
                    cajachica.fechahapertura = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cajachica.montoapertura = Convert.ToDouble(txtmonto.Text);

                    int idcajachica = db.Agregar(cajachica);

                    if (idcajachica > 0)
                    {
                        MessageBox.Show("Caja iniciada correctamente: " + idcajachica);
                        FrmMDI f1 = Application.OpenForms.OfType<FrmMDI>().SingleOrDefault();
                        f1.statusStrip1.BackColor = Color.LightGreen;
                        f1.lblestado.Text = "Abierto";
                        this.Close();
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
