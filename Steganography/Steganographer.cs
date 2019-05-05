using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Steganography
{
    public abstract class Steganographer
    {
        protected IConfidential Confidential { get; set; }
        public Steganographer(IConfidential confidential)
        {
            if (confidential.Key.HasValue && confidential.Key.Value < 1000)
            {
                throw new SteganographyException("The password specified for confidential information must be at least 999");
            }

            Confidential = confidential;
        }
        public abstract Task<IConfidentialResult> Inject(CancellationToken cancellation);

        protected byte[] GetConfidentialRawDataWithSizeInformation()
        {
            List<byte> bytes = new List<byte>(Confidential.RawData);
            bytes.InsertRange(0, BitConverter.GetBytes(Confidential.RawData.Length).Reverse().ToArray());
            return bytes.ToArray();
        }
    }
}
