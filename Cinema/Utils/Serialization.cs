using System.IO;
using System.Xml.Serialization;

namespace Cinema.Utils
{
    public class Serialization : IXMLSerializator
    {
        public Stream SerializeToXML<T>(T obj)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(stream, obj);

            return stream;
        }

        public T Deserialize<T>(Stream stream) where T : class
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));

            try
            {
                return xs.Deserialize(stream) as T;
            }
            catch
            {
                return null;
            }
        }
    }
}
