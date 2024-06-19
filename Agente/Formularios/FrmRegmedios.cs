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
    public partial class FrmRegmedios : Form
    {
        public string accion = "";
        public FrmRegmedios()
        {
            InitializeComponent();
        }

        private void FrmRegmedios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" ¿Esta seguro de efectuar la operacion?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (txtnombre.Text.Length > 0)
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


           

        }

        private void Agregar()
        {
            using (MediospagoBLL db=new MediospagoBLL())
            {
                try
                {
                    Mediospago mediospago = new Mediospago();
                    mediospago.nombre = txtnombre.Text;

                    if (db.Agregar(mediospago) >0)
                    {
                        MessageBox.Show("Medio de pago registrado correctamente");
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

            using (MediospagoBLL db = new MediospagoBLL())
            {
                try
                {
                    Mediospago mediospago = new Mediospago();
                    mediospago.idmedio = Convert.ToInt32(lblidmedio.Text);
                    mediospago.nombre = txtnombre.Text;

                    if (db.Editar(mediospago) > 0)
                    {
                        MessageBox.Show("Medio de pago modificado correctamente");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); ;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            txtnombre.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
