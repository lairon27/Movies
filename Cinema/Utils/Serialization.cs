using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Cinema.Utils
{
   class Serialization
    {
        public static Stream SerializeToXML<T>(T obj)
        {
            MemoryStream stream = new();
            XmlSerializer xs = new(typeof(T));
            xs.Serialize(stream, obj);

            return stream;
        }

        public static T Deserialize<T>(Stream stream) where T : class
        {
            XmlSerializer xs = new(typeof(T));

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
