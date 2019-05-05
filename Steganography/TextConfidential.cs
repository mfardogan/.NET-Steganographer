using System.Drawing;
using System.Text;

namespace Steganography
{
    public class TextConfidential : IConfidential
    {
        public TextConfidential(string text)
            => ConfidentialRawData = Encoding.UTF8.GetBytes(text);
        public int? Key { get; set; }
        public Bitmap Image { get; set; }
        public byte[] ConfidentialRawData { get; }

    }
}
