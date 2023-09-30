using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.Applications.Solitaire;
using CrystalOS.SystemFiles;
using CrystalOS2;
using CrystalOS2.Applications.Task_Scheduler;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_tut.Applications.Calculator;
using Kernel = CrystalOS2.Kernel;

namespace CrystalOS.Applications.About
{
    public class About_code : App
    {
        public static bool request_info = true;
        public static string s = "";
        public static string fs_total = "";
        public static string fs_free = "";
        public static string cpubarnd = "";
        public static string usedram = "";
        public static string username = "Crystal-PC";
        public static string is_protected = "No";
        public bool movable = false;

        public int desk_ID { get; set; }

        public int x = 100;
        public int y = 100;

        public string name
        {
            get { return "About"; }
        }

        public bool minimised { get; set; }
        public int z { get; set; }

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.About.About.bmp")] public static byte[] Solitaire;
        public static Bitmap solitaire = new Bitmap(Solitaire);
        public void App()
        {
            #region core
            ImprovedVBE.DrawImageAlpha(solitaire, x, y);

            ImprovedVBE._DrawACSIIString(username, x + 260, y + 97, 0);
            ImprovedVBE._DrawACSIIString(is_protected, x + 313, y + 125, 0);
            ImprovedVBE._DrawACSIIString(fs_total, x + 284, y + 152, 0);
            ImprovedVBE._DrawACSIIString(fs_free, x + 313, y + 179, 0);
            ImprovedVBE._DrawACSIIString(cpubarnd, x + 280, y + 205, 0);
            ImprovedVBE._DrawACSIIString(usedram, x + 283, y + 233, 0);
            ImprovedVBE._DrawACSIIString(s, x + 138, y + 245, 0);
            if (Task_Manager.indicator == Task_Manager.calculators.Count - 1)
            {
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
                    
                    //fs_total = (CrystalOS2.Kernel.fs.GetTotalSize("0:\\") / (1024 * 1024)).ToString();
                    //fs_free = (CrystalOS2.Kernel.fs.GetTotalFreeSpace("0:\\") / (1024 * 1024)).ToString();
                    cpubarnd = (Cosmos.Core.CPU.GetAmountOfRAM()).ToString();
                    usedram = (Cosmos.Core.CPU.GetEndOfKernel() / (1024 * 1024)).ToString();
                    request_info = false;
                }
            }
            else
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x && Kernel.X < x + solitaire.Width)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + solitaire.Height)
                        {
                            z = 999;
                        }
                    }
                }
            }
            #endregion core

            #region mechanical
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (Kernel.X > x + 406 && Kernel.X < x + 448)
                {
                    if (Kernel.Y > y && Kernel.Y < y + 17)
                    {
                        Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                    }
                }
                if (movable == false)
                {
                    if (Kernel.X > x && Kernel.X < x + 352)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 18)
                        {
                            movable = true;
                        }
                    }
                }
            }
            if (movable == true)
            {
                x = (int)Kernel.X;
                y = (int)Kernel.Y;
                if (MouseManager.MouseState == MouseState.Right)
                {
                    movable = false;
                }
            }
            #endregion core
        }
    }
}