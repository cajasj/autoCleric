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
            Console.WriteLine("object is {0}", scriptPass.ElementAt(0));
            scriptPass.ElementAt(0).loginUser(logName,userPass);
           Console.WriteLine("call powerschool class");
        }
    }
}