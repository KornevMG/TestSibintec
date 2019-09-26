using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskManager.Logs
{
    public interface ILogger
    {
        void log(string msg);
    }
}
