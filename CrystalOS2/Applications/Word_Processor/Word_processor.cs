using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
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

        public static string charset = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
        #region fonts
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Word_Processor.font.eff")] public static byte[] Arial;
        #endregion fonts

        public static string sample = "";
        public static int[] buffer = new int[1920 * 890];

        public static bool update = true;
        public static bool first = true;

        public static int last_x = 0;
        public static int last_y = 0;

        public static int help = 0;
        public static void Core()
        {
            bmp.RawData.CopyTo(ImprovedVBE.cover.RawData, 29 * 1920);

            int x = 16;
            int y = 192;
            if (first == true)
            {
                Array.Copy(bmp.RawData, 1920 * 161, buffer, 0, 1920 * 890);
                first = false;
            }
            if (update == true)
            {
                draw_text(sample, x, y);
                update = false;
            }

            KeyEvent key;
            if(KeyboardManager.TryReadKey(out key))
            {
                if(key.Key == ConsoleKeyEx.Backspace)
                {
                    if(sample.Length != 0)
                    {
                        sample = sample.Remove(sample.Length - 1);

                        for(int i = 0; i < 17; i++)
                        {
                            Array.Copy(bmp.RawData, (1920 * 190) + (last_y + i) * 1920 + last_x, buffer, (last_y + i) * 1920 + last_x, 10);
                        }
                    }
                    if(sample.Length >= 10)
                    {
                        help = sample.Length - 10;
                    }
                    else
                    {
                        help = 0;
                    }
                    update = true;
                }
                else if(key.Key == ConsoleKeyEx.Enter || key.Key == ConsoleKeyEx.NumEnter)
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
            buffer.CopyTo(ImprovedVBE.cover.RawData, 1920 * 190);
        }

        public static void draw_text(string text, int x, int y)
        {
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
                        byte[] b = new byte[694];
                        Array.Copy(Arial, i * 694, b, 0, 694);

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
                                    if (_x <= 1920)
                                    {
                                        if (chara.RawData[counter] == 0)
                                        {
                                            counter++;
                                        }
                                        else
                                        {
                                            buffer[((_y * 1920) - (1920 - _x))] = 0;
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
                        Array.Copy(chara.RawData, h * chara.Width, buffer, (y + h) * 1920 + x, chara.Width);
                        h++;
                    }*/

                    //ImprovedVBE.DrawImageAlpha2(chara, x, y);
                    x += 11;
                }
            }
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
