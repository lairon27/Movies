using System.IO;
using System.Xml.Serialization;

namespace Cinema.Utils
{
   class Serialization
    {
        public static void SerializeToXML<T>(T obj, StreamWriter wr)
        {
            XmlSerializer xs = new(typeof(T));
            xs.Serialize(wr, obj);
        }

        public static T Deserialize<T>(StreamReader rd) where T : class
        {
            XmlSerializer xs = new(typeof(T));
            return xs.Deserialize(rd) as T;
        }
    }
}
