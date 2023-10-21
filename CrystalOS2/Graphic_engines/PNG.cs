using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Graphic_engines
{
    class PNG
    {
        public static int Width = 0;
        public static int Height = 0;

        public static List<int> pixels = new List<int>();
        public static void FromPNG(byte[] Binary)
        {
            if (Binary[0] != 137 ||
            Binary[1] != 80 ||
            Binary[2] != 78 ||
            Binary[3] != 71 ||
            Binary[4] != 13 ||
            Binary[5] != 10 ||
            Binary[6] != 26 ||
            Binary[7] != 10)
            {
                throw new("Invalid header magic!");
            }

            BinaryReader Reader = new BinaryReader(new MemoryStream(Binary));
            Reader.BaseStream.Position = 8;
            bool calc = true;

            while (Reader.BaseStream.Position < Reader.BaseStream.Length)
            {
                uint Length = Reader.ReadUInt32();
                long Position = Reader.BaseStream.Position;
                bool IsDone = false;

                switch (Encoding.ASCII.GetString(Reader.ReadBytes(4)))
                {
                    case "IHDR":
                        ImprovedVBE._DrawACSIIString("IHDR", 10, 500, ImprovedVBE.colourToNumber(255, 255, 255));
                        Reader.BaseStream.Position = 18;//+=5
                        byte[] data2 = Reader.ReadBytes(2);
                        List<byte> reversed2 = new()
                        {
                            data2[1],
                            data2[0]
                        };
                        BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(reversed2.ToArray()));
                        binaryReader2.BaseStream.Position = 0;
                        Width = binaryReader2.ReadInt16();

                        Reader.BaseStream.Position += 2;

                        
                        //Height = Reader.ReadInt16();
                        byte[] data = Reader.ReadBytes(2);
                        List<byte> reversed = new()
                        {
                            data[1],
                            data[0]
                        };
                        BinaryReader binaryReader = new BinaryReader(new MemoryStream(reversed.ToArray()));
                        binaryReader.BaseStream.Position = 0;
                        Height = binaryReader.ReadInt16();
                        //reverse binary, feed binaryreader, output number
                        //Working idea!
                        Reader.BaseStream.Position = 74;
                        ImprovedVBE._DrawACSIIString(Encoding.ASCII.GetString(Reader.ReadBytes(4)), 10, 540, ImprovedVBE.colourToNumber(255, 255, 255));
                        Reader.BaseStream.Position = 78;

                        ImprovedVBE._DrawACSIIString("IDAT is here", 10, 540, ImprovedVBE.colourToNumber(255, 255, 255));
                        List<byte> Buffer = new();
                        Reader.BaseStream.Position += 2;
                        try
                        {
                            for (int i = 2; i < Length; i++)
                            {
                                Buffer.Add(Reader.ReadByte());
                            }
                        }
                        catch { }
                        List<byte> Data = DeflateStream.Inflate(Buffer);

                        BinaryReader D = new(new MemoryStream(Data.ToArray()));

                        var totalScanlines = Data.Count / (Width + 1) / 4;

                        var prevScanline = new List<byte>();

                        for (int y = 0; y < totalScanlines; y++)
                        {
                            var filter = D.ReadByte();

                            var dat = new List<byte>();

                            for (int x = 0; x < Width * 4; x++)
                            {
                                dat.Add(D.ReadByte());
                            }
                            var scanline = new List<byte>();

                            if (filter == 1)
                            {
                                scanline.Add(dat[0]);
                                for (var index = 1; index < dat.Count; index++)
                                {
                                    scanline.Add((byte)((scanline[index - 4 > 0 ? index - 4 : 0] + dat[index - 1]) % 256));
                                    //scanline.Add((byte) (255));
                                }
                            }
                            else if (filter == 2)
                            {
                                for (var index = 0; index < dat.Count; index++)
                                {
                                    scanline.Add((byte)((prevScanline[index] + dat[index]) % 256));
                                    //scanline.Add((byte) (255));
                                }
                            }
                            else
                            {
                            }

                            var line = new BinaryReader(new MemoryStream(scanline.ToArray()));
                            prevScanline.Clear();
                            prevScanline.AddRange(scanline);

                            for (int x = 0; x < Width; x++)
                            {
                                // Read ARGB color
                                pixels.Add((int)line.ReadUInt32());
                            }
                        }
                        /*
                        List<byte> Data = Buffer;

                        BinaryReader D = new(new MemoryStream(Data.ToArray()));

                        var totalScanlines = Data.Count / (Width + 1) / 4;

                        var prevScanline = new List<byte>();

                        for (int y = 0; y < totalScanlines; y++)
                        {
                            var filter = D.ReadByte();

                            var dat = new List<byte>();

                            for (int x = 0; x < Width * 4; x++)
                            {
                                dat.Add(D.ReadByte());
                            }
                            var scanline = new List<byte>();

                            if (filter == 1)
                            {
                                scanline.Add(dat[0]);
                                for (var index = 1; index < dat.Count; index++)
                                {
                                    scanline.Add((byte)((scanline[index - 4 > 0 ? index - 4 : 0] + dat[index - 1]) % 256));
                                    //scanline.Add((byte) (255));
                                }
                            }
                            else if (filter == 2)
                            {
                                for (var index = 0; index < dat.Count; index++)
                                {
                                    scanline.Add((byte)((prevScanline[index] + dat[index]) % 256));
                                    //scanline.Add((byte) (255));
                                }
                            }
                            else
                            {
                            }

                            var line = new BinaryReader(new MemoryStream(scanline.ToArray()));
                            prevScanline.Clear();
                            prevScanline.AddRange(scanline);

                            for (int x = 0; x < Width; x++)
                            {
                                // Read ARGB color
                                pixels.Add((int)line.ReadUInt32());
                            }
                        }
                        */
                        break;
                    case "PLTE":
                        break;
                    case "IEND":
                        IsDone = true;
                        break;
                }

                if (IsDone)
                {
                    break;
                }

                ImprovedVBE._DrawACSIIString("Width: " + Width, 10, 560, ImprovedVBE.colourToNumber(255, 255, 255));
                ImprovedVBE._DrawACSIIString("Height: " + Height, 10, 575, ImprovedVBE.colourToNumber(255, 255, 255));

                Reader.BaseStream.Position = (int)(Position + Length) + 4;
            }

            Reader.BaseStream.Position = 8;

            int counter = 0;

            for(int i = 0; i < Binary.Length; i++)
            {
                if (Binary[i] == 7d)
                {
                    counter = i;
                    i = Binary.Length + 5;
                }
            }

            //ImprovedVBE._DrawACSIIString("IDAT is here: " + counter, 10, 540, ImprovedVBE.colourToNumber(255, 255, 255));

            if (Encoding.ASCII.GetString(Binary).Contains("IDAT"))
            {
                //ImprovedVBE._DrawACSIIString("IDAT is here", 10, 540, ImprovedVBE.colourToNumber(255, 255, 255));
            }

            foreach(int i in pixels)
            {
                int x = 50;
                ImprovedVBE.DrawPixelfortext(x, 500, i);
                x++;
            }

        }
    }
}

public class DeflateStream
{
    /// <summary>
    /// Decode deflated data.
    /// </summary>
    /// <param name="compressed">deflated input data</param>
    /// <returns>uncompressed output</returns>
    public static List<byte> Inflate(IList<byte> compressed)
    {
        return new DeflateStream { In = compressed }.Inflate();
    }

    #region Internal

    // fast-way is faster to check than jpeg huffman, but slow way is slower
    private const int FastBits = 9; // accelerate all cases in default tables
    private const int FastMask = (1 << FastBits) - 1;

    private static readonly int[] DistExtra = new[]
    {
        0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9,
        10, 10, 11, 11, 12, 12, 13, 13
    };

    private static readonly int[] LengthBase = new[]
    {
        3, 4, 5, 6, 7, 8, 9, 10, 11, 13,
        15, 17, 19, 23, 27, 31, 35, 43, 51, 59,
        67, 83, 99, 115, 131, 163, 195, 227, 258, 0, 0
    };

    private static readonly int[] LengthExtra = new[]
    {
        0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4,
        4, 4, 4, 5, 5, 5, 5, 0, 0, 0
    };

    private static readonly int[] DistBase = new[]
    {
        1, 2, 3, 4, 5, 7, 9, 13, 17, 25, 33, 49, 65, 97, 129, 193,
        257, 385, 513, 769, 1025, 1537, 2049, 3073, 4097, 6145, 8193,
        12289, 16385, 24577, 0, 0
    };

    private static readonly int[] LengthDezigzag = new[]
    {
        16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2,
        14,
        1, 15
    };

    // @TODO: should statically initialize these for optimal thread safety
    private static readonly byte[] DefaultLength = new byte[288];
    private static readonly byte[] DefaultDistance = new byte[32];

    private IList<byte> In = new List<byte>();
    private List<byte> Out = new();
    private uint CodeBuffer;
    private int NumBits;

    private Huffman Distance = new(new());
    private Huffman Length = new(new());

    private int InPos;

    private static void InitDefaults()
    {
        int i; // use <= to match clearly with spec
        for (i = 0; i <= 143; ++i) DefaultLength[i] = 8;
        for (; i <= 255; ++i) DefaultLength[i] = 9;
        for (; i <= 279; ++i) DefaultLength[i] = 7;
        for (; i <= 287; ++i) DefaultLength[i] = 8;

        for (i = 0; i <= 31; ++i) DefaultDistance[i] = 5;
    }

    private static int BitReverse16(int n)
    {
        n = (n & 0xAAAA) >> 1 | (n & 0x5555) << 1;
        n = (n & 0xCCCC) >> 2 | (n & 0x3333) << 2;
        n = (n & 0xF0F0) >> 4 | (n & 0x0F0F) << 4;
        n = (n & 0xFF00) >> 8 | (n & 0x00FF) << 8;
        return n;
    }

    private static int BitReverse(int v, int bits)
    {
        //  Debug.Assert(bits <= 16);
        // to bit reverse n bits, reverse 16 and shift
        // e.g. 11 bits, bit reverse and shift away 5
        return BitReverse16(v) >> 16 - bits;
    }

    private int Get8()
    {
        return InPos >= In.Count ? 0 : In[InPos++];
    }

    private void FillBits()
    {
        do
        {
            // Debug.Assert(CodeBuffer < (1U << NumBits));
            CodeBuffer |= (uint)(Get8() << NumBits);
            NumBits += 8;
        } while (NumBits <= 24);
    }

    private uint Receive(int n)
    {
        if (NumBits < n) FillBits();
        var k = (uint)(CodeBuffer & (1 << n) - 1);
        CodeBuffer >>= n;
        NumBits -= n;
        return k;
    }

    private int HuffmanDecode(Huffman z)
    {
        int s;
        if (NumBits < 16) FillBits();
        int b = z.Fast[CodeBuffer & FastMask];
        if (b < 0xffff)
        {
            s = z.Size[b];
            CodeBuffer >>= s;
            NumBits -= s;
            return z.Value[b];
        }

        // not resolved by fast table, so compute it the slow way
        // use jpeg approach, which requires MSbits at top
        int k = BitReverse((int)CodeBuffer, 16);

        for (s = FastBits + 1; ; ++s)
        {
            if (k < z.MaxCode[s])
                break;
        }

        if (s == 16) return -1; // invalid code!
                                // code size is s, so:
        b = (k >> 16 - s) - z.FirstCode[s] + z.FirstSymbol[s];
        //  Debug.Assert(z.Size[b] == s);
        CodeBuffer >>= s;
        NumBits -= s;
        return z.Value[b];
    }

    private void ParseHuffmanBlock()
    {
        for (; ; )
        {
            int z = HuffmanDecode(Length);
            if (z < 256)
            {
                if (z < 0) throw new Exception("bad huffman code"); // error in huffman codes
                Out.Add((byte)z);
            }
            else
            {
                if (z == 256) return;
                z -= 257;
                int len = LengthBase[z];
                if (LengthExtra[z] != 0) len += (int)Receive(LengthExtra[z]);
                z = HuffmanDecode(Distance);
                if (z < 0) throw new Exception("bad huffman code");
                int dist = DistBase[z];
                if (DistExtra[z] != 0) dist += (int)Receive(DistExtra[z]);
                dist = Out.Count - dist;
                if (dist < 0) throw new Exception("bad dist");
                for (int i = 0; i < len; i++, dist++)
                    Out.Add(Out[dist]);
            }
        }
    }

    private void ComputeHuffmanCodes()
    {
        var lenCodes = new byte[286 + 32 + 137]; //padding for maximum single op
        var codeLengthSizes = new byte[19];

        uint hlit = Receive(5) + 257;
        uint hdist = Receive(5) + 1;
        uint hclen = Receive(4) + 4;

        for (int i = 0; i < hclen; ++i)
            codeLengthSizes[LengthDezigzag[i]] = (byte)Receive(3);

        var codeLength = new Huffman(new ArraySegment<byte>(codeLengthSizes));

        int n = 0;
        while (n < hlit + hdist)
        {
            int c = HuffmanDecode(codeLength);
            // Debug.Assert(c >= 0 && c < 19);
            if (c < 16)
            {
                lenCodes[n++] = (byte)c;
            }
            else if (c == 16)
            {
                c = (int)Receive(2) + 3;
                for (int i = 0; i < c; i++) lenCodes[n + i] = lenCodes[n - 1];
                n += c;
            }
            else if (c == 17)
            {
                c = (int)Receive(3) + 3;
                for (int i = 0; i < c; i++) lenCodes[n + i] = 0;
                n += c;
            }
            else
            {
                //Debug.Assert(c == 18);
                c = (int)Receive(7) + 11;
                for (int i = 0; i < c; i++) lenCodes[n + i] = 0;
                n += c;
            }
        }
        if (n != hlit + hdist) throw new Exception("bad codelengths");
        Length = new Huffman(new ArraySegment<byte>(lenCodes, 0, (int)hlit));
        Distance = new Huffman(new ArraySegment<byte>(lenCodes, (int)hlit, (int)hdist));
    }

    private void ParseUncompressedBlock()
    {
        var header = new byte[4];
        if ((NumBits & 7) != 0)
            Receive(NumBits & 7); // discard
                                  // drain the bit-packed data into header
        int k = 0;
        while (NumBits > 0)
        {
            header[k++] = (byte)(CodeBuffer & 255); // wtf this warns?
            CodeBuffer >>= 8;
            NumBits -= 8;
        }
        //Debug.Assert(NumBits == 0);
        // now fill header the normal way
        while (k < 4)
        {
            header[k++] = (byte)Get8();
        }

        int len = (header[1] * 256) + header[0];
        int nlen = (header[3] * 256) + header[2];

        if (nlen != (len ^ 0xffff)) throw new Exception("zlib corrupt");
        if (InPos + len > In.Count) throw new Exception("read past buffer");

        for (int i = InPos; i < InPos + len; i++)
        {
            Out.Add(In[i]);
        }
        InPos += len;
    }

    private List<byte> Inflate()
    {
        Out = new List<byte>();
        NumBits = 0;
        CodeBuffer = 0;

        bool final;
        do
        {
            final = Receive(1) != 0;
            var type = (int)Receive(2);
            if (type == 0)
            {
                ParseUncompressedBlock();
            }
            else if (type == 3)
            {
                throw new Exception("invalid block type");
            }
            else
            {
                if (type == 1)
                {
                    // use fixed code lengths
                    if (DefaultDistance[31] == 0) InitDefaults();
                    Length = new Huffman(new ArraySegment<byte>(DefaultLength));
                    Distance = new Huffman(new ArraySegment<byte>(DefaultDistance));
                }
                else
                {
                    ComputeHuffmanCodes();
                }
                ParseHuffmanBlock();
            }
        } while (!final);

        return Out;
    }

    private class Huffman
    {
        public readonly ushort[] Fast = new ushort[1 << FastBits];
        public readonly ushort[] FirstCode = new ushort[16];
        public readonly ushort[] FirstSymbol = new ushort[16];
        public readonly int[] MaxCode = new int[17];
        public readonly byte[] Size = new byte[288];
        public readonly ushort[] Value = new ushort[288];

        public Huffman(ArraySegment<byte> sizeList)
        {
            if (sizeList.Array == null)
            {
                return;
            }

            int i;
            int k = 0;
            var nextCode = new int[16];
            var sizes = new int[17];

            // DEFLATE spec for generating codes
            for (i = 0; i < Fast.Length; i++) Fast[i] = 0xffff;
            for (i = 0; i < sizeList.Count; ++i)
                ++sizes[sizeList.Array[i + sizeList.Offset]];
            sizes[0] = 0;
            /*   for (i = 1; i < 16; ++i)
                   Debug.Assert(sizes[i] <= (1 << i));*/
            int code = 0;
            for (i = 1; i < 16; ++i)
            {
                nextCode[i] = code;
                FirstCode[i] = (ushort)code;
                FirstSymbol[i] = (ushort)k;
                code += sizes[i];
                if (sizes[i] != 0)
                    if (code - 1 >= 1 << i) throw new Exception("bad codelengths");
                MaxCode[i] = code << 16 - i; // preshift for inner loop
                code <<= 1;
                k += sizes[i];
            }
            MaxCode[16] = 0x10000; // sentinel
            for (i = 0; i < sizeList.Count; ++i)
            {
                int s = sizeList.Array[i + sizeList.Offset];
                if (s != 0)
                {
                    int c = nextCode[s] - FirstCode[s] + FirstSymbol[s];
                    Size[c] = (byte)s;
                    Value[c] = (ushort)i;
                    if (s <= FastBits)
                    {
                        int j = BitReverse(nextCode[s], s);
                        while (j < 1 << FastBits)
                        {
                            Fast[j] = (ushort)c;
                            j += 1 << s;
                        }
                    }
                    ++nextCode[s];
                }
            }
        }
    }

    #endregion
}