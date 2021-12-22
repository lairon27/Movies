using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Cinema.Commands
{
   class MovieSerialization
    {
        public static void SerializeMovieItemToXML<Movie>(Movie item, string FilePath)
        {
            XmlSerializer xs = new(typeof(Movie));
            using (StreamWriter wr = new StreamWriter(FilePath))
            {
                xs.Serialize(wr, item);
            }
        }
    }
}
