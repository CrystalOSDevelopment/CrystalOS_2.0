using Cosmos.Core.Memory;
using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using CrystalOS.SystemFiles;
using CrystalOS2;

namespace CrystalOS2.SystemFiles.Boot
{
    class Boot_Login
    {
        ImprovedVBE vbedr = new ImprovedVBE();
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Boot.corner.bmp")] public static byte[] corner;
        public static Bitmap Corner = new Bitmap(corner);

        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Boot.boot.bmp")] public static byte[] boot;
        public static Bitmap Boot = new Bitmap(boot);
        public static bool enabled = true;

        public static string opened = "no";

        public void Boot_process(VBECanvas c)
        {
            if(enabled == true)
            {
                while (Kernel.a != 597)
                {
                    //ImprovedVBE.DrawFilledRectangle(1, 1, 0, 1919, 1079);
                    ImprovedVBE.DrawImageAlpha(Boot, 0, 0);
                    ImprovedVBE.DrawImageAlpha(Corner, 185, 470);
                    ImprovedVBE.DrawImageAlpha(Corner, 185 + Kernel.a, 470);
                    ImprovedVBE.DrawFilledRectangle(16777215, 194, 470, Kernel.a, 20);
                    try
                    {
                        ImprovedVBE._DrawACSIIString((Kernel.a / 5.97).ToString().Remove(5) + "% done", 450, 505, 16777215);
                    }
                    catch
                    {
                        ImprovedVBE._DrawACSIIString((Kernel.a / 5.97).ToString() + "% done", 450, 505, 16777215);
                    }
                    Kernel.a += 3;
                    ImprovedVBE.display(c);
                    Kernel.Update();
                    c.Display();
                    Heap.Collect();
                }

                Bool_Manager.wallp = "Windows_Puma";
                Bool_Manager.is_locked = false;

                enabled = false;
            }
            
        }
    }
}
