using CrystalOS2;
using IL2CPU.API.Attribs;
using System;
using System.Drawing;

class TTFReader
{
    [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.file.ttf")]
    public static byte[] fontData;

    public static void Main()
    {
        int imageSize = 256;
        char character = 'A';


            int numTables = ReadUShort(fontData, 4);
            int cmapOffset = 0, cmapLength = 0, glyfOffset = 0;

            for (int i = 0; i < numTables; i++)
            {
                int tableOffset = 12 + (i * 16);
                string tableName = ReadTag(fontData, tableOffset);

                if (tableName == "cmap")
                {
                    cmapOffset = ReadULong(fontData, tableOffset + 8);
                    cmapLength = ReadULong(fontData, tableOffset + 12);
                }
                else if (tableName == "glyf")
                {
                    glyfOffset = ReadULong(fontData, tableOffset + 8);
                }
            }

            int charCode = (int)character;
            int glyphIndex = FindGlyphIndex(fontData, cmapOffset, cmapLength, charCode);
        try
        {
            int glyphOffset = glyfOffset + ReadUInt(fontData, glyfOffset + (glyphIndex * 2)) * 2;
            int numberOfContours = ReadShort(fontData, glyphOffset);

            if (numberOfContours >= 0)
            {
                Console.WriteLine("Font does not have a glyph for the character.");
                return;
            }

            int xMin = ReadShort(fontData, glyphOffset + 2);
            int yMin = ReadShort(fontData, glyphOffset + 4);
            int xMax = ReadShort(fontData, glyphOffset + 6);
            int yMax = ReadShort(fontData, glyphOffset + 8);

            int width = xMax - xMin + 1;
            int height = yMax - yMin + 1;

            DrawGlyphPath(fontData, glyphOffset, Color.Black);
        }
        catch (Exception ex)
        {
            ImprovedVBE._DrawACSIIString(ex.Message, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
        }
    }

    static int FindGlyphIndex(byte[] fontData, int cmapOffset, int cmapLength, int charCode)
    {
        int tableEndOffset = cmapOffset + cmapLength;
        int numberOfSubtables = ReadUShort(fontData, cmapOffset + 2);

        for (int i = 0; i < numberOfSubtables; i++)
        {
            int subtableOffset = cmapOffset + 4 + (i * 8) + cmapOffset;
            int platformID = ReadUShort(fontData, subtableOffset);
            int platformSpecificID = ReadUShort(fontData, subtableOffset + 2);
            int subtableOffsetOffset = ReadULong(fontData, subtableOffset + 4);

            if ((platformID == 3 && (platformSpecificID == 1 || platformSpecificID == 0))
                || (platformID == 0 && platformSpecificID == 3))
            {
                int subtableFormat = ReadUShort(fontData, cmapOffset + subtableOffsetOffset);

                if (subtableFormat == 4)
                {
                    int segCount = ReadUShort(fontData, cmapOffset + subtableOffsetOffset + 6) / 2;

                    int[] endCodes = new int[segCount];
                    int[] startCodes = new int[segCount];
                    int[] idDeltas = new int[segCount];
                    int[] idRangeOffsets = new int[segCount];

                    Array.Copy(fontData, cmapOffset + subtableOffsetOffset + 14, endCodes, 0, segCount * 2);
                    Array.Copy(fontData, cmapOffset + subtableOffsetOffset + 16 + (segCount * 2), startCodes, 0, segCount * 2);
                    Array.Copy(fontData, cmapOffset + subtableOffsetOffset + 16 + (4 * segCount) + (2 * segCount), idDeltas, 0, segCount * 2);
                    Array.Copy(fontData, cmapOffset + subtableOffsetOffset + 16 + (6 * segCount) + (2 * segCount), idRangeOffsets, 0, segCount * 2);

                    for (int j = 0; j < segCount; j++)
                    {
                        if (charCode <= endCodes[j])
                        {
                            if (idRangeOffsets[j] == 0)
                            {
                                return (idDeltas[j] + charCode) % 65536;
                            }
                            else
                            {
                                int glyphOffset = cmapOffset + subtableOffsetOffset + 16 + (6 * segCount) + (4 * segCount) + ReadUShort(fontData, cmapOffset + subtableOffsetOffset + 16 + (6 * segCount) + (4 * segCount) + (idRangeOffsets[j] / 2) + ((charCode - startCodes[j]) * 2));
                                return (ReadUShort(fontData, glyphOffset) + idDeltas[j]) % 65536;
                            }
                        }
                    }
                }
                else if (subtableFormat == 6)
                {
                    int firstCode = fontData[cmapOffset + subtableOffsetOffset];
                    int entryCount = ReadUShort(fontData, cmapOffset + subtableOffsetOffset + 2);

                    if (charCode >= firstCode && charCode < firstCode + entryCount)
                    {
                        return ReadUShort(fontData, cmapOffset + subtableOffsetOffset + 4 + (charCode - firstCode) * 2);
                    }
                }
            }
        }

        return 0;
    }

    static void DrawGlyphPath(byte[] fontData, int glyphOffset, Color pen)
    {
        int numberOfContours = ReadShort(fontData, glyphOffset);

        for (int i = 0; i < numberOfContours; i++)
        {
            int endPtOffset = glyphOffset + 10 + (i * 2);
            int startPointIndex = ReadUShort(fontData, endPtOffset) + 1;

            for (int j = startPointIndex; j <= ReadUShort(fontData, endPtOffset + 2); j++)
            {
                int pointOffset = glyphOffset + 10 + (numberOfContours * 2) + (i * 2) + ((j - startPointIndex) * 2);

                int xCoord = ReadShort(fontData, pointOffset);
                int yCoord = ReadShort(fontData, pointOffset + 2);

                ImprovedVBE.DrawFilledRectangle(pen.ToArgb(), xCoord, yCoord, 1, 1);
            }
        }
    }

    static int ReadUShort(byte[] data, int offset)
    {
        return (data[offset] << 8) | data[offset + 1];
    }

    static int ReadShort(byte[] data, int offset)
    {
        return (short)((data[offset] << 8) | data[offset + 1]);
    }

    static int ReadUInt(byte[] data, int offset)
    {
        return (data[offset] << 24) | (data[offset + 1] << 16) | (data[offset + 2] << 8) | data[offset + 3];
    }

    static int ReadULong(byte[] data, int offset)
    {
        return (data[offset] << 56) | (data[offset + 1] << 48) | (data[offset + 2] << 40) | (data[offset + 3] << 32) | (data[offset + 4] << 24) | (data[offset + 5] << 16) | (data[offset + 6] << 8) | data[offset + 7];
    }

    static string ReadTag(byte[] data, int offset)
    {
        char[] tagChars = new char[4];
        for (int i = 0; i < 4; i++)
        {
            tagChars[i] = (char)(data[offset + i]);
        }

        return new string(tagChars);
    }
}