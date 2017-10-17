namespace autoResign
{
    partial class mainForm
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
            this.pass = new System.Windows.Forms.TextBox();
            this.logIn = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.filePath = new System.Windows.Forms.Button();
            this.pathName = new System.Windows.Forms.TextBox();
            this.parseExcel = new System.Windows.Forms.Button();
            this.parsedData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(238, 15);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(100, 20);
            this.pass.TabIndex = 0;
            this.pass.TextChanged += new System.EventHandler(this.pass_TextChanged);
            // 
            // logIn
            // 
            this.logIn.Location = new System.Drawing.Point(536, 12);
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(75, 23);
            this.logIn.TabIndex = 1;
            this.logIn.Text = "login";
            this.logIn.UseVisualStyleBackColor = true;
            this.logIn.Click += new System.EventHandler(this.logIn_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(42, 15);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(100, 20);
            this.userName.TabIndex = 0;
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(536, 54);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(75, 23);
            this.filePath.TabIndex = 3;
            this.filePath.Text = "browse";
            this.filePath.UseVisualStyleBackColor = true;
            this.filePath.Click += new System.EventHandler(this.filePath_Click);
            // 
            // pathName
            // 
            this.pathName.Location = new System.Drawing.Point(12, 56);
            this.pathName.Name = "pathName";
            this.pathName.ReadOnly = true;
            this.pathName.Size = new System.Drawing.Size(505, 20);
            this.pathName.TabIndex = 4;
            // 
            // parseExcel
            // 
            this.parseExcel.Location = new System.Drawing.Point(536, 101);
            this.parseExcel.Name = "parseExcel";
            this.parseExcel.Size = new System.Drawing.Size(75, 23);
            this.parseExcel.TabIndex = 5;
            this.parseExcel.Text = "parse";
            this.parseExcel.UseVisualStyleBackColor = true;
            this.parseExcel.Click += new System.EventHandler(this.parseExcel_Click);
            // 
            // parsedData
            // 
            this.parsedData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.parsedData.GridLines = true;
            this.parsedData.Location = new System.Drawing.Point(12, 82);
            this.parsedData.Name = "parsedData";
            this.parsedData.Size = new System.Drawing.Size(505, 314);
            this.parsedData.TabIndex = 6;
            this.parsedData.UseCompatibleStateImageBehavior = false;
            this.parsedData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "position";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "School";
            this.columnHeader3.Width = 106;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "race";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "hire Date";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "effective date";
            this.columnHeader6.Width = 104;
            // 
            // warningLabel
            // 
            this.warningLabel.Location = new System.Drawing.Point(393, 12);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(124, 41);
            this.warningLabel.TabIndex = 7;
            this.warningLabel.Text = "Warning fail to log in requires the program to restart";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 408);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.parsedData);
            this.Controls.Add(this.parseExcel);
            this.Controls.Add(this.pathName);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.logIn);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.pass);
            this.Name = "mainForm";
            this.Text = "main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.Button logIn;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button filePath;
        private System.Windows.Forms.TextBox pathName;
        private System.Windows.Forms.Button parseExcel;
        private System.Windows.Forms.ListView parsedData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label warningLabel;
    }
}

