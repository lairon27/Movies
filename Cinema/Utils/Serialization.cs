using System;
using System.IO;
using System.Windows;
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
            catch(Exception e)
            {
                //return null;
                return MessageBox.Show(e.Message) as T;
            }
        }
    }
}
