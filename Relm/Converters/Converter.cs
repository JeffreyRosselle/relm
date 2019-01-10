using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Relm.Converters
{
    public static class Converter
    {
        /// <summary>
        /// Converts an image to byte[]
        /// </summary>
        /// <param name="image">Image which needs to be converted</param>
        /// <returns>byte[] of the converted image</returns>
        public static byte[] ToByteArray(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    image.Save(ms, image.RawFormat);
                }
                catch (ArgumentNullException)
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Converts a byte[] to an image
        /// </summary>
        /// <param name="byteArray">byte[] which needs to be converted</param>
        /// <returns>Image of the converted byte[]</returns>
        public static Image ToImage(this byte[] byteArray)
        {
            try
            {
                return Image.FromStream(new MemoryStream(byteArray));
            }
            catch
            {
                throw new FormatException("Data is not an image");
            }
        }
    }
}
