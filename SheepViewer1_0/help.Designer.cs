namespace SheepViewer1_0
{
    partial class help
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
            this.helpWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // helpWebBrowser
            // 
            this.helpWebBrowser.AccessibleDescription = "Online Help";
            this.helpWebBrowser.AccessibleName = "Online Help";
            this.helpWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.helpWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.helpWebBrowser.Name = "helpWebBrowser";
            this.helpWebBrowser.Size = new System.Drawing.Size(944, 501);
            this.helpWebBrowser.TabIndex = 0;
            this.helpWebBrowser.Url = new System.Uri("https://aedwardspv.000webhostapp.com/privategallery/20200404/", System.UriKind.Absolute);
            // 
            // help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.helpWebBrowser);
            this.Name = "help";
            this.Text = "Help - SheepServer 1.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser helpWebBrowser;
    }
}