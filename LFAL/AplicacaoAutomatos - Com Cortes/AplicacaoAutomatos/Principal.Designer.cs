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
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 503);
            this.Controls.Add(this.pnlAutomato);
            this.Controls.Add(this.txtValidar);
            this.Name = "Principal";
            this.Text = "Autômatos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValidar;
        private System.Windows.Forms.Panel pnlAutomato;

    }
}

