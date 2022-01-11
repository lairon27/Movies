using System.Collections.ObjectModel;
using System.IO;

namespace Cinema.Utils
{
    class FileManager
    {
        public static string FileName;

        public FileManager()
        {
            FileName = @"C:\Users\anna.moskalenko\Desktop\moviesFile.txt";
        }

        public static void SaveData(MemoryStream stream)
        {
           using(var filestream = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            { 
                stream.Position = 0;
                stream.CopyTo(filestream);
                filestream.Close();
                stream.Close();
            }
        }

        public static MemoryStream LoadData()
        {
            MemoryStream stream = new();
            using (var filestream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                filestream.CopyTo(stream);
            }

            stream.Position = 0;
            return stream;
        }
    }
}
