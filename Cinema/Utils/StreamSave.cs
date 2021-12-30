using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Utils
{
    class StreamSave
    {
        public static void SaveAsFile(string filePath, ObservableCollection<Movie> obj)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {

                foreach (var item in obj)
                {
                    sw.WriteLine(item);
                }
            }
        }

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
    }
}
