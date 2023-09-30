using CrystalOS2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureMapper.GFFFontRenderer
{
    public class Glyph
    {
        public readonly int GlyphWidth;
        public int[] pointsX;
        public int[] pointsY;

        public Glyph(int GlyphWidth)
        {
            this.GlyphWidth = GlyphWidth;
        }

        internal void DrawGlyph(int x, int y, int scale, Color color)
        {
            for (int i = 0; i < pointsX.Length; i++)
            {
                ImprovedVBE.DrawFilledRectangle(color.ToArgb(), (pointsX[i] * scale) + x, (pointsY[i] * scale) + y, scale, scale);
            }
        }
    }
}