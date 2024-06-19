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
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            using (CategoriaBLL db=new CategoriaBLL())
            {
                try
                {
                    dtgcats.DataSource = db.Listar();
                    dtgcats.Columns["idcategoria"].Visible = false;
                    dtgcats.Columns["NOMBRE"].Width = 300;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegcat cat = new FrmRegcat();
            cat.accion = "agregar";
            cat.ShowDialog();

            Listar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmRegcat cat = new FrmRegcat();

            int idcat = Convert.ToInt32(dtgcats.CurrentRow.Cells["idcategoria"].Value);
            cat.lblidcat.Text = idcat.ToString();
            cat.accion = "modificar";
            cat.txtnombre.Text = dtgcats.CurrentRow.Cells["NOMBRE"].Value.ToString();
            cat.ShowDialog();

            Listar(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show(" ¿Esta seguro de anular la categoria?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (CategoriaBLL db = new CategoriaBLL())
                {
                    try
                    {
                        Categoria cat = new Categoria();
                        cat.idcategoria = Convert.ToInt32(dtgcats.CurrentRow.Cells["idcategoria"].Value);

                        if (db.Anular(cat) > 0)
                        {
                            MessageBox.Show("Categoria anulada");
                            Listar();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
