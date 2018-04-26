namespace DokuExtractorStandardGUI
{
    partial class frmTemplateEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplateEditor));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClassTemplateEditor = new System.Windows.Forms.TabPage();
            this.tabGroupTemplateEditor = new System.Windows.Forms.TabPage();
            this.ucClassTemplateEditor1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucClassTemplateEditor();
            this.ucGroupTemplateEditor1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucGroupTemplateEditor();
            this.tabControl1.SuspendLayout();
            this.tabClassTemplateEditor.SuspendLayout();
            this.tabGroupTemplateEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabClassTemplateEditor);
            this.tabControl1.Controls.Add(this.tabGroupTemplateEditor);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1104, 579);
            this.tabControl1.TabIndex = 1;
            // 
            // tabClassTemplateEditor
            // 
            this.tabClassTemplateEditor.Controls.Add(this.ucClassTemplateEditor1);
            this.tabClassTemplateEditor.Location = new System.Drawing.Point(4, 22);
            this.tabClassTemplateEditor.Name = "tabClassTemplateEditor";
            this.tabClassTemplateEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabClassTemplateEditor.Size = new System.Drawing.Size(1096, 553);
            this.tabClassTemplateEditor.TabIndex = 0;
            this.tabClassTemplateEditor.Text = "Class Template Editor";
            this.tabClassTemplateEditor.UseVisualStyleBackColor = true;
            // 
            // tabGroupTemplateEditor
            // 
            this.tabGroupTemplateEditor.Controls.Add(this.ucGroupTemplateEditor1);
            this.tabGroupTemplateEditor.Location = new System.Drawing.Point(4, 22);
            this.tabGroupTemplateEditor.Name = "tabGroupTemplateEditor";
            this.tabGroupTemplateEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroupTemplateEditor.Size = new System.Drawing.Size(1096, 553);
            this.tabGroupTemplateEditor.TabIndex = 1;
            this.tabGroupTemplateEditor.Text = "Group Template Editor";
            this.tabGroupTemplateEditor.UseVisualStyleBackColor = true;
            // 
            // ucClassTemplateEditor1
            // 
            this.ucClassTemplateEditor1.BackColor = System.Drawing.Color.White;
            this.ucClassTemplateEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucClassTemplateEditor1.Location = new System.Drawing.Point(3, 3);
            this.ucClassTemplateEditor1.Name = "ucClassTemplateEditor1";
            this.ucClassTemplateEditor1.Size = new System.Drawing.Size(1090, 547);
            this.ucClassTemplateEditor1.TabIndex = 0;
            // 
            // ucGroupTemplateEditor1
            // 
            this.ucGroupTemplateEditor1.BackColor = System.Drawing.Color.White;
            this.ucGroupTemplateEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGroupTemplateEditor1.Location = new System.Drawing.Point(3, 3);
            this.ucGroupTemplateEditor1.Name = "ucGroupTemplateEditor1";
            this.ucGroupTemplateEditor1.Size = new System.Drawing.Size(1090, 547);
            this.ucGroupTemplateEditor1.TabIndex = 0;
            // 
            // frmTemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1104, 579);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTemplateEditor";
            this.Text = "TemplateEditor";
            this.Load += new System.EventHandler(this.frmTemplateEditor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabClassTemplateEditor.ResumeLayout(false);
            this.tabGroupTemplateEditor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClassTemplateEditor;
        private System.Windows.Forms.TabPage tabGroupTemplateEditor;
        private UserControlsTemplateEditor.ucClassTemplateEditor ucClassTemplateEditor1;
        private UserControlsTemplateEditor.ucGroupTemplateEditor ucGroupTemplateEditor1;
    }
}