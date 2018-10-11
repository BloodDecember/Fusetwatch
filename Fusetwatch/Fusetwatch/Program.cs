using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Fusetwatch
{
    class Program
    {
        

        public static void Count(object obj)
        {
            Console.Clear();
            Process[] runningProcessByName = Process.GetProcessesByName("Fuset");
            if (runningProcessByName.Length != 0)
            {
                Console.WriteLine("Бот работает");
            }
            else
            {
                Console.WriteLine("Запуск бота...");
                KillChrome("chrome");
                KillChrome("chromedriver");

                Process.Start(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Fuset.exe");
                Thread.Sleep(10000);

            }

        }

        public static void KillChrome(string name)
        {
            System.Diagnostics.Process[] procs = null;

            try
            {
                procs = Process.GetProcessesByName(name);

                foreach (var item in procs)
                {
                    if (!item.HasExited)
                    {
                        item.Kill();
                    }
                }


            }
            finally
            {
                if (procs != null)
                {
                    foreach (Process p in procs)
                    {
                        p.Dispose();
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            string num = "";

            //if (File.Exists("Setting.txt"))
            //{
            //    StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Setting.txt");
            //    //Read the first line of text
            //    num = sr.ReadLine();
            //    sr.Close();
            //}

            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 0, 2000);



            Console.ReadLine();
        }
    }
}
