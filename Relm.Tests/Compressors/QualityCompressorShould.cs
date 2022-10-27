using Microsoft.VisualStudio.TestTools.UnitTesting;
using Relm.Compressors;
using Relm.Converters;
using Relm.Tests.Resources;

namespace Relm.Tests.Compressors
{
    [TestClass]
    public class QualityCompressorShould
    {
        [TestMethod]
        public void CompressImage()
        {
            var image = new Images().banner.SetHeight(75);
            var image1 = image.Compress();
            var image2 = image.Compress(50);
            var image3 = image.Compress(0);

            Assert.IsNotNull(image1);
            Assert.IsNotNull(image2);
            Assert.IsNotNull(image3);
            Assert.IsTrue(image.Size() == image1.Size());
            Assert.IsTrue(image1.Size() > image2.Size());
            Assert.IsTrue(image2.Size() > image3.Size());
        }

        [TestMethod]
        public void CompressByteArray()
        {
            var array = new Images().banner.SetHeight(75);
            var array1 = array.Compress();
            var array2 = array.Compress(50);
            var array3 = array.Compress(0);

            Assert.IsNotNull(array1);
            Assert.IsNotNull(array2);
            Assert.IsNotNull(array3);
            Assert.IsTrue(array.Size() == array1.Size());
            Assert.IsTrue(array1.Size() > array2.Size());
            Assert.IsTrue(array2.Size() > array3.Size());
        }
    }
}
