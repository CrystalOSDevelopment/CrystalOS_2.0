using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTest.Graphic_engines._3d_render
{
    public static class rendering
    {
        public static VBECanvas vbe;
        public static void drawbox(int x, int y, int width, int height, int angle)
        {
            if(angle == 0)
            {
                ImprovedVBE.DrawFilledRectangle(vbe, 0, x, y, width, height);
            }
        }
        public static int pointer = 1;
        public static int prev_pointer = 1;
        public static int y2 = 0;
        public static int x2 = 0;
        public static void trapez(int x, int y, int width, int height, int side)
        {
            while(pointer < width)
            {
                if(prev_pointer < side)
                {
                    if (pointer % 2 == 0)
                    {
                        prev_pointer++;
                        ImprovedVBE.DrawLine(vbe, 0, x + pointer, y - prev_pointer, height - prev_pointer * 2);
                    }
                    else
                    {
                        ImprovedVBE.DrawLine(vbe, 0, x + pointer, y - prev_pointer, height - prev_pointer * 2);
                    }
                }
                else { break; }
                pointer++;
            }

            while (pointer > 1)
            {
                if (prev_pointer <= side)
                {
                    if (pointer % 2 == 0)
                    {
                        prev_pointer--;
                        ImprovedVBE.DrawLine(vbe, 0, x - pointer + 1, y - prev_pointer, height - prev_pointer * 2);
                    }
                    else
                    {
                        ImprovedVBE.DrawLine(vbe, 0, x - pointer + 1, y - prev_pointer, height - prev_pointer * 2);
                    }
                }
                else { break; }
                pointer--;
            }
            pointer = 1;
            prev_pointer = 1;

            /*
while (pointer > 1)
            {
                    if (pointer % 3 == 0)
                    {
                        prev_pointer--;
                        ImprovedVBE.DrawLine(vbe, 0, x - pointer, y - prev_pointer, height - prev_pointer);
                    }
                    else
                    {
                        ImprovedVBE.DrawLine(vbe, 0, x - pointer, y - prev_pointer, height - prev_pointer);
                    }
                pointer--;
            }
            */
        }
    }
}
