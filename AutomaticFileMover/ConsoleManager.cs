using App.ConvertMdbToAccdb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticFileMover
{
    public static class ConsoleManager
    {
        public static string errorMessage { get; set; }

        private static bool pathFolderExist(string pathFolder)
        {
            bool flag = false;
            if (Directory.Exists(pathFolder))
                flag = true;
            else
                ConsoleManager.errorMessage = $"Le chemin du dossier spécifié n'existe pas.";
            return flag;
        }

        public static string setSourcePath()
        {
            bool isValid = false;
            string str = ConsoleManager.readPathFolder(Const.INIFILE_SOURCE_VAR);
            if (string.IsNullOrEmpty(str))
            {
                while (!isValid)
                {
                    ConsoleManager.errorMessage = string.Empty;
                    str = Display.readLine("Indiquez le chemin du dossier source :");
                    if (ConsoleManager.pathFolderExist(str))
                    {
                        ConsoleManager.WritePathFile(Const.INIFILE_SOURCE_VAR,str);
                        isValid = true;
                    }
                    if (!string.IsNullOrEmpty(ConsoleManager.errorMessage))
                        Display.errorMessageWithoutExit(ConsoleManager.errorMessage);
                }
            }
            Display.Clear();
            Display.successMessage($"Le dossier source '{str}' est valide.");
            Singleton.sourcePath = str;
            return str;
        }
        public static string setDestinationPath()
        {
            bool isValid = false;
            string str = ConsoleManager.readPathFolder(Const.INIFILE_DESTINATION_VAR);
            if (string.IsNullOrEmpty(str))
            {
                while (!isValid)
                {
                    ConsoleManager.errorMessage = string.Empty;
                    str = Display.readLine("Indiquez le chemin du dossier destination :");
                    if (ConsoleManager.pathFolderExist(str))
                    {
                        ConsoleManager.WritePathFile(Const.INIFILE_DESTINATION_VAR, str);
                        isValid = true;
                    }
                    if (!string.IsNullOrEmpty(ConsoleManager.errorMessage))
                        Display.errorMessageWithoutExit(ConsoleManager.errorMessage);
                }
            }
            Display.Clear();
            Display.successMessage($"Le dossier destination '{str}' est valide.");
            Singleton.destinationPath = str;
            return str;
        }
        public static string readPathFolder(string key)
        {
            string str = string.Empty;
            IniFile iniFile = new IniFile(Const.INIFILE_PATH);
            if (iniFile.KeyExists(key, (string)null))
            {
                string path = iniFile.Read(key, (string)null);
                if (!string.IsNullOrEmpty(Const.INIFILE_PATH) && iniFile.IsValidPath(path, false) && Directory.Exists(path))
                    str = path;
                else
                    str = string.Empty;
            }
            return str;
        }

        public static string WritePathFile(string key, string sourcePath)
        {
            new IniFile(Const.INIFILE_PATH).Write(key, sourcePath.Trim(), (string)null);
            return sourcePath;
        }
    }
}
