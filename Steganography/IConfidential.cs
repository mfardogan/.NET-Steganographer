using System.Drawing;

namespace Steganography
{
    public interface IConfidential
    {
        int? Key { get; set; }
        byte[] RawData { get; }
    }
}
