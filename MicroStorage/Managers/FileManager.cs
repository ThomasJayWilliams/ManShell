using System;
using System.IO;

using ManShell.BusinessObjects;

namespace MicroStorage
{
    public static class FileManager
    {
        private static string localPath = Environment.CurrentDirectory;
        private static string dirName = "microstorage";
        private static string fileName = "storage.json";
        private static string fullFileName = localPath + "\\" + dirName + "\\" + fileName;
        private static string backupFileName = "storage.backup.json";
        private static string fullBackupFileName = localPath + "\\" + dirName + "\\" + backupFileName;
        private static string helpFullFileName = localPath + "\\" + dirName + "\\" + "help.txt";

        internal static event FileLoadingHandler OnLoadHandler;

        public static void Save(string arg)
        {
            if (string.IsNullOrEmpty(arg))
                throw new ArgumentNullException();
            if (!File.Exists(fullFileName))
                File.Create(fullFileName);
            File.WriteAllText(fullFileName, arg);
        }

        public static string GetHelpInfo()
        {
            var str = string.Empty;
            if (File.Exists(helpFullFileName))
                using (var reader = new StreamReader(helpFullFileName))
                    str = reader.ReadToEnd();
            else
                CreateFile(helpFullFileName);
            return str;
        }

        public static void LoadBackup()
        {
            if (File.Exists(fullFileName) && File.Exists(fullBackupFileName))
            {
                var reader = new StreamReader(fullBackupFileName);
                string data = reader.ReadToEnd();
                reader.Close();

                if (!string.IsNullOrEmpty(data))
                    File.WriteAllText(fullFileName, data);

                if (OnLoadHandler != null)
                    OnLoadHandler.Invoke(new FileLoadingEventArgs(fullBackupFileName, data));
            }
        }

        public static void SaveBackup()
        {
            if (!File.Exists(fullFileName))
                CreateFile(fullFileName);

            if (!File.Exists(fullBackupFileName))
                CreateFile(fullBackupFileName);

            string data = GetData();

            if (!string.IsNullOrEmpty(data))
                File.WriteAllText(fullBackupFileName, data);
        }

        public static string GetData()
        {
            var data = string.Empty;

            CreateFile(fullFileName);

            var reader = new StreamReader(fullFileName);
            data = reader.ReadToEnd();
            reader.Close();

            if (OnLoadHandler != null)
                OnLoadHandler.Invoke(new FileLoadingEventArgs(fullFileName, data));

            return data;
        }

        private static void CreateFile(string fullName)
        {
            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);

            if (!File.Exists(fullName))
            {
                FileStream file = File.Create(fullName);
                file.Close();
            }
        }
    }
}
