using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace BrowsingTimeManagament
{
    class Program
    {
        private const string TITLE_NETFLIX = "Netflix";
        private const string TITLE_YOUTUBE = "YouTube";
        static void Main(string[] args)
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine("Current Time : " + currentTime);
            try
            {
                Process[] processlist = Process.GetProcesses();

                foreach (Process process in processlist)
                {
                    string processName = process.ProcessName;
                    if (processName == "msedge")
                    {
                        string browsingTime = (currentTime.Subtract(process.StartTime).TotalMinutes).ToString();

                        Console.WriteLine("Running process : " + processName);
                        Console.WriteLine("MainWindowTitle : " + process.MainWindowTitle);
                        Console.WriteLine("Process Started Time : " + process.StartTime.ToString());
                        Console.WriteLine("Browsing Time :" + browsingTime + "minutes");
                        float floatBrowsingTime = float.Parse(browsingTime);
                        Boolean checkResult = checkWindowTitle(process, TITLE_NETFLIX, floatBrowsingTime);
                        Boolean checkResult2 = checkWindowTitle(process, TITLE_YOUTUBE, floatBrowsingTime);
                        if (checkResult == true | checkResult2 == true)
                        {
                            break;
                        }
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="title"></param>
        /// <param name="floatBrowsingTime"></param>
        private static Boolean checkWindowTitle(Process process, string title, float floatBrowsingTime)
        {
            if (process.MainWindowTitle.Contains(title) & floatBrowsingTime > 60)
            {
                Console.WriteLine("Please take a break");
                Process photoViewer = new Process();
                photoViewer.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                photoViewer.StartInfo.Arguments = @"C:\DATA\kyuukeichite.jpg";
                photoViewer.Start();
                return true;
            }
            return false;
        }
    }
}
