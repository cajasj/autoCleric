using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace autoResign
{
     class callPowerSchool
    {
        public void enterSite(List<powerSchool> scriptPass, string logName, string userPass)
        {
            scriptPass.ElementAt(0).loginUser(logName,userPass);
           
        }
    }
}