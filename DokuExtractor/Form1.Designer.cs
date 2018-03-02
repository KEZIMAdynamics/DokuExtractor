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
            this.tbRegexFullString = new System.Windows.Forms.TextBox();
            this.tbRegexHalfString = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btFindRegexExpression = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
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
            // tbRegexFullString
            // 
            this.tbRegexFullString.Location = new System.Drawing.Point(17, 45);
            this.tbRegexFullString.Multiline = true;
            this.tbRegexFullString.Name = "tbRegexFullString";
            this.tbRegexFullString.Size = new System.Drawing.Size(421, 99);
            this.tbRegexFullString.TabIndex = 9;
            // 
            // tbRegexHalfString
            // 
            this.tbRegexHalfString.Location = new System.Drawing.Point(497, 45);
            this.tbRegexHalfString.Multiline = true;
            this.tbRegexHalfString.Name = "tbRegexHalfString";
            this.tbRegexHalfString.Size = new System.Drawing.Size(397, 99);
            this.tbRegexHalfString.TabIndex = 10;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Date",
            "Text"});
            this.listBox1.Location = new System.Drawing.Point(913, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 11;
            // 
            // btFindRegexExpression
            // 
            this.btFindRegexExpression.Location = new System.Drawing.Point(1070, 49);
            this.btFindRegexExpression.Name = "btFindRegexExpression";
            this.btFindRegexExpression.Size = new System.Drawing.Size(178, 95);
            this.btFindRegexExpression.TabIndex = 12;
            this.btFindRegexExpression.Text = "Regex Expression finden";
            this.btFindRegexExpression.UseVisualStyleBackColor = true;
            this.btFindRegexExpression.Click += new System.EventHandler(this.btFindRegexExpression_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "FullString";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "HalfString";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRegexFullString);
            this.groupBox1.Controls.Add(this.btFindRegexExpression);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbRegexHalfString);
            this.groupBox1.Location = new System.Drawing.Point(12, 660);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1263, 150);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regex Expression Finder";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 822);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox tbRegexFullString;
        private System.Windows.Forms.TextBox tbRegexHalfString;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btFindRegexExpression;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

