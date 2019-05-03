using System.Drawing;

namespace Steganography
{
    public class ConfidentialResult : IConfidentialResult
    {
        public ConfidentialResult(Bitmap image) => Image = image;
        public Bitmap Image { get; }
        public int? Key { get; set; }
    }
}
