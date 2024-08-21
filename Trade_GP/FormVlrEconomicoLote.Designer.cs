
namespace Trade_GP
{
    partial class FormVlrEconomicoLotes
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.btParametros = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.dbLocais = new System.Windows.Forms.DataGridView();
            this.lblCancelamentoAtivado = new System.Windows.Forms.Label();
            this.dbMeses = new System.Windows.Forms.DataGridView();
            this.lblMeses = new System.Windows.Forms.Label();
            this.lblTarefas = new System.Windows.Forms.Label();
            this.dtGridLog = new System.Windows.Forms.DataGridView();
            this.gbMensaProcessamento = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelic = new System.Windows.Forms.ComboBox();
            this.lblTipoProc = new System.Windows.Forms.Label();
            this.cbTipoProcessamento = new System.Windows.Forms.ComboBox();
            this.lblLocalPeriodo = new System.Windows.Forms.Label();
            this.lblProcesso = new System.Windows.Forms.Label();
            this.pgProcesso = new System.Windows.Forms.ProgressBar();
            this.btProcessar = new System.Windows.Forms.Button();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).BeginInit();
            this.gbMensaProcessamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(-3, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1530, 23);
            this.lblTitulo.TabIndex = 62;
            this.lblTitulo.Text = "Cálculo Do Valor Ecômico Por Lote";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // gbParametros
            // 
            this.gbParametros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbParametros.Controls.Add(this.btParametros);
            this.gbParametros.Controls.Add(this.btProximo);
            this.gbParametros.Location = new System.Drawing.Point(0, 55);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Size = new System.Drawing.Size(215, 162);
            this.gbParametros.TabIndex = 63;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Perâmetros";
            // 
            // btParametros
            // 
            this.btParametros.BackColor = System.Drawing.Color.Red;
            this.btParametros.Location = new System.Drawing.Point(15, 35);
            this.btParametros.Name = "btParametros";
            this.btParametros.Size = new System.Drawing.Size(145, 23);
            this.btParametros.TabIndex = 7;
            this.btParametros.Text = "PARÂMETROS";
            this.btParametros.UseVisualStyleBackColor = false;
            this.btParametros.Click += new System.EventHandler(this.btParametros_Click);
            // 
            // btProximo
            // 
            this.btProximo.ForeColor = System.Drawing.Color.Green;
            this.btProximo.Location = new System.Drawing.Point(108, 84);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(100, 23);
            this.btProximo.TabIndex = 6;
            this.btProximo.Text = "Próximo";
            this.btProximo.UseVisualStyleBackColor = true;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // dbLocais
            // 
            this.dbLocais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbLocais.Location = new System.Drawing.Point(221, 55);
            this.dbLocais.Name = "dbLocais";
            this.dbLocais.Size = new System.Drawing.Size(706, 162);
            this.dbLocais.TabIndex = 64;
            // 
            // lblCancelamentoAtivado
            // 
            this.lblCancelamentoAtivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelamentoAtivado.ForeColor = System.Drawing.Color.Red;
            this.lblCancelamentoAtivado.Location = new System.Drawing.Point(12, 235);
            this.lblCancelamentoAtivado.Name = "lblCancelamentoAtivado";
            this.lblCancelamentoAtivado.Size = new System.Drawing.Size(1337, 23);
            this.lblCancelamentoAtivado.TabIndex = 66;
            this.lblCancelamentoAtivado.Text = "CANCELAMENTO SOLICITADO!";
            this.lblCancelamentoAtivado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancelamentoAtivado.Click += new System.EventHandler(this.lblCancelamentoAtivado_Click);
            // 
            // dbMeses
            // 
            this.dbMeses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dbMeses.CausesValidation = false;
            this.dbMeses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbMeses.Location = new System.Drawing.Point(12, 288);
            this.dbMeses.Name = "dbMeses";
            this.dbMeses.Size = new System.Drawing.Size(492, 376);
            this.dbMeses.TabIndex = 68;
            // 
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Location = new System.Drawing.Point(12, 272);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(38, 13);
            this.lblMeses.TabIndex = 67;
            this.lblMeses.Text = "Meses";
            // 
            // lblTarefas
            // 
            this.lblTarefas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTarefas.AutoSize = true;
            this.lblTarefas.Location = new System.Drawing.Point(530, 272);
            this.lblTarefas.Name = "lblTarefas";
            this.lblTarefas.Size = new System.Drawing.Size(33, 13);
            this.lblTarefas.TabIndex = 70;
            this.lblTarefas.Text = "Lotes";
            // 
            // dtGridLog
            // 
            this.dtGridLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridLog.CausesValidation = false;
            this.dtGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridLog.Location = new System.Drawing.Point(533, 288);
            this.dtGridLog.Name = "dtGridLog";
            this.dtGridLog.Size = new System.Drawing.Size(834, 376);
            this.dtGridLog.TabIndex = 69;
            // 
            // gbMensaProcessamento
            // 
            this.gbMensaProcessamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaProcessamento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbMensaProcessamento.Controls.Add(this.label1);
            this.gbMensaProcessamento.Controls.Add(this.cbSelic);
            this.gbMensaProcessamento.Controls.Add(this.lblTipoProc);
            this.gbMensaProcessamento.Controls.Add(this.cbTipoProcessamento);
            this.gbMensaProcessamento.Controls.Add(this.lblLocalPeriodo);
            this.gbMensaProcessamento.Controls.Add(this.lblProcesso);
            this.gbMensaProcessamento.Controls.Add(this.pgProcesso);
            this.gbMensaProcessamento.Controls.Add(this.btProcessar);
            this.gbMensaProcessamento.Location = new System.Drawing.Point(933, 55);
            this.gbMensaProcessamento.Name = "gbMensaProcessamento";
            this.gbMensaProcessamento.Size = new System.Drawing.Size(425, 162);
            this.gbMensaProcessamento.TabIndex = 71;
            this.gbMensaProcessamento.TabStop = false;
            this.gbMensaProcessamento.Text = "Atenção";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selic";
            // 
            // cbSelic
            // 
            this.cbSelic.FormattingEnabled = true;
            this.cbSelic.Items.AddRange(new object[] {
            "06/2024",
            "07/2024",
            "08/2024",
            "09/2024",
            "10/2024"});
            this.cbSelic.Location = new System.Drawing.Point(190, 97);
            this.cbSelic.Name = "cbSelic";
            this.cbSelic.Size = new System.Drawing.Size(164, 21);
            this.cbSelic.TabIndex = 6;
            // 
            // lblTipoProc
            // 
            this.lblTipoProc.AutoSize = true;
            this.lblTipoProc.Location = new System.Drawing.Point(6, 78);
            this.lblTipoProc.Name = "lblTipoProc";
            this.lblTipoProc.Size = new System.Drawing.Size(104, 13);
            this.lblTipoProc.TabIndex = 5;
            this.lblTipoProc.Text = "Tipo Processamento";
            // 
            // cbTipoProcessamento
            // 
            this.cbTipoProcessamento.FormattingEnabled = true;
            this.cbTipoProcessamento.Items.AddRange(new object[] {
            "1-NORMAL",
            "2-CORREÇÃO",
            "3-ATUALIZAÇÃO"});
            this.cbTipoProcessamento.Location = new System.Drawing.Point(9, 95);
            this.cbTipoProcessamento.Name = "cbTipoProcessamento";
            this.cbTipoProcessamento.Size = new System.Drawing.Size(164, 21);
            this.cbTipoProcessamento.TabIndex = 4;
            // 
            // lblLocalPeriodo
            // 
            this.lblLocalPeriodo.AutoSize = true;
            this.lblLocalPeriodo.Location = new System.Drawing.Point(6, 129);
            this.lblLocalPeriodo.Name = "lblLocalPeriodo";
            this.lblLocalPeriodo.Size = new System.Drawing.Size(35, 13);
            this.lblLocalPeriodo.TabIndex = 3;
            this.lblLocalPeriodo.Text = "label2";
            // 
            // lblProcesso
            // 
            this.lblProcesso.AutoSize = true;
            this.lblProcesso.Location = new System.Drawing.Point(6, 27);
            this.lblProcesso.Name = "lblProcesso";
            this.lblProcesso.Size = new System.Drawing.Size(93, 13);
            this.lblProcesso.TabIndex = 2;
            this.lblProcesso.Text = "Acompanhamento";
            // 
            // pgProcesso
            // 
            this.pgProcesso.Location = new System.Drawing.Point(6, 43);
            this.pgProcesso.Name = "pgProcesso";
            this.pgProcesso.Size = new System.Drawing.Size(410, 23);
            this.pgProcesso.TabIndex = 1;
            // 
            // btProcessar
            // 
            this.btProcessar.Location = new System.Drawing.Point(190, 129);
            this.btProcessar.Name = "btProcessar";
            this.btProcessar.Size = new System.Drawing.Size(226, 23);
            this.btProcessar.TabIndex = 0;
            this.btProcessar.Tag = "0";
            this.btProcessar.Text = "Processamento";
            this.btProcessar.UseVisualStyleBackColor = true;
            this.btProcessar.Click += new System.EventHandler(this.btProcessar_Click);
            // 
            // FormVlrEconomicoLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 666);
            this.Controls.Add(this.gbMensaProcessamento);
            this.Controls.Add(this.lblTarefas);
            this.Controls.Add(this.dtGridLog);
            this.Controls.Add(this.dbMeses);
            this.Controls.Add(this.lblMeses);
            this.Controls.Add(this.lblCancelamentoAtivado);
            this.Controls.Add(this.dbLocais);
            this.Controls.Add(this.gbParametros);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormVlrEconomicoLotes";
            this.Text = "Calculo Valor Econômico Por Lote";
            this.Activated += new System.EventHandler(this.FormVlrEconomicoLotes_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVlrEconomicoLotes_FormClosed);
            this.Load += new System.EventHandler(this.FormVlrEconomicoLotes_Load);
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbLocais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridLog)).EndInit();
            this.gbMensaProcessamento.ResumeLayout(false);
            this.gbMensaProcessamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.Button btParametros;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.DataGridView dbLocais;
        private System.Windows.Forms.Label lblCancelamentoAtivado;
        private System.Windows.Forms.DataGridView dbMeses;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.Label lblTarefas;
        private System.Windows.Forms.DataGridView dtGridLog;
        private System.Windows.Forms.GroupBox gbMensaProcessamento;
        private System.Windows.Forms.Label lblTipoProc;
        private System.Windows.Forms.ComboBox cbTipoProcessamento;
        private System.Windows.Forms.Label lblLocalPeriodo;
        private System.Windows.Forms.Label lblProcesso;
        private System.Windows.Forms.ProgressBar pgProcesso;
        private System.Windows.Forms.Button btProcessar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSelic;
    }
}