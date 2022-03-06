using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Utils
{
    public interface IXMLSerializator
    {
        Stream SerializeToXML<T>(T obj);
        T Deserialize<T>(Stream stream) where T : class;
    }
}
