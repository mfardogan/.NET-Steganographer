using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Steganography
{
    public static class SecretInformationSteganographyExposer
    {
        static IEnumerable<MemoryQuadruple> GetQuadruples(Bitmap cover, int? key)
        {
            Func<int> getContentLength = () =>
            {
                MemoryQuadruple[] secretQuadruples = { cover.GetPixel(0, 0),
                    cover.GetPixel(0, 1),
                    cover.GetPixel(0, 2),
                    cover.GetPixel(0, 3)
                };

                byte[] buffer = secretQuadruples.Select(secretQuadruple => secretQuadruple.Attract(key: key)).ToArray();

                if (BitConverter.IsLittleEndian)
                    Array.Reverse(buffer);
                return BitConverter.ToInt32(buffer, 0) + 1;
            };

            int dot = -3;
            int content = getContentLength();
            List<MemoryQuadruple> bitQuadruples = new List<MemoryQuadruple>();

            for (int x = 0; x < cover.Width; x++)
            {
                for (int y = 0; y < cover.Height; y++)
                {
                    if (dot++ == content)
                        return bitQuadruples;

                    bitQuadruples.Add(cover.GetPixel(x, y));
                }
            }
            return bitQuadruples;
        }

        /// <summary>
        /// Returns the hidden data within bitmap.
        /// </summary>
        /// <param name="cover">Base image</param>
        /// <param name="key">Encryption key</param>
        /// <returns>ISteganographyExpose</returns>
        public static IConfidentialExpose Attract(Bitmap cover, int? key)
        {
            List<MemoryQuadruple> bitQuadruples = GetQuadruples(cover, key).ToList();
            IEnumerable<byte> bytes = bitQuadruples.GetRange(4, bitQuadruples.Count - 4).Select(x => x.Attract(key: key));

            IConfidentialExpose steganographyExpose = new ConfidentialExpose(bytes.ToArray());
            return steganographyExpose;
        }
    }
}
