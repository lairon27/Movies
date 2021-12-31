using System.Collections.ObjectModel;
using System.IO;

namespace Cinema.Utils
{
    class StreamSave
    {
        //public static void SaveStreamAsFile(string filePath, Stream inputStream, string fileName)
        //{
        //    DirectoryInfo info = new(filePath);
        //    if (!info.Exists)
        //    {
        //        info.Create();
        //    }

        //    string path = Path.Combine(filePath, fileName);
        //    using FileStream outputFileStream = new(path, FileMode.Create);
        //    inputStream.CopyTo(outputFileStream);
        //}

        public static void SaveData<T>(ObservableCollection<T> obj)
        {
            using StreamWriter file = new(@"C:\Users\anna.moskalenko\Desktop\aaaaaa.txt");
            foreach (var item in obj)
            {
                file.WriteLine(item.ToString());
            }
            file.Close();
        }
    }
}
