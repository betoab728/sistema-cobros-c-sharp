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

    public partial class frmRegcajero : Form
    {
        public string accion = "";

        public frmRegcajero()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegcajero_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Length > 0 && txtclave.Text.Length>0 && txtdni.Text.Length > 0)
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
                MessageBox.Show("Ingrese todos los datos");
            }

        }

        private void Agregar()
        {
            using (CajeroBLL db = new CajeroBLL())
            {
                try
                {
                    Cajero cajero = new Cajero();
                    cajero.nombre = txtnombre.Text;
                    cajero.dni = txtdni.Text;
                    cajero.contraseña = txtclave.Text;

                    if (db.Agregar(cajero) > 0)
                    {
                        MessageBox.Show("Cajero registrado correctamente");
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

            using (CajeroBLL db = new CajeroBLL())
            {
                try
                {
                    Cajero cajero = new Cajero();

                    cajero.idcajero = Convert.ToInt32(lblidcajero.Text);
                    cajero.nombre = txtnombre.Text;
                    cajero.dni = txtdni.Text;
                    cajero.contraseña = txtclave.Text;

                    if (db.Editar(cajero) > 0)
                    {
                        MessageBox.Show("Cajero modificado correctamente");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); ;
                }
            }

        }
    }
}
