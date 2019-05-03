using System.Drawing;

namespace Steganography
{
    public interface IConfidentialResult
    {
        Bitmap Image { get;  }
        int? Key { get; set; }
    }
}
