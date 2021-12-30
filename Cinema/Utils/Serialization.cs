using System.IO;
using System.Xml.Serialization;

namespace Cinema.Utils
{
   class Serialization
    {
        public static void SerializeToXML<T>(T obj, string FilePath)
        {
            XmlSerializer xs = new(typeof(T));
            using StreamWriter wr = new(FilePath);
            xs.Serialize(wr, obj);
        }

        public static T Deserialize<T>(string FilePath) where T : class
        {
            XmlSerializer xs = new(typeof(T));
            using StreamReader rd = new(FilePath);
            var result = xs.Deserialize(rd) as T;
            return result;
        }
    }
}
