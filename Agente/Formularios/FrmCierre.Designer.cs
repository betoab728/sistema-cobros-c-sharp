namespace Agente.Formularios
{
    partial class FrmCierre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtobs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmontoapertura = new System.Windows.Forms.TextBox();
            this.txtmontocierre = new System.Windows.Forms.TextBox();
            this.dtgope = new System.Windows.Forms.DataGridView();
            this.dtgmedios = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsaldo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgmedios)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::Agente.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(400, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "Salir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Agente.Properties.Resources.cut_edit_scissors_icon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(293, 469);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cerrar caja";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Observaciones";
            // 
            // txtobs
            // 
            this.txtobs.Location = new System.Drawing.Point(110, 443);
            this.txtobs.Name = "txtobs";
            this.txtobs.Size = new System.Drawing.Size(387, 20);
            this.txtobs.TabIndex = 5;
            this.txtobs.TextChanged += new System.EventHandler(this.txtobs_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Efectivo apertura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Efectivo cierre";
            // 
            // txtmontoapertura
            // 
            this.txtmontoapertura.Location = new System.Drawing.Point(371, 341);
            this.txtmontoapertura.Name = "txtmontoapertura";
            this.txtmontoapertura.ReadOnly = true;
            this.txtmontoapertura.Size = new System.Drawing.Size(100, 20);
            this.txtmontoapertura.TabIndex = 8;
            this.txtmontoapertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmontocierre
            // 
            this.txtmontocierre.Location = new System.Drawing.Point(371, 367);
            this.txtmontocierre.Name = "txtmontocierre";
            this.txtmontocierre.ReadOnly = true;
            this.txtmontocierre.Size = new System.Drawing.Size(100, 20);
            this.txtmontocierre.TabIndex = 9;
            this.txtmontocierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgope
            // 
            this.dtgope.AllowUserToAddRows = false;
            this.dtgope.AllowUserToDeleteRows = false;
            this.dtgope.BackgroundColor = System.Drawing.Color.White;
            this.dtgope.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgope.Location = new System.Drawing.Point(15, 28);
            this.dtgope.Name = "dtgope";
            this.dtgope.ReadOnly = true;
            this.dtgope.Size = new System.Drawing.Size(482, 257);
            this.dtgope.TabIndex = 10;
            // 
            // dtgmedios
            // 
            this.dtgmedios.AllowUserToAddRows = false;
            this.dtgmedios.AllowUserToDeleteRows = false;
            this.dtgmedios.BackgroundColor = System.Drawing.Color.White;
            this.dtgmedios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgmedios.Location = new System.Drawing.Point(15, 304);
            this.dtgmedios.Name = "dtgmedios";
            this.dtgmedios.ReadOnly = true;
            this.dtgmedios.Size = new System.Drawing.Size(237, 133);
            this.dtgmedios.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "RESUMEN POR MEDIO DE PAGO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Saldo";
            // 
            // txtsaldo
            // 
            this.txtsaldo.Location = new System.Drawing.Point(371, 393);
            this.txtsaldo.Name = "txtsaldo";
            this.txtsaldo.ReadOnly = true;
            this.txtsaldo.Size = new System.Drawing.Size(100, 20);
            this.txtsaldo.TabIndex = 14;
            this.txtsaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(388, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "EFECTIVO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(227, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "OPERACIONES";
            // 
            // FrmCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 514);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtsaldo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtgmedios);
            this.Controls.Add(this.dtgope);
            this.Controls.Add(this.txtmontocierre);
            this.Controls.Add(this.txtmontoapertura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtobs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCierre";
            this.Load += new System.EventHandler(this.FrmCierre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgmedios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtobs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmontoapertura;
        private System.Windows.Forms.TextBox txtmontocierre;
        private System.Windows.Forms.DataGridView dtgope;
        private System.Windows.Forms.DataGridView dtgmedios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsaldo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}