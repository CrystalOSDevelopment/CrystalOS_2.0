using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using CrystalOS2;
using CrystalOS2.Applications.File_Explorer;
using CrystalOS2.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalOS.Applications.Terminal;

namespace CrystalOS.Applications.Menu
{
    public class Menumgr
    {
        public static bool opened = false;
        public static int opened_since = 90;
        public static int c = 50;
        public static int z = 50;
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Menu.bmp")] public static byte[] Menu;
        public static Bitmap menu = new Bitmap(Menu);
        public static void MenuManager()
        {
            if(c > 900)
            {
                c = 50;
                z += 50;
            }
            if(opened == false)
            {
                if (opened_since > 20)
                {
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (MouseManager.X > 925 && MouseManager.X < 995)
                        {
                            if (MouseManager.Y > 0 && MouseManager.Y < 57)
                            {
                                opened = true;
                                opened_since = 0;
                            }
                        }
                    }
                }
                else
                {
                    opened_since++;
                }
            }
            if (opened == true)
            {
                ImprovedVBE.DrawImageAlpha(menu, 775, 35); // 775, 30

                #region function
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > 775 + 19 && MouseManager.X < 775 + 86)
                    {
                        if (MouseManager.Y > 35 + 217 && MouseManager.Y < 35 + 233)
                        {
                            Cosmos.System.Power.Shutdown();
                        }
                    }
                    if (MouseManager.X > 775 + 96 && MouseManager.X < 775 + 142)
                    {
                        if (MouseManager.Y > 30 + 217 && MouseManager.Y < 30 + 233)
                        {
                            Cosmos.System.Power.Reboot();
                        }
                    }
                    if (MouseManager.X > 775 + 10 && MouseManager.X < 775 + 65)
                    {
                        if (MouseManager.Y > 30 + 15 && MouseManager.Y < 30 + 85)
                        {
                            Bool_Manager.Settings_Opened = true;
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string>("settings", z, c, false, ""));
                            c += 100;
                            z += 100;
                            opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 78 && MouseManager.X < 775 + 134)
                    {
                        if (MouseManager.Y > 30 + 15 && MouseManager.Y < 30 + 85)
                        {
                            Bool_Manager.Calculator_Opened = true;
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string>("calculator", z, c, false, ""));
                            c += 100;
                            z += 100;
                            opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 147 && MouseManager.X < 775 + 216)
                    {
                        if (MouseManager.Y > 30 + 15 && MouseManager.Y < 30 + 85)
                        {
                            Bool_Manager.Text_Editor_Opened = true;
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string>("text_editor", z, c, false, ""));
                            c += 100;
                            z += 100;
                            opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 225 && MouseManager.X < 775 + 290)
                    {
                        if (MouseManager.Y > 30 + 15 && MouseManager.Y < 30 + 85)
                        {
                            Bool_Manager.File_Explorer_Opened = true;

                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string>("explorer", z, c, false, "0:\\"));
                            File_Explorer.hell = true;
                            File_Explorer.readwrite = true;
                            Task_Manager.indicator = 0;
                            Task_Manager.counter = 0;
                            Task_Manager.foo = 0;
                            Task_Manager.editor_counter = 0;
                            Task_Manager.filemgr_counter = 0;
                            File_Explorer.container.Clear();
                            c += 100;
                            z += 100;
                            opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 1 && MouseManager.X < 775 + 67)
                    {
                        if (MouseManager.Y > 30 + 99 && MouseManager.Y < 30 + 182)
                        {
                            Bool_Manager.About_Opened = true;
                            opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 71 && MouseManager.X < 775 + 146)
                    {
                        if (MouseManager.Y > 30 + 99 && MouseManager.Y < 30 + 182)
                        {
                            Bool_Manager.Programmers_choice = true;
                            opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 224 && MouseManager.X < 775 + 293)
                    {
                        if (MouseManager.Y > 30 + 99 && MouseManager.Y < 30 + 182)
                        {
                            Bool_Manager.Music_Player_Opened = true;
                            opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 157 && MouseManager.X < 775 + 212)
                    {
                        if (MouseManager.Y > 30 + 99 && MouseManager.Y < 30 + 182)
                        {
                            //Bool_Manager.Terminal_Opened = true;
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string>("terminal", z, c, false, "C:\\"));
                            Terminal_Core.displayed.Add("C:\\");
                            c += 100;
                            z += 100;
                            opened = false;
                            opened = false;
                        }
                    }
                    else
                    {
                        opened = false;
                    }
                }
                #endregion function

                if (opened_since > 20)
                {
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (MouseManager.X > 925 && MouseManager.X < 995)
                        {
                            if (MouseManager.Y > 0 && MouseManager.Y < 57)
                            {
                                opened = false;
                                opened_since = 0;
                            }
                        }
                    }

                }
                else
                {
                    opened_since++;
                }
            }
        }
    }
}
