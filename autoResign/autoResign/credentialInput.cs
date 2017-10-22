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
        public string credUser = "";
        public string credPass = "";
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
    }
}
