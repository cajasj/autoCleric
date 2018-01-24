using System;

namespace autoResign
{
    public class CheckTextBox:mainForm
    {
        public bool CheckEmpty(string firstInput, string secondInput)
        {

            if (firstInput != "" && secondInput != "")
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkLine(string onlyInput)
        {
            if (onlyInput != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
