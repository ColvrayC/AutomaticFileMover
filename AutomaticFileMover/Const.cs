using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticFileMover
{
    public static class Const
    {
        public static string INIFILE_PATH = Const.removeTexteFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "\\AutomaticFileMover.ini");
        public static string INIFILE_SOURCE_VAR = "SourcePath";
        public static string INIFILE_DESTINATION_VAR = "DestinationPath";

        private static string removeTexteFile(string path)
        {
            if (!string.IsNullOrEmpty(path) && path.Contains("file:\\"))
                path = path.Substring(6, path.Length - 6);
            return path;
        }
    }
}
