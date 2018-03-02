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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbExtractedData = new System.Windows.Forms.TextBox();
            this.btOpenTemplateDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbInputPfad
            // 
            this.tbInputPfad.Enabled = false;
            this.tbInputPfad.Location = new System.Drawing.Point(12, 2);
            this.tbInputPfad.Name = "tbInputPfad";
            this.tbInputPfad.Size = new System.Drawing.Size(494, 20);
            this.tbInputPfad.TabIndex = 0;
            // 
            // btLos
            // 
            this.btLos.Location = new System.Drawing.Point(276, 574);
            this.btLos.Name = "btLos";
            this.btLos.Size = new System.Drawing.Size(508, 64);
            this.btLos.TabIndex = 1;
            this.btLos.Text = "LOS";
            this.btLos.UseVisualStyleBackColor = true;
            this.btLos.Click += new System.EventHandler(this.btLos_Click);
            // 
            // tbInhalt
            // 
            this.tbInhalt.Location = new System.Drawing.Point(28, 61);
            this.tbInhalt.Multiline = true;
            this.tbInhalt.Name = "tbInhalt";
            this.tbInhalt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInhalt.Size = new System.Drawing.Size(627, 487);
            this.tbInhalt.TabIndex = 2;
            // 
            // btBeispieltemplateGenerieren
            // 
            this.btBeispieltemplateGenerieren.Location = new System.Drawing.Point(38, 580);
            this.btBeispieltemplateGenerieren.Name = "btBeispieltemplateGenerieren";
            this.btBeispieltemplateGenerieren.Size = new System.Drawing.Size(174, 53);
            this.btBeispieltemplateGenerieren.TabIndex = 3;
            this.btBeispieltemplateGenerieren.Text = "Beispieltemplate generieren";
            this.btBeispieltemplateGenerieren.UseVisualStyleBackColor = true;
            this.btBeispieltemplateGenerieren.Click += new System.EventHandler(this.btBeispieltemplateGenerieren_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(808, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Extracted Data";
            // 
            // tbExtractedData
            // 
            this.tbExtractedData.Location = new System.Drawing.Point(681, 61);
            this.tbExtractedData.Multiline = true;
            this.tbExtractedData.Name = "tbExtractedData";
            this.tbExtractedData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbExtractedData.Size = new System.Drawing.Size(579, 487);
            this.tbExtractedData.TabIndex = 6;
            // 
            // btOpenTemplateDir
            // 
            this.btOpenTemplateDir.Location = new System.Drawing.Point(880, 580);
            this.btOpenTemplateDir.Name = "btOpenTemplateDir";
            this.btOpenTemplateDir.Size = new System.Drawing.Size(165, 53);
            this.btOpenTemplateDir.TabIndex = 7;
            this.btOpenTemplateDir.Text = "Templateverzeichnis öffnen";
            this.btOpenTemplateDir.UseVisualStyleBackColor = true;
            this.btOpenTemplateDir.Click += new System.EventHandler(this.btOpenTemplateDir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 676);
            this.Controls.Add(this.btOpenTemplateDir);
            this.Controls.Add(this.tbExtractedData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbExtractedData;
        private System.Windows.Forms.Button btOpenTemplateDir;
    }
}

