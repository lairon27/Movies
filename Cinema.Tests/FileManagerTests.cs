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
        public async Task Save_SaveData_SavedData()
        {
            //Arrange
            var path = "..\\Files\\testFile1.xml";
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

        [TestMethod]
        public async Task Load_LoadData_LoadedData()
        {
            //Arrange
            var path = "..\\Files\\testFile1.xml";

            if (File.Exists(path))
            {
                var fileManager = new FileManager(path);
                var stream = new MemoryStream();

                //Act
                await fileManager.LoadData(stream);

                //Assert
                Assert.IsTrue(stream.Length > 0);
            }   
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
