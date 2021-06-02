using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    static class LogWriter
    {
        /// <summary>
        /// Writes the param string into the log file
        /// </summary>
        /// <param name="text"></param>
        public static void WriteToLog(string text)
        {
            string path = Directory.GetCurrentDirectory() + $"\\log_{DateTime.Now.ToString("yy-MM-dd")}.txt";

            if (File.Exists(path))
            {
                using (StreamWriter fs = File.AppendText(path))
                {
                    fs.WriteLine($"[{DateTime.Now.ToString("T")}] {text}");
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"[{DateTime.Now.ToString("T")}] {text}");
                }
            }
        }
    }
}
