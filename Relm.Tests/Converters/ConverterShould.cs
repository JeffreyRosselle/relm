using Microsoft.VisualStudio.TestTools.UnitTesting;
using Relm.Converters;
using Relm.Tests.Resources;
using System;
using System.Drawing;
using System.Linq;

namespace Relm.Tests.Converters
{
    [TestClass]
    public class ConverterShould
    {
        private Image image;

        [TestInitialize]
        public void Init()
        {
            image = new Images()._100100;
        }

        [TestMethod]
        public void ToByteArray()
        {
            var output = image.ToByteArray();

            Assert.IsNotNull(output);
            Assert.IsTrue(output.Count() > 0);
        }

        [TestMethod]
        public void ToImage()
        {
            var byteArray = new Images()._100100.ToByteArray();
            var output = byteArray.ToImage();

            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void SameImage()
        {
            var byteArray = image.ToByteArray();

            var output = byteArray.ToImage();

            Assert.IsNotNull(output);
            Assert.AreEqual(image.Size, output.Size);
            Assert.AreEqual(image.PixelFormat, output.PixelFormat);
        }

        [TestMethod]
        public void SameByteArray()
        {
            var byteArray = image.ToByteArray();
            image = byteArray.ToImage();

            var output = image.ToByteArray();

            Assert.IsNotNull(output);
            Assert.AreEqual(byteArray.Count(), output.Count());
            Assert.AreEqual(byteArray[5], output[5]);
            Assert.AreEqual(byteArray[byteArray.Count() - 1], output[byteArray.Count() - 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ThrowExceptionWhenNoImage()
        {
            var byteArray = new byte[2];
            var image = byteArray.ToImage();

            Assert.IsNull(image);
        }
    }
}
