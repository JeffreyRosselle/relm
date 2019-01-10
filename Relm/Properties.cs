using Relm.Converters;
using System.Drawing;
using System.Linq;

namespace Relm
{
    public static class Properties
    {
        /// <summary>
        /// Gets the height of a byte[]
        /// </summary>
        /// <param name="byteArray">The byte[] you want the height of</param>
        /// <returns>height</returns>
        public static int Height(this byte[] byteArray)
        {
            return byteArray.ToImage().Height;
        }

        /// <summary>
        /// Gets the width of a byte[]
        /// </summary>
        /// <param name="byteArray">The byte[] you want the width of</param>
        /// <returns>width</returns>
        public static int Width(this byte[] byteArray)
        {
            return byteArray.ToImage().Width;
        }

        /// <summary>
        /// Get the size the byte[] in bytes
        /// </summary>
        /// <param name="byteArray">The image in byte[]</param>
        /// <returns>Length in bytes</returns>
        public static long Size(this byte[] byteArray)
        {
            return byteArray.Count();
        }

        /// <summary>
        /// Get the size an image in bytes
        /// </summary>
        /// <param name="byteArray">The image you want the size of</param>
        /// <returns>Length in bytes</returns>
        public static long Size(this Image image)
        {
            return image.ToByteArray().Count();
        }
    }
}
