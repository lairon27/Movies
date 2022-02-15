using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Cinema.Utils
{
    public class FileManager
    {
        public string FilePath;
        public FileManager(string path)
        {
            FilePath = path;
        }
        public async Task SaveData(Stream stream)
        {
           using(var filestream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            { 
                stream.Position = 0;
                await stream.CopyToAsync(filestream);
            }
        }
        public async Task LoadData(Stream stream)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            if (File.Exists(FilePath) && stream != null)
            {
                using (var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    await fileStream.CopyToAsync(stream);
                    stream.Position = 0;
                }
            }

            //stopwatch.Stop();
            //MessageBox.Show($"Time loading: {stopwatch.Elapsed}");
        }
    }
}
