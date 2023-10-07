using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrystalOS2.Applications.Word_Processor
{
    public class Word_processor
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Word_Processor.app.bmp")] public static byte[] back;
        public static Bitmap bmp = new Bitmap(back);

        //public static string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        #region fonts
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Word_Processor.file.ttf")] public static byte[] Arial;
        #endregion fonts

        public static string sample = "";
        public static int[] buffer = new int[1024 * 749];

        public static int[] dropdown = new int[71 * 22];

        public static string selected_font = "Arial";

        public static bool update = true;
        public static bool first = true;

        public static int last_x = 0;
        public static int last_y = 0;

        public static int help = 0;

        public static bool is_active = true;
        public static void Core()
        {
            bmp.RawData.CopyTo(ImprovedVBE.cover.RawData, 20 * 1024);

            int x = 8;
            int y = 140;
            if (first == true)
            {
                Array.Copy(bmp.RawData, 1024 * 116, buffer, 0, 1024 * 652);
                
                for(int i = 53; i < 75; i++)
                {
                    Array.Copy(bmp.RawData, 1024 * i + 42, dropdown, 71 * (i - 53), 71);
                }
                dropdown = draw_text(selected_font, 5, 5, ImprovedVBE.colourToNumber(255, 255, 255), dropdown, 71, 0);

                first = false;
            }
            if (update == true)
            {
                buffer = draw_text(sample, x, y, ImprovedVBE.colourToNumber(0, 0, 0), buffer, 1024, help);
                update = false;
            }

            if (Kernel.Keyboard_cur == false)
            {
                KeyEvent key;
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (sample.Length != 0)
                        {
                            sample = sample.Remove(sample.Length - 1);

                            for (int i = 0; i < 17; i++)
                            {
                                Array.Copy(bmp.RawData, (1024 * 125) + (last_y + i) * 1024 + last_x, buffer, (last_y + i) * 1024 + last_x, 10);
                            }
                        }
                        if (sample.Length >= 10)
                        {
                            help = sample.Length - 10;
                        }
                        else
                        {
                            help = 0;
                        }
                        update = true;
                    }
                    else if (key.Key == ConsoleKeyEx.Enter || key.Key == ConsoleKeyEx.NumEnter)
                    {
                        sample += "\n";
                        help = sample.Length - 10;
                        update = true;
                    }
                    else
                    {
                        sample += key.KeyChar;
                        help = sample.Length - 10;
                        update = true;
                    }
                }
            }
            ImprovedVBE.DrawImageArray(71, 22, dropdown, 42, 53 + 20);
            buffer.CopyTo(ImprovedVBE.cover.RawData, 1024 * 135);
        }

        public static MemoryStream memoryStream = new MemoryStream(ImprovedVBE.Arial);
        public static int Size = 16;
        public static string charset = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        public static int[] draw_text(string text, int x, int y, int color, int[] source, int width, int help)
        {
            /*
            y = 2;
            for (int c = 0; c < text.Length; c++)
            {
                if (text[c] == '\n')
                {
                    y += 16;
                    x = 16;
                }
                else if (text[c] == ' ')
                {
                    x += 11;
                }
                else
                {
                    if ((c <= help && c >= help - 10) ||  help < 10)
                    {
                        int i = charset.IndexOf(text[c]);
                        byte[] b = new byte[1014];//694
                        Array.Copy(Arial, i * 1014, b, 0, 1014);

                        Bitmap chara = new Bitmap(b);

                        int h = 0;
                        int counter = 0;
                        last_x = x;
                        last_y = y;
                        for (int _y = y; _y < y + chara.Height; _y++)
                        {
                            for (int _x = x; _x < x + chara.Width; _x++)
                            {
                                if (_y <= 890)
                                {
                                    if (_x <= 1024)
                                    {
                                        if (chara.RawData[counter] == 0)
                                        {
                                            counter++;
                                        }
                                        else
                                        {
                                            source[((_y * width) - (width - _x))] = color;
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
                                    counter += (int)chara.Width;
                                }
                            }
                        }

                        help++;
                    }
                    /*
                    while (h < chara.Height)
                    {
                        Array.Copy(chara.RawData, h * chara.Width, buffer, (y + h) * 1024 + x, chara.Width);
                        h++;
                    }*

                    //ImprovedVBE.DrawImageAlpha2(chara, x, y);
                    x += 16;
                }
            }
            */
            int ext = x;

            foreach (char c in text)
            {
                if (c == '\n')
                {
                    y += 16;
                    x = ext;
                }
                else if (c == ' ')
                {
                    x += 13;
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
                                    source[(h + y) * width + (aw * 8) + ww + x] = color;
                                    //DrawPixelfortext((aw * 8) + ww + x, h + y, color);
                                }
                            }
                        }
                    }
                    x += 13;
                }
            }
            return source;
        }

        public static string LoremIpsum(int minWords, int maxWords,
    int minSentences, int maxSentences,
    int numParagraphs)
        {

            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
        "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
        "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                result.Append("\n");
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                        if(numWords % 10 == 0 && numWords != 0)
                        {
                            result.Append("\n");
                        }
                    }
                    result.Append(". ");
                }
                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
