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
            this.endDate = new System.Windows.Forms.TextBox();
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
            this.testButton = new System.Windows.Forms.RadioButton();
            this.YTDButton = new System.Windows.Forms.RadioButton();
            this.excelButton = new System.Windows.Forms.RadioButton();
            this.startDate = new System.Windows.Forms.TextBox();
            this.studentID = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fixRTC = new System.Windows.Forms.RadioButton();
            this.numberID = new System.Windows.Forms.TextBox();
            this.parseID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(266, 60);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(100, 20);
            this.endDate.TabIndex = 9;
            this.endDate.Visible = false;
            this.endDate.TextChanged += new System.EventHandler(this.endDate_TextChanged);
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
            this.logIn.Enabled = false;
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
            this.userName.TextChanged += new System.EventHandler(this.userName_TextChanged);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(536, 54);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(75, 23);
            this.filePath.TabIndex = 3;
            this.filePath.Text = "browse";
            this.filePath.UseVisualStyleBackColor = true;
            this.filePath.Visible = false;
            this.filePath.Click += new System.EventHandler(this.filePath_Click);
            // 
            // pathName
            // 
            this.pathName.Location = new System.Drawing.Point(12, 56);
            this.pathName.Name = "pathName";
            this.pathName.ReadOnly = true;
            this.pathName.Size = new System.Drawing.Size(505, 20);
            this.pathName.TabIndex = 4;
            this.pathName.Visible = false;
            this.pathName.TextChanged += new System.EventHandler(this.pathName_TextChanged);
            // 
            // parseExcel
            // 
            this.parseExcel.Location = new System.Drawing.Point(536, 83);
            this.parseExcel.Name = "parseExcel";
            this.parseExcel.Size = new System.Drawing.Size(75, 23);
            this.parseExcel.TabIndex = 5;
            this.parseExcel.Text = "parse";
            this.parseExcel.UseVisualStyleBackColor = true;
            this.parseExcel.Visible = false;
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
            this.parsedData.Visible = false;
            this.parsedData.SelectedIndexChanged += new System.EventHandler(this.parsedData_SelectedIndexChanged);
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
            // testButton
            // 
            this.testButton.AutoSize = true;
            this.testButton.Location = new System.Drawing.Point(536, 183);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(42, 17);
            this.testButton.TabIndex = 8;
            this.testButton.Text = "test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.CheckedChanged += new System.EventHandler(this.testButton_CheckedChanged);
            // 
            // YTDButton
            // 
            this.YTDButton.AutoSize = true;
            this.YTDButton.Location = new System.Drawing.Point(536, 206);
            this.YTDButton.Name = "YTDButton";
            this.YTDButton.Size = new System.Drawing.Size(47, 17);
            this.YTDButton.TabIndex = 8;
            this.YTDButton.TabStop = true;
            this.YTDButton.Text = "YTD";
            this.YTDButton.UseVisualStyleBackColor = true;
            this.YTDButton.CheckedChanged += new System.EventHandler(this.YTDButton_CheckedChanged);
            // 
            // excelButton
            // 
            this.excelButton.AutoSize = true;
            this.excelButton.Location = new System.Drawing.Point(536, 229);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(50, 17);
            this.excelButton.TabIndex = 8;
            this.excelButton.TabStop = true;
            this.excelButton.Text = "excel";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.CheckedChanged += new System.EventHandler(this.excelButton_CheckedChanged);
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(70, 57);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(100, 20);
            this.startDate.TabIndex = 9;
            this.startDate.Visible = false;
            this.startDate.TextChanged += new System.EventHandler(this.startDate_TextChanged);
            // 
            // studentID
            // 
            this.studentID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID});
            this.studentID.GridLines = true;
            this.studentID.Location = new System.Drawing.Point(12, 83);
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(145, 314);
            this.studentID.TabIndex = 10;
            this.studentID.UseCompatibleStateImageBehavior = false;
            this.studentID.View = System.Windows.Forms.View.Details;
            this.studentID.Visible = false;
            this.studentID.SelectedIndexChanged += new System.EventHandler(this.studentID_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 143;
            // 
            // fixRTC
            // 
            this.fixRTC.AutoSize = true;
            this.fixRTC.Location = new System.Drawing.Point(536, 253);
            this.fixRTC.Name = "fixRTC";
            this.fixRTC.Size = new System.Drawing.Size(63, 17);
            this.fixRTC.TabIndex = 11;
            this.fixRTC.TabStop = true;
            this.fixRTC.Text = "RTC Fix";
            this.fixRTC.UseVisualStyleBackColor = true;
            this.fixRTC.CheckedChanged += new System.EventHandler(this.fixRTC_CheckedChanged);
            // 
            // numberID
            // 
            this.numberID.Location = new System.Drawing.Point(238, 83);
            this.numberID.Multiline = true;
            this.numberID.Name = "numberID";
            this.numberID.Size = new System.Drawing.Size(100, 313);
            this.numberID.TabIndex = 12;
            this.numberID.Visible = false;
            // 
            // parseID
            // 
            this.parseID.Location = new System.Drawing.Point(536, 112);
            this.parseID.Name = "parseID";
            this.parseID.Size = new System.Drawing.Size(75, 23);
            this.parseID.TabIndex = 13;
            this.parseID.Text = "Add to List";
            this.parseID.UseVisualStyleBackColor = true;
            this.parseID.Visible = false;
            this.parseID.Click += new System.EventHandler(this.parseID_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Start Date";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "End Date";
            this.label2.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 408);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parseID);
            this.Controls.Add(this.numberID);
            this.Controls.Add(this.fixRTC);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.YTDButton);
            this.Controls.Add(this.testButton);
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
        private System.Windows.Forms.RadioButton testButton;
        private System.Windows.Forms.RadioButton YTDButton;
        private System.Windows.Forms.RadioButton excelButton;
        private System.Windows.Forms.TextBox startDate;
        private System.Windows.Forms.TextBox endDate;
        private System.Windows.Forms.ListView studentID;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.RadioButton fixRTC;
        private System.Windows.Forms.TextBox numberID;
        private System.Windows.Forms.Button parseID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

