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
using CrystalOS2;
using Kernel = CrystalOS2.Kernel;
using Youtube_tut.Applications.Calculator;
using CrystalOS.Applications.About;
using CrystalOS2.Applications.MultiDesk;
using CrystalOS2.Applications.Browser;
using CrystalOS2.Applications.Calendar;
using CrystalOS2.Applications.Paint;
using CrystalOS.NewFolder.NewFolder;
using CrystalOS2.Applications;

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

        public static int z_axis = 0;
        public static void MenuManager()
        {

            if (MouseManager.MouseState == MouseState.None)
            {
                clicked = false;
            }

            if (c > 600)
            {
                c = 30;
                z += 30;
            }
            if(opened == false)
            {
                if (opened_since > 30)//90
                {
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (Kernel.X > ImprovedVBE.width / 2 - 15 && Kernel.X < ImprovedVBE.width / 2 + 15)
                        {
                            if (Kernel.Y > 0 && Kernel.Y < 19)
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
                ImprovedVBE.DrawImageAlpha(menu, (int)((ImprovedVBE.width / 2) - (menu.Width / 2)), 22); // 775, 30

                #region function
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 19 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 86)
                    {
                        if (Kernel.Y > 21 + 217 && Kernel.Y < 21 + 233)
                        {
                            Cosmos.System.Power.Shutdown();
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 96 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 142)
                    {
                        if (Kernel.Y > 21 + 217 && Kernel.Y < 21 + 233)
                        {
                            Cosmos.System.Power.Reboot();
                        }
                    }
                    if (Kernel.X > 930 && Kernel.X < 980)
                    {
                        if (Kernel.Y > 244 && Kernel.Y < 265)
                        {
                            Lock_Screen.username = "";
                            Lock_Screen.password = "";
                            Lock_Screen.hidden_pass = "";
                            Bool_Manager.wallp = "Lock_Screen";
                            Bool_Manager.is_locked = true;
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 10 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 65)
                    {
                        if (Kernel.Y > 21 + 15 && Kernel.Y < 21 + 85)
                        {
                            //Bool_Manager.Settings_Opened = true;
                            //Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool, int>("settings", z, c, false, "1", true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                            Settings s = new Settings();
                            s.x = c;
                            s.y = z;
                            s.desk_ID = Core.Current_Desktop;
                            s.minimised = false;

                            Task_Manager.calculators.Add(s);
                            c += 100;
                            z += 100;
                            opened = false;
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 78 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 134)
                    {
                        if (Kernel.Y > 21 + 15 && Kernel.Y < 21 + 85)
                        {
                            //Bool_Manager.Calculator_Opened = true;
                            Calculator calc = new Calculator();
                            calc.x = z;
                            calc.y = c;
                            calc.z = z_axis;

                            calc.desk_ID = CrystalOS2.Applications.MultiDesk.Core.Current_Desktop;
                            calc.minimised = false;
                            Task_Manager.calculators.Add(calc);

                            c += 100;
                            z += 100;
                            z_axis++;
                            opened = false;
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 147 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 216)
                    {
                        if (Kernel.Y > 21 + 15 && Kernel.Y < 21 + 85)
                        {
                            Bool_Manager.Text_Editor_Opened = true;
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool, int>("text_editor", z, c, false, "", true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                            Text_Editor.Text_Editor.line.Add(0);
                            c += 100;
                            z += 100;
                            opened = false;
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 225 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 290)
                    {
                        if (Kernel.Y > 21 + 15 && Kernel.Y < 21 + 85)
                        {
                            Bool_Manager.File_Explorer_Opened = true;

                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool, int>("explorer", z, c, false, "0:\\", true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
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
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 1 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 67)
                    {
                        if (Kernel.Y > 21 + 99 && Kernel.Y < 21 + 182)
                        {
                            Bool_Manager.About_Opened = true;
                            About_code a = new About_code();
                            a.x = z;
                            a.y = c;
                            a.desk_ID = Core.Current_Desktop;
                            a.minimised = false;

                            c += 100;
                            z += 100;

                            Task_Manager.calculators.Add(a);
                            opened = false;
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 71 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 146)
                    {
                        if (Kernel.Y > 21 + 99 && Kernel.Y < 21 + 182)
                        {
                            Bool_Manager.Programmers_choice = true;
                            opened = false;
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 224 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 293)
                    {
                        if (Kernel.Y > 21 + 99 && Kernel.Y < 21 + 182)
                        {
                            Bool_Manager.Music_Player_Opened = true;
                            //opened = false;
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 157 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 212)
                    {
                        if (Kernel.Y > 21 + 99 && Kernel.Y < 21 + 182)
                        {
                            Bool_Manager.Terminal_Opened = true;
                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool, int>("terminal", z, c, false, "C:\\", true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                            //Terminal_Core.displayed.Add("C:\\");
                            c += 100;
                            z += 100;
                            opened = false;
                        }
                    }
                    if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 234 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 262)
                    {
                        if (Kernel.Y > 21 + 99 && Kernel.Y < 21 + 182)
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
                    ImprovedVBE.DrawImageAlpha(menu2, (int)((ImprovedVBE.width / 2) + (menu.Width / 2) - 15), 121);
                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if (Kernel.X > (ImprovedVBE.width / 2) - (menu.Width / 2) + 234 && Kernel.X < (ImprovedVBE.width / 2) - (menu.Width / 2) + 262)
                        {
                            if (Kernel.Y > 21 + 99 && Kernel.Y < 21 + 182)
                            {
                                if (opened_since > 20)
                                {
                                    opened_since = 0;
                                    submenu = false;
                                }
                            }
                        }
                        //More apps
                        if (Kernel.X > (ImprovedVBE.width / 2) + (menu.Width / 2) - 12 && Kernel.X < (ImprovedVBE.width / 2) + (menu.Width / 2) + 113)//3
                        {
                            if (Kernel.Y > 128 && Kernel.Y < 155)
                            {
                                Bool_Manager.Taskman = true;
                                opened = false;
                                submenu = false;
                            }
                            if (Kernel.Y > 128 + 39 && Kernel.Y < 128 + 39 + 27)
                            {
                                Bool_Manager.Calendar = true;
                                Calendar cal = new Calendar();
                                cal.x = z;
                                cal.y = c;
                                cal.desk_ID = CrystalOS2.Applications.MultiDesk.Core.Current_Desktop;
                                cal.minimised = false;

                                Task_Manager.calculators.Add(cal);

                                Core core = new Core();
                                core.x = z + 50;
                                core.y = c + 50;
                                core.desk_ID = CrystalOS2.Applications.MultiDesk.Core.Current_Desktop;
                                core.minimised = false;

                                Task_Manager.calculators.Add(core);

                                opened = false;
                                submenu = false;
                            }
                            if (Kernel.Y > 128 + 71 && Kernel.Y < 128 + 71 + 27)
                            {
                                Bool_Manager.Paint = true;
                                Paint b = new Paint();
                                b.x = z;
                                b.y = c;
                                b.minimised = false;
                                b.desk_ID = CrystalOS2.Applications.MultiDesk.Core.Current_Desktop;

                                Task_Manager.calculators.Add(b);

                                opened = false;
                                submenu = false;
                            }
                            if (Kernel.Y > 128 + 105 && Kernel.Y < 128 + 105 + 27)
                            {
                                Bool_Manager.Clock = true;
                                opened = false;
                                submenu = false;
                            }
                            if (Kernel.Y > 128 + 138 && Kernel.Y < 128 + 138 + 27)
                            {
                                Browser b = new Browser();
                                b.x = z;
                                b.y = c;
                                b.input = content;
                                b.minimised = false;
                                b.desk_ID = CrystalOS2.Applications.MultiDesk.Core.Current_Desktop;

                                Task_Manager.calculators.Add(b);
                                opened = false;
                                submenu = false;
                            }
                            if (Kernel.Y > 128 + 172 && Kernel.Y < 128 + 172 + 43)
                            {
                                Kernel.power_on = true;
                                CrystalOS2.Kernel.show_gb = true;
                                Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool, int>("Gameboy", z, c, false, "", true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                                opened = false;
                                submenu = false;
                            }
                            if (Kernel.Y > 128 + 218 && Kernel.Y < 128 + 245)
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

                if (opened_since > 30)//90
                {
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (Kernel.X > ImprovedVBE.width / 2 - 15 && Kernel.X < ImprovedVBE.width / 2 + 15)
                        {
                            if (Kernel.Y > 0 && Kernel.Y < 19)
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
        }
    }
}
