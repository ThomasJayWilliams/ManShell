﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MicroStorage
{
    public static class FileManager
    {
        private static string _localPath = Environment.CurrentDirectory;
        private static string _fileName = "storage.dat";
        private static string _fullFileName = _localPath + "\\" + _fileName;

        public static void Save(string arg)
        {
            if (string.IsNullOrEmpty(arg))
                throw new ArgumentNullException();
            if (!File.Exists(_fullFileName))
                File.Create(_fullFileName);
            File.WriteAllText(_fullFileName, arg);
        }

        public static string GetData()
        {
            string data = string.Empty;

            if (!File.Exists(_fullFileName))
            {
                FileStream file = File.Create(_fullFileName);
                file.Close();
            }

            StreamReader reader = new StreamReader(_fullFileName);
            data = reader.ReadToEnd();
            reader.Close();

            return data;
        }
    }
}
