using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomaticFileMover
{
    public class FilesManager
    {
        private BackgroundWorker bw;

        public FilesManager()
        {
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoSleep;
            bw.RunWorkerCompleted += bw_DoSleepCompleted;
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
        }

       

        private void bw_DoSleep(object sender, DoWorkEventArgs e)
        {
                Thread.Sleep(10000);
        }

        /// <summary>
        /// Liste les fichiers dans le dossier source
        /// </summary>
        private string FileExist()
        {
            var files =  Directory.GetFiles(Singleton.sourcePath);

            var fileOrderByTime = files.OrderBy(x => new FileInfo(x).CreationTime.TimeOfDay).FirstOrDefault();

            if (string.IsNullOrEmpty(fileOrderByTime))
                return string.Empty;
            else
                return fileOrderByTime;
        }
        public void activate()
        {
            Display.Clear();
            Display.infosMessage("En fonctionnement...");

            while (true)
            {
                //Marque une pause
                bw.RunWorkerAsync();

                var fileExist = FileExist();
                //Si un fichier est présent le bon sera sélectionné
                if(!string.IsNullOrEmpty(fileExist))
                    moveFile(fileExist);
                   
                while (bw.IsBusy) { }
            }
        }

        /// <summary>
        /// Déplace les fichiers
        /// </summary>
        private void moveFile(string pathSourceFile)
        {
            try
            {
                var fileName = Path.GetFileName(pathSourceFile);
                File.Move(pathSourceFile, $@"{Singleton.destinationPath}\{fileName}");
                Display.successMessage($"Le fichier '{pathSourceFile}' a été déplacé.");
            }
            catch{ Display.errorMessageWithoutExit($"Le fichier '{pathSourceFile}' n'a pas pu être déplacé !");}
        }

        private void bw_DoSleepCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
    }
}
