using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace BrowsingTimeManagament
{
    class Program
    {
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
                        if (process.MainWindowTitle.Contains("Netflix") & floatBrowsingTime > 60)
                        {
                            Console.WriteLine("Please take a break");
                            Process photoViewer = new Process();
                            photoViewer.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                            photoViewer.StartInfo.Arguments = @"C:\DATA\kyuukeichite.jpg";
                            photoViewer.Start();
                            break;
                        }
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                throw e;
            }
            //Console.ReadLine();
        }
    }
}
