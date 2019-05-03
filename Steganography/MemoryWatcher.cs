using System;
using System.Linq;

namespace Steganography
{
    internal struct MemoryWatcher
    {
        #region FIELDS
        bool[] bits;
        const char TRUE = '1';
        const char FALSE = '0';
        #endregion
        public MemoryWatcher(byte number) : this()
              => bits = Convert.ToString(number, 2)
                .PadLeft(8, FALSE).Select(dig => dig == TRUE ? true : false)
                .ToArray();
        public bool this[int index]
        {
            get => bits.Length <= index ? default : bits[index];
            set => bits[index] = value;
        }

        public int? Key { get; set; }

        public static implicit operator MemoryWatcher(byte number) => new MemoryWatcher(number);
        public static implicit operator MemoryWatcher(bool[] bits) => new MemoryWatcher() { bits = bits };

        public static implicit operator int(MemoryWatcher memoryWatcher)
        {
            string binaryString = new string(memoryWatcher.bits
                .Select(bit => bit ? TRUE : FALSE)
                .ToArray());

            byte asByte = Convert.ToByte(binaryString, 2);
            return !memoryWatcher.Key.HasValue ? asByte : (byte)(asByte ^ memoryWatcher.Key.Value);
        }
    }
}
