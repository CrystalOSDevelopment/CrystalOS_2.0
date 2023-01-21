using Cosmos.Core.IOGroup;
using Cosmos.HAL.Audio;
using Cosmos.System;
using Cosmos.System.Audio.IO;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using CrystalOS.Applications;
using CrystalOS.Applications.Text_Editor;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS.SystemFiles.Setup
{
    public static class Installer
    {
        [ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_Base.bmp")] public static byte[] Setup_Base;
        public static Bitmap Setup = new Bitmap(Setup_Base);
        [ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Welcome_Window.bmp")] public static byte[] Welcome_Window;
        public static Bitmap Welcome = new Bitmap(Welcome_Window);
        [ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_Collecting_1.bmp")] public static byte[] Collecting_Window;
        public static Bitmap Collect = new Bitmap(Collecting_Window);
        [ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_Base_Collecting.bmp")] public static byte[] Setup_Base_Collecting;
        public static Bitmap Setup_Collect = new Bitmap(Setup_Base_Collecting);
        [ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_Visual1.bmp")] public static byte[] Setup_Visual1;
        public static Bitmap Setup_Visual_pref1 = new Bitmap(Setup_Visual1);
        [ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Visual_pref2.bmp")] public static byte[] Setup_Visual2;
        public static Bitmap Setup_Visual_pref2 = new Bitmap(Setup_Visual2);
        [ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_finished.bmp")] public static byte[] Setup_Finished;
        public static Bitmap Setup_finished = new Bitmap(Setup_Finished);
        [ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_Finished_Window.bmp")] public static byte[] Setup_Finished_Window;
        public static Bitmap Setup_finished_window = new Bitmap(Setup_Finished_Window);
        public static int clicked_since = 90;
        public static string name = "";
        public static string username = "";
        public static string password = "";
        public static string password2 = "";

        public static string active = "name";

        public static bool Name_Box = true;
        public static bool Username_Box = false;
        public static bool Password_Box = false;
        public static bool Password2_Box = false;

        public static string selected_cursor = "default";
        public static string wallpaper = "";

        public static void Installer_Run(VBECanvas c)
        {
            if(Bool_Manager.Is_Setup_Running == true)
            {
                if(Bool_Manager.Welcome_Window == true)
                {
                    c.DrawImage(Setup, 0, 0);
                    c.DrawImage(Welcome, 850, 350);
                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if(clicked_since > 90)
                        {
                            if(MouseManager.X > 850 + 453 || MouseManager.X < 850 + 536)
                            {
                                if(MouseManager.Y > 350 + 364 || MouseManager.Y < 350 + 385)
                                {
                                    Bool_Manager.Collecting_Window = true;
                                    Bool_Manager.Welcome_Window = false;
                                    clicked_since = 0;
                                }
                            }
                        }
                    }
                }
                if(Bool_Manager.Collecting_Window == true)
                {
                    c.DrawImage(Setup_Collect, 0, 0);
                    c.DrawImage(Collect, 850, 350);
                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if(MouseManager.X > 850 + 118 && MouseManager.X < 850 + 555)
                        {
                            if(MouseManager.Y > 350 + 98 && MouseManager.Y < 350 + 119)
                            {
                                active = "name";
                                clicked_since = 0;
                            }
                            if (MouseManager.Y > 350 + 132 && MouseManager.Y < 350 + 153)
                            {
                                active = "username";
                                clicked_since = 0;
                            }
                            if (MouseManager.Y > 350 + 166 && MouseManager.Y < 350 + 187)
                            {
                                active = "password";
                                clicked_since = 0;
                            }
                            if (MouseManager.Y > 350 + 203 && MouseManager.Y < 350 + 224)
                            {
                                active = "password2";
                                clicked_since = 0;
                            }
                        }
                        if (clicked_since > 90)
                        {
                            if (MouseManager.X > 850 + 453 && MouseManager.X < 850 + 536)
                            {
                                if (MouseManager.Y > 350 + 364 && MouseManager.Y < 350 + 385)
                                {
                                    Bool_Manager.Visual_pref1 = true;
                                    Bool_Manager.Collecting_Window = false;
                                    clicked_since = 0;
                                }
                            }
                        }
                    }
                    StringManager.StringWriter(c, name, 850 + 123, 350 + 103);
                    StringManager.StringWriter(c, username, 850 + 123, 350 + 137);
                    StringManager.StringWriter(c, password, 850 + 123, 350 + 171);
                    StringManager.StringWriter(c, password2, 850 + 123, 350 + 208);
                }
                clicked_since += 1;
                KeyEvent key;
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if(active == "name")
                        {
                            if (name.Length != 0)
                            {
                                name = name.Remove(name.Length - 1);
                                return;
                            }
                        }
                        if(active == "username")
                        {
                            if (username.Length != 0)
                            {
                                username = username.Remove(username.Length - 1);
                                return;
                            }
                        }
                        if(active == "password")
                        {
                            if (password.Length != 0)
                            {
                                password = password.Remove(password.Length - 1);
                                return;
                            }
                        }
                        if(active == "password2")
                        {
                            if (password2.Length != 0)
                            {
                                password2 = password.Remove(password2.Length - 1);
                                return;
                            }
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        Name_Box = false;
                        return;
                    }
                    else
                    {
                        if(active == "name")
                        {
                            if (name.Length < 24)
                            {
                                name += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length < 24)
                            {
                                username += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length < 24)
                            {
                                password += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length < 24)
                            {
                                password2 += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (active == "name")
                        {
                            if (name.Length != 0)
                            {
                                name = name.Remove(name.Length - 1);
                                return;
                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length != 0)
                            {
                                username = username.Remove(username.Length - 1);
                                return;
                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length != 0)
                            {
                                password = password.Remove(password.Length - 1);
                                return;
                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length != 0)
                            {
                                password2 = password.Remove(password2.Length - 1);
                                return;
                            }
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        Name_Box = false;
                        return;
                    }
                    else
                    {
                        if (active == "name")
                        {
                            if (name.Length < 24)
                            {
                                name += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length < 24)
                            {
                                username += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length < 24)
                            {
                                password += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length < 24)
                            {
                                password2 += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (active == "name")
                        {
                            if (name.Length != 0)
                            {
                                name = name.Remove(name.Length - 1);
                                return;
                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length != 0)
                            {
                                username = username.Remove(username.Length - 1);
                                return;
                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length != 0)
                            {
                                password = password.Remove(password.Length - 1);
                                return;
                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length != 0)
                            {
                                password2 = password.Remove(password2.Length - 1);
                                return;
                            }
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        Name_Box = false;
                        return;
                    }
                    else
                    {
                        if (active == "name")
                        {
                            if (name.Length < 24)
                            {
                                name += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length < 24)
                            {
                                username += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length < 24)
                            {
                                password += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length < 24)
                            {
                                password2 += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (active == "name")
                        {
                            if (name.Length != 0)
                            {
                                name = name.Remove(name.Length - 1);
                                return;
                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length != 0)
                            {
                                username = username.Remove(username.Length - 1);
                                return;
                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length != 0)
                            {
                                password = password.Remove(password.Length - 1);
                                return;
                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length != 0)
                            {
                                password2 = password.Remove(password2.Length - 1);
                                return;
                            }
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        Name_Box = false;
                        return;
                    }
                    else
                    {
                        if (active == "name")
                        {
                            if (name.Length < 24)
                            {
                                name += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length < 24)
                            {
                                username += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length < 24)
                            {
                                password += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length < 24)
                            {
                                password2 += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (active == "name")
                        {
                            if (name.Length != 0)
                            {
                                name = name.Remove(name.Length - 1);
                                return;
                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length != 0)
                            {
                                username = username.Remove(username.Length - 1);
                                return;
                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length != 0)
                            {
                                password = password.Remove(password.Length - 1);
                                return;
                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length != 0)
                            {
                                password2 = password.Remove(password2.Length - 1);
                                return;
                            }
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        Name_Box = false;
                        return;
                    }
                    else
                    {
                        if (active == "name")
                        {
                            if (name.Length < 24)
                            {
                                name += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "username")
                        {
                            if (username.Length < 24)
                            {
                                username += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password")
                        {
                            if (password.Length < 24)
                            {
                                password += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                        if (active == "password2")
                        {
                            if (password2.Length < 24)
                            {
                                password2 += key.KeyChar;
                                return;
                            }
                            else
                            {

                            }
                        }
                    }
                }
                if (Bool_Manager.Visual_pref1 == true)
                {
                    c.DrawImage(Setup_Collect, 0, 0);
                    c.DrawImage(Setup_Visual_pref1, 850, 350);
                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if (clicked_since > 90)
                        {
                            if (MouseManager.Y > 350 + 360 && MouseManager.Y < 350 + 381)
                            {
                                if (MouseManager.X > 850 + 447 && MouseManager.X < 850 + 530)
                                {
                                    clicked_since = 0;
                                    Bool_Manager.Visual_pref2 = true;
                                    Bool_Manager.Visual_pref1 = false;
                                }
                            }
                        }
                        if (MouseManager.Y > 350 + 119 && MouseManager.Y < 350 + 232)
                        {
                            if (MouseManager.X > 850 + 65 && MouseManager.X < 850 + 120)
                            {
                                selected_cursor = "default";
                            }
                        }
                        if (MouseManager.Y > 350 + 119 && MouseManager.Y < 350 + 232)
                        {
                            if (MouseManager.X > 850 + 191 && MouseManager.X < 850 + 248)
                            {
                                selected_cursor = "modern";
                            }
                        }
                        if (MouseManager.Y > 350 + 119 && MouseManager.Y < 350 + 232)
                        {
                            if (MouseManager.X > 850 + 284 && MouseManager.X < 850 + 399)
                            {
                                selected_cursor = "boomers_choice";
                            }
                        }
                        if (MouseManager.Y > 350 + 119 && MouseManager.Y < 350 + 232)
                        {
                            if (MouseManager.X > 850 + 437 && MouseManager.X < 850 + 495)
                            {
                                selected_cursor = "mupet";
                            }
                        }
                    }
                }
                if (Bool_Manager.Visual_pref2 == true)
                {
                    c.DrawImage(Setup_Collect, 0, 0);
                    c.DrawImage(Setup_Visual_pref2, 850, 350);
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (clicked_since > 90)
                        {
                            if (MouseManager.X > 850 + 453 && MouseManager.X < 850 + 536)
                            {
                                if (MouseManager.Y > 350 + 364 && MouseManager.Y < 350 + 385)
                                {
                                    clicked_since = 0;
                                    //File.Delete(@"0:\System_Data.sys");
                                    File.Create(@"0:\System_Data.sys");
                                    File.WriteAllText(@"0:\System_Data.sys", name + "\n" + username + "\n" + password + "\n" + password2 + "\n" + wallpaper + "\n" + selected_cursor + "\n" + "Setup_File");
                                    //Bool_Manager.Is_Setup_Running = false;
                                    Bool_Manager.Setup_Finished = true;
                                    Bool_Manager.Visual_pref2 = false;
                                }
                            }
                        }/*
                        if (MouseManager.Y > 350 + 360 && MouseManager.Y < 350 + 381)
                        {
                            if (MouseManager.X > 850 + 447 && MouseManager.X < 850 + 530)
                            {
                                File.Create(@"0:\System_Data.sys");
                                File.WriteAllText(@"0:\System_Data.sys", name + "\n" + username + "\n" + password + "\n" + password2 + "\n" + wallpaper + "\n" + selected_cursor);
                                Bool_Manager.Visual_pref2 = false;
                            }
                        }*/
                        if (MouseManager.Y > 350 + 90 && MouseManager.Y < 350 + 221)
                        {
                            if (MouseManager.X > 850 + 21 && MouseManager.X < 850 + 188)
                            {
                                wallpaper = "90's Style";
                            }
                            if (MouseManager.X > 850 + 230 && MouseManager.X < 850 + 418)
                            {
                                wallpaper = "Midnight in New York";
                            }
                            if (MouseManager.X > 850 + 459 && MouseManager.X < 850 + 618)
                            {
                                wallpaper = "autumn";
                            }
                        }
                        if (MouseManager.Y > 350 + 254 && MouseManager.Y < 350 + 370)
                        {
                            if (MouseManager.X > 850 + 21 && MouseManager.X < 850 + 188)
                            {
                                wallpaper = "Windows puma";
                            }
                        }
                    }
                }
                if(Bool_Manager.Setup_Finished == true)
                {
                    c.DrawImage(Setup_finished, 0, 0);
                    c.DrawImage(Setup_finished_window, 850, 350);
                    if (clicked_since > 90)
                    {
                        if (MouseManager.MouseState == MouseState.Left)
                        {
                            if (MouseManager.X > 850 + 553 && MouseManager.X < 850 + 636)
                            {
                                if (MouseManager.Y > 350 + 364 && MouseManager.Y < 350 + 385)
                                {
                                    Cosmos.System.Power.Reboot();
                                    //Bool_Manager.Is_Setup_Running = false;
                                    clicked_since = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}