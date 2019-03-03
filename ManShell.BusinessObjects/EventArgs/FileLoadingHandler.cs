using System;

namespace ManShell.BusinessObjects
{
	public class FileLoadingEventArgs
    {
        private string fileName;
        private string loadedData;

        public string FullFileName
        {
            get { return this.fileName; }
        }

        public string FileData
        {
            get { return this.loadedData; }
        }

        public FileLoadingEventArgs(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("message", "Argument cannot be null or empty!");
            this.fileName = fileName;
        }

        public FileLoadingEventArgs(string fileName, string loadedData)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(loadedData))
                throw new ArgumentNullException("Argument cannot be null or empty!");
            this.fileName = fileName;
            this.loadedData = loadedData;
        }
    }
}
