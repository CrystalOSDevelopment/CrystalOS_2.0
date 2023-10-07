using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS2.Applications.Task_Scheduler;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_tut.Applications.Calculator;

namespace CrystalOS2.Applications.MultiDesk
{
    public class Core : App
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.MultiDesk.DesktopWizard.bmp")] public static byte[] App_base;
        public static Bitmap App_b = new Bitmap(App_base);

        public static int Current_Desktop = 1;

        public int desk_ID { get; set; }

        public int x = 100;
        public int y = 100;

        public string name
        {
            get { return "Mult..."; }
        }

        public bool minimised { get; set; }
        public int z { get; set; }
        public bool movable = false;

        public void App()
        {
            ImprovedVBE.DrawImageAlpha(App_b, x + 7, y);

            if (Task_Manager.indicator == Task_Manager.calculators.Count - 1)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.Y > y + 28 && Kernel.Y < y + 28 + 46)
                    {
                        if (Kernel.X > x + 7 && Kernel.X < x + 7 + 99)
                        {
                            Current_Desktop = 1;
                            desk_ID = Current_Desktop;
                        }
                        if (Kernel.X > x + 7 + 118 && Kernel.X < x + 7 + 118 + 99)
                        {
                            Current_Desktop = 2;
                            desk_ID = Current_Desktop;
                        }
                        if (Kernel.X > x + 7 + 228 && Kernel.X < x + 7 + 228 + 99)
                        {
                            Current_Desktop = 3;
                            desk_ID = Current_Desktop;
                        }
                    }
                    if (Kernel.Y > y + 86 && Kernel.Y < y + 86 + 46)
                    {
                        if (Kernel.X > x + 7 && Kernel.X < x + 7 + 99)
                        {
                            Current_Desktop = 4;
                            desk_ID = Current_Desktop;
                        }
                        if (Kernel.X > x + 7 + 118 && Kernel.X < x + 7 + 118 + 99)
                        {
                            Current_Desktop = 5;
                            desk_ID = Current_Desktop;
                        }
                        if (Kernel.X > x + 7 + 228 && Kernel.X < x + 7 + 228 + 99)
                        {
                            Current_Desktop = 6;
                            desk_ID = Current_Desktop;
                        }
                    }
                    if (Kernel.Y > y + 144 && Kernel.Y < y + 144 + 46)
                    {
                        if (Kernel.X > x + 7 && Kernel.X < x + 7 + 99)
                        {
                            Current_Desktop = 7;
                            desk_ID = Current_Desktop;
                        }
                        if (Kernel.X > x + 7 + 118 && Kernel.X < x + 7 + 118 + 99)
                        {
                            Current_Desktop = 8;
                            desk_ID = Current_Desktop;
                        }
                        if (Kernel.X > x + 7 + 228 && Kernel.X < x + 7 + 228 + 99)
                        {
                            Current_Desktop = 9;
                            desk_ID = Current_Desktop;
                        }
                    }
                }

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x && Kernel.X < x + 220)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 20)
                        {
                            movable = true;
                        }
                    }
                }

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x + 306 && Kernel.X < x + 320)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 20)
                        {
                            Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                        }
                    }
                }

                if (movable == true)
                {
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        x = (int)Kernel.X;
                        y = (int)Kernel.Y;
                        movable = false;
                    }
                    else
                    {
                        x = (int)Kernel.X;
                        y = (int)Kernel.Y;
                    }
                }
            }
            else
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x && Kernel.X < x + App_b.Width)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + App_b.Height)
                        {
                            z = 999;
                        }
                    }
                }
            }
        }
    }
}
