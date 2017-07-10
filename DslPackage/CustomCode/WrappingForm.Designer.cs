namespace Maxsys.VisualLAL
{
    partial class WrappingForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.diagramPanel = new System.Windows.Forms.Panel();
            this.symbolsListBox = new System.Windows.Forms.ListBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnExportHTML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // diagramPanel
            // 
            this.diagramPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagramPanel.BackColor = System.Drawing.SystemColors.Window;
            this.diagramPanel.Location = new System.Drawing.Point(190, 4);
            this.diagramPanel.Name = "diagramPanel";
            this.diagramPanel.Size = new System.Drawing.Size(726, 593);
            this.diagramPanel.TabIndex = 0;
            // 
            // symbolsListBox
            // 
            this.symbolsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.symbolsListBox.BackColor = System.Drawing.SystemColors.Window;
            this.symbolsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.symbolsListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.symbolsListBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.symbolsListBox.HorizontalScrollbar = true;
            this.symbolsListBox.Location = new System.Drawing.Point(3, 44);
            this.symbolsListBox.Name = "symbolsListBox";
            this.symbolsListBox.ScrollAlwaysVisible = true;
            this.symbolsListBox.Size = new System.Drawing.Size(181, 546);
            this.symbolsListBox.TabIndex = 1;
            this.symbolsListBox.SelectedIndexChanged += new System.EventHandler(this.symbolsListBox_SelectedIndexChanged);
            this.symbolsListBox.Leave += new System.EventHandler(this.symbolsListBox_Leave);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(94, 4);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(90, 34);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "VALIDAR MODELO";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnExportHTML
            // 
            this.btnExportHTML.Location = new System.Drawing.Point(3, 4);
            this.btnExportHTML.Name = "btnExportHTML";
            this.btnExportHTML.Size = new System.Drawing.Size(90, 34);
            this.btnExportHTML.TabIndex = 3;
            this.btnExportHTML.Text = "EXPORTAR HTML";
            this.btnExportHTML.UseVisualStyleBackColor = true;
            this.btnExportHTML.Click += new System.EventHandler(this.btnExportHTML_Click);
            // 
            // WrappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnExportHTML);
            this.Controls.Add(this.symbolsListBox);
            this.Controls.Add(this.diagramPanel);
            this.Name = "WrappingForm";
            this.Size = new System.Drawing.Size(919, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel diagramPanel;
        private System.Windows.Forms.ListBox symbolsListBox;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnExportHTML;
    }
}
