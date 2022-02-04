using System;
using System.IO;

namespace Cinema.Utils
{
    class FileManager
    {
        public string FilePath;
        public FileManager(string path)
        {
            FilePath = path;
        }
        public void SaveData(Stream stream)
        {
           using(var filestream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            { 
                stream.Position = 0;
                stream.CopyTo(filestream);
            }
        }
        public void LoadData(ref Stream stream)
        {
            if (File.Exists(FilePath))
            {
                stream = File.OpenRead(FilePath);
            }
        }
    }
}
