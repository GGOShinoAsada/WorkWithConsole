using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace WorkWithConsole
{
    class WorkWithCmd
    {
      /// <summary>
      /// доступ к пути универсальный для проекта
      /// </summary>
      /// <returns></returns>
        private static string file()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace(@"\bin\Debug", @"\command files\");
            return path;
        }
        /// <summary>
        /// основное окно программы-исполнителя bat файлов
        /// </summary>
        public static void GetStart()
        {
           
            try
            {
                var process = new Process();
               var startinfo = new ProcessStartInfo(file()+"test.bat");
                #region config
                startinfo.RedirectStandardOutput = true;
                startinfo.UseShellExecute = false;
                startinfo.CreateNoWindow = true;
                process.StartInfo = startinfo;
                process.OutputDataReceived += Print;
                process.ErrorDataReceived += Print;
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        /// <summary>
        /// печать событий на консоль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void Print(object sender, DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                Console.WriteLine(args.Data);
            }
        }
        /// <summary>
        /// универсальный метод вывода на консоль принимает переменную и аргументы
        /// </summary>
        /// <param name="cmdpath"></param>
        /// <param name="args"></param>
        public static void ExecuteCommand(string cmdpath, string args)
        {

            try
            {
                var processinfo = new ProcessStartInfo(cmdpath, args);
                processinfo.CreateNoWindow = true;
                processinfo.UseShellExecute = false;
                processinfo.RedirectStandardOutput = true;
                processinfo.RedirectStandardError = true;
                var process = Process.Start(processinfo);
                process.OutputDataReceived += Print;
                process.BeginOutputReadLine();
                process.ErrorDataReceived += Print;
                process.BeginErrorReadLine();
                //get output
                PrintConsole(process);

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        private static void PrintConsole(Process process)
        {
            string output = process.StandardOutput.ReadToEnd();
            foreach (string t in output.Split('\n'))
            {
                Console.WriteLine(t);
            }
        }

    }
}
