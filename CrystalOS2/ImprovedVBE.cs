using Cosmos.Core.IOGroup;
using Cosmos.HAL.Drivers;
using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using CrystalOS2;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = Cosmos.System.Graphics.Image;

namespace CrystalOS2
{
    public class ImprovedVBE
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.90_Style.bmp")] public static byte[] VBECanvas;
        //Comment out from here
        [ManifestResourceStream(ResourceName = "CrystalOS2.autumn.bmp")] public static byte[] autumn;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Midnight_in_NY.bmp")] public static byte[] midnight_in_NY;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Windows_puma.bmp")] public static byte[] Windows_Puma;

        [ManifestResourceStream(ResourceName = "CrystalOS2.Arial_16.btf")] public static byte[] Arial;
        //All the way to here

        //These are black images matching the size exacly the resolution
        public static Bitmap cover = new Bitmap(VBECanvas);//The base canvas
        public static Bitmap data = new Bitmap(VBECanvas);//To reset the base canvas
        //You could comment these out
        public static Bitmap data2 = new Bitmap(autumn);
        public static Bitmap data3 = new Bitmap(midnight_in_NY);
        public static Bitmap data4 = new Bitmap(Windows_Puma);
        //till here

        public static int width = 1024;
        public static int height = 768;

        public static void display(VBECanvas c)
        {
            c.DrawImage(cover, 0, 0);
            //clear(c, Color.Black);
            //cover.RawData = data.RawData;
            clear(c, Color.Black);
        }

        public static void clear(VBECanvas c, Color col)
        {
            int x = 0;
            if (Bool_Manager.wallp == "autumn")
            {
                data2.RawData.CopyTo(cover.RawData, 0);//Use one of these to copy the clean bitmap onto the used one.
            }
            else if (Bool_Manager.wallp == "90_Style")
            {
                /*
                foreach (int i in cover.RawData)
                {
                    cover.RawData[x] = data.RawData[x];
                    x++;
                }*/
                data.RawData.CopyTo(cover.RawData, 0);
            }
            else if (Bool_Manager.wallp == "Windows_Puma")
            {
                /*
                foreach (int i in cover.RawData)
                {
                    cover.RawData[x] = data4.RawData[x];
                    x++;
                }
                */
                data4.RawData.CopyTo(cover.RawData, 0);
            }
            else if (Bool_Manager.wallp == "Midnight_in_NY")
            {
                /*
                foreach (int i in cover.RawData)
                {
                    cover.RawData[x] = data3.RawData[x];
                    x++;
                }*/
                data3.RawData.CopyTo(cover.RawData, 0);
            }
            else if (Bool_Manager.wallp == "Lock_Screen")
            {
                /*
                foreach (int i in cover.RawData)
                {
                    cover.RawData[x] = Lock_Screen.screen.RawData[x];
                    x++;
                }*/
                //Lock_Screen.screen.RawData.CopyTo(cover.RawData, 0);
            }
        }
        public static void DrawPixelfortext(int x, int y, int color)
        {
            //16777215 white
            if (x > 0 && x < width && y > 0 && y < height)
            {
                cover.RawData[y * width + x] = color;
            }
        }

        public static void DrawFilledRectangle(int color, int X, int Y, int Width, int Height)
        {
            int r = (color & 0xff0000) >> 16;
            int g = (color & 0x00ff00) >> 8;
            int b = (color & 0x0000ff);

            float blendFactor = 0.5f;
            float inverseBlendFactor = 1 - blendFactor;

            for (int j = Y; j < Y + Height; j++)
            {
                for (int i = X; i < X + Width; i++)
                {
                    int r3 = (cover.RawData[j * width + i] & 0xff0000) >> 16;
                    int g3 = (cover.RawData[j * width + i] & 0x00ff00) >> 8;
                    int b3 = (cover.RawData[j * width + i] & 0x0000ff);
                    //Color c = Color.FromArgb(cover.RawData[j * width + i]);

                    int r2 = (int)(inverseBlendFactor * r3 + blendFactor * r);
                    int g2 = (int)(inverseBlendFactor * g3 + blendFactor * g);
                    int b2 = (int)(inverseBlendFactor * b3 + blendFactor * b);

                    DrawPixelfortext(i, j, colourToNumber(r2, g2, b2));
                }
            }
            /*
            if(X <= width)
            {
                int[] line = new int[Width];
                if(X < 0)
                {
                    line = new int[Width + X];
                }
                else if (X + Width > width)
                {
                    line = new int[Width - (X + Width - width)];
                }
                Array.Fill(line, color);

                for (int i = Y - 1; i < Y + Height - 1; i++)
                {
                    Array.Copy(line, 0, cover.RawData, (i * width) + X, line.Length);
                }
            }
            */
        }

        //Slower but can be improved with Array.Copy();
        public static void DrawImage(Image image, int x, int y)
        {
            int counter = 0;
            int prewy = y;
            for (int _y = y; _y < y + image.Height; _y++)
            {
                for (int _x = x; _x < x + image.Width; _x++)
                {
                    if ((_y * width) - (width - _x) < width * height)
                    {
                        if (_x > width || _x < 0)
                        {
                            //cover.RawData[((_y * width) - (width - _x))] = 0;
                            counter++;
                        }
                        else
                        {
                            cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                            counter++;
                        }
                    }
                }
                prewy++;
            }
        }
        public static void DrawImageArray(int Width, int Height, int[] RawData, int x, int y)
        {
            int counter = 0;
            int scan_line = 0;
            for (int _y = y; _y < y + Height; _y++)
            {
                int[] line = new int[Width];

                Array.Copy(RawData, scan_line * Width, line, 0, Width);

                if (line[0] != 0 || line[^1] != 0)
                {
                    line.CopyTo(cover.RawData, (_y - 1) * width + x);
                    //TODO: copy just a specific amount of length
                    counter += (int)Width;
                }
                else
                {
                    for (int _x = x; _x < x + Width; _x++)
                    {
                        if (_y <= height - 1)
                        {
                            if (_x <= width)
                            {
                                if (RawData[counter] == 0)
                                {
                                    counter++;
                                }
                                else
                                {
                                    cover.RawData[((_y * width) - (width - _x))] = RawData[counter];
                                    counter++;
                                }
                            }
                            else
                            {
                                counter++;
                            }
                        }
                        else
                        {
                            counter += (int)Width;
                        }
                    }
                }
                scan_line++;
            }
        }

        public static void DrawImageAlpha2(Image image, int x, int y)
        {
            int counter = 0;
            for (int _y = y; _y < y + image.Height; _y++)
            {
                for (int _x = x; _x < x + image.Width; _x++)
                {
                    if (_y <= height - 1)
                    {
                        if (_x <= width)
                        {
                            if (image.RawData[counter] == 0)
                            {
                                counter++;
                            }
                            else
                            {
                                cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                                counter++;
                            }
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        counter += (int)image.Width;
                    }
                }
            }
        }

        //Don't use this!
        public static void DrawImageAlpha(Image image, int x, int y)
        {
            int[] line = new int[image.Width];
            if(x < width)
            {
                if (x < 0)
                {
                    line = new int[image.Width + x];
                    x = 0;
                }
                else if (x + image.Width > width)
                {
                    line = new int[image.Width - (x + image.Width - width)];
                }

                int counter = 0;
                int scan_line = 0;
                for (int _y = y; _y < y + image.Height; _y++)
                {
                    Array.Copy(image.RawData, scan_line * image.Width, line, 0, line.Length);

                    if (line[0] != 0 || line[^1] != 0)
                    {
                        line.CopyTo(cover.RawData, (_y - 1) * width + x);
                        //TODO: copy just a specific amount of length
                        counter += (int)image.Width;
                    }
                    else
                    {
                        for (int _x = x; _x < x + image.Width; _x++)
                        {
                            if (_y <= height - 1)
                            {
                                if (_x <= width)
                                {
                                    if (image.RawData[counter] == 0)
                                    {
                                        counter++;
                                    }
                                    else
                                    {
                                        cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                                        counter++;
                                    }
                                }
                                else
                                {
                                    counter++;
                                }
                            }
                            else
                            {
                                counter += (int)image.Width;
                            }
                        }
                    }
                    scan_line++;
                }
            }
        }

        static string ASC16Base64 = "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AAB4zMzM2MzGxsbMAAAAAAAA/sbGwMDAwMDAwAAAAAAAAAAA/mxsbGxsbGwAAAAAAAAA/sZgMBgwYMb+AAAAAAAAAAAAftjY2NjYcAAAAAAAAAAAZmZmZmZ8YGDAAAAAAAAAAHbcGBgYGBgYAAAAAAAAAH4YPGZmZjwYfgAAAAAAAAA4bMbG/sbGbDgAAAAAAAA4bMbGxmxsbGzuAAAAAAAAHjAYDD5mZmZmPAAAAAAAAAAAAH7b29t+AAAAAAAAAAAAAwZ+29vzfmDAAAAAAAAAHDBgYHxgYGAwHAAAAAAAAAB8xsbGxsbGxsYAAAAAAAAAAP4AAP4AAP4AAAAAAAAAAAAYGH4YGAAA/wAAAAAAAAAwGAwGDBgwAH4AAAAAAAAADBgwYDAYDAB+AAAAAAAADhsbGBgYGBgYGBgYGBgYGBgYGBgYGNjY2HAAAAAAAAAAABgYAH4AGBgAAAAAAAAAAAAAdtwAdtwAAAAAAAAAOGxsOAAAAAAAAAAAAAAAAAAAAAAAABgYAAAAAAAAAAAAAAAAAAAAGAAAAAAAAAAADwwMDAwM7GxsPBwAAAAAANhsbGxsbAAAAAAAAAAAAABw2DBgyPgAAAAAAAAAAAAAAAAAfHx8fHx8fAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";
        static MemoryStream ASC16FontMS = new MemoryStream(Convert.FromBase64String(ASC16Base64));

        public static MemoryStream memoryStream = new MemoryStream(Arial);
        public static int Size = 16;
        public static string charset = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

        public static void _DrawACSIIString(string s, int x, int y, int color)
        {
            /*
            string[] lines = s.Split('\n');
            for (int l = 0; l < lines.Length; l++)
            {
                for (int c = 0; c < lines[l].Length; c++)
                {
                    int offset = (Encoding.ASCII.GetBytes(lines[l][c].ToString())[0] & 0xFF) * 16;
                    ASC16FontMS.Seek(offset, SeekOrigin.Begin);
                    byte[] fontbuf = new byte[16];
                    ASC16FontMS.Read(fontbuf, 0, fontbuf.Length);

                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((fontbuf[i] & (0x80 >> j)) != 0)
                            {
                                if (x + c * 8 > width)
                                {

                                }
                                else
                                {
                                    DrawPixelfortext((int)((x + j) + (c * 8)), (int)(y + i + (l * 16)), color);
                                }
                            }
                        }
                    }
                }
            }
            */

            foreach (char c in s)
            {
                if (c == '\n')
                {
                    y += 12;
                }
                else if (c == ' ')
                {
                    x += 10;
                }
                else
                {
                    int aIndex = charset.IndexOf(c);
                    int SizePerFont = Size * (Size / 8);
                    byte[] buffer = new byte[SizePerFont];
                    memoryStream.Seek(SizePerFont * aIndex, SeekOrigin.Begin);
                    memoryStream.Read(buffer, 0, buffer.Length);

                    for (int h = 0; h < Size; h++)
                    {
                        for (int aw = 0; aw < Size / 8; aw++)
                        {
                            for (int ww = 0; ww < 8; ww++)
                            {
                                if ((buffer[(h * (Size / 8)) + aw] & (0x80 >> ww)) != 0)
                                {
                                    DrawPixelfortext((aw * 8) + ww + x, h + y, color);
                                }
                            }
                        }
                    }
                    if (c == 'W' || c == 'w')
                    {
                        x += 13;
                    }
                    else
                    {
                        x += 9;
                    }
                }
            }
        }

        public static void ScaleImage(Image image, int x, int y)
        {
            int counter = 0;
            int counter2 = 1;
            int counter3 = 0;
            int h_pixel = 0;
            int prewy = y;
            for (int _y = y; _y < y + image.Height * 3; _y++)
            {
                for (int _x = x; _x < x + image.Width * 3; _x++)
                {
                    if ((_y * width) - (width - _x) < width * height)
                    {
                        if (_x > width)
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter2 % 3 == 0)
                            {
                                cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                                counter++;
                                counter2++;
                            }
                            else
                            {
                                cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                                counter2++;
                            }
                        }
                    }
                }
                counter -= (int)image.Width;
                _y += 1;
                for (int _x = x; _x < x + image.Width * 3; _x++)
                {
                    if ((_y * width) - (width - _x) < width * height)
                    {
                        if (_x > width)
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter2 % 3 == 0)
                            {
                                cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                                counter++;
                                counter2++;
                            }
                            else
                            {
                                cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                                counter2++;
                            }
                        }
                    }
                }
                counter -= (int)image.Width;
                _y += 1;
                for (int _x = x; _x < x + image.Width * 3; _x++)
                {
                    if ((_y * width) - (width - _x) < width * height)
                    {
                        if (_x > width)
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter2 % 3 == 0)
                            {
                                cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                                counter++;
                                counter2++;
                            }
                            else
                            {
                                cover.RawData[((_y * width) - (width - _x))] = image.RawData[counter];
                                counter2++;
                            }
                        }
                    }
                }
                counter2 = 1;
                prewy++;
            }
        }

        public static int colourToNumber(int r, int g, int b)
        {
            return (r << 16) + (g << 8) + (b);
        }

        public static void line(float x1, float y1, float x2, float y2, int color)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            float length = (float)Math.Sqrt(dx * dx + dy * dy);

            float angle = (float)Math.Atan2(dy, dx);

            for (float i = 0; i < length; i++)
            {
                ImprovedVBE.DrawPixelfortext((int)(x1 + Math.Cos(angle) * i), (int)(y1 + Math.Sin(angle) * i), color);
            }
        }

        /*public static void DrawFilledCircle(int X, int Y, int Width, int Height, int color)
        {
            int centerX = Width / 2;
            int centerY = Height / 2;
            int radius = Math.Min(centerX, centerY) - 10; // Subtracting a value to leave some margin

            // Draw the circle using vertical lines
            for (int x = centerX - radius; x <= centerX + radius; x++)
            {
                int deltaY = (int)Math.Sqrt(radius * radius - (x - centerX) * (x - centerX));
                for (int y = centerY - deltaY; y <= centerY + deltaY; y++)
                {
                    DrawPixelfortext(x + X, y + Y, color);
                }
            }
        }*/

        public static void DrawFilledEllipse(int xCenter, int yCenter, int yR, int xR, int color)
        {
            int r = (color & 0xff0000) >> 16;
            int g = (color & 0x00ff00) >> 8;
            int b = (color & 0x0000ff);

            float blendFactor = 0.5f;
            float inverseBlendFactor = 1 - blendFactor;
            for (int y = -yR; y <= yR; y++)
            {
                for (int x = -xR; x <= xR; x++)
                {
                    if ((x * x * yR * yR) + (y * y * xR * xR) <= yR * yR * xR * xR)
                    {
                        int r3 = (cover.RawData[(yCenter + y) * width + xCenter + x] & 0xff0000) >> 16;
                        int g3 = (cover.RawData[(yCenter + y) * width + xCenter + x] & 0x00ff00) >> 8;
                        int b3 = (cover.RawData[(yCenter + y) * width + xCenter + x] & 0x0000ff);
                        //Color c = Color.FromArgb(cover.RawData[j * width + i]);

                        int r2 = (int)(inverseBlendFactor * r3 + blendFactor * r);
                        int g2 = (int)(inverseBlendFactor * g3 + blendFactor * g);
                        int b2 = (int)(inverseBlendFactor * b3 + blendFactor * b);

                        DrawPixelfortext(xCenter + x, yCenter + y, colourToNumber(r2, g2, b2));

                        //DrawPixelfortext(xCenter + x, yCenter + y, color);
                    }
                }
            }
        }
    }
}
