using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using CrystalOS2;
using CrystalOS2.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = CrystalOS2.Kernel;
using System.Diagnostics;
using CrystalOS.Applications.About;
using System.IO;
using CrystalOS2.SystemFiles;

namespace CrystalOS.NewFolder.NewFolder
{
    public static class Settings
    {
        public static bool movable = false;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Settings.Settings.bmp")] public static byte[] settings_base;
        public static Bitmap Settings_base = new Bitmap(settings_base);
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Settings.Settings_Cursors.bmp")] public static byte[] settings_base_cur;
        public static Bitmap Settings_base_cur = new Bitmap(settings_base_cur);
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Settings.User.bmp")] public static byte[] usr;
        public static Bitmap User = new Bitmap(usr);

        #region buttons
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.UI_Elements.Radio.bmp")] public static byte[] unsel;
        public static Bitmap Unsel = new Bitmap(unsel);
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.UI_Elements.Radio_Selected.bmp")] public static byte[] sel;
        public static Bitmap Sel = new Bitmap(sel);
        #endregion buttons

        public static string current = "1";
        public static bool clicked = false;

        public static bool usernameinput = true;
        public static bool passwordinput = false;
        public static string username = "";
        public static string password = "";
        public static string hidden_pass = "";
        public static bool trylogin = false;

        public static int selected = 0;
        public static void settings(int x, int y)
        {
            current = Task_Manager.Tasks[Task_Manager.indicator].Item5;
            if (Task_Manager.Tasks[Task_Manager.indicator].Item5 == "1")
            {
                if (MouseManager.MouseState == MouseState.None)
                {
                    clicked = false;
                }
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

                    if(clicked == false)
                    {
                        if (MouseManager.X > x + 545 && MouseManager.X < x + 645)
                        {
                            if (MouseManager.Y > y + 347 && MouseManager.Y < y + 389)
                            {
                                Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", x, y, false, "2", true));
                                clicked = true;
                            }
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
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, true, current, true));
                            }
                        }
                    }
                }

                if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
                {
                    int f = (int)MouseManager.X;
                    int g = (int)MouseManager.Y;
                    Task_Manager.Tasks.RemoveAt(0);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, true, current, true));
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, false, current, true));
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
            else if(Task_Manager.Tasks[Task_Manager.indicator].Item5 == "3")
            {
                if(MouseManager.MouseState == MouseState.None)
                {
                    clicked = false;
                }
                    ImprovedVBE.DrawImageAlpha(Settings_base_cur, x, y);

                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (MouseManager.X > x + 34 && MouseManager.X < x + 131)
                        {
                            if (MouseManager.Y > y + 89 && MouseManager.Y < y + 226)
                            {
                                Kernel.sel_curs = "bas4";
                            }
                        }
                        if (MouseManager.X > x + 149 && MouseManager.X < x + 267)
                        {
                            if (MouseManager.Y > y + 89 && MouseManager.Y < y + 226)
                            {
                                Kernel.sel_curs = "bas3";
                            }
                        }
                        if (MouseManager.X > x + 284 && MouseManager.X < x + 386)
                        {
                            if (MouseManager.Y > y + 89 && MouseManager.Y < y + 226)
                            {
                                Kernel.sel_curs = "bas1";
                            }
                        }
                        if (MouseManager.X > x + 392 && MouseManager.X < x + 472)
                        {
                            if (MouseManager.Y > y + 89 && MouseManager.Y < y + 226)
                            {
                                Kernel.sel_curs = "bas2";
                            }
                        }

                    if (MouseManager.X > x + 545 && MouseManager.X < x + 645)
                    {
                        if (MouseManager.Y > y + 347 && MouseManager.Y < y + 389)
                        {
                            if(clicked == false)
                            {
                                Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", x, y, false, "1", true));
                                clicked = true;
                            }
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
                                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, true, current, true));
                                }
                            }
                        }
                    }

                    if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
                    {
                        int f = (int)MouseManager.X;
                        int g = (int)MouseManager.Y;
                        Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, true, current, true));
                        if (MouseManager.MouseState == MouseState.Right)
                        {
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, false, current, true));
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
            else if (Task_Manager.Tasks[Task_Manager.indicator].Item5 == "2")
            {
                if (MouseManager.MouseState == MouseState.None)
                {
                    clicked = false;
                }
                ImprovedVBE.DrawImageAlpha(User, x, y);

                if(selected == 0)
                {
                    ImprovedVBE.DrawImageAlpha(Sel, x + 43, y + 136);
                    ImprovedVBE.DrawImageAlpha(Unsel, x + 162, y + 136);
                    ImprovedVBE.DrawImageAlpha(Unsel, x + 333, y + 136);
                }
                else if(selected == 1)
                {
                    ImprovedVBE.DrawImageAlpha(Sel, x + 162, y + 136);
                    ImprovedVBE.DrawImageAlpha(Unsel, x + 43, y + 136);
                    ImprovedVBE.DrawImageAlpha(Unsel, x + 333, y + 136);
                }
                else if(selected == 2)
                {
                    ImprovedVBE.DrawImageAlpha(Sel, x + 333, y + 136);
                    ImprovedVBE.DrawImageAlpha(Unsel, x + 162, y + 136);
                    ImprovedVBE.DrawImageAlpha(Unsel, x + 43, y + 136);
                }

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > x + 158 && MouseManager.X < x + 468)
                    {
                        if (MouseManager.Y > y + 186 && MouseManager.Y < y + 213)
                        {
                            usernameinput = true;
                            passwordinput = false;
                        }
                    }
                    if (MouseManager.X > x + 158 && MouseManager.X < x + 468)
                    {
                        if (MouseManager.Y > y + 224 && MouseManager.Y < y + 251)
                        {
                            usernameinput = false;
                            passwordinput = true;
                        }
                    }

                    if(MouseManager.Y > y + 136 && MouseManager.Y < y + 152)
                    {
                        if(MouseManager.X > x + 43 && MouseManager.X < x + 59)
                        {
                            selected = 0;
                        }
                        if (MouseManager.X > x + 162 && MouseManager.X < x + 178)
                        {
                            selected = 1;
                        }
                        if(MouseManager.X > x + 333 && MouseManager.X < x + 349)
                        {
                            selected = 2;
                        }
                    }

                    if (MouseManager.X > x + 545 && MouseManager.X < x + 645)
                    {
                        if (MouseManager.Y > y + 347 && MouseManager.Y < y + 389)
                        {
                            if (clicked == false)
                            {
                                Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", x, y, false, "3", false));
                                clicked = true;
                            }
                        }
                    }

                    if (MouseManager.X > x + 425 && MouseManager.X < x + 526)
                    {
                        if (MouseManager.Y > y + 347 && MouseManager.Y < y + 389)
                        {
                            if (clicked == false)
                            {
                                Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", x, y, false, "1", true));
                                clicked = true;

                            }
                        }
                    }

                    if (MouseManager.X > x + 11 && MouseManager.X < x + 112)
                    {
                        if (MouseManager.Y > y + 347 && MouseManager.Y < y + 389)
                        {
                            if (clicked == false)
                            {
                                trylogin = true;
                            }
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
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, true, current, true));
                            }
                        }
                    }
                }

                if (usernameinput == true)
                {
                    KeyEvent key;
                    if (KeyboardManager.TryReadKey(out key))
                    {
                        if (key.Key == ConsoleKeyEx.Backspace)
                        {
                            if (username.Length != 0)
                            {
                                username = username.Remove(username.Length - 1);
                            }
                        }
                        else if (key.Key == ConsoleKeyEx.Enter)
                        {
                            passwordinput = true;
                            usernameinput = false;
                        }
                        else
                        {
                            username += key.KeyChar;
                        }
                    }

                }

                if (passwordinput == true)
                {
                    KeyEvent key;
                    if (KeyboardManager.TryReadKey(out key))
                    {
                        if (key.Key == ConsoleKeyEx.Backspace)
                        {
                            if (password.Length != 0)
                            {
                                hidden_pass = hidden_pass.Remove(hidden_pass.Length - 1);
                                password = password.Remove(password.Length - 1);
                            }
                        }
                        else if (key.Key == ConsoleKeyEx.Enter)
                        {
                            trylogin = true;
                        }
                        else
                        {
                            password += key.KeyChar;
                            hidden_pass += "*";
                        }
                    }
                }

                try
                {
                    ImprovedVBE._DrawACSIIString(username, x + 162, y + 190, 0);
                    ImprovedVBE._DrawACSIIString(hidden_pass, x + 162, y + 228, 0);
                }
                catch
                {

                }

                if (trylogin == true)
                {
                    //Identify user!
                    /*
                    string[] data = File.ReadAllLines(@"0:\System_Data.sys");
                    int counter = 1;
                    int found_user = 0;
                    foreach (string s in data)
                    {
                        if (s == username)
                        {
                            found_user++;
                        }
                        counter++;
                        
                    }
                    if (found_user == 0)
                    {
                        

                    }
                    */
                    string[] data1 = File.ReadAllLines(@"0:\System_Data.sys");
                    string s = File.ReadAllText(@"0:\System_Data.sys");
                    s += "\n\n" + data1[0] + "\n" + username + "\n" + Lock_Screen.Encoder(password) + "\n" + Kernel.saved + "\n" + Kernel.sel_curs + "\n" + selected.ToString() + "\n" + "Setup_File";
                    //ImprovedVBE._DrawACSIIString(s, x + 162, y + 350, 0);
                    File.Delete(@"0:\System_Data.sys");
                    
                    File.Create(@"0:\System_Data.sys");
                    File.WriteAllText(@"0:\System_Data.sys", s);
                    trylogin = false;
                }

                if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
                {
                    int f = (int)MouseManager.X;
                    int g = (int)MouseManager.Y;
                    Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, true, current, true));
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", f, g, false, current, true));
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
