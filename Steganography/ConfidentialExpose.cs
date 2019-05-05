namespace Steganography
{
    public class ConfidentialExpose : IConfidentialExpose
    {
        public ConfidentialExpose(byte[] data) => ConfidentialRawData = data;
        public byte[] ConfidentialRawData { get; set; }
    }
}
