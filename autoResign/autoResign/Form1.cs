using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoResign
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public  string logName = "";
        public  string userPass = "";
        private void logIn_Click(object sender, EventArgs e)
        {
            logName = userName.Text;
            userPass = pass.Text;
            powerSchoolForm admin = new powerSchoolForm(logName, userPass);

            this.Hide();
            admin.ShowDialog();
            this.Show();
            
        }
        
    }
}
