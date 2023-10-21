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

        public void Boot_process()
        {
            if(enabled == true)
            {
                while (Kernel.a != 912)
                {
                    //ImprovedVBE.DrawFilledRectangle(1, 1, 0, 1919, 1079);
                    ImprovedVBE.DrawImageAlpha(Boot, 1, 1);
                    ImprovedVBE.DrawImageAlpha(Corner, 505, 751);
                    ImprovedVBE.DrawImageAlpha(Corner, 505 + Kernel.a, 751);
                    ImprovedVBE.DrawFilledRectangle(16777215, 514, 751, Kernel.a, 20);
                    try
                    {
                        ImprovedVBE._DrawACSIIString((Kernel.a / 9.12).ToString().Remove(5) + "% done", 925, 812, 16777215);
                    }
                    catch
                    {
                        ImprovedVBE._DrawACSIIString((Kernel.a / 9.12).ToString() + "% done", 925, 812, 16777215);
                    }
                    Kernel.a += 3;
                    vbedr.display(Kernel.vbe);
                    Kernel.Update();
                    Kernel.vbe.Display();
                    Heap.Collect();
                }

                Bool_Manager.wallp = "Windows_Puma";
                Bool_Manager.is_locked = false;

                enabled = false;
            }
            
        }
    }
}
