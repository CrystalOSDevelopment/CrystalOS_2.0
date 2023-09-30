using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using CrystalOS2._3d_graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2._3d_demo
{
    public class Program
    {
        public static int offset = 0;
        public static int x_axis = 0;
        public static int y_axis = 0;

        public static int plus = 200;

        //public static List<Vector3> points = new List<Vector3>();
        //public static List<Vector3> temp = new List<Vector3>();

        //public static Vector3 centroid;
        public static void Main()
        {
            
            ImprovedVBE.DrawFilledRectangle(ImprovedVBE.colourToNumber(0, 0, 0), 0, 1, 1024, 768);
            /*
            ImprovedVBE.DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 231, 174), 1, 1, 1024, 500);

            Basics.Draw_Wall(-1, 100, 0, 250, 500, ImprovedVBE.colourToNumber(255, 191, 245), true, -50 + offset);
            Basics.Draw_Wall(342, 50, 0, 342, 500, ImprovedVBE.colourToNumber(255, 28, 28), true, 0 + offset);
            Basics.Draw_Wall(684, 50, 0, 345, 500, ImprovedVBE.colourToNumber(137, 224, 255), true, 50 + offset);
            */

            /*
            if(points.Count() < 8)
            {
                Vector3 a = new Vector3();
                a.X = 300; a.Y = 300; a.Z = 200;
                points.Add(a);

                Vector3 b = new Vector3();
                b.X = 400;
                b.Y = 300;
                b.Z = 200;
                points.Add(b);

                Vector3 c = new Vector3();
                c.X = 400;
                c.Y = 400;
                c.Z = 200;
                points.Add(c);

                Vector3 d = new Vector3();
                d.X = 300;
                d.Y = 400;
                d.Z = 200;
                points.Add(d);

                Vector3 e = new Vector3();
                e.X = 100;
                e.Y = 100;
                e.Z = 110;
                points.Add(e);

                Vector3 f = new Vector3();
                f.X = 200;
                f.Y = 100;
                f.Z = 110;
                points.Add(f);

                Vector3 g = new Vector3();
                g.X = 200;
                g.Y = 200;
                g.Z = 110;
                points.Add(g);

                Vector3 h = new Vector3();
                h.X = 100;
                h.Y = 200;
                h.Z = 110;
                points.Add(h);
            }

            /*
            foreach(var p in points)
            {
                centroid.X += p.X;
                centroid.Y += p.Y;
                centroid.Z += p.Z;
            }
            centroid.X /= points.Count();
            centroid.Y /= points.Count();
            centroid.Z /= points.Count();
            

            foreach (var p in points)
            {
                try
                {
                    temp.Add(ImprovedVBE.rotate(p, 0.002f, 0.002f, 0.002f));
                }
                catch
                {

                }
                //
            }

            points.Clear();
            points = new List<Vector3>(temp);
            temp.Clear();

            int y = 100;

            foreach (var p in points)
            {
                ImprovedVBE.DrawPixelfortext((int)p.X, (int)p.Y, ImprovedVBE.colourToNumber(255, 255, 255));

                ImprovedVBE._DrawACSIIString(p.X + "\n" + p.Y + "\n" + p.Z, 100, y, 0);
                y += 16 * 4;
            }

            */

            Cube.Main();

            //Teapot.Main();

            /*
            KeyEvent key;
            if (KeyboardManager.TryReadKey(out key))
            {
                if (key.Key == ConsoleKeyEx.D)
                {
                    Basics.Camera_X += 8;
                    if(x_axis > 1080)
                    {
                        x_axis = -1080;
                        offset *= -1;
                    }
                    x_axis += 16;
                    offset++;
                }
                if (key.Key == ConsoleKeyEx.A)
                {
                    Basics.Camera_X -= 8;
                    if(x_axis < -1080)
                    {
                        x_axis = 1080;
                        offset *= -1;
                    }
                    x_axis -= 16;
                    offset--;
                }
                if (key.Key == ConsoleKeyEx.S)
                {
                    Basics.Camera_Z += 8;
                }
                if (key.Key == ConsoleKeyEx.W)
                {
                    Basics.Camera_Z -= 8;
                }
                if (key.Key == ConsoleKeyEx.UpArrow)
                {
                    Basics.Camera_Y += 8;
                }
                if (key.Key == ConsoleKeyEx.DownArrow)
                {
                    Basics.Camera_Y -= 8;
                }
            }
            */

            //rray.Fill(Basics.canvas, 2000);
        }
    }
}
