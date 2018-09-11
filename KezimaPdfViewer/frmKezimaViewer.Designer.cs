namespace KezimaPdfViewer
{
    partial class frmKezimaViewer
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
            this.ucKezimaPdfViewer1 = new KezimaPdfViewer.ucKezimaPdfViewer();
            this.SuspendLayout();
            // 
            // ucKezimaPdfViewer1
            // 
            this.ucKezimaPdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKezimaPdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.ucKezimaPdfViewer1.Name = "ucKezimaPdfViewer1";
            this.ucKezimaPdfViewer1.Size = new System.Drawing.Size(800, 450);
            this.ucKezimaPdfViewer1.TabIndex = 0;
            // 
            // frmKezimaViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucKezimaPdfViewer1);
            this.Name = "frmKezimaViewer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmKezimaViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucKezimaPdfViewer ucKezimaPdfViewer1;
    }
}

