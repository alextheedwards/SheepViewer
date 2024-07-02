namespace SheepViewer1_0
{
    partial class import
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
            this.importView = new System.Windows.Forms.ListView();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.deleteRow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // importView
            // 
            this.importView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importView.Location = new System.Drawing.Point(12, 41);
            this.importView.Name = "importView";
            this.importView.Size = new System.Drawing.Size(920, 448);
            this.importView.TabIndex = 0;
            this.importView.UseCompatibleStateImageBehavior = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(12, 12);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(110, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importBtn.Location = new System.Drawing.Point(822, 12);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(110, 23);
            this.importBtn.TabIndex = 2;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // open
            // 
            this.open.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.open.Location = new System.Drawing.Point(282, 12);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(110, 23);
            this.open.TabIndex = 3;
            this.open.Text = "Open Data Source";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // deleteRow
            // 
            this.deleteRow.Enabled = false;
            this.deleteRow.Location = new System.Drawing.Point(552, 12);
            this.deleteRow.Name = "deleteRow";
            this.deleteRow.Size = new System.Drawing.Size(110, 23);
            this.deleteRow.TabIndex = 4;
            this.deleteRow.Text = "Delete Row";
            this.deleteRow.UseVisualStyleBackColor = true;
            this.deleteRow.Click += new System.EventHandler(this.deleteRow_Click);
            // 
            // import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.deleteRow);
            this.Controls.Add(this.open);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.importView);
            this.Name = "import";
            this.Text = "Import Data Set - SheepServer 1.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView importView;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button deleteRow;
    }
}