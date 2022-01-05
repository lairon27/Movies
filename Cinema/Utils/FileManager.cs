using System.Collections.ObjectModel;
using System.IO;

namespace Cinema.Utils
{
    class FileManager
    {
        private const string FilePath = @"C:\Users\anna.moskalenko\Desktop\rrrre.txt";

        public static void SaveData<T>(T obj)
        {
            using StreamWriter wr = new(FilePath);
            
            Serialization.SerializeToXML(obj, wr);
        }

        public static T LoadData<T>() where T : class
        {
            using StreamReader rd = new(FilePath);

            var result = Serialization.Deserialize<T>(rd) as T;
            return result; 
        }
    }
}
