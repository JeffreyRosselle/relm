using Microsoft.VisualStudio.TestTools.UnitTesting;
using Relm.Converters;
using Relm.Tests.Resources;
using System.Drawing;
using System.Drawing.Imaging;

namespace Relm.Tests.Converters
{
    [TestClass]
    public class TypeConverterShould
    {
        [TestMethod]
        public void ImageToJpg()
        {
            var image = new Images()._100100.ToJpg();

            Assert.IsNotNull(image);
            Assert.AreEqual(ImageFormat.Jpeg, image.RawFormat);
        }

        [TestMethod]
        public void ImageToPng()
        {
            var image = new Images()._100100.ToPng();

            Assert.IsNotNull(image);
            Assert.AreEqual(ImageFormat.Png, image.RawFormat);
        }

        [TestMethod]
        public void ImageToGif()
        {
            var image = new Images()._100100.ToGif();

            Assert.IsNotNull(image);
            Assert.AreEqual(ImageFormat.Gif, image.RawFormat);
        }

        [TestMethod]
        public void ImageToIcon()
        {
            var icon = new Images()._100100.ToIcon();

            Assert.IsNotNull(icon);
            Assert.AreEqual(typeof(Icon), icon.GetType());
        }

        [TestMethod]
        public void ByteArrayToJpg()
        {
            var image = new Images()._100100.ToByteArray().ToJpg().ToImage();

            Assert.IsNotNull(image);
            Assert.AreEqual(ImageFormat.Jpeg, image.RawFormat);
        }

        [TestMethod]
        public void ByteArrayToPng()
        {
            var image = new Images()._100100.ToByteArray().ToPng().ToImage();

            Assert.IsNotNull(image);
            Assert.AreEqual(ImageFormat.Png, image.RawFormat);
        }

        [TestMethod]
        public void ByteArrayToGif()
        {
            var image = new Images()._100100.ToByteArray().ToGif().ToImage();

            Assert.IsNotNull(image);
            Assert.AreEqual(ImageFormat.Gif, image.RawFormat);
        }


        [TestMethod]
        public void ByteArrayToIcon()
        {
            var icon = new Images()._100100.ToByteArray().ToIcon();

            Assert.IsNotNull(icon);
            Assert.AreEqual(typeof(Icon), icon.GetType());
        }
    }

}
