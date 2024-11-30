using System;
using UnityEngine;

namespace FontRenderer
{

    // https://developer.apple.com/fonts/TrueType-Reference-Manual/RM06/Chap6.html Table 4
    public struct OffsetSubTable
    {
        public uint scalerType;
        public ushort numTables;
        public ushort searchRange;
        public ushort entrySelector;
        public ushort rangeShift;
    }
    // https://developer.apple.com/fonts/TrueType-Reference-Manual/RM06/Chap6.html Table 5
    public struct tableDirectory
    {
        public uint tag;
        public uint checkSum;
        public uint offset;
        public uint length;

    }
    // https://developer.apple.com/fonts/TrueType-Reference-Manual/RM06/Chap6.html Table 5 codeExample after
    public static class ChecksumCalculator
    {
        public static uint CalcTableChecksum(uint[] table, uint numberOfBytesInTable)
        {
            uint sum = 0;
            uint nLongs = (numberOfBytesInTable + 3) / 4;
            for (uint i = 0; i < nLongs; i++)
            {
                sum += table[i];
            }
            return sum;
        }
    }
}
