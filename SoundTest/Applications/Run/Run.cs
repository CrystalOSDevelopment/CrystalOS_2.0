using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Applications.Run
{
    public static class Run
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Run.Run.bmp")] public static byte[] Window;
        public static Bitmap base_Window = new Bitmap(Window);
        public static void Run_Window()
        {
            if(MouseManager.MouseState == MouseState.Left)
            {
                if(MouseManager.X > 77 && MouseManager.X < 145)
                {
                    if(MouseManager.Y > 2 && MouseManager.Y < 26)
                    {
                        Bool_Manager.Run_Window = true;
                    }
                }
            }
            if(Bool_Manager.Run_Window == true)
            {
                ImprovedVBE.DrawImageAlpha(base_Window, 3, 32);
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > 374 && MouseManager.X < 389)
                    {
                        if (MouseManager.Y > 36 && MouseManager.Y < 48)
                        {
                            Bool_Manager.Run_Window = false;
                        }
                    }
                }
            }
        }
    }
}
