using System;
using System.IO;

namespace BackupsExtra.Entity
{
    public class Loger
    {
        private static string _path = "/Users/andrejpodvysockij/Desktop/Log/logs.txt";
        public static void WriteLog(string message, string logType)
        {
            if (logType == "Console")
            {
                Console.WriteLine(message);
            }

            if (logType == "File")
            {
                using (StreamWriter sw = new StreamWriter(_path, true))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}