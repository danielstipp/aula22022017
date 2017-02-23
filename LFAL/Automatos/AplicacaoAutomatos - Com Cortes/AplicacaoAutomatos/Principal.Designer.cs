namespace AplicacaoAutomatos
{
    partial class Principal
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
            this.txtValidar = new System.Windows.Forms.TextBox();
            this.pnlAutomato = new System.Windows.Forms.Panel();
            this.btnAfd = new System.Windows.Forms.Button();
            this.addEstado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxOrigem = new System.Windows.Forms.ComboBox();
            this.cboxDestino = new System.Windows.Forms.ComboBox();
            this.addTrans = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEstados = new System.Windows.Forms.Label();
            this.lblTrans = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddEstadoF = new System.Windows.Forms.Button();
            this.btnLimpa = new System.Windows.Forms.Button();
            this.lblgrafo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPronto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.btn_closing = new System.Windows.Forms.Button();
            this.txtExpress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCriaAutom = new System.Windows.Forms.Button();
            this.gridTable = new System.Windows.Forms.DataGridView();
            this.btnFillTable = new System.Windows.Forms.Button();
            this.txtdfaedge = new System.Windows.Forms.TextBox();
            this.txtdependencia = new System.Windows.Forms.TextBox();
            this.pnlMini = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValidar
            // 
            this.txtValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidar.Location = new System.Drawing.Point(12, 12);
            this.txtValidar.Name = "txtValidar";
            this.txtValidar.Size = new System.Drawing.Size(681, 38);
            this.txtValidar.TabIndex = 0;
            this.txtValidar.TextChanged += new System.EventHandler(this.txtValidar_TextChanged);
            // 
            // pnlAutomato
            // 
            this.pnlAutomato.Location = new System.Drawing.Point(12, 56);
            this.pnlAutomato.Name = "pnlAutomato";
            this.pnlAutomato.Size = new System.Drawing.Size(681, 435);
            this.pnlAutomato.TabIndex = 1;
            // 
            // btnAfd
            // 
            this.btnAfd.Location = new System.Drawing.Point(708, 59);
            this.btnAfd.Name = "btnAfd";
            this.btnAfd.Size = new System.Drawing.Size(140, 38);
            this.btnAfd.TabIndex = 2;
            this.btnAfd.Text = "Converter AFD";
            this.btnAfd.UseVisualStyleBackColor = true;
            this.btnAfd.Click += new System.EventHandler(this.btnAfd_Click);
            // 
            // addEstado
            // 
            this.addEstado.Location = new System.Drawing.Point(708, 156);
            this.addEstado.Name = "addEstado";
            this.addEstado.Size = new System.Drawing.Size(140, 23);
            this.addEstado.TabIndex = 4;
            this.addEstado.Text = "Adicionar Estado";
            this.addEstado.UseVisualStyleBackColor = true;
            this.addEstado.Click += new System.EventHandler(this.addEstado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(705, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Origem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(778, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Destino";
            // 
            // cboxOrigem
            // 
            this.cboxOrigem.FormattingEnabled = true;
            this.cboxOrigem.Location = new System.Drawing.Point(708, 236);
            this.cboxOrigem.Name = "cboxOrigem";
            this.cboxOrigem.Size = new System.Drawing.Size(67, 21);
            this.cboxOrigem.TabIndex = 9;
            // 
            // cboxDestino
            // 
            this.cboxDestino.FormattingEnabled = true;
            this.cboxDestino.Location = new System.Drawing.Point(781, 236);
            this.cboxDestino.Name = "cboxDestino";
            this.cboxDestino.Size = new System.Drawing.Size(67, 21);
            this.cboxDestino.TabIndex = 10;
            // 
            // addTrans
            // 
            this.addTrans.Location = new System.Drawing.Point(708, 307);
            this.addTrans.Name = "addTrans";
            this.addTrans.Size = new System.Drawing.Size(140, 23);
            this.addTrans.TabIndex = 11;
            this.addTrans.Text = "Adicionar Transição";
            this.addTrans.UseVisualStyleBackColor = true;
            this.addTrans.Click += new System.EventHandler(this.addTrans_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(708, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(711, 281);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(708, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Número de Estados: ";
            // 
            // lblEstados
            // 
            this.lblEstados.AutoSize = true;
            this.lblEstados.Location = new System.Drawing.Point(830, 356);
            this.lblEstados.Name = "lblEstados";
            this.lblEstados.Size = new System.Drawing.Size(13, 13);
            this.lblEstados.TabIndex = 15;
            this.lblEstados.Text = "0";
            // 
            // lblTrans
            // 
            this.lblTrans.AutoSize = true;
            this.lblTrans.Location = new System.Drawing.Point(830, 379);
            this.lblTrans.Name = "lblTrans";
            this.lblTrans.Size = new System.Drawing.Size(13, 13);
            this.lblTrans.TabIndex = 17;
            this.lblTrans.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(708, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Número de Transições: ";
            // 
            // btnAddEstadoF
            // 
            this.btnAddEstadoF.Location = new System.Drawing.Point(708, 185);
            this.btnAddEstadoF.Name = "btnAddEstadoF";
            this.btnAddEstadoF.Size = new System.Drawing.Size(140, 23);
            this.btnAddEstadoF.TabIndex = 18;
            this.btnAddEstadoF.Text = "Adicionar Estado Final";
            this.btnAddEstadoF.UseVisualStyleBackColor = true;
            this.btnAddEstadoF.Click += new System.EventHandler(this.btnAddEstadoF_Click);
            // 
            // btnLimpa
            // 
            this.btnLimpa.Location = new System.Drawing.Point(708, 420);
            this.btnLimpa.Name = "btnLimpa";
            this.btnLimpa.Size = new System.Drawing.Size(140, 23);
            this.btnLimpa.TabIndex = 19;
            this.btnLimpa.Text = "Limpa Tela";
            this.btnLimpa.UseVisualStyleBackColor = true;
            this.btnLimpa.Click += new System.EventHandler(this.btnLimpa_Click);
            // 
            // lblgrafo
            // 
            this.lblgrafo.AutoSize = true;
            this.lblgrafo.Location = new System.Drawing.Point(757, 30);
            this.lblgrafo.Name = "lblgrafo";
            this.lblgrafo.Size = new System.Drawing.Size(0, 13);
            this.lblgrafo.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(708, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Grafo: ";
            // 
            // cmbPronto
            // 
            this.cmbPronto.FormattingEnabled = true;
            this.cmbPronto.Location = new System.Drawing.Point(708, 470);
            this.cmbPronto.Name = "cmbPronto";
            this.cmbPronto.Size = new System.Drawing.Size(67, 21);
            this.cmbPronto.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(708, 454);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Automato Pronto";
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(781, 470);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(67, 23);
            this.btnGerar.TabIndex = 24;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btn_closing
            // 
            this.btn_closing.Location = new System.Drawing.Point(708, 103);
            this.btn_closing.Name = "btn_closing";
            this.btn_closing.Size = new System.Drawing.Size(140, 38);
            this.btn_closing.TabIndex = 25;
            this.btn_closing.Text = "Converter AFD (Closing)";
            this.btn_closing.UseVisualStyleBackColor = true;
            this.btn_closing.Click += new System.EventHandler(this.btn_closing_Click);
            // 
            // txtExpress
            // 
            this.txtExpress.Location = new System.Drawing.Point(12, 522);
            this.txtExpress.Name = "txtExpress";
            this.txtExpress.Size = new System.Drawing.Size(256, 20);
            this.txtExpress.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 505);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Criar autömato apartir da expressão regular";
            // 
            // btnCriaAutom
            // 
            this.btnCriaAutom.Location = new System.Drawing.Point(274, 519);
            this.btnCriaAutom.Name = "btnCriaAutom";
            this.btnCriaAutom.Size = new System.Drawing.Size(140, 23);
            this.btnCriaAutom.TabIndex = 28;
            this.btnCriaAutom.Text = "Criar Automato";
            this.btnCriaAutom.UseVisualStyleBackColor = true;
            this.btnCriaAutom.Click += new System.EventHandler(this.btnCriaAutom_Click);
            // 
            // gridTable
            // 
            this.gridTable.AllowUserToAddRows = false;
            this.gridTable.AllowUserToDeleteRows = false;
            this.gridTable.AllowUserToResizeColumns = false;
            this.gridTable.AllowUserToResizeRows = false;
            this.gridTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTable.Location = new System.Drawing.Point(871, 56);
            this.gridTable.Name = "gridTable";
            this.gridTable.ReadOnly = true;
            this.gridTable.Size = new System.Drawing.Size(346, 221);
            this.gridTable.TabIndex = 29;
            this.gridTable.UseWaitCursor = true;
            // 
            // btnFillTable
            // 
            this.btnFillTable.Location = new System.Drawing.Point(871, 298);
            this.btnFillTable.Name = "btnFillTable";
            this.btnFillTable.Size = new System.Drawing.Size(135, 23);
            this.btnFillTable.TabIndex = 30;
            this.btnFillTable.Text = "Reduzir Automato";
            this.btnFillTable.UseVisualStyleBackColor = true;
            this.btnFillTable.Click += new System.EventHandler(this.btnFillTable_Click);
            // 
            // txtdfaedge
            // 
            this.txtdfaedge.Location = new System.Drawing.Point(871, 356);
            this.txtdfaedge.Multiline = true;
            this.txtdfaedge.Name = "txtdfaedge";
            this.txtdfaedge.ReadOnly = true;
            this.txtdfaedge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdfaedge.Size = new System.Drawing.Size(168, 191);
            this.txtdfaedge.TabIndex = 32;
            // 
            // txtdependencia
            // 
            this.txtdependencia.Location = new System.Drawing.Point(1049, 356);
            this.txtdependencia.Multiline = true;
            this.txtdependencia.Name = "txtdependencia";
            this.txtdependencia.ReadOnly = true;
            this.txtdependencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdependencia.Size = new System.Drawing.Size(168, 191);
            this.txtdependencia.TabIndex = 33;
            // 
            // pnlMini
            // 
            this.pnlMini.Location = new System.Drawing.Point(1223, 56);
            this.pnlMini.Name = "pnlMini";
            this.pnlMini.Size = new System.Drawing.Size(681, 435);
            this.pnlMini.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(868, 340);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Análise:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1046, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Dependencias:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(868, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Tabela";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1220, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Automato Reduzido";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 559);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnlMini);
            this.Controls.Add(this.txtdependencia);
            this.Controls.Add(this.txtdfaedge);
            this.Controls.Add(this.btnFillTable);
            this.Controls.Add(this.gridTable);
            this.Controls.Add(this.btnCriaAutom);
            this.Controls.Add(this.txtExpress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_closing);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPronto);
            this.Controls.Add(this.lblgrafo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLimpa);
            this.Controls.Add(this.btnAddEstadoF);
            this.Controls.Add(this.lblTrans);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblEstados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addTrans);
            this.Controls.Add(this.cboxDestino);
            this.Controls.Add(this.cboxOrigem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addEstado);
            this.Controls.Add(this.btnAfd);
            this.Controls.Add(this.pnlAutomato);
            this.Controls.Add(this.txtValidar);
            this.Name = "Principal";
            this.Text = "Autômatos";
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValidar;
        private System.Windows.Forms.Panel pnlAutomato;
        private System.Windows.Forms.Button btnAfd;
        private System.Windows.Forms.Button addEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxOrigem;
        private System.Windows.Forms.ComboBox cboxDestino;
        private System.Windows.Forms.Button addTrans;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEstados;
        private System.Windows.Forms.Label lblTrans;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddEstadoF;
        private System.Windows.Forms.Button btnLimpa;
        private System.Windows.Forms.Label lblgrafo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPronto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btn_closing;
        private System.Windows.Forms.TextBox txtExpress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCriaAutom;
        private System.Windows.Forms.DataGridView gridTable;
        private System.Windows.Forms.Button btnFillTable;
        private System.Windows.Forms.TextBox txtdfaedge;
        private System.Windows.Forms.TextBox txtdependencia;
        private System.Windows.Forms.Panel pnlMini;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;

    }
}

