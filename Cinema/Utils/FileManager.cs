using System.IO;

namespace Cinema.Utils
{
    class FileManager
    {
        //public static string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        //public static string FolderName = Path.Combine(ProjectPath, "FilesFolder");
        ////public static string FileName;
        //public DirectoryInfo directory;

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
                filestream.Close();
            }
        }
        public Stream LoadData()
        {
            Stream stream = null;

            if (File.Exists(FilePath))
            {
                 stream = File.OpenRead(FilePath);
            }
           
            return stream;
        }
    }
}
