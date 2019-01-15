using System;
using System.IO;

namespace MicroStorage
{
    public static class FileManager
    {
        private static string localPath = Environment.CurrentDirectory;
        private static string dirName = "microstorage";
        private static string fileName = "storage.json";
        private static string fullFileName = localPath + "\\" + dirName + "\\" + fileName;

        public static void Save(string arg)
        {
            if (string.IsNullOrEmpty(arg))
                throw new ArgumentNullException();
            if (!File.Exists(fullFileName))
                File.Create(fullFileName);
            File.WriteAllText(fullFileName, arg);
        }

        public static string GetData()
        {
            var data = string.Empty;

            if (!File.Exists(fullFileName))
            {
                Directory.CreateDirectory(dirName);
                FileStream file = File.Create(fullFileName);
                file.Close();
            }

            var reader = new StreamReader(fullFileName);
            data = reader.ReadToEnd();
            reader.Close();

            return data;
        }
    }
}
