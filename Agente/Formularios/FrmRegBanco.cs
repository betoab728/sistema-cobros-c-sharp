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
    public partial class FrmRegBanco : Form
    {
        public string accion = "";

        public FrmRegBanco()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRegBanco_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Length>0)
            {
                if (accion.Equals("agregar"))
                {
                    Agregar();
                }
                else if (accion.Equals("modificar"))
                {
                    Modificar();
                }
            }
            else
            {
                MessageBox.Show("Ingres un nombre");
            }

           
        }


        private void Agregar()
        {
            using (BancosBLL db=new BancosBLL())
            {
                try
                {
                    Banco banco = new Banco();
                    banco.nombre = txtnombre.Text;

                    if (db.Agregar(banco)>0)
                    {
                        MessageBox.Show("Banco registrado correctamente");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Modificar()
        {

            using (BancosBLL db = new BancosBLL())
            {
                try
                {
                    Banco banco = new Banco();
                    banco.idbanco = Convert.ToInt32(lblidbanco.Text);
                    banco.nombre = txtnombre.Text;

                    if (db.Editar(banco) > 0)
                    {
                        MessageBox.Show("Banco modificado correctamente");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); ;
                }
            }
            
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            txtnombre.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
