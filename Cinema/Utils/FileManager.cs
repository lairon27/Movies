using System;
using System.IO;
using System.Threading.Tasks;

namespace Cinema.Utils
{
    public class FileManager
    {
        public string FilePath;
        public FileManager(string path)
        {
            FilePath = path;
        }
        public async void SaveData(Stream stream)
        {
           using(var filestream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            { 
                stream.Position = 0;
                await stream.CopyToAsync(filestream);
            }
        }
        public async void LoadData(Stream stream)
        {
            if (File.Exists(FilePath) && stream != null)
            {
                using (var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    await fileStream.CopyToAsync(stream);
                    stream.Position = 0;
                }
            }
        }
    }
}
