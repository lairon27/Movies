using System.IO;

namespace Cinema.Utils
{
    public interface IXMLSerializator
    {
        Stream SerializeToXML<T>(T obj);
        T Deserialize<T>(Stream stream) where T : class;
    }
}
