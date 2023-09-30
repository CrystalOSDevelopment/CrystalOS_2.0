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
using Youtube_tut.Applications.Calculator;

namespace CrystalOS.NewFolder.NewFolder
{
    public class Settings : App
    {
        public bool movable = false;
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

        public string current = "1";
        public bool clicked = false;

        public bool usernameinput = true;
        public bool passwordinput = false;
        public string username = "";
        public string password = "";
        public string hidden_pass = "";
        public bool trylogin = false;

        public int selected = 0;
        public int desk_ID { get; set; }

        public int x = 100;
        public int y = 100;

        public string name
        {
            get { return "Sett..."; }
        }

        public bool minimised { get; set; }
        public int z { get; set; }

        public void App()
        {
            if (current == "1")
            {
                if (MouseManager.MouseState == MouseState.None && clicked == true)
                {
                    clicked = false;
                    current = "2";
                }
                ImprovedVBE.DrawImageAlpha(Settings_base, x, y);

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x + 87 && Kernel.X < x + 299)
                    {
                        if (Kernel.Y > y + 99 && Kernel.Y < y + 219)
                        {
                            Kernel.saved = "90_Style";
                            Bool_Manager.wallp = "90_Style";
                        }
                    }
                    if (Kernel.X > x + 350 && Kernel.X < x + 561)
                    {
                        if (Kernel.Y > y + 99 && Kernel.Y < y + 219)
                        {
                            Kernel.saved = "Midnight_in_NY";
                            Bool_Manager.wallp = "Midnight_in_NY";
                        }
                    }
                    if (Kernel.X > x + 87 && Kernel.X < x + 299)
                    {
                        if (Kernel.Y > y + 222 && Kernel.Y < y + 343)
                        {
                            Kernel.saved = "autumn";
                            Bool_Manager.wallp = "autumn";
                        }
                    }
                    if (Kernel.X > x + 350 && Kernel.X < x + 561)
                    {
                        if (Kernel.Y > y + 222 && Kernel.Y < y + 343)
                        {
                            Kernel.saved = "Windows_Puma";
                            Bool_Manager.wallp = "Windows_Puma";
                        }
                    }

                    if(clicked == false)
                    {
                        if (Kernel.X > x + 545 && Kernel.X < x + 645)
                        {
                            if (Kernel.Y > y + 347 && Kernel.Y < y + 389)
                            {
                                clicked = true;
                            }
                        }
                    }

                    if (Kernel.X > x + 623 && Kernel.X < x + 644)
                    {
                        if (Kernel.Y > y + 8 && Kernel.Y < y + 24)
                        {
                            Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                        }
                    }
                    if (movable == false)
                    {
                        if (Kernel.X > x && Kernel.X < x + 570)
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
                    x = (int)MouseManager.X;
                    y = (int)MouseManager.Y;

                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        movable = false;
                    }
                }
            }
            else if(current == "3")
            {
                if(MouseManager.MouseState == MouseState.None && clicked == true)
                {
                    clicked = false;
                }
                ImprovedVBE.DrawImageAlpha(Settings_base_cur, x, y);

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x + 34 && Kernel.X < x + 131)
                    {
                        if (Kernel.Y > y + 89 && Kernel.Y < y + 226)
                        {
                            Kernel.sel_curs = "bas4";
                        }
                    }
                    if (Kernel.X > x + 149 && Kernel.X < x + 267)
                    {
                        if (Kernel.Y > y + 89 && Kernel.Y < y + 226)
                        {
                            Kernel.sel_curs = "bas3";
                        }
                    }
                    if (Kernel.X > x + 284 && Kernel.X < x + 386)
                    {
                        if (Kernel.Y > y + 89 && Kernel.Y < y + 226)
                        {
                            Kernel.sel_curs = "bas1";
                        }
                    }
                    if (Kernel.X > x + 392 && Kernel.X < x + 472)
                    {
                        if (Kernel.Y > y + 89 && Kernel.Y < y + 226)
                        {
                            Kernel.sel_curs = "bas2";
                        }
                    }

                    if (Kernel.X > x + 545 && Kernel.X < x + 645)
                    {
                        if (Kernel.Y > y + 347 && Kernel.Y < y + 389)
                        {
                            if(clicked == false)
                            {
                                current = "2";
                                clicked = true;
                            }
                        }
                    }

                    if (Kernel.X > x + 623 && Kernel.X < x + 644)
                    {
                        if (Kernel.Y > y + 8 && Kernel.Y < y + 24)
                        {
                            //Bool_Manager.Settings_Opened = false;
                            Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                        }
                    }
                    if (movable == false)
                    {
                        if (Kernel.X > x && Kernel.X < x + 570)
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
                    x = (int)MouseManager.X;
                    y = (int)MouseManager.Y;

                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        movable = false;
                    }
                }
            }
            else if (current == "2")
            {
                if (MouseManager.MouseState == MouseState.None && clicked == true)
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
                    if (Kernel.X > x + 158 && Kernel.X < x + 468)
                    {
                        if (Kernel.Y > y + 186 && Kernel.Y < y + 213)
                        {
                            usernameinput = true;
                            passwordinput = false;
                        }
                    }
                    if (Kernel.X > x + 158 && Kernel.X < x + 468)
                    {
                        if (Kernel.Y > y + 224 && Kernel.Y < y + 251)
                        {
                            usernameinput = false;
                            passwordinput = true;
                        }
                    }

                    if(Kernel.Y > y + 136 && Kernel.Y < y + 152)
                    {
                        if(Kernel.X > x + 43 && Kernel.X < x + 59)
                        {
                            selected = 0;
                        }
                        if (Kernel.X > x + 162 && Kernel.X < x + 178)
                        {
                            selected = 1;
                        }
                        if(Kernel.X > x + 333 && Kernel.X < x + 349)
                        {
                            selected = 2;
                        }
                    }

                    if (Kernel.X > x + 545 && Kernel.X < x + 645)
                    {
                        if (Kernel.Y > y + 347 && Kernel.Y < y + 389)
                        {
                            if (clicked == false)
                            {
                                current = "3";
                                clicked = true;
                            }
                        }
                    }

                    if (Kernel.X > x + 425 && Kernel.X < x + 526)
                    {
                        if (Kernel.Y > y + 347 && Kernel.Y < y + 389)
                        {
                            if (clicked == false)
                            {
                                current = "1";
                            }
                        }
                    }

                    if (Kernel.X > x + 11 && Kernel.X < x + 112)
                    {
                        if (Kernel.Y > y + 347 && Kernel.Y < y + 389)
                        {
                            if (clicked == false)
                            {
                                trylogin = true;
                            }
                        }
                    }

                    if (Kernel.X > x + 623 && Kernel.X < x + 644)
                    {
                        if (Kernel.Y > y + 8 && Kernel.Y < y + 24)
                        {
                            //Bool_Manager.Settings_Opened = false;
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                        }
                    }
                    if (movable == false)
                    {
                        if (Kernel.X > x && Kernel.X < x + 570)
                        {
                            if (Kernel.Y > y && Kernel.Y < y + 18)
                            {
                                movable = true;
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

                if (movable == true)
                {
                    x = (int)MouseManager.X;
                    y = (int)MouseManager.Y;

                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        movable = false;
                    }
                }
            }
            if (Task_Manager.indicator == Task_Manager.calculators.Count - 1)
            {

            }
            else
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x && Kernel.X < x + Settings_base.Width)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + Settings_base.Height)
                        {
                            z = 999;
                        }
                    }
                }
            }
        }
    }
}
