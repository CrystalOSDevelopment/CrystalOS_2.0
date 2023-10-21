using Cosmos.Core.IOGroup;
using Cosmos.HAL.Drivers;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using CrystalOS2.SystemFiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = Cosmos.System.Graphics.Image;
using MOOS.Misc;

namespace CrystalOS2
{
    public class ImprovedVBE
    {
        //public static byte[] frame_buffer;
        //public static Bitmap frame = new Bitmap(frame_buffer);

        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.90_Style.bmp")] public static byte[] Canvas;
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.autumn.bmp")] public static byte[] autumn;
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Midnight_in_NY.bmp")] public static byte[] midnight_in_NY;
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Windows_puma.bmp")] public static byte[] Windows_Puma;
        //public static int[] data;
        public static Bitmap cover = new Bitmap(Canvas);
        public static Bitmap data = new Bitmap(Canvas);
        public static Bitmap data2 = new Bitmap(autumn);
        public static Bitmap data3 = new Bitmap(midnight_in_NY);
        public static Bitmap data4 = new Bitmap(Windows_Puma);

        public void init()
        {
            //cover = new Bitmap(Canvas);
        }
        public void display(Canvas c)
        {
            c.DrawImage(cover, 1, 1);
            //clear(c, Color.Black);
            //cover.RawData = data.RawData;
            clear(c, Color.Black);
        }

        public static void clear(Canvas c, Color col)
        {
            int x = 0;
            if(Bool_Manager.wallp == "autumn")
            {
                /*
                foreach (int i in cover.RawData)
                {
                    cover.RawData[x] = data2.RawData[x];
                    x++;
                }*/
                data2.RawData.CopyTo(cover.RawData, 0);
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
            else if(Bool_Manager.wallp == "Lock_Screen")
            {
                /*
                foreach (int i in cover.RawData)
                {
                    cover.RawData[x] = Lock_Screen.screen.RawData[x];
                    x++;
                }*/
                Lock_Screen.screen.RawData.CopyTo(cover.RawData, 0);
            }
        }
        public static void DrawPixel(Canvas c, int x, int y, Color col)
        {
            if (y * 1920 == 0)
            {
                y = 1;
                cover.RawData[x * y] = col.ToArgb();
            }
            else
            {
                cover.RawData[(y * 1920) - (1920 - x)] = col.ToArgb();
            }
        }
        public static void DrawPixelfortext(int x, int y, int color)
        {
            //16777215 white
            try
            {
                if((y * 1920) - (1920 - x) < 1920 * 1080)
                {
                    if (y * 1920 == 0)
                    {
                        y = 1;
                        cover.RawData[x * y] = color;
                    }
                    else
                    {
                        cover.RawData[(y * 1920) - (1920 - x)] = color;
                    }
                }
            }
            catch { }
        }

        public static void DrawFilledRectangle(int color, int X, int Y, int Width, int Height)
        {
            for (int j = Y; j < Y + Height; j++)
            {
                for (int i = X; i < X + Width; i++)
                {
                    try
                    {
                        cover.RawData[(j * 1920) - (1920 - i)] = color;
                    }
                    catch
                    {

                    }
                }
            }
        }
        /*public static void DrawLine(int color, int dx, int dy, int x1, int y1)
        {
            //DrawFilledRectangle(color, X, Y, 1, Height);

            int i, sdx, sdy, dxabs, dyabs, x, y, px, py;

            dxabs = Math.Abs(dx);
            dyabs = Math.Abs(dy);
            sdx = Math.Sign(dx);
            sdy = Math.Sign(dy);
            x = dyabs >> 1;
            y = dxabs >> 1;
            px = x1;
            py = y1;

            if (dxabs >= dyabs) /* the line is more horizontal than vertical /
            {
                for (i = 0; i < dxabs; i++)
                {
                    y += dyabs;
                    if (y >= dxabs)
                    {
                        y -= dxabs;
                        py += sdy;
                    }
                    px += sdx;
                    DrawPixelfortext(px, py, color);
                }
            }
            else /* the line is more vertical than horizontal /
            {
                for (i = 0; i < dyabs; i++)
                {
                    x += dxabs;
                    if (x >= dyabs)
                    {
                        x -= dyabs;
                        px += sdx;
                    }
                    py += sdy;
                    DrawPixelfortext(px, py, color);
                }
            }
        }*/

        public static void DrawDiagonalLine(int color, int dx, int dy, int x1, int y1)
        {
            int i, sdx, sdy, dxabs, dyabs, x, y, px, py;

            dxabs = Math.Abs(dx);
            dyabs = Math.Abs(dy);
            sdx = Math.Sign(dx);
            sdy = Math.Sign(dy);
            x = dyabs >> 1;
            y = dxabs >> 1;
            px = x1;
            py = y1;

            if (dxabs >= dyabs) /* the line is more horizontal than vertical */
            {
                for (i = 0; i < dxabs; i++)
                {
                    y += dyabs;
                    if (y >= dxabs)
                    {
                        y -= dxabs;
                        py += sdy;
                    }
                    px += sdx;
                    DrawPixelfortext(px, py, color);
                }
            }
            else /* the line is more vertical than horizontal */
            {
                for (i = 0; i < dyabs; i++)
                {
                    x += dxabs;
                    if (x >= dyabs)
                    {
                        x -= dyabs;
                        px += sdx;
                    }
                    py += sdy;
                    DrawPixelfortext(px, py, color);
                }
            }
        }

        public static void TrimLine(ref int x1, ref int y1, ref int x2, ref int y2)
        {
            // in case of vertical lines, no need to perform complex operations
            if (x1 == x2)
            {
                x1 = (int)Math.Min(1920 - 1, Math.Max(0, x1));
                x2 = x1;
                y1 = (int)Math.Min(1080 - 1, Math.Max(0, y1));
                y2 = (int)Math.Min(1080 - 1, Math.Max(0, y2));

                return;
            }

            // never attempt to remove this part,
            // if we didn't calculate our new values as floats, we would end up with inaccurate output
            float x1_out = x1, y1_out = y1;
            float x2_out = x2, y2_out = y2;

            // calculate the line slope, and the entercepted part of the y axis
            float m = (y2_out - y1_out) / (x2_out - x1_out);
            float c = y1_out - m * x1_out;

            // handle x1
            if (x1_out < 0)
            {
                x1_out = 0;
                y1_out = c;
            }
            else if (x1_out >= 1920)
            {
                x1_out = 1920 - 1;
                y1_out = (1920 - 1) * m + c;
            }

            // handle x2
            if (x2_out < 0)
            {
                x2_out = 0;
                y2_out = c;
            }
            else if (x2_out >= 1920)
            {
                x2_out = 1920 - 1;
                y2_out = (1920 - 1) * m + c;
            }

            // handle y1
            if (y1_out < 0)
            {
                x1_out = -c / m;
                y1_out = 0;
            }
            else if (y1_out >= 1080)
            {
                x1_out = (1080 - 1 - c) / m;
                y1_out = 1080 - 1;
            }

            // handle y2
            if (y2_out < 0)
            {
                x2_out = -c / m;
                y2_out = 0;
            }
            else if (y2_out >= 1080)
            {
                x2_out = (1080 - 1 - c) / m;
                y2_out = 1080 - 1;
            }

            // final check, to avoid lines that are totally outside bounds
            if (x1_out < 0 || x1_out >= 1920 || y1_out < 0 || y1_out >= 1080)
            {
                x1_out = 0; x2_out = 0;
                y1_out = 0; y2_out = 0;
            }

            if (x2_out < 0 || x2_out >= 1920 || y2_out < 0 || y2_out >= 1080)
            {
                x1_out = 0; x2_out = 0;
                y1_out = 0; y2_out = 0;
            }

            // replace inputs with new values
            x1 = (int)x1_out; y1 = (int)y1_out;
            x2 = (int)x2_out; y2 = (int)y2_out;
        }

        public static void DrawHorizontalLine(int color, int dx, int x1, int y1)
        {
            uint i;

            for (i = 0; i < dx; i++)
            {
                DrawPixelfortext((int)(x1 + i), y1, color);
            }
        }
        public static void DrawVerticalLine(int color, int dy, int x1, int y1)
        {
            int i;

            for (i = 0; i < dy; i++)
            {
                DrawPixelfortext((int)x1, (int)(y1 + i), color);
            }
        }

        public static void DrawLine(int color, int x1, int y1, int x2, int y2)
        {
            // trim the given line to fit inside the canvas boundries
            TrimLine(ref x1, ref y1, ref x2, ref y2);

            int dx, dy;

            dx = x2 - x1;      /* the horizontal distance of the line */
            dy = y2 - y1;      /* the vertical distance of the line */

            if (dy == 0) /* The line is horizontal */
            {
                DrawHorizontalLine(color, dx, x1, y1);
                return;
            }

            if (dx == 0) /* the line is vertical */
            {
                DrawVerticalLine(color, dy, x1, y1);
                return;
            }

            /* the line is neither horizontal neither vertical, is diagonal then! */
            DrawDiagonalLine(color, dx, dy, x1, y1);
        }

        public static void DrawImage(Image image, int x, int y)
        {
            int counter = 0;
            int prewy = y;
            for (int _y = y; _y < y + image.Height; _y++)
            {
                for (int _x = x; _x < x + image.Width; _x++)
                {
                    if ((_y * 1920) - (1920 - _x) < 1920 * 1080)
                    {
                        if (_x > 1900)
                        {
                            //cover.RawData[((_y * 1920) - (1920 - _x))] = 0;
                            counter++;
                        }
                        else
                        {
                            cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
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
            int prewy = y;
            for (int _y = y; _y < y + Height; _y++)
            {
                for (int _x = x; _x < x + Width; _x++)
                {
                    if ((_y * 1920) - (1920 - _x) < 1920 * 1080)
                    {
                        if (_x > 1900)
                        {
                            cover.RawData[((_y * 1920) - (1920 - _x))] = 0;
                            counter++;
                        }
                        else
                        {
                            cover.RawData[((_y * 1920) - (1920 - _x))] = RawData[counter];
                            counter++;
                        }
                    }
                }
                prewy++;
            }
        }

        public static void DrawImageAlpha2(Image image, int x, int y)
        {
            int counter = 0;
            for (int _y = y; _y < y + image.Height; _y++)
            {
                for (int _x = x; _x < x + image.Width; _x++)
                {
                    if (_y <= 1079)
                    {
                        if (_x <= 1920)
                        {
                            if (image.RawData[counter] == 0)
                            {
                                counter++;
                            }
                            else
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = 0;
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

        public static void DrawImageAlpha(Image image, int x, int y)
        {
            int counter = 0;
            for (int _y = y; _y < y + image.Height; _y++)
            {
                for (int _x = x; _x < x + image.Width; _x++)
                {
                    if (_y <= 1079)
                    {
                        if (_x <= 1920)
                        {
                            if (image.RawData[counter] == 0)
                            {
                                counter++;
                            }
                            else
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
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

        static string ASC16Base64 = "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AAB4zMzM2MzGxsbMAAAAAAAA/sbGwMDAwMDAwAAAAAAAAAAA/mxsbGxsbGwAAAAAAAAA/sZgMBgwYMb+AAAAAAAAAAAAftjY2NjYcAAAAAAAAAAAZmZmZmZ8YGDAAAAAAAAAAHbcGBgYGBgYAAAAAAAAAH4YPGZmZjwYfgAAAAAAAAA4bMbG/sbGbDgAAAAAAAA4bMbGxmxsbGzuAAAAAAAAHjAYDD5mZmZmPAAAAAAAAAAAAH7b29t+AAAAAAAAAAAAAwZ+29vzfmDAAAAAAAAAHDBgYHxgYGAwHAAAAAAAAAB8xsbGxsbGxsYAAAAAAAAAAP4AAP4AAP4AAAAAAAAAAAAYGH4YGAAA/wAAAAAAAAAwGAwGDBgwAH4AAAAAAAAADBgwYDAYDAB+AAAAAAAADhsbGBgYGBgYGBgYGBgYGBgYGBgYGNjY2HAAAAAAAAAAABgYAH4AGBgAAAAAAAAAAAAAdtwAdtwAAAAAAAAAOGxsOAAAAAAAAAAAAAAAAAAAAAAAABgYAAAAAAAAAAAAAAAAAAAAGAAAAAAAAAAADwwMDAwM7GxsPBwAAAAAANhsbGxsbAAAAAAAAAAAAABw2DBgyPgAAAAAAAAAAAAAAAAAfHx8fHx8fAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";
        static MemoryStream ASC16FontMS = new MemoryStream(Convert.FromBase64String(ASC16Base64));

        public static void _DrawACSIIString(string s, int x, int y, int color)
        {
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
                                if(x + c * 8 > 1920)
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
        }

        public static void getimagepart(Bitmap image, int x, int y, int width, int height, int draw_x, int draw_y)
        {
            int counter = 0;
            for (int _y = draw_y; _y < draw_y + image.Height; _y++)
            {
                for (int _x = draw_x; _x < draw_x + image.Width; _x++)
                {
                    if(_y >= draw_y + y && _y <= draw_y + y + height)
                    {
                        if (_x >= draw_x + x && _x <= draw_x + x + width)
                        {
                            if (image.RawData[counter] == 0)
                            {
                                counter++;
                            }
                            else
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
                                counter++;
                                draw_x++;
                            }
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        counter++;
                    }
                }
                draw_y++;
            }
        }

        public static int[] temp;
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
                    if ((_y * 1920) - (1920 - _x) < 1920 * 1080)
                    {
                        if (_x > 1920)
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter2 % 3 == 0)
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
                                counter++;
                                counter2++;
                            }
                            else
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
                                counter2++;
                            }
                        }
                    }
                }
                counter -= (int)image.Width;
                _y += 1;
                for (int _x = x; _x < x + image.Width * 3; _x++)
                {
                    if ((_y * 1920) - (1920 - _x) < 1920 * 1080)
                    {
                        if (_x > 1920)
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter2 % 3 == 0)
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
                                counter++;
                                counter2++;
                            }
                            else
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
                                counter2++;
                            }
                        }
                    }
                }
                counter -= (int)image.Width;
                _y += 1;
                for (int _x = x; _x < x + image.Width * 3; _x++)
                {
                    if ((_y * 1920) - (1920 - _x) < 1920 * 1080)
                    {
                        if (_x > 1920)
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter2 % 3 == 0)
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
                                counter++;
                                counter2++;
                            }
                            else
                            {
                                cover.RawData[((_y * 1920) - (1920 - _x))] = image.RawData[counter];
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
    }
}
