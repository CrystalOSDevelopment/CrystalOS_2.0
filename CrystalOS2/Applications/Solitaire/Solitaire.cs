using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using CrystalOS2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS.Applications.Solitaire
{
    public class Solitaire
    {
        public static List<int> rnd = new List<int>();
        public static Random random = new Random();

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Solitaire.A_Red_Heart.bmp")] public static byte[] redheart0;
        public static Bitmap Redheart0 = new Bitmap(redheart0);
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Solitaire.Solitaire.bmp")] public static byte[] background0;
        public static Bitmap Background = new Bitmap(background0);

        public static void Solitaire_core()
        {
            ImprovedVBE.DrawImage(Background, 1245, 120);
            for (int i = 0; i < 33; i++)
            {
                if (rnd.Count < 33)
                {
                    int random_num = random.Next(1, 34);
                    if (!rnd.Contains(random_num))
                    {
                        rnd.Add(random_num);
                    }
                    //rnd = rnd.Concat(new int[1] { random_num }).ToArray();
                }
            }
            int width = 1300;
            int height = 145;
            for (int i = 1; i < 29; i++)
            {
                if (i == 1 || i == 3 || i == 6 || i == 10 || i == 15 || i == 21 || i == 28)
                {
                    ImprovedVBE.DrawImageAlpha(Redheart0, width, height);
                    height = 145;
                    width += 75;
                }
                else
                {
                    ImprovedVBE.DrawImageAlpha(Redheart0, width, height);
                    height += 30;
                }
            }
            int y = 30;
            foreach(int number in rnd)
            {
                ImprovedVBE._DrawACSIIString(number.ToString(), 50, y, 16777215);
                y += 15;
            }
            //rnd = rnd.Concat(new[] { random.Next(1, 100) }).ToArray();
        }
    }
}
