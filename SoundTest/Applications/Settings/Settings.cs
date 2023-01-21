using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using SoundTest;
using SoundTest.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = SoundTest.Kernel;

namespace CrystalOS.NewFolder.NewFolder
{
    public static class Settings
    {
        public static bool movable = false;
        [ManifestResourceStream(ResourceName = "SoundTest.Applications.Settings.Settings.bmp")] public static byte[] settings_base;
        public static Bitmap Settings_base = new Bitmap(settings_base);
        public static void settings(int x, int y)
        {
            if(Bool_Manager.Settings_Opened == true)
            {
                ImprovedVBE.DrawImageAlpha(Settings_base, x, y);

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > x + 87 && MouseManager.X < x + 299)
                    {
                        if (MouseManager.Y > y + 99 && MouseManager.Y < y + 219)
                        {
                            Kernel.saved = "90_Style";
                            Bool_Manager.wallp = "90_Style";
                        }
                    }
                    if (MouseManager.X > x + 350 && MouseManager.X < x + 561)
                    {
                        if (MouseManager.Y > y + 99 && MouseManager.Y < y + 219)
                        {
                            Kernel.saved = "Midnight_in_NY";
                            Bool_Manager.wallp = "Midnight_in_NY";
                        }
                    }
                    if (MouseManager.X > x + 87 && MouseManager.X < x + 299)
                    {
                        if (MouseManager.Y > y + 222 && MouseManager.Y < y + 343)
                        {
                            Kernel.saved = "autumn";
                            Bool_Manager.wallp = "autumn";
                        }
                    }
                    if (MouseManager.X > x + 350 && MouseManager.X < x + 561)
                    {
                        if (MouseManager.Y > y + 222 && MouseManager.Y < y + 343)
                        {
                            Kernel.saved = "Windows_Puma";
                            Bool_Manager.wallp = "Windows_Puma";
                        }
                    }

                    if (MouseManager.X > Task_Manager.Tasks[Task_Manager.indicator].Item2 + 623 && MouseManager.X < Task_Manager.Tasks[Task_Manager.indicator].Item2 + 644)
                    {
                        if (MouseManager.Y > Task_Manager.Tasks[Task_Manager.indicator].Item3 + 8 && MouseManager.Y < Task_Manager.Tasks[Task_Manager.indicator].Item3 + 24)
                        {
                            //Bool_Manager.Settings_Opened = false;
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                        }
                    }
                    if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == false)
                    {
                        if (MouseManager.X > x && MouseManager.X < x + 570)
                        {
                            if (MouseManager.Y > y && MouseManager.Y < y + 18)
                            {
                                int f = (int)MouseManager.X;
                                int g = (int)MouseManager.Y;
                                Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string>("settings", f, g, true, ""));
                            }
                        }
                    }
                }

                if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
                {
                    int f = (int)MouseManager.X;
                    int g = (int)MouseManager.Y;
                    Task_Manager.Tasks.RemoveAt(0);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string>("settings", f, g, true, ""));
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string>("settings", f, g, false, ""));
                        Task_Manager.Tasks.Reverse();
                        //movable = false;
                    }
                    
                    if (MouseManager.X > x && MouseManager.X < x + 352)
                    {
                        if (MouseManager.Y > y && MouseManager.Y < y + 18)
                        {
                            //movable = false;
                        }
                    }
                    
                }
            }
        }
    }
}
