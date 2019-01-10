using Microsoft.VisualStudio.TestTools.UnitTesting;
using Relm.Converters;
using Relm.Tests.Resources;

namespace Relm.Tests
{
    [TestClass]
    public class PropertiesShould
    {
        [TestMethod]
        public void GetHeight100()
        {
            var output = new Images()._100100.ToByteArray().Height();

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output);
        }

        [TestMethod]
        public void GetHeight50()
        {
            var output = new Images()._20050.ToByteArray().Height();

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output);
        }

        [TestMethod]
        public void GetWidth100()
        {
            var output = new Images()._100100.ToByteArray().Width();

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output);
        }

        [TestMethod]
        public void GetHeight200()
        {
            var output = new Images()._20050.ToByteArray().Width();

            Assert.IsNotNull(output);
            Assert.AreEqual(200, output);
        }

        [TestMethod]
        public void GetSizeImage()
        {
            var output1 = new Images()._100100.Size();
            var output2 = new Images()._100150.Size();

            Assert.IsNotNull(output1);
            Assert.IsTrue(output1 > 0);
            Assert.IsNotNull(output2);
            Assert.IsTrue(output2 > 0);
            Assert.IsTrue(output2 > output1);
        }

        [TestMethod]
        public void GetSizeByteArray()
        {
            var output1 = new Images()._100100.ToByteArray().Size();
            var output2 = new Images()._100150.ToByteArray().Size();

            Assert.IsNotNull(output1);
            Assert.IsTrue(output1 > 0);
            Assert.IsNotNull(output2);
            Assert.IsTrue(output2 > 0);
            Assert.IsTrue(output2 > output1);
            Assert.AreEqual(new Images()._100100.Size(), output1);
            Assert.AreEqual(new Images()._100150.Size(), output2);
        }

        [TestMethod]
        public void GetSizeTheSameForImageAndByte()
        {
            var image = new Images()._100100.Size();
            var byteArray = new Images()._100100.ToByteArray().Size();

            Assert.IsNotNull(image);
            Assert.IsNotNull(byteArray);
            Assert.AreEqual(image, byteArray);
        }
    }
}
