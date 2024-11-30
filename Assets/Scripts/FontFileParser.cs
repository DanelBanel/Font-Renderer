using UnityEngine;

namespace FontRenderer
{
    public class FontFileParser
    {
        private FontFileReader fontReader;

        public FontFileParser(FontFileReader _fontReader)
        {
            this.fontReader = _fontReader;
        }

        public OffsetSubTable parseOffestSubTable()
        {
            OffsetSubTable offsetSubTable = new OffsetSubTable
            {
                scalerType = fontReader.ReadUInt32(),
                numTables = fontReader.ReadUInt16(),
                searchRange = fontReader.ReadUInt16(),
                entrySelector = fontReader.ReadUInt16(),
                rangeShift = fontReader.ReadUInt16()
            };
            Debug.Log($"offsetSubTable.scalerType : {offsetSubTable.scalerType}");
            Debug.Log($"offsetSubTable.numTables : {offsetSubTable.numTables}");
            Debug.Log($"offsetSubTable.scalesearchRangerType : {offsetSubTable.searchRange}");
            Debug.Log($"offsetSubTable.entrySelector : {offsetSubTable.entrySelector}");
            Debug.Log($"offsetSubTable.rangeShift : {offsetSubTable.rangeShift}");

            return offsetSubTable;
        }
    }
}
