using System;
using System.IO;

namespace Cinema.Utils
{
    public class FileManager
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
        public void LoadData(Stream stream)
        {
            if (File.Exists(FilePath) && stream != null)
            {
                using(var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(stream);
                    stream.Position = 0;
                }
            }
        }
    }
}
