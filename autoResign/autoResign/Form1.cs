using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public string rtcString="";
        public string excelString="";
        public List<string> idCorrectFormat= new List<string>();
        public List<powerSchool> scriptPass = new List<powerSchool>();
        public string[] idRay;
        public string path;
        public int stateSchoolID = 8;
        public mainForm()
        {
            InitializeComponent();
            parseExcel.Enabled = false;
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"\idList.txt";
       
        }
        

        /// <summary>
        /// log in is enabled as soon as both text boxes have characters
        /// </summary>
        private void logIn_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(path + @"\idList.txt", String.Empty);
            using (StreamWriter sIDText = new StreamWriter(path, true))
            {
                foreach (string sID in idCorrectFormat)
                {
                    sIDText.WriteLine(sID);
                   
                }
                sIDText.Close();
            }
            
            
            logName = userName.Text;
            userPass = passText.Text; 
            this.Hide();
            Console.WriteLine("id list path is {0}",path); 
            
            scriptPass.ElementAt(0).loginUser(logName, userPass);

            scriptPass.ElementAt(0).ShowDialog();
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
            parseIDCheck(stateSchoolID);    
           
        }

        private void parseIDCheck(int idLength)
        {
            string multiLineID = numberID.Text;
            string[] idArray = multiLineID.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] notNumber = new string[idArray.Length];
            int idLengthMinus=idLength-1;
            int k = 0;
            if (numberID.Text != "")
            {

                foreach (var id in idArray)
                {
                    string studentIDTrimed = id.Trim();
                    
                    double result;
                    bool isNumber = double.TryParse(studentIDTrimed, out result); 
                    if (studentIDTrimed.Length != idLength && studentIDTrimed.Length != idLengthMinus)
                    {
                        Console.WriteLine(studentIDTrimed);
                        Console.WriteLine(studentIDTrimed.Length);
                        isNumber = false;
                    }
                    else { isNumber = true; }
                    
                    if (isNumber)
                    {
                        idCorrectFormat.Add(studentIDTrimed);
                        rtcString = studentIDTrimed;
                        studentID.Items.Add(studentIDTrimed);
                    }
                    else
                    {
                        notNumber[k] = studentIDTrimed;
                        k++;

                    }
                }

                var notNumberCombined = string.Join("\n", notNumber);
                const string pageBreak = "\n";
                if (notNumberCombined == "" || notNumberCombined[0] == '\n')
                {
                    notNumberCombined = Regex.Replace(notNumberCombined, pageBreak, "");
                }

                if (notNumberCombined != "")

                {
                    MessageBox.Show(notNumberCombined);
                }

                numberID.Clear();
            }
            else
            {
                MessageBox.Show("enter a value");
            }
            var checkIDListView = new CheckTextBox();
            logIn.Enabled = checkIDListView.checkLine(rtcString);
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
            this.listViewData = new string [rowCount,rowCount];
            for (int i = 2; i <= rowCount; i++)
            {
                if (parseRange.Cells[i, 2] != null && parseRange.Cells[i, 2].Value2 != null)
                {
                    fullName = parseRange.Cells[i, 2].Value2.ToString();
                    var firstName = fullName;
                    parseName(ref lastName,ref firstName);
                    listViewData[i - 2, 0] = lastName;
                    listViewData[i - 2, 1] = firstName;
                    fullName = lastName + "," + firstName;
                    excelString = fullName;
                }
                     
                    var dataTable = new ListViewItem(fullName);
                    
                for (int j = 3; j <= colCount; j++)
                {
                    if (parseRange.Cells[i, j] != null && parseRange.Cells[i, j].Value2 != null)
                    {
                        string afterFirstColumn=parseRange.Cells[i, j].Value2.ToString();
                        dataTable.SubItems.Add(afterFirstColumn);
                    }
                }
                parsedData.Items.Add(dataTable);
            }
            MessageBox.Show("all items has been added");
           
           
        }

      
     

        private void parseName(ref string last,ref string first)
        {
            var firstLastSeparated = first.Split(',');
            last = firstLastSeparated[0];
            first = firstLastSeparated[1];
            const string whiteSpace = " ";
            var whiteSpaceCheck = new Regex(whiteSpace);
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
        /// check if boxes are empty
        /// </summary>
        private void excelButton_CheckedChanged(object sender, EventArgs e)
        {
            if (excelButton.Checked)
            {
                scriptPass.Clear();
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
                scriptPass.Clear();
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
            scriptPass.Clear();
            var name = new CheckTextBox();
            logIn.Enabled = name.CheckEmpty(userName.Text, passText.Text);
        }


        private void overlaps_CheckedChanged(object sender, EventArgs e)
        {
            if (overlaps.Checked)
            {
                stateSchoolID = 10;
                scriptPass.Clear();
                scriptPass.Add(new StudentOverlaps());
                studentID.Visible = true;
                numberID.Visible = true;
                parseID.Visible = true;
                var checkIDListView = new CheckTextBox();
                logIn.Enabled = checkIDListView.checkLine(rtcString);
            }
            else
            {
                studentID.Items.Clear();
                studentID.Visible = false;
                numberID.Visible = false;
                parseID.Visible = false;
            }
        }
        private void fixRTC_CheckedChanged(object sender, EventArgs e)
        {

            if (fixRTC.Checked)
            {
                stateSchoolID = 8;
                scriptPass.Clear();
                scriptPass.Add(new StudentRTC());
                Console.WriteLine(scriptPass.ElementAt(0));
                studentID.Visible = true;
                numberID.Visible = true;
                parseID.Visible = true;
                var checkIDListView = new CheckTextBox();
                logIn.Enabled = checkIDListView.checkLine(rtcString);
            }
            else
            {
                studentID.Items.Clear();
                studentID.Visible = false;
                numberID.Visible = false;
                parseID.Visible = false;
            }
        }

        private void endDate_TextChanged(object sender, EventArgs e)
        {
            var start = new CheckTextBox();
            logIn.Enabled = start.CheckEmpty(startDate.Text, endDate.Text);
        }


        private void startDate_TextChanged(object sender, EventArgs e)
        {
            var start = new CheckTextBox();
            logIn.Enabled = start.CheckEmpty(startDate.Text, endDate.Text);
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
            var name = new CheckTextBox();
            logIn.Enabled = name.CheckEmpty(userName.Text, passText.Text);
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            var name = new CheckTextBox();
            passText.PasswordChar = '*';
            logIn.Enabled = name.CheckEmpty(userName.Text, passText.Text);
        }

        private void pathName_TextChanged(object sender, EventArgs e)
        {
            var checkPath = new CheckTextBox();
            parseExcel.Enabled = checkPath.checkLine(pathName.Text);
        }

        private void studentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkIDListView= new CheckTextBox();
            logIn.Enabled = checkIDListView.checkLine(rtcString);
        }

        private void parsedData_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkExcelListView=new CheckTextBox();
            logIn.Enabled = checkExcelListView.checkLine(excelString);
        }

        private void historicalGrade_CheckedChanged(object sender, EventArgs e)
        {

            if (historicalGrade.Checked)
            {
                stateSchoolID = 8;
                scriptPass.Clear();
                scriptPass.Add(new cleanHistorical()); 
                studentID.Visible = true;
                numberID.Visible = true;
                parseID.Visible = true;
                var checkIDListView = new CheckTextBox();
                logIn.Enabled = checkIDListView.checkLine(rtcString);
            }
            else
            {
                studentID.Items.Clear();
                studentID.Visible = false;
                numberID.Visible = false;
                parseID.Visible = false;
            }
        }
    }
}
