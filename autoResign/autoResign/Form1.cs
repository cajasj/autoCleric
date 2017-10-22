using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace autoResign
{
    public partial class mainForm : Form
    {

        public string logName = "";
        public string userPass = "";
        public string[,] listViewData; 
        public mainForm()
        {
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
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
                string fullName = "";
                string lastName="";
                string firstName = "";
                string afterFirstColumn="";
                this.listViewData = new string [rowCount,rowCount];
                ListViewItem dataTable;   
                for (int i = 2; i <= rowCount; i++)
                {
                    if (parseRange.Cells[i, 2] != null && parseRange.Cells[i, 2].Value2 != null)
                    {
                        fullName = parseRange.Cells[i, 2].Value2.ToString();
                        firstName = fullName;
                        parseName(ref lastName,ref firstName);
                        listViewData[i - 2, 0] = lastName;
                        listViewData[i - 2, 1] = firstName;
                        fullName = lastName + "," + firstName;
                    }
                     
                        dataTable = new ListViewItem(fullName);
                    
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

        private void parseName(ref string last,ref string first)
        {
            string[] firstLastSeparated=new string[3];
            firstLastSeparated=first.Split(',');
            last = firstLastSeparated[0];
            first = firstLastSeparated[1];
            string whiteSpace = " ";
            Regex whiteSpaceCheck = new Regex(whiteSpace);
            while(first.IndexOf(whiteSpace)==0)
            {
                first = first.Substring(1, first.Length-1);
            }
            if (whiteSpaceCheck.IsMatch(first))
            {
                first = first.Substring(0, first.IndexOf(whiteSpace));
                Console.WriteLine(first);
            }
            
        }
    }
}
