namespace autoResign
{
    partial class credentialInput
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
            this.retryLogin = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.retryUser = new System.Windows.Forms.TextBox();
            this.retryPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // retryLogin
            // 
            this.retryLogin.Location = new System.Drawing.Point(12, 181);
            this.retryLogin.Name = "retryLogin";
            this.retryLogin.Size = new System.Drawing.Size(75, 23);
            this.retryLogin.TabIndex = 0;
            this.retryLogin.Text = "log in";
            this.retryLogin.UseVisualStyleBackColor = true;
            this.retryLogin.Click += new System.EventHandler(this.retryLogin_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(170, 180);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // retryUser
            // 
            this.retryUser.Location = new System.Drawing.Point(112, 56);
            this.retryUser.Name = "retryUser";
            this.retryUser.Size = new System.Drawing.Size(100, 20);
            this.retryUser.TabIndex = 2;
            // 
            // retryPass
            // 
            this.retryPass.Location = new System.Drawing.Point(112, 96);
            this.retryPass.Name = "retryPass";
            this.retryPass.Size = new System.Drawing.Size(100, 20);
            this.retryPass.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "user";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "password";
            // 
            // credentialInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.retryPass);
            this.Controls.Add(this.retryUser);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.retryLogin);
            this.Name = "credentialInput";
            this.Text = "credentialInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button retryLogin;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox retryUser;
        private System.Windows.Forms.TextBox retryPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}