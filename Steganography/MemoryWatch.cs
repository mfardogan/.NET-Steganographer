using System;
using System.Linq;

namespace Steganography
{
    internal struct MemoryWatch
    {
        #region FIELDS
        bool[] bits;
        const char TRUE = '1';
        const char FALSE = '0';
        #endregion
        public MemoryWatch(byte number) : this()
              => bits = Convert.ToString(number, 2)
                .PadLeft(8, FALSE).Select(dig => dig == TRUE ? true : false)
                .ToArray();
       
        #region Properties
        public bool this[int index]
        {
            get => bits.Length <= index ? default : bits[index];
            set => bits[index] = value;
        }

        public int? Key { get; set; }
        #endregion

        #region Operators
        public static implicit operator MemoryWatch(byte number) => new MemoryWatch(number);
        public static implicit operator MemoryWatch(bool[] bits) => new MemoryWatch() { bits = bits };

        public static implicit operator int(MemoryWatch memoryWatcher)
        {
            string binaryString = new string(memoryWatcher.bits
                .Select(bit => bit ? TRUE : FALSE)
                .ToArray());

            byte asByte = Convert.ToByte(binaryString, 2);
            return !memoryWatcher.Key.HasValue ? asByte : (byte)(asByte ^ memoryWatcher.Key.Value);
        } 
        #endregion
    }
}
