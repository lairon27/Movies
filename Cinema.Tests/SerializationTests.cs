using Cinema.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cinema.Tests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void SerializeToXML_SerializeObjectToStream_SerializedObject()
        {
            //Arrange
            var serialization = new Serialization();
            var movie = new Movie
            {
                MovieId = new Guid(),
                MovieName = "SpiderMan: No Way Home"
            };

            //Act
            var stream = serialization.SerializeToXML(movie);

            //Assert
            Assert.IsNotNull(stream);
        }
    }
}
