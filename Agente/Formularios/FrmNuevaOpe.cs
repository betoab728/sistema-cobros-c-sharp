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
    public partial class FrmNuevaOpe : Form
    {
        SoloNumeros validar = new SoloNumeros();
        public FrmNuevaOpe()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNuevaOpe_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            ListarBancos();
            ListarMedios();
        }

        private void ListarCategorias()
        {
            using (CategoriaBLL db=new CategoriaBLL())
            {
                try
                {

                    cmboperacion.ValueMember = "idcategoria";
                    cmboperacion.DisplayMember = "nombre";
                    cmboperacion.DataSource = db.Listar();

                    cmboperacion.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ListarMedios()
        {
            using (MediospagoBLL db = new MediospagoBLL())
            {
                try
                {
                    cmbmedio.ValueMember = "idmedio";
                    cmbmedio.DisplayMember = "nombre";

                    cmbmedio.DataSource = db.Listar();

                    cmbmedio.SelectedIndex = -1;
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ListarBancos()
        {
            using (BancosBLL db=new BancosBLL())
            {
                try
                {
                    cmbbanco.ValueMember = "idbanco";
                    cmbbanco.DisplayMember = "nombre";
                    cmbbanco.DataSource = db.Listar();
                    cmbbanco.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtmonto_Enter(object sender, EventArgs e)
        {
            txtmonto.SelectAll();
        }

        private void txtmonto_Click(object sender, EventArgs e)
        {
            txtmonto.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (dtpfecha.Checked==false)
            {
                MessageBox.Show("Indique la fecha");
                return;
            }

            if (txtmonto.Text.Length==0)
            {
                MessageBox.Show("Ingrese un monto");
                return;
            }
            if (cmbbanco.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione un banco");
                return;
            }

            if (cmbmedio.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un medio de pago");
                return;
            }

            if (optdeposito.Checked==false && optpago.Checked == false && optgiro.Checked == false)
            {
                MessageBox.Show("Seleccione un tipo de operacion");
                return;
            }

            DialogResult dialogResult = MessageBox.Show(" ¿Esta seguro de efectuar la operacion?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int idcategoria = Convert.ToInt32(cmboperacion.SelectedValue);

                if (!cmboperacion.Enabled)
                {
                    idcategoria = 29;
                }

                //21 universidad, 31 giro, 29 deposito , 30 pago tarjeta
                if (idcategoria==31) //
                {
                    Grabargiro();
                }

               else if (idcategoria == 29) //
                {
                    Grabardeposito();
                }

               else if (idcategoria == 30) //
                {
                    Grabarpagostarjeta();
                }
                else
                {
                    Grabarpagos();
                }


                this.Close();
            }




        }


        private void Grabar()
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    int tipo = 0; // 1 pago , 2deposito
                    int idcategoria = 0;

                    if (optpago.Checked)
                    {
                        tipo = 1;
                        idcategoria = Convert.ToInt32(cmboperacion.SelectedValue);
                    }

                    if (optdeposito.Checked)
                    {
                        tipo = 2;
                        idcategoria = 29;
                    }

                 
                    Operacion operacion = new Operacion();
                    operacion.numero_operacion = txtoperacion.Text;
                    operacion.cuenta_origen = txtcuentaorigen.Text;
                    operacion.cuenta_destino = txtcuentadestino.Text;
                    operacion.nombre_destino = txtnombredestino.Text;
                    operacion.monto = Convert.ToDouble(txtmonto.Text);
                    operacion.recibo = "Recibo \n "+txtrecibo.Text;
                    operacion.deuda = "Deuda \n " + txtdeuda.Text;
                    operacion.mora = "Mora \n " + txtmora.Text;
                    operacion.vcmto = "Vencimiento \n " + txtvcmto.Text;


                    operacion.idcategoria = idcategoria;
                    operacion.idbanco = Convert.ToInt32(cmbbanco.SelectedValue);
                    operacion.fecha = Convert.ToDateTime(dtpfecha.Value.ToString("yyyy-MM-dd"));
                    operacion.tipo = tipo;
                    operacion.idmedio = Convert.ToInt32(cmbmedio.SelectedValue);
                    operacion.descripcionpago = txtdescripcion.Text;

                    int idoperacion = db.Agregar(operacion);

                    if (idoperacion>0)
                    {
                        MessageBox.Show("Operacion registrada "+ idoperacion);

                        if (tipo==2)
                        {
                            Imprimir(idoperacion);
                            this.Close();
                        }
                        else
                        {
                            ImprimirPago(idoperacion);
                            this.Close();
                        }


                      

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void Imprimir(int idoperacion)
        {
            using (OperacionBLL db=new OperacionBLL())
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

        private void txtnombredestino_TextChanged(object sender, EventArgs e)
        {
            txtnombredestino.CharacterCasing = CharacterCasing.Upper;
        }

        private void optdeposito_CheckedChanged(object sender, EventArgs e)
        {
            cmboperacion.Enabled = false;

           // panelpago.Visible = false;
            paneldeposito.Visible = true;
            //deposito id 29


          

            panelpagos.Visible = false;
            paneldeposito.Visible = true;

            panelgiro.Visible = false;
            paneltarjeta.Visible = false;

        }

        private void optpago_CheckedChanged(object sender, EventArgs e)
        {
            cmboperacion.Enabled = true;

            panelpagos.Visible = true;
            paneldeposito.Visible = false;

            panelgiro.Visible = false;
            paneltarjeta.Visible = false;

        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {
            txtdescripcion.CharacterCasing = CharacterCasing.Upper;
        }

        private void optgiro_CheckedChanged(object sender, EventArgs e)
        {
            cmboperacion.Enabled = true;

            panelpagos.Visible = false;
            paneldeposito.Visible = false;

            panelgiro.Visible = true;
            paneltarjeta.Visible = false;

        }

        private void cmboperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoria = Convert.ToInt32(cmboperacion.SelectedValue);

            if (categoria == 30)
            {
                paneltarjeta.Visible = true;

                panelpagos.Visible = false;
                paneldeposito.Visible = false;

                panelgiro.Visible = false;
            }
        }

        private void Grabardeposito()
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    int idcategoria = Convert.ToInt32(cmboperacion.SelectedValue);

                    idcategoria = 29;

                    Operacion operacion = new Operacion();
                    operacion.numero_operacion = txtoperacion.Text;
                    operacion.cuenta_origen = txtcuentaorigen.Text;
                    operacion.cuenta_destino = txtcuentadestino.Text;
                    operacion.titular = txttitulardeposito.Text;
                    operacion.monto = Convert.ToDouble(txtmonto.Text);



                    operacion.idcategoria = idcategoria;
                    operacion.idbanco = Convert.ToInt32(cmbbanco.SelectedValue);
                    operacion.fecha = Convert.ToDateTime(dtpfecha.Value.ToString("yyyy-MM-dd"));
                  
                    operacion.idmedio = Convert.ToInt32(cmbmedio.SelectedValue);

                    operacion.recibo = txtrecibo.Text;
                    operacion.deuda = txtdeuda.Text;
                    operacion.mora = txtmora.Text;
                    operacion.vcmto = txtvcmto.Text;


                    int idoperacion = db.Agregardeposito(operacion);

                    if (idoperacion > 0)
                    {
                        MessageBox.Show("Operacion registrada " + idoperacion);


                        Imprimir(idoperacion);


                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("error deposito:"+ ex.Message);
                }
            }
        }

        private void Grabarpagos()
        {

            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    int idcategoria = Convert.ToInt32(cmboperacion.SelectedValue);

                    Operacion operacion = new Operacion();
                    operacion.numero_operacion = txtoperacion.Text;

                    operacion.monto = Convert.ToDouble(txtmonto.Text);



                    operacion.idcategoria = idcategoria;
                    operacion.idbanco = Convert.ToInt32(cmbbanco.SelectedValue);
                    operacion.fecha = Convert.ToDateTime(dtpfecha.Value.ToString("yyyy-MM-dd"));

                    operacion.idmedio = Convert.ToInt32(cmbmedio.SelectedValue);
                    operacion.pagosempresa = txtempresa.Text;
                    operacion.pagoscategoria = txtcategoria.Text;
                    operacion.pagosservicio = txtservicio.Text;
                    operacion.pagoscodigo = txtcodigo.Text;
                    operacion.titular = txttitularpago.Text;

                    operacion.recibo = txtrecibo.Text;
                    operacion.deuda = txtdeuda.Text;
                    operacion.mora = txtmora.Text;
                    operacion.vcmto = txtvcmto.Text;


                    int idoperacion = db.Agregarpagos(operacion);


                    if (idoperacion > 0)
                    {
                        MessageBox.Show("pago registrado ...3011" + idoperacion);

                        ImprimirPagos(idoperacion);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("error pagos:" + ex.Message);
                }
            }
        }

        private void Grabarpagostarjeta()
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    int idcategoria = Convert.ToInt32(cmboperacion.SelectedValue);

                    Operacion operacion = new Operacion();
                    operacion.numero_operacion = txtoperacion.Text;

                    operacion.monto = Convert.ToDouble(txtmonto.Text);



                    operacion.idcategoria = idcategoria;
                    operacion.idbanco = Convert.ToInt32(cmbbanco.SelectedValue);
                    operacion.fecha = Convert.ToDateTime(dtpfecha.Value.ToString("yyyy-MM-dd"));

                    operacion.idmedio = Convert.ToInt32(cmbmedio.SelectedValue);

                  
                    


                    operacion.tarjetacredito = txttarjeta.Text;
                    operacion.montotarjeta = Convert.ToDouble( txtmontotarjeta.Text);
                    operacion.tarjetadestino =txtdestino.Text;

                    operacion.titular = txttitular.Text;

                    operacion.recibo = txtrecibo.Text;
                    operacion.deuda = txtdeuda.Text;
                    operacion.mora = txtmora.Text;
                    operacion.vcmto = txtvcmto.Text;


                    int idoperacion = db.Agregarpagostarjeta(operacion);


                    if (idoperacion > 0)
                    {
                        MessageBox.Show("Operacion registrada " + idoperacion);
                        ImprimirPagostarjeta(idoperacion);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("error pagostarjeta:" + ex.Message);
                }
            }
        }
        private void Grabargiro()
        {

            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    int idcategoria = Convert.ToInt32(cmboperacion.SelectedValue);

                    Operacion operacion = new Operacion();
                    operacion.numero_operacion = txtoperacion.Text;

                    operacion.monto = Convert.ToDouble(txtmonto.Text);



                    operacion.idcategoria = idcategoria;
                    operacion.idbanco = Convert.ToInt32(cmbbanco.SelectedValue);
                    operacion.fecha = Convert.ToDateTime(dtpfecha.Value.ToString("yyyy-MM-dd"));

                    operacion.idmedio = Convert.ToInt32(cmbmedio.SelectedValue);


                    operacion.giromonto = Convert.ToDouble( txtmontogiro.Text);
                    operacion.girocomision = Convert.ToDouble( txtcomision.Text);
                    operacion.girodocumento = txtdocumento.Text;
               
                    operacion.girobeneficiario = txtbeneficiario.Text;
                    operacion.giroclave = txtclave.Text;

                    operacion.recibo = txtrecibo.Text;
                    operacion.deuda = txtdeuda.Text;
                    operacion.mora = txtmora.Text;
                    operacion.vcmto = txtvcmto.Text;


                    int idoperacion = db.Agregargiro(operacion);


                    if (idoperacion > 0)
                    {
                        MessageBox.Show("Operacion registrada " + idoperacion);

                        ImprimirGiros(idoperacion);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("error giros:" + ex.Message);
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

       

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmontogiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validar.Solonumeros(Convert.ToInt32(e.KeyChar), txtmontogiro);
        }

        private void txtcomision_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validar.Solonumeros(Convert.ToInt32(e.KeyChar), txtcomision);
        }

        private void txttitulardeposito_TextChanged(object sender, EventArgs e)
        {
            txttitulardeposito.CharacterCasing = CharacterCasing.Upper;
        }

        private void txttitular_TextChanged(object sender, EventArgs e)
        {
            txttitular.CharacterCasing = CharacterCasing.Upper;
        }

        private void txttitularpago_TextChanged(object sender, EventArgs e)
        {
            txttitularpago.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtempresa_TextChanged(object sender, EventArgs e)
        {
            txtempresa.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtcategoria_TextChanged(object sender, EventArgs e)
        {
            txtcategoria.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtservicio_TextChanged(object sender, EventArgs e)
        {
            txtservicio.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtmontotarjeta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmontotarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validar.Solonumeros(Convert.ToInt32(e.KeyChar), txtmontotarjeta);
        }

        private void txtbeneficiario_TextChanged(object sender, EventArgs e)
        {
            txtbeneficiario.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtcomision_Leave(object sender, EventArgs e)
        {
            Calcularmonto();
        }

        private void Calcularmonto()
        {
            if (txtmontogiro.Text.Length > 0)
            {
                if (txtcomision.Text.Length > 0)
                {
                    double monto = Convert.ToDouble(txtmontogiro.Text);
                    double comision = Convert.ToDouble(txtcomision.Text);

                    double total = monto + comision;
                    txtmonto.Text = string.Format("{0:0.00}", total); 

                }
            }
        }

        private void txtcomision_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmontogiro_Leave(object sender, EventArgs e)
        {
            Calcularmonto();
        }

        private void cmboperacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmboperacion.Text.Equals("UNIVERSIDAD"))

              {
                panelrecibo.Visible = true;

            }
        }
    }
}
