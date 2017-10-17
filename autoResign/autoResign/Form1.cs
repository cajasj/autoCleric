using System;
using System.Diagnostics;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
            if (pass.Text != "" && userName.Text != "")
            {
                if (pathName.Text == "")
                {

                    MessageBox.Show("please select a file");
                }
                else { 
                    logName = userName.Text;
                    userPass = pass.Text;
                    
                    powerSchoolForm admin = new powerSchoolForm(logName, userPass);
                    this.Hide();
                    admin.ShowDialog();
                    MessageBox.Show("session now over");
                    this.Dispose();
                }
            }
            else
            {
                
                MessageBox.Show("enter user Name or Password"); 
            }
            
        }
        

        private void filePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog search = new OpenFileDialog();
            search.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (search.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                pathName.Text = search.FileName;
            }
        }

        private void parseExcel_Click(object sender, EventArgs e)
        {
            if (pathName.Text != "")
            {

                logIn.Enabled = false;
                filePath.Enabled = false;
                parseExcel.Enabled = false;
                Excel.Application parseMe = new Excel.Application();
                Excel.Workbook parseBook = parseMe.Workbooks.Open(pathName.Text);
                Excel._Worksheet parseSheet = parseBook.Sheets[1];
                Excel.Range parseRange = parseSheet.UsedRange;
                int rowCount = parseRange.Rows.Count;
                int colCount = parseRange.Columns.Count;
                string firstColumn="";
                string afterFirstColumn="";
                ListViewItem dataTable;
                
                    
                
                for (int i = 1; i <= rowCount; i++)
                {
                    
                    if (parseRange.Cells[i, 2] != null && parseRange.Cells[i, 2].Value2 != null)
                    {
                        firstColumn = parseRange.Cells[i, 2].Value2.ToString();
                    }
                     
                        dataTable = new ListViewItem(firstColumn);
                    
                    for (int j = 3; j <= colCount; j++)
                    {


                        if (parseRange.Cells[i, j] != null && parseRange.Cells[i, j].Value2 != null)
                        {

                            afterFirstColumn =parseRange.Cells[i, j].Value2.ToString();
                            dataTable.SubItems.Add(afterFirstColumn);
                            
                        }

                    }
                    parsedData.Items.Add(dataTable);
                }
                MessageBox.Show("all items has been added");

                logIn.Enabled = true;
                filePath.Enabled = true;
                parseExcel.Enabled = true;
            }
            else
            {
                MessageBox.Show("browse for an excel file");
            }
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            pass.PasswordChar = '*';

        }
    }
}
