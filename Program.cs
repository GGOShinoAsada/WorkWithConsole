using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkWithConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface.GetMenu();
            //WorkWithCmd.ExecuteCommand("ping.exe", "-t -n 3 192.168.100.1");
            //WorkWithCmd.ExecuteCommand("tracert.exe", "11.1.0.1");
            //WorkWithCmd.ExecuteCommand("netstat.exe", "-a -n -o");
            //WorkWithCmd.ExecuteCommand("net.exe", "config workstation");
            //WorkWithCmd.GetStart();
            Console.ReadKey();
        }
    }
}
