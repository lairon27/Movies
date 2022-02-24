using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Utils
{
    public interface IFileManager
    {
        Task SaveData(Stream stream);
        Task LoadData(Stream stream);
    }
}
