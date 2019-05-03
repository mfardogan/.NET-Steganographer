using System.Drawing;

namespace Steganography
{
    public class ImageConfidential : IConfidential
    {
        public ImageConfidential(Bitmap bitmap)
            => ConfidentialRawData = (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[]));
        public int? Key { get; set; }
        public Bitmap Image { get; set; }
        public byte[] ConfidentialRawData { get; }
    }
}
