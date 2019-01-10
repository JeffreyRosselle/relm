using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Relm.Converters
{
    public static class TypeConverter
    {
        /// <summary>
        /// Converts an image to JPG
        /// </summary>
        /// <param name="image">The image you want to convert</param>
        /// <returns>JPG image</returns>
        public static Image ToJpg(this Image image)
        {
            if (image.RawFormat != ImageFormat.Jpeg)
                return Convert(image, ImageFormat.Jpeg);
            return image;
        }

        /// <summary>
        /// Converts an image to PNG
        /// </summary>
        /// <param name="image">The image you want to convert</param>
        /// <returns>PNG image</returns>
        public static Image ToPng(this Image image)
        {
            if (image.RawFormat != ImageFormat.Png)
                return Convert(image, ImageFormat.Png);
            return image;
        }

        /// <summary>
        /// Converts an image to GIF
        /// </summary>
        /// <param name="image">The image you want to convert</param>
        /// <returns>GIF image</returns>
        public static Image ToGif(this Image image)
        {
            if (image.RawFormat != ImageFormat.Gif)
                return Convert(image, ImageFormat.Gif);
            return image;
        }

        /// <summary>
        /// Converts an image to an icon
        /// </summary>
        /// <param name="image">The image you want to convert</param>
        /// <returns>Icon</returns>
        public static Icon ToIcon(this Image image)
        {
            return ConvertToIcon(image);
        }

        /// <summary>
        /// Converts a byte array to JPG
        /// </summary>
        /// <param name="array">The array you want to convert</param>
        /// <returns>JPG byte array</returns>
        public static byte[] ToJpg(this byte[] array)
        {
            return array.ToImage().ToJpg().ToByteArray();
        }

        /// <summary>
        /// Converts a byte array to PNG
        /// </summary>
        /// <param name="array">The array you want to convert</param>
        /// <returns>PNG byte array</returns>
        public static byte[] ToPng(this byte[] array)
        {
            return array.ToImage().ToPng().ToByteArray();
        }

        /// <summary>
        /// Converts a byte array to GIF
        /// </summary>
        /// <param name="array">The array you want to convert</param>
        /// <returns>GIF byte array</returns>
        public static byte[] ToGif(this byte[] array)
        {
            return array.ToImage().ToGif().ToByteArray();
        }

        /// <summary>
        /// Converts a byte array to an icon
        /// </summary>
        /// <param name="array">The array you want to convert</param>
        /// <returns>Icon</returns>
        public static Icon ToIcon(this byte[] array)
        {
            return ConvertToIcon(array.ToImage());
        }

        private static Icon ConvertToIcon(Image image)
        {
            var bitmap = (Bitmap)(image);
            bitmap.MakeTransparent(Color.White);
            var hicon = bitmap.GetHicon();
            var ico = Icon.FromHandle(hicon);
            bitmap.Dispose();

            return ico;
        }

        internal static Image Convert(Image image, ImageFormat format, long quality = 100L)
        {
            var myEncoderParameters = new EncoderParameters(1);

            var myEncoderParameter = new EncoderParameter(Encoder.Quality, quality);
            myEncoderParameters.Param[0] = myEncoderParameter;

            byte[] array;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, GetEncoder(format), myEncoderParameters);
                array = ms.ToArray();
            }

            return array.ToImage();
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }
    }
}
