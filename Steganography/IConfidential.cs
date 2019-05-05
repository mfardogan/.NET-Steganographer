using System.Drawing;

namespace Steganography
{
    public interface IConfidential
    {
        int? Key { get; set; }
        Bitmap Image { get; set; }
        byte[] ConfidentialRawData { get; }

    }
}
