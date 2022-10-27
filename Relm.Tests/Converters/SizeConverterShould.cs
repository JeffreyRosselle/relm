using Microsoft.VisualStudio.TestTools.UnitTesting;
using Relm.Converters;
using Relm.Enums;
using Relm.Tests.Resources;
using System.Drawing;

namespace Relm.Tests.Converters
{
    [TestClass]
    public class SizeConverterShould
    {
        #region SetSize
        [TestMethod]
        public void SetWidthImage()
        {
            var output = new Images()._100100.SetWidth(50, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width);
            Assert.AreEqual(100, output.Height);
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthImageRatio()
        {
            var output = new Images()._100100.SetWidth(50);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width);
            Assert.AreEqual(50, output.Height);
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthImageStretch()
        {
            var output = new Images()._100100.SetWidth(200, false, true);

            Assert.IsNotNull(output);
            Assert.AreEqual(200, output.Width);
            Assert.AreEqual(100, output.Height);
            Assert.IsTrue(new Images()._100100.Size() < output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthImageRatioStretch()
        {
            var output = new Images()._100100.SetWidth(200, true, true);

            Assert.IsNotNull(output);
            Assert.AreEqual(200, output.Width);
            Assert.AreEqual(200, output.Height);
            Assert.IsTrue(new Images()._100100.Size() < output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthImageRatioNoStretch()
        {
            var output = new Images()._100100.SetWidth(200);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width);
            Assert.AreEqual(100, output.Height);
            Assert.AreEqual(new Images()._100100.Size(), output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetMaxWidthImage()
        {
            var output = new Images()._100100.SetMaxWidth(50, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width);
            Assert.AreEqual(100, output.Height);
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetMaxWidthImageRatio()
        {
            var output = new Images()._100100.SetMaxWidth(50);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width);
            Assert.AreEqual(50, output.Height);
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetNoMaxWidthImage()
        {
            var output = new Images()._100100.SetMaxWidth(200, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width);
            Assert.AreEqual(100, output.Height);
            Assert.IsFalse(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightImage()
        {
            var output = new Images()._100100.SetHeight(50, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width);
            Assert.AreEqual(50, output.Height);
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightImageRatio()
        {
            var output = new Images()._100100.SetHeight(50);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width);
            Assert.AreEqual(50, output.Height);
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightImageStretch()
        {
            var output = new Images()._100100.SetHeight(200, false, true);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width);
            Assert.AreEqual(200, output.Height);
            Assert.IsTrue(new Images()._100100.Size() < output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightImageRatioStretch()
        {
            var output = new Images()._100100.SetHeight(200, true, true);

            Assert.IsNotNull(output);
            Assert.AreEqual(200, output.Width);
            Assert.AreEqual(200, output.Height);
            Assert.IsTrue(new Images()._100100.Size() < output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightImageRatioNoStretch()
        {
            var output = new Images()._100100.SetHeight(200);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width);
            Assert.AreEqual(100, output.Height);
            Assert.AreEqual(new Images()._100100.Size(), output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetMaxHeightImage()
        {
            var output = new Images()._100100.SetMaxHeight(50, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width);
            Assert.AreEqual(50, output.Height);
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetMaxHeightImageRatio()
        {
            var output = new Images()._100100.SetMaxHeight(50);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width);
            Assert.AreEqual(50, output.Height);
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetNoMaxHeightImage()
        {
            var output = new Images()._100100.SetMaxHeight(200, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width);
            Assert.AreEqual(100, output.Height);
            Assert.IsFalse(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthByteArray()
        {
            var output = new Images()._100100.ToByteArray().SetWidth(50, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width());
            Assert.AreEqual(100, output.Height());
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthByteArrayRatio()
        {
            var output = new Images()._100100.ToByteArray().SetWidth(50);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width());
            Assert.AreEqual(50, output.Height());
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthByteArrayStretch()
        {
            var output = new Images()._100100.ToByteArray().SetWidth(200, false, true);

            Assert.IsNotNull(output);
            Assert.AreEqual(200, output.Width());
            Assert.AreEqual(100, output.Height());
            Assert.IsTrue(new Images()._100100.Size() < output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthByteArrayRatioStretch()
        {
            var output = new Images()._100100.ToByteArray().SetWidth(200, true, true);

            Assert.IsNotNull(output);
            Assert.AreEqual(200, output.Width());
            Assert.AreEqual(200, output.Height());
            Assert.IsTrue(new Images()._100100.Size() < output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetWidthByteArrayRatioNoStretch()
        {
            var output = new Images()._100100.ToByteArray().SetWidth(200);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width());
            Assert.AreEqual(100, output.Height());
            Assert.AreEqual(new Images()._100100.Size(), output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetMaxWidthByteArray()
        {
            var output = new Images()._100100.ToByteArray().SetMaxWidth(50, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width());
            Assert.AreEqual(100, output.Height());
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetMaxWidthByteArrayRatio()
        {
            var output = new Images()._100100.ToByteArray().SetMaxWidth(50);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width());
            Assert.AreEqual(50, output.Height());
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetNoMaxWidthByteArray()
        {
            var output = new Images()._100100.ToByteArray().SetMaxWidth(200, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width());
            Assert.AreEqual(100, output.Height());
            Assert.IsFalse(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightByteArray()
        {
            var output = new Images()._100100.ToByteArray().SetHeight(50, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width());
            Assert.AreEqual(50, output.Height());
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightByteArrayRatio()
        {
            var output = new Images()._100100.ToByteArray().SetHeight(50);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width());
            Assert.AreEqual(50, output.Height());
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightByteArrayStretch()
        {
            var output = new Images()._100100.ToByteArray().SetHeight(200, false, true);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width());
            Assert.AreEqual(200, output.Height());
            Assert.IsTrue(new Images()._100100.Size() < output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightByteArrayRatioStretch()
        {
            var output = new Images()._100100.ToByteArray().SetHeight(200, true, true);

            Assert.IsNotNull(output);
            Assert.AreEqual(200, output.Width());
            Assert.AreEqual(200, output.Height());
            Assert.IsTrue(new Images()._100100.Size() < output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetHeightByteArrayRatioNoStretch()
        {
            var output = new Images()._100100.ToByteArray().SetHeight(200);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width());
            Assert.AreEqual(100, output.Height());
            Assert.AreEqual(new Images()._100100.Size(), output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetMaxHeightByteArray()
        {
            var output = new Images()._100100.ToByteArray().SetMaxHeight(50, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width());
            Assert.AreEqual(50, output.Height());
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetMaxHeightByteArrayRatio()
        {
            var output = new Images()._100100.ToByteArray().SetMaxHeight(50);

            Assert.IsNotNull(output);
            Assert.AreEqual(50, output.Width());
            Assert.AreEqual(50, output.Height());
            Assert.IsTrue(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }

        [TestMethod]
        public void SetNoMaxHeightByteArray()
        {
            var output = new Images()._100100.ToByteArray().SetMaxHeight(200, false);

            Assert.IsNotNull(output);
            Assert.AreEqual(100, output.Width());
            Assert.AreEqual(100, output.Height());
            Assert.IsFalse(new Images()._100100.Size() > output.Size(), $"Original: {new Images()._100100.Size()}  | Output: {output.Size()}");
        }
        #endregion

        #region Crop
        [TestMethod]
        public void CropImageTopLeft()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.TopLeft);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(0, 0), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(0, 49), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(49, 0), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(49, 49), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropImageTopCenter()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.TopCenter);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(24, 0), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(24, 49), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(74, 0), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(74, 49), result.GetPixel(49, 49));
        }

        [TestMethod]
        public void CropImageTopRight()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.TopRight);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(49, 0), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(49, 49), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(99, 0), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(98, 49), result.GetPixel(49, 49));
        }

        [TestMethod]
        public void CropImageMiddleLeft()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.MiddleLeft);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(0, 24), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(0, 73), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(49, 24), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(49, 73), result.GetPixel(49, 49));
        }

        [TestMethod]
        public void CropImageMiddleCenter()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.MiddleCenter);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(24, 24), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(24, 73), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(73, 24), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(73, 73), result.GetPixel(49, 49));
        }

        [TestMethod]
        public void CropImageMiddleRight()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.MiddleRight);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(49, 24), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(49, 73), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(98, 24), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(98, 73), result.GetPixel(49, 49));
        }

        [TestMethod]
        public void CropImageBottomLeft()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.BottomLeft);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(0, 49), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(0, 98), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(49, 49), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(49, 99), result.GetPixel(49, 49));
        }

        [TestMethod]
        public void CropImageBottomCenter()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.BottomCenter);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(24, 49), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(24, 98), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(74, 49), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(74, 99), result.GetPixel(49, 49));
        }

        [TestMethod]
        public void CropImageBottomRight()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.Crop(50, 50, CropPosition.BottomRight);

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(49, 49), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(49, 99), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(98, 49), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(99, 99), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayTopLeft()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.TopLeft).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(0, 0), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(0, 49), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(49, 0), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(49, 49), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayopCenter()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.TopCenter).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(24, 0), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(24, 49), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(74, 0), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(74, 49), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayTopRight()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.TopRight).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(49, 0), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(49, 49), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(99, 0), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(98, 49), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayMiddleLeft()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.MiddleLeft).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(0, 24), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(0, 73), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(49, 24), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(49, 73), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayMiddleCenter()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.MiddleCenter).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(24, 24), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(24, 73), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(73, 24), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(73, 73), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayMiddleRight()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.MiddleRight).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(49, 24), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(49, 73), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(98, 24), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(98, 73), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayBottomLeft()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.BottomLeft).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(0, 49), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(0, 98), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(49, 49), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(49, 99), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayBottomCenter()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.BottomCenter).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(24, 49), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(24, 99), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(74, 49), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(74, 99), result.GetPixel(49, 49));
        }

        [Ignore]
        [TestMethod]
        public void CropByteArrayBottomRight()
        {
            var image = (Bitmap)new Images().banner.SetHeight(100, false).SetWidth(100, false);
            var result = (Bitmap)image.ToByteArray().Crop(50, 50, CropPosition.BottomRight).ToImage();

            Assert.IsNotNull(result);
            Assert.AreEqual(50, result.Height);
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(image.GetPixel(49, 49), result.GetPixel(0, 0));
            Assert.AreEqual(image.GetPixel(49, 99), result.GetPixel(0, 49));
            Assert.AreEqual(image.GetPixel(98, 49), result.GetPixel(49, 0));
            Assert.AreEqual(image.GetPixel(99, 99), result.GetPixel(49, 49));
        }
        #endregion
    }
}
