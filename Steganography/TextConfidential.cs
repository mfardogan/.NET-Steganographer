using System.Text;

namespace Steganography
{
    public class TextConfidential : IConfidential
    {
        public TextConfidential(string text)
            => RawData = Encoding.UTF8.GetBytes(text);
        public int? Key { get; set; }
        public byte[] RawData { get; }

    }
}
