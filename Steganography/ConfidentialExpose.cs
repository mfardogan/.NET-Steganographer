namespace Steganography
{
    public class ConfidentialExpose : IConfidentialExpose
    {
        public ConfidentialExpose(byte[] data) => RawData = data;
        public byte[] RawData { get; set; }
    }
}
