namespace VKProjectLauncher
{
    partial class AuthorizationForm
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
            this.GetToken = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // GetToken
            // 
            this.GetToken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GetToken.Location = new System.Drawing.Point(0, 0);
            this.GetToken.MinimumSize = new System.Drawing.Size(20, 20);
            this.GetToken.Name = "GetToken";
            this.GetToken.Size = new System.Drawing.Size(800, 450);
            this.GetToken.TabIndex = 0;
            // 
            // AutorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GetToken);
            this.Name = "AutorizationForm";
            this.Text = "Авторизация";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser GetToken;
    }
}