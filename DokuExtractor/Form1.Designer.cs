namespace DokuExtractorGUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbInputPfad = new System.Windows.Forms.TextBox();
            this.btLos = new System.Windows.Forms.Button();
            this.tbInhalt = new System.Windows.Forms.TextBox();
            this.btBeispieltemplateGenerieren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbInputPfad
            // 
            this.tbInputPfad.Location = new System.Drawing.Point(12, 2);
            this.tbInputPfad.Name = "tbInputPfad";
            this.tbInputPfad.Size = new System.Drawing.Size(494, 20);
            this.tbInputPfad.TabIndex = 0;
            // 
            // btLos
            // 
            this.btLos.Location = new System.Drawing.Point(144, 372);
            this.btLos.Name = "btLos";
            this.btLos.Size = new System.Drawing.Size(508, 64);
            this.btLos.TabIndex = 1;
            this.btLos.Text = "LOS";
            this.btLos.UseVisualStyleBackColor = true;
            this.btLos.Click += new System.EventHandler(this.btLos_Click);
            // 
            // tbInhalt
            // 
            this.tbInhalt.Location = new System.Drawing.Point(105, 93);
            this.tbInhalt.Multiline = true;
            this.tbInhalt.Name = "tbInhalt";
            this.tbInhalt.Size = new System.Drawing.Size(567, 192);
            this.tbInhalt.TabIndex = 2;
            // 
            // btBeispieltemplateGenerieren
            // 
            this.btBeispieltemplateGenerieren.Location = new System.Drawing.Point(67, 466);
            this.btBeispieltemplateGenerieren.Name = "btBeispieltemplateGenerieren";
            this.btBeispieltemplateGenerieren.Size = new System.Drawing.Size(174, 53);
            this.btBeispieltemplateGenerieren.TabIndex = 3;
            this.btBeispieltemplateGenerieren.Text = "Beispieltemplate generieren";
            this.btBeispieltemplateGenerieren.UseVisualStyleBackColor = true;
            this.btBeispieltemplateGenerieren.Click += new System.EventHandler(this.btBeispieltemplateGenerieren_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 542);
            this.Controls.Add(this.btBeispieltemplateGenerieren);
            this.Controls.Add(this.tbInhalt);
            this.Controls.Add(this.btLos);
            this.Controls.Add(this.tbInputPfad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInputPfad;
        private System.Windows.Forms.Button btLos;
        private System.Windows.Forms.TextBox tbInhalt;
        private System.Windows.Forms.Button btBeispieltemplateGenerieren;
    }
}

