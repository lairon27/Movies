using System.Collections.ObjectModel;
using System.IO;

namespace Cinema.Utils
{
    class FileManager
    {
        //public static string FileName;

        //public FileManager()
        //{
        //    FileName = "moviesFile.xml";
        //}

        public static void SaveData(Stream stream, string FileName)
        {
           using(var filestream = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            { 
                stream.Position = 0;
                stream.CopyTo(filestream);
                filestream.Close();
            }
        }

        public static Stream LoadData(string FileName)
        {
            var stream = File.OpenRead(FileName);
            return stream;
        }
    }
}
