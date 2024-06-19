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
    public partial class FrmRegcat : Form
    {
        public string accion = "";
        public FrmRegcat()
        {
            InitializeComponent();
        }

        private void FrmRegcat_Load(object sender, EventArgs e)
        {

        }

        private void Agregar()
        {
            using (CategoriaBLL db = new CategoriaBLL())
            {
                try
                {
                    Categoria categoria = new Categoria();
                    categoria.nombre = txtnombre.Text;

                    if (db.Agregar(categoria) > 0)
                    {
                        MessageBox.Show("Categoria registrada correctamente");
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

            using (CategoriaBLL db = new CategoriaBLL())
            {
                try
                {
                    Categoria categoria = new Categoria();
                    categoria.idcategoria = Convert.ToInt32(lblidcat.Text);
                    categoria.nombre = txtnombre.Text;

                    if (db.Editar(categoria) > 0)
                    {
                        MessageBox.Show("Categotia modificada correctamente");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); ;
                }
            }

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

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            txtnombre.CharacterCasing = CharacterCasing.Upper;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
