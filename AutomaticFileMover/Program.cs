using App.ConvertMdbToAccdb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomaticFileMover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Auto File Mover";
            Display.Title();

            loadPaths();

            var fm = new FilesManager();
             fm.activate();
        }
        static void loadPaths()
        {
            var iniFile = new IniFile(Const.INIFILE_PATH);
            //Vérifie que les valeurs sont présentes
            ConsoleManager.setSourcePath();
            ConsoleManager.setDestinationPath();
        }

        private void waiter()
        {
            Thread.Sleep(5000);
        }
    }
}
