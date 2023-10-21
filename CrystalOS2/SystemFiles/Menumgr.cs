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
using CrystalOS2.SystemFiles;
using ProjectDMG;
using CrystalOS2.SystemFiles.Boot;

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

        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Menu2.bmp")] public static byte[] Menu2;
        public static Bitmap menu2 = new Bitmap(Menu2);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Browser.index.html")] public static byte[] contents;
        public static string content = ASCIIEncoding.UTF8.GetString(contents);

        public static bool submenu = false;

        public static bool clicked = false;
        public static void MenuManager()
        {

            if (MouseManager.MouseState == MouseState.None)
            {
                clicked = false;
            }

            if (c > 900)
            {
                c = 50;
                z += 50;
            }
            if(opened == false)
            {
                if (opened_since > 30)//90
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
                    if (MouseManager.X > 930 && MouseManager.X < 980)
                    {
                        if (MouseManager.Y > 244 && MouseManager.Y < 265)
                        {
                            Lock_Screen.username = "";
                            Lock_Screen.password = "";
                            Lock_Screen.hidden_pass = "";
                            Bool_Manager.wallp = "Lock_Screen";
                            Bool_Manager.is_locked = true;
                        }
                    }
                    if (MouseManager.X > 775 + 10 && MouseManager.X < 775 + 65)
                    {
                        if (MouseManager.Y > 30 + 15 && MouseManager.Y < 30 + 85)
                        {
                            Bool_Manager.Settings_Opened = true;
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("settings", z, c, false, "1", true));
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
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("calculator", z, c, false, "", true));
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
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("text_editor", z, c, false, "", true));
                            Text_Editor.Text_Editor.line.Add(0);
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

                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("explorer", z, c, false, "0:\\", true));
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
                            //opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 157 && MouseManager.X < 775 + 212)
                    {
                        if (MouseManager.Y > 30 + 99 && MouseManager.Y < 30 + 182)
                        {
                            Bool_Manager.Terminal_Opened = true;
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("terminal", z, c, false, "C:\\", true));
                            //Terminal_Core.displayed.Add("C:\\");
                            c += 100;
                            z += 100;
                            opened = false;
                        }
                    }
                    if (MouseManager.X > 775 + 234 && MouseManager.X < 775 + 262)
                    {
                        if (MouseManager.Y > 30 + 99 && MouseManager.Y < 30 + 182)
                        {
                            if (opened_since > 20)
                            {
                                submenu = true;
                                opened_since = 0;
                            }
                        }
                    }
                    else
                    {
                        //opened = false;
                    }
                }
                if (submenu == true)
                {
                    ImprovedVBE.DrawImageAlpha(menu2, 1064, 134);
                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if (MouseManager.X > 775 + 234 && MouseManager.X < 775 + 262)
                        {
                            if (MouseManager.Y > 30 + 99 && MouseManager.Y < 30 + 182)
                            {
                                if (opened_since > 20)
                                {
                                    opened_since = 0;
                                    submenu = false;
                                }
                            }
                        }
                        //More apps
                        if (MouseManager.X > 1067 && MouseManager.X < 1189)
                        {
                            if (MouseManager.Y > 141 && MouseManager.Y < 168)
                            {
                                Bool_Manager.Taskman = true;
                                opened = false;
                                submenu = false;
                            }
                            if (MouseManager.Y > 134 + 39 && MouseManager.Y < 134 + 39 + 27)
                            {
                                Bool_Manager.Calendar = true;
                                opened = false;
                                submenu = false;
                            }
                            if (MouseManager.Y > 134 + 71 && MouseManager.Y < 134 + 71 + 27)
                            {
                                Bool_Manager.Paint = true;
                                opened = false;
                                submenu = false;
                            }
                            if (MouseManager.Y > 134 + 105 && MouseManager.Y < 134 + 105 + 27)
                            {
                                Bool_Manager.Clock = true;
                                opened = false;
                                submenu = false;
                            }
                            if (MouseManager.Y > 134 + 138 && MouseManager.Y < 134 + 138 + 27)
                            {
                                Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("Browser", z, c, false, content, true));
                                opened = false;
                                submenu = false;
                            }
                            if (MouseManager.Y > 134 + 172 && MouseManager.Y < 134 + 172 + 43)
                            {
                                CrystalOS2.Kernel.power_on = true;
                                //CrystalOS2.Kernel.show_gb = true;
                                Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("Gameboy", z, c, false, "", true));
                                opened = false;
                                submenu = false;
                            }
                            if (MouseManager.Y > 134 + 218 && MouseManager.Y < 134 + 245)
                            {
                                Boot_Login.opened = "yes";
                                //CrystalOS2.Kernel.show_gb = true;
                                //Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("Video", z, c, false, "", true));
                                opened = false;
                                submenu = false;
                            }
                        }
                    }
                }
                #endregion function
                
                if (opened_since > 30)
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
