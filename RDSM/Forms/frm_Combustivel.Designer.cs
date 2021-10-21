
namespace RDSM.Forms
{
    partial class frm_Combustivel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Combustivel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dtGridDados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.dtPDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPosto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoComb = new System.Windows.Forms.ComboBox();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoGasolina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorDiario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LitrosTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LitrosDiarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnImportar);
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::RDSM.Properties.Resources.sair;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(893, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 32);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.Image = global::RDSM.Properties.Resources.Processar;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportar.Location = new System.Drawing.Point(26, 3);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(81, 32);
            this.btnImportar.TabIndex = 1;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Image = global::RDSM.Properties.Resources.pesquisar;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(113, 3);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(84, 32);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dtGridDados
            // 
            this.dtGridDados.AllowUserToAddRows = false;
            this.dtGridDados.AllowUserToDeleteRows = false;
            this.dtGridDados.AllowUserToOrderColumns = true;
            this.dtGridDados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtGridDados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGridDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGridDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Posto,
            this.TipoGasolina,
            this.PUn,
            this.ValorTotal,
            this.ValorDiario,
            this.LitrosTotal,
            this.LitrosDiarios});
            this.dtGridDados.GridColor = System.Drawing.Color.Gainsboro;
            this.dtGridDados.Location = new System.Drawing.Point(12, 127);
            this.dtGridDados.Name = "dtGridDados";
            this.dtGridDados.Size = new System.Drawing.Size(962, 257);
            this.dtGridDados.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de Combustível";
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataInicial.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(24, 76);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(102, 20);
            this.dtpDataInicial.TabIndex = 6;
            this.dtpDataInicial.UseWaitCursor = true;
            // 
            // dtPDataFinal
            // 
            this.dtPDataFinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtPDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPDataFinal.Location = new System.Drawing.Point(161, 76);
            this.dtPDataFinal.Name = "dtPDataFinal";
            this.dtPDataFinal.Size = new System.Drawing.Size(106, 20);
            this.dtPDataFinal.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data Inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data Final";
            // 
            // txtPosto
            // 
            this.txtPosto.Location = new System.Drawing.Point(329, 76);
            this.txtPosto.Name = "txtPosto";
            this.txtPosto.Size = new System.Drawing.Size(160, 20);
            this.txtPosto.TabIndex = 9;
            this.txtPosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPosto.Enter += new System.EventHandler(this.txtPosto_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Posto de abastecimento";
            // 
            // cmbTipoComb
            // 
            this.cmbTipoComb.FormattingEnabled = true;
            this.cmbTipoComb.Location = new System.Drawing.Point(541, 74);
            this.cmbTipoComb.Name = "cmbTipoComb";
            this.cmbTipoComb.Size = new System.Drawing.Size(433, 21);
            this.cmbTipoComb.TabIndex = 11;
            this.cmbTipoComb.SelectedIndexChanged += new System.EventHandler(this.cmbTipoComb_SelectedIndexChanged);
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.Width = 62;
            // 
            // Posto
            // 
            this.Posto.HeaderText = "Posto";
            this.Posto.Name = "Posto";
            this.Posto.Width = 68;
            // 
            // TipoGasolina
            // 
            this.TipoGasolina.HeaderText = "Tipo de Gasolina";
            this.TipoGasolina.Name = "TipoGasolina";
            this.TipoGasolina.Width = 125;
            // 
            // PUn
            // 
            this.PUn.HeaderText = "P/Un. (€)";
            this.PUn.Name = "PUn";
            this.PUn.Width = 78;
            // 
            // ValorTotal
            // 
            this.ValorTotal.HeaderText = "Valor Total (€)";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.Width = 94;
            // 
            // ValorDiario
            // 
            this.ValorDiario.HeaderText = "Valor Diário (€)";
            this.ValorDiario.Name = "ValorDiario";
            this.ValorDiario.Width = 98;
            // 
            // LitrosTotal
            // 
            this.LitrosTotal.HeaderText = "Litros Total";
            this.LitrosTotal.Name = "LitrosTotal";
            this.LitrosTotal.Width = 91;
            // 
            // LitrosDiarios
            // 
            this.LitrosDiarios.HeaderText = "Litros Diários (L)";
            this.LitrosDiarios.Name = "LitrosDiarios";
            this.LitrosDiarios.Width = 105;
            // 
            // frm_Combustivel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(982, 396);
            this.Controls.Add(this.cmbTipoComb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPosto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtPDataFinal);
            this.Controls.Add(this.dtpDataInicial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGridDados);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Combustivel";
            this.ShowInTaskbar = false;
            this.Text = "  Valores Combustível";
            this.Load += new System.EventHandler(this.frm_Combustivel_Load);
            this.Enter += new System.EventHandler(this.frm_Combustivel_Enter);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.DataGridView dtGridDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPesquisar;
        public System.Windows.Forms.DateTimePicker dtpDataInicial;
        public System.Windows.Forms.DateTimePicker dtPDataFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPosto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoComb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoGasolina;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorDiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn LitrosTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn LitrosDiarios;
    }
}