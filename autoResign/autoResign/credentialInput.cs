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
    public partial class credentialInput : Form
    {
        private string credUser = "";
        private string credPass = "";
        public credentialInput()
        {
            InitializeComponent();
        }

        private void retryLogin_Click(object sender, EventArgs e)
        {

            credUser = retryUser.Text;
            credPass = retryPass.Text;
            this.Close();
        }
        public string getName
        {
            get { return credUser; }
        }
        public string getPass
        {
            get { return credPass; }
        }
    }
}
