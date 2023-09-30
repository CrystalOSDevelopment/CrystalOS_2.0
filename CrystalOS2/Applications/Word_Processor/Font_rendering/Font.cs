using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureMapper.GFFFontRenderer
{
    internal class BallerFont
    {
        public int VerticalSpacing { get; internal set; }
        public int CharacterSpacing { get; internal set; }
        public int GlyphHeight { get; internal set; }
        public Glyph[] Glyphs { get; internal set; }
    }
}