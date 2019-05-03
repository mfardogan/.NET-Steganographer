using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Steganography
{
    public class SecretInformationStaganographer
    {
        #region FIELDS
        IConfidential confidential;
        #endregion

        public SecretInformationStaganographer(IConfidential confidential)
        {
            this.confidential = confidential;
            if (confidential.Key.HasValue && confidential.Key.Value < 1000)
            {
                throw new SteganographyException("The password specified for confidential information must be at least 999");
            }
        }
        /// <summary>
        /// Injects hidden data into the bitmap.
        /// </summary>
        /// <param name="cancellation">Token for operation cancellation.</param>
        /// <returns>Task</returns>
        public virtual Task<IConfidentialResult> Inject(CancellationToken cancellation)
        {
            Size size = confidential.Image.Size;
            if (size.Width * size.Height < confidential.ConfidentialRawData.Length + 4)
            {
                throw new SteganographyException("Confidential information is too large for cover image!");
            }

            Func<byte[], byte[]> addSizeInformationBytes = (bytes) =>
            {
                byte[] sizeOf = BitConverter.GetBytes(bytes.Length);
                Array.Reverse(sizeOf);

                var source = new byte[sizeOf.Length + bytes.Length];
                sizeOf.CopyTo(source, 0);
                bytes.CopyTo(source, sizeOf.Length);
                return source;
            };

            Bitmap content = new Bitmap(size.Width, size.Height);
            Queue<byte> pure = new Queue<byte>(addSizeInformationBytes(confidential.ConfidentialRawData));

            return Task<IConfidentialResult>.Factory.StartNew(() =>
            {
                for (int x = 0; x < size.Width; x++)
                {
                    for (int y = 0; y < size.Height; y++)
                    {
                        if (cancellation.IsCancellationRequested)
                        {
                            cancellation.ThrowIfCancellationRequested();
                        }

                        MemoryQuadruple secret = confidential.Image.GetPixel(x, y);
                        if (pure.Any()) { secret.Inject(pure.Dequeue(), confidential.Key); }
                        content.SetPixel(x, y, secret);
                    }
                }

                return new ConfidentialResult(content) { Key = confidential.Key };
            }, cancellation);
        }
    }
}
