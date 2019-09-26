using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TaskManager.Logs
{
    public class Logger : ILogger
    {
        public void log(string msg)
        {

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt");
            if (msg.Length > 0)
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    try
                    {
                        sw.WriteLine("{0} {1}: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), msg);
                        sw.Flush();
                    }
                    catch (Exception ex)
                    {
                        string er = ex.Message;
                    }
                }
            }
        }
    }
}