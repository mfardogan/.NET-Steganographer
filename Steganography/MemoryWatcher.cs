using System;
using System.Collections.Generic;
using System.Linq;

namespace Steganography
{
    internal struct MemoryWatcher
    {
        #region FIELDS
        bool[] bits;
        const char TRUELOGIC = '1';
        const char FALSELOGIC = '0';
        #endregion
        public MemoryWatcher(byte number) : this()
              => bits = Convert.ToString(number, 2)
                .PadLeft(8, FALSELOGIC).Select(dig => dig == TRUELOGIC ? true : false)
                .ToArray();
        public bool this[int index]
        {
            get => bits.Length <= index ? default : bits[index];
            set => bits[index] = value;
        }

        public int? Key { get; set; }
        public byte Decimal
        {
            get
            {
                byte data = Convert.ToByte(new string(bits.Select(bit => bit ? TRUELOGIC : FALSELOGIC).ToArray()), 2);
                return !Key.HasValue ? data : (byte)(data ^ Key.Value);
            }
        }

        public static implicit operator MemoryWatcher(byte number) => new MemoryWatcher(number);
        public static implicit operator MemoryWatcher(bool[] bits) => new MemoryWatcher() { bits = bits };
        public static implicit operator int(MemoryWatcher memoryWatcher) => Convert.ToInt32(memoryWatcher.Decimal);
    }
}
