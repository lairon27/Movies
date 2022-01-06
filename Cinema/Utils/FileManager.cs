using System.Collections.ObjectModel;
using System.IO;

namespace Cinema.Utils
{
    class FileManager
    {
        //public string FilePath;
        //public FileManager()
        //{
        //    FilePath = @"C:\Users\anna.moskalenko\Desktop\123.txt";
        //}

        //public static void SaveData<T>(T obj)
        //{
        //    using StreamWriter wr = new(FilePath);

        //    Serialization.SerializeToXML(obj, wr);

        //    //using stream = new(FilePath);
        //}

        public static void SaveData<T>(T obj, string FilePath)
        {
            using StreamWriter wr = new(FilePath);

            Serialization.SerializeToXML(obj, wr);

        }

        public static T LoadData<T>(string FilePath) where T : class
        {
            using StreamReader rd = new(FilePath);

            var result = Serialization.Deserialize<T>(rd) as T;
            return result; 
        }
    }
}
