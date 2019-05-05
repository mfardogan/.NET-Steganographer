using System.Drawing;

namespace Steganography
{
    internal struct MemoryByteQuadruple
    {
        #region FILEDS
        public const int LSB1 = 6;
        public const int LSB2 = 7;
        MemoryWatch A, R, G, B;
        #endregion
        public MemoryByteQuadruple(Color current) : this()
        {
            A = current.A;
            R = current.R;
            G = current.G;
            B = current.B;
        }

        /// <summary>
        /// It stores confidential information in the byte.
        /// </summary>
        /// <param name="data">Confidential information</param>
        /// <param name="key">Encryption key</param>
        public void Inject(byte data, int? key)
        {
            if (key.HasValue) { data = (byte)(data ^ key.Value); }

            MemoryWatch memoryWatcher = data;

            A[LSB1] = memoryWatcher[0];
            A[LSB2] = memoryWatcher[1];

            R[LSB1] = memoryWatcher[2];
            R[LSB2] = memoryWatcher[3];

            G[LSB1] = memoryWatcher[4];
            G[LSB2] = memoryWatcher[5];

            B[LSB1] = memoryWatcher[6];
            B[LSB2] = memoryWatcher[7];
        }

        /// <summary>
        /// It gives confidential information from byte.
        /// </summary>
        /// <param name="key">Encryption key</param>
        /// <returns>Byte</returns>
        public byte Attract(int? key)
        {
            MemoryWatch memoryWatcher = new bool[] {
                A[LSB1], A[LSB2],
                R[LSB1], R[LSB2],
                G[LSB1], G[LSB2],
                B[LSB1], B[LSB2] };

            if (!key.HasValue)
            {
                return (byte)memoryWatcher;
            }

            return (byte)(memoryWatcher ^ key.Value);
        }

        #region Operators
        public static implicit operator MemoryByteQuadruple(Color color) => new MemoryByteQuadruple(color);
        public static implicit operator Color(MemoryByteQuadruple memoryQuadruple) => Color.FromArgb(memoryQuadruple.A, memoryQuadruple.R, memoryQuadruple.G, memoryQuadruple.B); 
        #endregion
    }
}
