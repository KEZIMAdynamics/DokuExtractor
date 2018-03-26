namespace GdPicturePdfViewer
{
    partial class frmGdPictureViewer
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
            this.ucGdPicturePdfViewer1 = new GdPicturePdfViewer.ucGdPicturePdfViewer();
            this.SuspendLayout();
            // 
            // ucGdPicturePdfViewer1
            // 
            this.ucGdPicturePdfViewer1.BackColor = System.Drawing.Color.White;
            this.ucGdPicturePdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGdPicturePdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.ucGdPicturePdfViewer1.Name = "ucGdPicturePdfViewer1";
            this.ucGdPicturePdfViewer1.Size = new System.Drawing.Size(620, 527);
            this.ucGdPicturePdfViewer1.TabIndex = 0;
            // 
            // frmGdPictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(620, 527);
            this.Controls.Add(this.ucGdPicturePdfViewer1);
            this.Name = "frmGdPictureViewer";
            this.Text = "frmGdPictureViewer";
            this.Load += new System.EventHandler(this.frmGdPictureViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucGdPicturePdfViewer ucGdPicturePdfViewer1;
    }
}

