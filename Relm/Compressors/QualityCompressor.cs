using Relm.Converters;
using System.Drawing;

namespace Relm.Compressors
{
    public static class QualityCompressor
    {
        /// <summary>
        /// Reduces the image size by lowering the quality.
        /// </summary>
        /// <param name="image">The image you want to reduce the size of</param>
        /// <param name="quality">Number between 0 and 100. 0 being lowest quality and 100 best.</param>
        /// <returns>Compressed image</returns>
        /// <remarks>
        ///     Default is set to 80 which lowers the size but still gives decent quality
        ///     The lower the quality, the uglier the image will turn out to be.
        ///     Images will only compress when they are resized. Compressing an image without changing it may result in a larger file.
        /// </remarks>
        public static Image Compress(this Image image, long quality = 80L)
        {
            var result = TypeConverter.Convert(image, image.RawFormat, quality);
            if (result.Size() < image.Size())
                return result;
            return image;
        }

        /// <summary>
        /// Reduces the byte array size by lowering the quality.
        /// </summary>
        /// <param name="array">The array you want to reduce the size of</param>
        /// <param name="quality">Number between 0 and 100. 0 being lowest quality and 100 best.</param>
        /// <returns>Compressed byte array</returns>
        /// <remarks>
        ///     Default is set to 80 which lowers the size but still gives decent quality
        ///     The lower the quality, the uglier the image will turn out to be.
        ///     Images will only compress when they are resized. Compressing an image without changing it may result in a larger file.
        /// </remarks>        
        public static byte[] Compress(this byte[] array, long quality = 80L)
        {
            var result = array.ToImage().Compress(quality).ToByteArray();
            if (result.Size() < array.Size())
                return result;
            return array;
        }
    }
}
