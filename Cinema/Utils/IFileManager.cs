using System.IO;
using System.Threading.Tasks;

namespace Cinema.Utils
{
    public interface IFileManager
    {
        Task SaveData(Stream stream);
        Task LoadData(Stream stream);
    }
}
