using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample
{
    public  class Logger
    {
        int  _level;
        string _message = null;
        public enum ERROR_LEVEL
        {
            ERROR = 0,
            INFO
        };
        public Logger(int level , string message)
        {
            _level = level;
            _message = message;
        }
    }
}
