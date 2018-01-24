using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
//using System.Collections.Generic;

namespace autoResign
{
    public partial class mainForm : Form
    {

        public string logName = "";
        public string userPass = "";
        public string[,] listViewData;
        public string checkedItem = "";
        public bool test = false;
        
        //var scriptTypes = new List<PowerSchool>();
        public mainForm()
        {
            InitializeComponent();
            parseExcel.Enabled = false;
        }
        

        /// <summary>
        /// log in is enabled as soon as both text boxes have characters
        /// </summary>
        private void logIn_Click(object sender, EventArgs e)
        {
           
            logName = userName.Text;
            userPass = pass.Text;
                    
            powerSchoolForm admin = new powerSchoolForm(logName, userPass);
            this.Hide();
            admin.ShowDialog();
            MessageBox.Show("session now over");
            this.Dispose();
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
        private void parseID_Click(object sender, EventArgs e)
        {
            string multiLineID = numberID.Text;
            string [] idArray = multiLineID.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string [] notNumber = new String [idArray.Length];
            int k = 0;
            if (numberID.Text != "")
            {
               
                
                for (int i = 0; i < idArray.Length; i++)
                {
                    string studentIDTrimed = idArray[i].TrimEnd();
                    int result;
                    bool isNumber = int.TryParse(studentIDTrimed, out result);
                    if (isNumber)
                    {
                        studentID.Items.Add(studentIDTrimed);
                    }
                    else
                    {
                        notNumber[k] = studentIDTrimed;
                        k++;
                        
                    }
                }

                for(k=0;k<notNumber.Length;k++)
                {
                    if (notNumber[k] != null)
                    {
                        Console.WriteLine("index {0}: {1}",k,notNumber[k]);
                    }
                    else
                    {
                        break;
                    }

                }

                numberID.Clear();
            }
            else
            {
                MessageBox.Show("enter a value");
            }
        }
        private void parseExcel_Click(object sender, EventArgs e)
        {
           
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
                
            filePath.Enabled = true;
            parseExcel.Enabled = true;
           
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

       
        /// <summary>
        /// radio button if checked makes thing in/visible
        /// </summary>
        private void excelButton_CheckedChanged(object sender, EventArgs e)
        {
            if (excelButton.Checked)
            {
                
                var checkPath = new CheckTextBox();
                logIn.Enabled = checkPath.checkLine(pathName.Text);
                parsedData.Visible = true;
                pathName.Visible = true;
                filePath.Visible = true;
                parseExcel.Visible = true;
            }
            else
            {
                pathName.Visible = false;
                parsedData.Visible = false;
                filePath.Visible = false;
                parseExcel.Visible = false;
            }
        }

        private void YTDButton_CheckedChanged(object sender, EventArgs e)
        {
            if (YTDButton.Checked)
            {
                startDate.Visible = true;
                endDate.Visible = true;
                var start = new CheckTextBox();
                logIn.Enabled = start.CheckEmpty(startDate.Text, endDate.Text);
            }
            else
            {
                startDate.Visible = false;
                endDate.Visible = false;
            }
        }
 

        private void testButton_CheckedChanged(object sender, EventArgs e)
        {
            var name = new CheckTextBox();
            logIn.Enabled = name.CheckEmpty(userName.Text, pass.Text);
        }


        private void fixRTC_CheckedChanged(object sender, EventArgs e)
        {

            if (fixRTC.Checked)
            {
                studentID.Visible = true;
                numberID.Visible = true;
                parseID.Visible = true;
            }
            else
            {
                studentID.Visible = false;
                numberID.Visible = false;
                parseID.Visible = false;
            }
        }

      
    }
}
