using Cinema.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cinema.Tests
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        [DeploymentItem(@"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\moviesFileAttribute17w.xml")]
        public async Task Save_SaveData_SavedData()
        {
            //Arrange
            var path = "moviesFileAttribute17w.xml";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            var fileManager = new FileManager(path);
            var stream = GenerateStreamFromString("hello");

            //Act
            await fileManager.SaveData(stream);

            //Assert
            
            Assert.IsTrue(File.Exists(path));
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
