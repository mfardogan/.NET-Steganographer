using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Steganography
{
    public class ImageCoveredSteganography : Steganographer
    {
        /// <summary>
        /// Create a steganographer for injects hidden data into the bitmap.
        /// </summary>
        /// <param name="confidential">Secret data</param>
        /// <param name="cover">Cover image</param>
        public ImageCoveredSteganography(IConfidential confidential, Bitmap cover)
            : base(confidential) => CoverImage = cover;
        public Bitmap CoverImage { get; set; }

        /// <summary>
        /// Injects hidden data into the bitmap.
        /// </summary>
        /// <param name="cancellation">Token for operation cancellation.</param>
        /// <returns>Task</returns>
        public override Task<IConfidentialResult> Inject(CancellationToken cancellation)
        {
            Size size = CoverImage.Size;
            if (size.Width * size.Height < Confidential.RawData.Length + 4)
            {
                throw new SteganographyException("Confidential information is too large for cover image!");
            }

            Bitmap content = new Bitmap(size.Width, size.Height);
            Queue<byte> pure = new Queue<byte>(GetConfidentialRawDataWithSizeInformation());
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

                        MemoryQuadruple secret = CoverImage.GetPixel(x, y);
                        if (pure.Any()) { secret.Inject(pure.Dequeue(), Confidential.Key); }
                        content.SetPixel(x, y, secret);
                    }
                }

                return new ConfidentialResult(content) { Key = Confidential.Key };
            }, cancellation);
        }
    }
}
