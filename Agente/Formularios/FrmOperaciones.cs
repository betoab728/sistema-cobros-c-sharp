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
    public partial class FrmOperaciones : Form
    {
        public FrmOperaciones()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void optcierre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbcriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcriterio.SelectedIndex==0)
            {
                dtpfecha.Visible = false;
                txtbuscar.Visible = false;
            }
            else if (cmbcriterio.SelectedIndex == 1)
            {
                dtpfecha.Visible = true;
                txtbuscar.Visible = false;
            }
            else if (cmbcriterio.SelectedIndex == 2)
            {
                dtpfecha.Visible = false;
                txtbuscar.Visible = true;
            }

            else if (cmbcriterio.SelectedIndex == 3)
            {
                dtpfecha.Visible = false;
                txtbuscar.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


            DialogResult dialogResult = MessageBox.Show(" ¿Esta seguro de anular la operacion?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                using (OperacionBLL db = new OperacionBLL())
                {
                    try
                    {
                        Operacion operacion = new Operacion();
                        operacion.idoperacion = Convert.ToInt32(dtgope.CurrentRow.Cells["idoperacion"].Value);

                        if (db.Anular(operacion) > 0)
                        {
                            MessageBox.Show("operacion anulada");
                            Buscar(); 
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();
                    int tipo = 0;

                    if (cmbcriterio.SelectedIndex == 0) tipo = 1;
                    if (cmbcriterio.SelectedIndex == 1) tipo = 2;
                    if (cmbcriterio.SelectedIndex == 2) tipo = 3;
                    if (cmbcriterio.SelectedIndex == 3) tipo = 4;

                    operacion.fecha = Convert.ToDateTime(dtpfecha.Value.ToString("yyyy-MM-dd"));
                    operacion.numero_operacion = txtbuscar.Text;
                    operacion.nombre_destino = txtbuscar.Text;

                    if (txtbuscar.Visible)
                    {
                        MessageBox.Show("Ingrese un texto a buscar");
                    }

                    DataTable buscar = db.Buscar(operacion, tipo);

                    dtgope.DataSource = buscar;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FrmOperaciones_Load(object sender, EventArgs e)
        {
            cmbcriterio.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dtgope.Rows.Count > 0)
            {
                DatagridAexcel exportar = new DatagridAexcel();

                exportar.ExportarDataGridViewExcel(dtgope);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmNuevaOpe ope = new FrmNuevaOpe();
            ope.MdiParent = this.MdiParent;
            ope.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int idope = Convert.ToInt32(dtgope.CurrentRow.Cells["idoperacion"].Value);
            
            int idcategoria = Convert.ToInt32(dtgope.CurrentRow.Cells["idcategoria"].Value); ;

            if (idope > 0)
            {
                //21 universidad, 31 giro, 29 deposito , 30 pago tarjeta
                if (idcategoria==31)
                {
                    ImprimirGiros(idope);
                }

                else if (idcategoria == 29)
                {
                    Imprimir(idope);
                }

               else if (idcategoria == 30)
                {
                    ImprimirPagostarjeta(idope);
                }

                else
                {
                    ImprimirPagos(idope);
                }

            }
        }

        private void Imprimir(int idoperacion)
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();
                    operacion.idoperacion = idoperacion;

                    FrmTicket ticket = new FrmTicket();
                    ReportDataSource fuente = new ReportDataSource("DataSetTicket", db.Imprimir(operacion));
                    ticket.reportViewer1.LocalReport.DataSources.Clear();
                    ticket.reportViewer1.LocalReport.DataSources.Add(fuente);
                    ticket.reportViewer1.LocalReport.ReportEmbeddedResource = "Agente.Reportes.RptTicket.rdlc";

                    ticket.reportViewer1.RefreshReport();
                    ticket.reportViewer1.LocalReport.Refresh();

                    ticket.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ImprimirPagos(int ope)
        {

            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();
                    operacion.idoperacion = ope;


                    FrmTicket ticket = new FrmTicket();
                    ReportDataSource fuente = new ReportDataSource("DataSetpagos", db.ImprimirPagos(operacion));
                    ticket.reportViewer1.LocalReport.DataSources.Clear();
                    ticket.reportViewer1.LocalReport.DataSources.Add(fuente);
                    ticket.reportViewer1.LocalReport.ReportEmbeddedResource = "Agente.Reportes.RptPagos.rdlc";

                    ticket.reportViewer1.RefreshReport();
                    ticket.reportViewer1.LocalReport.Refresh();

                    ticket.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void ImprimirGiros(int ope)
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();
                    operacion.idoperacion = ope;

                    FrmTicket ticket = new FrmTicket();
                    ReportDataSource fuente = new ReportDataSource("DataSetgiros", db.ImprimirGiros(operacion));
                    ticket.reportViewer1.LocalReport.DataSources.Clear();
                    ticket.reportViewer1.LocalReport.DataSources.Add(fuente);
                    ticket.reportViewer1.LocalReport.ReportEmbeddedResource = "Agente.Reportes.Rptgiros.rdlc";

                    ticket.reportViewer1.RefreshReport();
                    ticket.reportViewer1.LocalReport.Refresh();

                    ticket.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ImprimirPagostarjeta(int ope)
        {


            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();
                    operacion.idoperacion = ope;

                    FrmTicket ticket = new FrmTicket();
                    ReportDataSource fuente = new ReportDataSource("DataSetpagotarjeta", db.ImprimirPagostarjeta(operacion));
                    ticket.reportViewer1.LocalReport.DataSources.Clear();
                    ticket.reportViewer1.LocalReport.DataSources.Add(fuente);
                    ticket.reportViewer1.LocalReport.ReportEmbeddedResource = "Agente.Reportes.Rptpagotarjeta.rdlc";

                    ticket.reportViewer1.RefreshReport();
                    ticket.reportViewer1.LocalReport.Refresh();

                    ticket.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void ImprimirPago(int idoperacion)
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();
                    operacion.idoperacion = idoperacion;

                    FrmTicket ticket = new FrmTicket();
                    ReportDataSource fuente = new ReportDataSource("DataSetPago", db.ImprimirPago(operacion));
                    ticket.reportViewer1.LocalReport.DataSources.Clear();
                    ticket.reportViewer1.LocalReport.DataSources.Add(fuente);
                    ticket.reportViewer1.LocalReport.ReportEmbeddedResource = "Agente.Reportes.RptPago.rdlc";

                    ticket.reportViewer1.RefreshReport();
                    ticket.reportViewer1.LocalReport.Refresh();

                    ticket.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
