using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureMapper.GFFFontRenderer
{
    internal class FontRenderer
    {
        public static void DrawText(string v, int x, int y, int scale, Color color, BallerFont font)
        {
            string[] lines = v.Split("\n");
            int beginX = x;
            foreach (string line in lines)
            {
                x = beginX;
                foreach (char c in line)
                {
                    Glyph g = font.Glyphs[(int)c];
                    g.DrawGlyph(x, y, scale, color);
                    if ((int)c == 32)
                    {
                        x++;
                    }
                    x += (g.GlyphWidth + 1 + font.CharacterSpacing) * scale;
                }
                y += (font.GlyphHeight + font.VerticalSpacing) * scale;
            }
        }

        public static void DrawText(string v, int x, int y, Color color, BallerFont font)
        {
            DrawText(v, x, y, 1, color, font);
        }

        public static BallerFont LoadFont(byte[] fontFile)
        {
            //create the font base
            BallerFont font = new BallerFont();
            font.GlyphHeight = (int)fontFile[1];
            font.CharacterSpacing = (int)fontFile[2];
            font.VerticalSpacing = (int)fontFile[3];
            font.Glyphs = new Glyph[256];

            //init glyphs with width
            for (int i = 0; i < 256; i++)
            {
                font.Glyphs[i] = new Glyph((int)fontFile[4 + i]);
            }

            //create glyph data
            int glyphIndex = -1;
            int nextPointStartByte = 260;
            int pointIndex = 0;
            for (int currentByte = 4 + 256; currentByte < fontFile.Length; currentByte++)
            {
                if (currentByte == nextPointStartByte)
                {
                    glyphIndex++;
                    pointIndex = 0;
                    font.Glyphs[glyphIndex].pointsX = new int[(int)fontFile[currentByte]];
                    font.Glyphs[glyphIndex].pointsY = new int[(int)fontFile[currentByte]];
                    nextPointStartByte = currentByte + 1 + ((int)fontFile[currentByte] * 2);
                }
                else
                {
                    if (pointIndex % 2 == 0)
                    {
                        font.Glyphs[glyphIndex].pointsX[pointIndex / 2] = fontFile[currentByte];
                    }
                    else
                    {
                        font.Glyphs[glyphIndex].pointsY[pointIndex / 2] = fontFile[currentByte];

                    }
                    pointIndex++;
                }
            }

            return font;
        }

        public static BallerFont LoadFont(string path)
        {
            byte[] fontFile = File.ReadAllBytes(path);

            return LoadFont(fontFile);
        }
    }
}