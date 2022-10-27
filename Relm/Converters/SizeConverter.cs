using Relm.Enums;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Relm.Converters
{
    public static class SizeConverter
    {
        #region Public
        /// <summary>
        /// Sets the width of a byte[]
        /// </summary>
        /// <param name="byteArray">The byte[] which you want to resize.</param>
        /// <param name="width">The new width you want to give it</param>
        /// <param name="maintainRatio">Do you want to maintain the ratio and adjust the height accordenly to the width?</param>
        /// <param name="stretch">Can an image be stretched if the width is greater than the width of the image?</param>
        /// <returns>Resized byte[]</returns>
        public static byte[] SetWidth(this byte[] byteArray, int width, bool maintainRatio = true, bool stretch = false)
        {
            return byteArray.ToImage().SetWidth(width, maintainRatio, stretch).ToByteArray();
        }

        /// <summary>
        /// Sets the max width of a byte[]
        /// </summary>
        /// <param name="byteArray">The byte[] which you want to resize.</param>
        /// <param name="width">The new width you want to give it</param>
        /// <param name="maintainRatio">Do you want to maintain the ratio and adjust the height accordenly to the width?</param>
        /// <remarks>If the width of the image is lower then the one set, nothing will be changed.</remarks>
        /// <returns>Resized byte[]</returns>
        public static byte[] SetMaxWidth(this byte[] byteArray, int width, bool maintainRatio = true)
        {
            var image = byteArray.ToImage();
            if (image.Width > width)
                return image.SetWidth(width, maintainRatio, false).ToByteArray();
            return byteArray;
        }

        /// <summary>
        /// Sets the height of a byte[]
        /// </summary>
        /// <param name="byteArray">The byte[] which you want to resize.</param>
        /// <param name="height">The new height you want to give it</param>
        /// <param name="maintainRatio">Do you want to maintain the ratio and adjust the width accordenly to the height?</param>
        /// <param name="stretch">Can an image be stretched if the height is greater than the height of the image?</param>
        /// <returns>Resized byte[]</returns>
        public static byte[] SetHeight(this byte[] byteArray, int height, bool maintainRatio = true, bool stretch = false)
        {
            return byteArray.ToImage().SetHeight(height, maintainRatio, stretch).ToByteArray();
        }

        /// <summary>
        /// Sets the height of a byte[]
        /// </summary>
        /// <param name="byteArray">The byte[] which you want to resize.</param>
        /// <param name="height">The new height you want to give it</param>
        /// <param name="maintainRatio">Do you want to maintain the ratio and adjust the width accordenly to the height?</param>
        /// <remarks>If the height of the image is lower then the one set, nothing will be changed.</remarks>
        /// <returns>Resized byte[]</returns>
        public static byte[] SetMaxHeight(this byte[] byteArray, int height, bool maintainRatio = true)
        {
            var image = byteArray.ToImage();
            if (image.Height > height)
                return image.SetHeight(height, maintainRatio, false).ToByteArray();
            return byteArray;
        }

        /// <summary>
        /// Sets the width of an image
        /// </summary>
        /// <param name="byteArray">The image which you want to resize.</param>
        /// <param name="width">The new width you want to give it</param>
        /// <param name="maintainRatio">Do you want to maintain the ratio and adjust the height accordenly to the width?</param>
        /// <param name="stretch">Can an image be stretched if the width is greater than the width of the image?</param>
        /// <returns>Resized Image</returns>
        public static Image SetWidth(this Image image, int width, bool maintainRatio = true, bool stretch = false)
        {
            if (image.Width == width || (!stretch && image.Width < width)) return image;
            double ratio = 1;
            if (maintainRatio)
                ratio = CalcRatio(image.Width, width);

            return Resize(image, width, (int)(image.Height * ratio));

        }

        /// <summary>
        /// Sets the max width of an image
        /// </summary>
        /// <param name="byteArray">The image which you want to resize.</param>
        /// <param name="width">The new width you want to give it</param>
        /// <param name="maintainRatio">Do you want to maintain the ratio and adjust the height accordenly to the width?</param>
        /// <param name="stretch">Can an image be stretched if the width is greater than the width of the image?</param>
        /// <returns>Resized Image</returns>
        public static Image SetMaxWidth(this Image image, int width, bool maintainRatio = true)
        {
            if (image.Width > width)
                return image.SetWidth(width, maintainRatio, false);
            return image;
        }

        /// <summary>
        /// Sets the height of an image
        /// </summary>
        /// <param name="byteArray">The image which you want to resize.</param>
        /// <param name="height">The new height you want to give it</param>
        /// <param name="maintainRatio">Do you want to maintain the ratio and adjust the width accordenly to the height?</param>
        /// <param name="stretch">Can an image be stretched if the height is greater than the height of the image?</param>
        /// <returns>Resized Image</returns>
        public static Image SetHeight(this Image image, int height, bool maintainRatio = true, bool stretch = false)
        {
            if (image.Height == height || (!stretch && image.Height < height)) return image;
            double ratio = 1;
            if (maintainRatio)
                ratio = CalcRatio(image.Height, height);

            return Resize(image, (int)(image.Width * ratio), height);
        }

        /// <summary>
        /// Sets the height of an Image
        /// </summary>
        /// <param name="byteArray">The byte[] which you want to resize.</param>
        /// <param name="height">The new height you want to give it</param>
        /// <param name="maintainRatio">Do you want to maintain the ratio and adjust the width accordenly to the height?</param>
        /// <param name="stretch">Can an image be stretched if the height is greater than the height of the image?</param>
        /// <remarks>If the height of the image is lower then the one set, nothing will be changed.</remarks>
        /// <returns>Resized Image</returns>
        public static Image SetMaxHeight(this Image image, int height, bool maintainRatio = true)
        {
            if (image.Height > height)
                return image.SetHeight(height, maintainRatio, false);
            return image;
        }

        /// <summary>
        /// Crop you image to a certain size from a certain angle
        /// </summary>
        /// <param name="image">The image you want to crop</param>
        /// <param name="height">The height of the cropped image</param>
        /// <param name="width">The width of the cropped image</param>
        /// <param name="position">The position you want to start crop</param>
        /// <returns>Cropped image with the specified height and width</returns>
        public static Image Crop(this Image image, int height, int width, CropPosition position = CropPosition.MiddleCenter)
        {
            Rectangle cropRect;
            switch (position)
            {
                case CropPosition.TopLeft:
                    cropRect = new Rectangle(0, 0, width, height);
                    break;
                case CropPosition.TopCenter:
                    cropRect = new Rectangle(image.Width / 2 - width / 2 - 1, 0, width, height);
                    break;
                case CropPosition.TopRight:
                    cropRect = new Rectangle(image.Width - width - 1, 0, width, height);
                    break;
                case CropPosition.BottomRight:
                    cropRect = new Rectangle(image.Width - width - 1, image.Height - height - 1, width, height);
                    break;
                case CropPosition.BottomCenter:
                    cropRect = new Rectangle(image.Width / 2 - width / 2 - 1, image.Height - height - 1, width, height);
                    break;
                case CropPosition.BottomLeft:
                    cropRect = new Rectangle(0, image.Height - height - 1, width, height);
                    break;
                case CropPosition.MiddleRight:
                    cropRect = new Rectangle(image.Width - width - 1, image.Height / 2 - height / 2 - 1, width, height);
                    break;
                case CropPosition.MiddleLeft:
                    cropRect = new Rectangle(0, image.Height / 2 - height / 2 - 1, width, height);
                    break;
                case CropPosition.MiddleCenter:
                default:
                    cropRect = new Rectangle(image.Width / 2 - width / 2 - 1, image.Height / 2 - height / 2 - 1, width, height);
                    break;
            }
            var mp = new Bitmap(image);
            return mp.Clone(cropRect, image.PixelFormat);
        }

        public static byte[] Crop(this byte[] byteArray, int height, int width, CropPosition position = CropPosition.TopLeft)
        {
            return byteArray.ToImage().Crop(height, width, position).ToByteArray();
        }
        #endregion

        #region Private
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        /// <see cref="http://stackoverflow.com/questions/1922040/resize-an-image-c-sharp"/>
        private static Image Resize(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;


                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return TypeConverter.Convert(destImage, image.RawFormat, 80);
        }

        private static double CalcRatio(int orginal, int newSize)
        {
            return (double)newSize / orginal;
        }
        #endregion
    }
}
