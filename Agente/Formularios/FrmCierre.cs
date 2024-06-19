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
using Microsoft.Reporting.WinForms;

namespace Agente.Formularios
{
    public partial class FrmCierre : Form
    {
        public FrmCierre()
        {
            InitializeComponent();
        }

        private void FrmCierre_Load(object sender, EventArgs e)
        {
            Saldocierre();
            Resumen();
            Operaciones();
          //  this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Saldocierre()
        {
            using (CajachicaBLL db=new CajachicaBLL())
            {
                try
                {

                    DataTable saldo = db.Saldocierre();

                    if (saldo.Rows.Count>0)
                    {
                        txtmontoapertura.Text =saldo.Rows[0][1].ToString();
                        txtmontocierre.Text = saldo.Rows[0][2].ToString();
                        txtsaldo.Text = saldo.Rows[0][3].ToString();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message) ;
                }
            }
        }


        private void Resumen()
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try
                {

                    DataTable resumen = db.Resumenpormediocierre();

                    if (resumen.Rows.Count > 0)
                    {
                        dtgmedios.DataSource = resumen;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Operaciones()
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try
                {

                    DataTable ope = db.Operacionescierre();

                    if (ope.Rows.Count > 0)
                    {
                        dtgope.DataSource = ope;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtobs_TextChanged(object sender, EventArgs e)
        {
            txtobs.CharacterCasing = CharacterCasing.Upper;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" ¿Esta seguro de realiar el cierre?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Cierre();
            }
        }

        private void Cierre()
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try
                {
                    Cajachica caja = new Cajachica();
                    caja.efectivo = Convert.ToDouble( txtsaldo.Text);
                    caja.observacion = txtobs.Text;

                    int cierrecaja = db.Cierre(caja);

                    if (cierrecaja>0)
                    {
                        MessageBox.Show("Cierre realizado ");

                        FrmMDI f1 = Application.OpenForms.OfType<FrmMDI>().SingleOrDefault();
                        f1.statusStrip1.BackColor = Color.Red;
                        f1.lblestado.Text = "Cerrado";
                        Imprimircierre(cierrecaja);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Imprimircierre(int idcaja)
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try
                {
                   

                    FrmImprimircierre cierre = new FrmImprimircierre();
                    ReportDataSource fuente = new ReportDataSource("DataSetCierre", db.Imprimircierre(idcaja));
                    cierre.reportViewer1.LocalReport.DataSources.Clear();
                    cierre.reportViewer1.LocalReport.DataSources.Add(fuente);
                    cierre.reportViewer1.LocalReport.ReportEmbeddedResource = "Agente.Reportes.RptCierre.rdlc";

                    cierre.reportViewer1.RefreshReport();
                    cierre.reportViewer1.LocalReport.Refresh();

                    cierre.ShowDialog();

                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
