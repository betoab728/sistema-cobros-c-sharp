using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agente.Formularios;
using AgenteBLL;


namespace Agente
{
    public partial class FrmAcceso : Form
    {
        public FrmAcceso()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmAcceso_Load(object sender, EventArgs e)
        {
            ListarUsuario();
        }

        private void Buscar()
        {
            using (UsuarioBLL db =new UsuarioBLL())
            {
                try
                {
                    int idusuario = Convert.ToInt32(cmbusuario.SelectedValue);
                    string pass = txtpass.Text;

                    DataTable dt = db.Buscar(idusuario, pass);

                    if (dt.Rows.Count>0)
                    {
                        MessageBox.Show("Bienvenido","Acceso correcto");
                        FrmMDI mdi=new FrmMDI();
                        mdi.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado al usuario", "Acceso Denegado");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ListarUsuario()
        {
            using (UsuarioBLL db=new UsuarioBLL())
            {
                cmbusuario.ValueMember = "idusuario";
                cmbusuario.DisplayMember = "nombre";
                cmbusuario.DataSource = db.Listar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtpass.Text.Length>0)
            {
                Buscar();
            }
            else
            {
                MessageBox.Show("Ingese la contraseña");
            }
        }
    }
}
