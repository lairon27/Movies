using System.IO;
using System.Xml.Serialization;

namespace Cinema.Utils
{
   class Serialization
    {
        public static MemoryStream SerializeToXML<T>(T obj)
        {
            MemoryStream stream = new();
            XmlSerializer xs = new(typeof(T));
            xs.Serialize(stream, obj);

            return stream;
        }

        public static T Deserialize<T>(MemoryStream stream) where T : class
        {
            XmlSerializer xs = new(typeof(T));
            return xs.Deserialize(stream) as T;
        }
    }
}
