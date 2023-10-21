using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.Applications.Solitaire;
using CrystalOS.SystemFiles;
using CrystalOS2;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS.Applications.About
{
    public class About_code
    {
        public static bool request_info = true;
        public static string s = "";
        public static string fs_total = "";
        public static string fs_free = "";
        public static string cpubarnd = "";
        public static string usedram = "";
        public static string username = "";
        public static string is_protected = "";
        public static bool movable = false;

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.About.About.bmp")] public static byte[] Solitaire;
        public static Bitmap solitaire = new Bitmap(Solitaire);
        public static void About(int x, int y)
        {
            if (Bool_Manager.About_Opened == true)
            {
                ImprovedVBE.DrawImageAlpha(solitaire, Int_Manager.About_X, Int_Manager.About_Y);
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > Int_Manager.About_X + 406 && MouseManager.X < Int_Manager.About_X + 448)
                    {
                        if (MouseManager.Y > Int_Manager.About_Y && MouseManager.Y < Int_Manager.About_Y + 17)
                        {
                            Bool_Manager.About_Opened = false;
                        }
                    }
                    if (movable == false)
                    {
                        if (MouseManager.X > Int_Manager.About_X && MouseManager.X < Int_Manager.About_X + 352)
                        {
                            if (MouseManager.Y > Int_Manager.About_Y && MouseManager.Y < Int_Manager.About_Y + 18)
                            {
                                movable = true;
                            }
                        }
                    }
                }

                if (request_info == true)
                {
                    s = Cosmos.Core.CPU.GetCPUBrandString();
                    int num = 0;
                    int round = 0;
                    foreach (char ch in s)
                    {
                        if (num > 12)
                        {
                            s = s.Insert(round * num, "\n");
                            num = 0;
                            round += 1;
                        }
                        else
                        {
                            num += 1;
                        }
                    }
                    fs_total = (CrystalOS2.Kernel.fs.GetTotalSize("0:\\") / (1024 * 1024)).ToString();
                    fs_free = (CrystalOS2.Kernel.fs.GetTotalFreeSpace("0:\\") / (1024 * 1024)).ToString();
                    cpubarnd = (Cosmos.Core.CPU.GetAmountOfRAM()).ToString();
                    usedram = (Cosmos.Core.CPU.GetEndOfKernel() / (1024 * 1024)).ToString();
                    request_info = false;
                }
                ImprovedVBE._DrawACSIIString($"System user: {username}\nPassword protected: No\nDisk space(MB): {fs_total}\nDisk space free(MB): {fs_free}", x + 62, y + 31, 0);
                ImprovedVBE._DrawACSIIString($"Total RAM(MB): {cpubarnd}\nUsed RAM(MB): {usedram}", x + 88, y + 113, 0);
                ImprovedVBE._DrawACSIIString($"Processor brand: " + s, x + 72, y + 185, 0);

                ImprovedVBE._DrawACSIIString(username, x + 260, y + 97, 0);
                ImprovedVBE._DrawACSIIString(is_protected, x + 313, y + 125, 0);
                ImprovedVBE._DrawACSIIString(fs_total, x + 284, y + 152, 0);
                ImprovedVBE._DrawACSIIString(fs_free, x + 313, y + 179, 0);
                ImprovedVBE._DrawACSIIString(cpubarnd, x + 280, y + 205, 0);
                ImprovedVBE._DrawACSIIString(usedram, x + 283, y + 233, 0);
                ImprovedVBE._DrawACSIIString(s, x + 138, y + 245, 0);

                if (movable == true)
                {
                    Int_Manager.About_X = (int)MouseManager.X;
                    Int_Manager.About_Y = (int)MouseManager.Y;
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        movable = false;
                    }
                }
            }
        }
    }
}