using Anotar.NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodyLogSample
{
    class Test 
    {
        string Name;
        public Test(string name)
        {
            Name = name;
        }
        public void DisplayTest()
        {
            LogTo.Debug(Name);
        }

    }
}
