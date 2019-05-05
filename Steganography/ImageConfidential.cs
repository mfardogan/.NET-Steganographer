using System.Drawing;

namespace Steganography
{
    public class ImageConfidential : IConfidential
    {
        public ImageConfidential(Bitmap bitmap)
            => RawData = (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[]));
        public int? Key { get; set; }
        public byte[] RawData { get; }
    }
}
