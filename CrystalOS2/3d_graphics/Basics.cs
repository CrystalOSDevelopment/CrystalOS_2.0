using Cosmos.System.Graphics;
using CrystalOS2._3d_demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*
namespace CrystalOS2._3d_graphics
{
    public class Basics
    {
        public static int[] canvas = new int[800 * 600];

        #region camera
        public static int Camera_X = 0;
        public static int Camera_Y = 0;
        public static int Camera_Z = 0;

        public static int Rotate_U_D = 0;
        #endregion camera

        public static void Draw_Wall(int x, int y, int z, int width, int height, int color, bool border, int offset)
        {
            if(Camera_Z < z)
            {
                int distance = z - Camera_Z;
                x -= distance / 5;
                width += (distance / 5) * 2;

                y -= distance / 5;
                height += (distance / 5) * 2;
            }

            if (offset == 0)
            {
                for (int i = 0; i < height; i++)
                {
                    if(i == 0 || i == height - 1)
                    {
                        ImprovedVBE.DrawLine(color, x + Program.x_axis, y + i + Program.y_axis, x + width + Program.x_axis - (offset * 2), (y + offset) + i + Program.y_axis);
                    }
                    else
                    {
                        ImprovedVBE.DrawLine(0, x + Program.x_axis, y + i + Program.y_axis, x + width + Program.x_axis - (offset * 2), (y + offset) + i + Program.y_axis);
                    }
                }
            }
            if (offset < 0)
            {
                for (int i = 0; i < height; i++)
                {
                    if(i == 0 || i == height - 1)
                    {
                        ImprovedVBE.DrawLine(0, x + Program.x_axis, y + i + Program.y_axis, x + width + Program.x_axis - (offset * 2), (y + offset) + i + Program.y_axis);
                    }
                    else
                    {
                        ImprovedVBE.DrawLine(color, x + Program.x_axis, y + i + Program.y_axis, x + width + Program.x_axis - (offset * 2), (y + offset) + i + Program.y_axis);
                    }
                }
            }
            if (offset > 0)
            {
                for (int i = 0; i < height; i++)
                {
                    if(i == 0 || i == height - 1)
                    {
                        ImprovedVBE.DrawLine(0, x + Program.x_axis, y + i + Program.y_axis, x + width + Program.x_axis, (y + offset) + i + Program.y_axis);
                    }
                    else
                    {
                        ImprovedVBE.DrawLine(color, x + Program.x_axis, y + i + Program.y_axis, x + width + Program.x_axis, (y + offset) + i + Program.y_axis);
                    }
                }
            }

            //ImprovedVBE.DrawImageArray(800, 600, canvas, 10, 10);
        }

        public static void Deltoid(int x, int y, int a, int b, int c, int col)
        {
            int diff = b - a;
            for(int i = x; i <= x + b; i++)
            {
                if(i <= x + b - diff / 2)
                {
                    ImprovedVBE.DrawLine(col, i, y, i - (diff / 2), y + c);
                }
                else
                {
                    ImprovedVBE.DrawLine(col, i - diff, y, i, y + c);
                }
            }
            
        }
    }
}
*/