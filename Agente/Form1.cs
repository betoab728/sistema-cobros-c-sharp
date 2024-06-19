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

namespace Agente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Listar()
        {
            using (CategoriaBLL db = new CategoriaBLL())
                dtgCat.DataSource = db.Listar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
