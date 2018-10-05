using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fusetwatch
{
    class Program
    {
        public string patch;

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
                Process.Start(Convert.ToString(obj));
                Thread.Sleep(10000);

            }

        }

        static void Main(string[] args)
        {
            string num = "";

            if (File.Exists("Setting.txt"))
            {
                StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Setting.txt");
                //Read the first line of text
                num = sr.ReadLine();
                sr.Close();
            }

            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 0, 2000);



            Console.ReadLine();
        }
    }
}
