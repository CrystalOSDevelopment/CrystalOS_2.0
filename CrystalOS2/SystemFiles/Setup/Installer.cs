using Cosmos.Core.IOGroup;
using Cosmos.HAL.Audio;
using Cosmos.System;
using Cosmos.System.Audio.IO;
using Cosmos.System.Graphics;
using CrystalOS.Applications;
using CrystalOS.Applications.Text_Editor;
using CrystalOS2;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = CrystalOS2.Kernel;

namespace CrystalOS.SystemFiles.Setup
{
    public static class Installer
    {
        //[ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_Base.bmp")] public static byte[] Setup_Base;
        //public static Bitmap Setup = new Bitmap(Setup_Base);
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Setup.Welcome_Window.bmp")] public static byte[] Welcome_Window;
        public static Bitmap Welcome = new Bitmap(Welcome_Window);
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Setup.Setup_Collecting_1.bmp")] public static byte[] Collecting_Window;
        public static Bitmap Collect = new Bitmap(Collecting_Window);
        //[ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_Base_Collecting.bmp")] public static byte[] Setup_Base_Collecting;
        //public static Bitmap Setup_Collect = new Bitmap(Setup_Base_Collecting);
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Setup.Setup_Visual1.bmp")] public static byte[] Setup_Visual1;
        public static Bitmap Setup_Visual_pref1 = new Bitmap(Setup_Visual1);
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Setup.Visual_pref2.bmp")] public static byte[] Setup_Visual2;
        public static Bitmap Setup_Visual_pref2 = new Bitmap(Setup_Visual2);
        //[ManifestResourceStream(ResourceName = "CrystalOS.SystemFiles.Setup.Setup_finished.bmp")] public static byte[] Setup_Finished;
        //public static Bitmap Setup_finished = new Bitmap(Setup_Finished);
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Setup.Setup_Finished_Window.bmp")] public static byte[] Setup_Finished_Window;
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

        public static string passw;

        public static void Installer_Run()
        {
            if(Bool_Manager.Is_Setup_Running == true)
            {
                if(Bool_Manager.Welcome_Window == true)
                {
                    //ImprovedVBE.DrawImageAlpha(Setup, 1, 1);

                    //ImprovedVBE.DrawImageAlpha(Welcome, 1, 1);

                    Welcome.RawData.CopyTo(ImprovedVBE.cover.RawData, 0);

                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if(clicked_since > 90)
                        {
                            if (Kernel.X > 1250 && Kernel.X < 1330)
                            {
                                if (Kernel.Y > 733 && Kernel.Y < 766)
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
                    //ImprovedVBE.DrawImageAlpha(Setup_Collect, 1, 1);
                    //ImprovedVBE.DrawImageAlpha(Collect, 1, 1);


                    Collect.RawData.CopyTo(ImprovedVBE.cover.RawData, 0);

                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if(Kernel.X > 764 && Kernel.X < 1101)
                        {
                            if(Kernel.Y > 502 && Kernel.Y < 532)
                            {
                                active = "name";
                                clicked_since = 0;
                            }
                            if (Kernel.Y > 562 && Kernel.Y < 592)
                            {
                                active = "username";
                                clicked_since = 0;
                            }
                            if (Kernel.Y > 622 && Kernel.Y < 652)
                            {
                                active = "password";
                                clicked_since = 0;
                            }
                            /*
                            if (Kernel.Y > 350 + 203 && Kernel.Y < 350 + 224)
                            {
                                active = "password2";
                                clicked_since = 0;
                            }
                            */
                        }
                        if (clicked_since > 90)
                        {
                            if (Kernel.X > 1250 && Kernel.X < 1330)
                            {
                                if (Kernel.Y > 733 && Kernel.Y < 766)
                                {
                                    Bool_Manager.Visual_pref1 = true;
                                    Bool_Manager.Collecting_Window = false;
                                    clicked_since = 0;
                                }
                            }
                        }
                    }
                    ImprovedVBE._DrawACSIIString(name, 772, 508, 0);
                    ImprovedVBE._DrawACSIIString(username, 772, 568, 0);
                    ImprovedVBE._DrawACSIIString(password, 772, 628, 0);
                    //ImprovedVBE._DrawACSIIString(password2, 850 + 123, 350 + 208, 0);
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
                if (Bool_Manager.Visual_pref1 == true)
                {
                    //ImprovedVBE.DrawImageAlpha(Setup_Visual_pref1, 1, 1);

                    Setup_Visual_pref1.RawData.CopyTo(ImprovedVBE.cover.RawData, 0);

                    //c.DrawImage(Setup_Visual_pref1, 850, 350);
                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if (clicked_since > 90)
                        {
                            if (Kernel.X > 1250 && Kernel.X < 1330)
                            {
                                if (Kernel.Y > 733 && Kernel.Y < 766)
                                {
                                    clicked_since = 0;
                                    Bool_Manager.Visual_pref2 = true;
                                    Bool_Manager.Visual_pref1 = false;
                                }
                            }
                        }
                        if (Kernel.Y > 382 && Kernel.Y < 551)
                        {
                            if (Kernel.X > 606 && Kernel.X < 725)
                            {
                                selected_cursor = "bas4";
                            }
                            if (Kernel.X > 739 && Kernel.X < 858)
                            {
                                selected_cursor = "bas3";
                            }
                            if (Kernel.X > 859 && Kernel.X < 969)
                            {
                                selected_cursor = "bas1";
                            }
                            if (Kernel.X > 870 && Kernel.X < 989)
                            {
                                selected_cursor = "bas2";
                            }
                        }
                    }
                }
                if (Bool_Manager.Visual_pref2 == true)
                {
                    //ImprovedVBE.DrawImageAlpha(Setup_Visual_pref2, 1, 1);

                    Setup_Visual_pref2.RawData.CopyTo(ImprovedVBE.cover.RawData, 0);
                    
                    //ImprovedVBE.DrawImageAlpha(Setup_Visual_pref2, 850, 350);
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (clicked_since > 90)
                        {
                            if (Kernel.X > 1250 && Kernel.X < 1330)
                            {
                                if (Kernel.Y > 733 && Kernel.Y < 766)
                                {
                                    clicked_since = 0;
                                    passw = Encoder(password);
                                    //File.Delete(@"0:\System_Data.sys");
                                    File.Create(@"0:\System_Data.sys");
                                    File.WriteAllText(@"0:\System_Data.sys", name + "\n" + username + "\n" + passw + "\n" + wallpaper + "\n" + selected_cursor + "\n" + "Setup_File");
                                    //Bool_Manager.Is_Setup_Running = false;
                                    Bool_Manager.Setup_Finished = true;
                                    Bool_Manager.Visual_pref2 = false;
                                }
                            }
                        }/*
                        if (Kernel.Y > 350 + 360 && Kernel.Y < 350 + 381)
                        {
                            if (Kernel.X > 850 + 447 && Kernel.X < 850 + 530)
                            {
                                File.Create(@"0:\System_Data.sys");
                                File.WriteAllText(@"0:\System_Data.sys", name + "\n" + username + "\n" + password + "\n" + password2 + "\n" + wallpaper + "\n" + selected_cursor);
                                Bool_Manager.Visual_pref2 = false;
                            }
                        }*/
                        if (Kernel.Y > 388 && Kernel.Y < 523)
                        {
                            if (Kernel.X > 680 && Kernel.X < 937)
                            {
                                wallpaper = "90_Style";
                            }
                            if (Kernel.X > 997 && Kernel.X < 1252)
                            {
                                wallpaper = "Midnight_in_NY";
                            }
                            
                        }
                        if (Kernel.Y > 553 && Kernel.Y < 687)
                        {
                            if (Kernel.X > 680 && Kernel.X < 937)
                            {
                                wallpaper = "autumn";
                            }
                            if (Kernel.X > 997 && Kernel.X < 1252)
                            {
                                wallpaper = "Windows_Puma";
                            }
                        }
                    }
                }
                if(Bool_Manager.Setup_Finished == true)
                {
                    //c.DrawImage(Setup_finished, 1, 1);
                    //ImprovedVBE.DrawImageAlpha(Setup_finished_window, 1, 1);

                    Setup_finished_window.RawData.CopyTo(ImprovedVBE.cover.RawData, 0);

                    if (clicked_since > 90)
                    {
                        if (MouseManager.MouseState == MouseState.Left)
                        {
                            if (Kernel.X > 1252 && Kernel.X < 1332)
                            {
                                if (Kernel.Y > 733 && Kernel.Y < 766)
                                {
                                    Cosmos.System.Power.Reboot();
                                    Bool_Manager.Is_Setup_Running = false;
                                    clicked_since = 0;
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
string modded = c.ToString();
modded = input.Replace("a", "l0");
modded = modded.Replace("A", "l1");
modded = modded.Replace("b", "x0");
modded = modded.Replace("B", "x1");
modded = modded.Replace("c", "00");
modded = modded.Replace("C", "01");
modded = modded.Replace("d", "40");
modded = modded.Replace("D", "41");
modded = modded.Replace("e", "k0");
modded = modded.Replace("E", "k1");
modded = modded.Replace("f", "w0");
modded = modded.Replace("F", "w1");
modded = modded.Replace("g", "r0");
modded = modded.Replace("G", "r1");
modded = modded.Replace("h", "30");
modded = modded.Replace("H", "31");
modded = modded.Replace("i", "p0");
modded = modded.Replace("I", "p1");
modded = modded.Replace("j", "10");
modded = modded.Replace("J", "11");
modded = modded.Replace("k", "u0");
modded = modded.Replace("K", "u1");
modded = modded.Replace("l", "90");
modded = modded.Replace("L", "91");
modded = modded.Replace("m", "80");
modded = modded.Replace("M", "81");
modded = modded.Replace("n", "=0");
modded = modded.Replace("N", "=1");
modded = modded.Replace("o", "v0");
modded = modded.Replace("O", "v1");
modded = modded.Replace("p", "70");
modded = modded.Replace("P", "71");
modded = modded.Replace("q", "20");
modded = modded.Replace("Q", "21");
modded = modded.Replace("r", ":0");
modded = modded.Replace("R", ":1");
modded = modded.Replace("s", "z0");
modded = modded.Replace("S", "z1");
modded = modded.Replace("t", ".0");
modded = modded.Replace("T", ".1");
modded = modded.Replace("u", "60");
modded = modded.Replace("U", "61");
modded = modded.Replace("v", "c0");
modded = modded.Replace("V", "c1");
modded = modded.Replace("w", "e0");
modded = modded.Replace("W", "e1");
modded = modded.Replace("x", "a0");
modded = modded.Replace("X", "a1");
modded = modded.Replace("y", "m0");
modded = modded.Replace("Y", "m1");
modded = modded.Replace("z", "f0");
modded = modded.Replace("Z", "f1");

modded = modded.Replace("1", "d0");
modded = modded.Replace("2", "i0");
modded = modded.Replace("3", "o0");
modded = modded.Replace("4", "/0");
modded = modded.Replace("5", "h0");
modded = modded.Replace("6", "g0");
modded = modded.Replace("7", "j0");
modded = modded.Replace("8", "k0");
modded = modded.Replace("9", "n0");
modded = modded.Replace("0", "q0");
modded = modded.Replace(".", "t0");
modded = modded.Replace("/", "s0");
modded = modded.Replace(":", "y0");
modded = modded.Replace("=", "b0");

output += modded;
*/

        public static string Encoder(string input)
        {
            string output = "";
            foreach(char c in input)
            {
                if(c == 'a')
                {
                    output += "l0";
                }
                else if(c == 'A')
                {
                    output += "l1";
                }
                else if (c == 'b')
                {
                    output += "x0";
                }
                else if (c == 'B')
                {
                    output += "x1";
                }
                else if (c == 'c')
                {
                    output += "00";
                }
                else if (c == 'C')
                {
                    output += "01";
                }
                else if (c == 'd')
                {
                    output += "40";
                }
                else if (c == 'D')
                {
                    output += "41";
                }
                else if (c == 'e')
                {
                    output += "k0";
                }
                else if (c == 'E')
                {
                    output += "k1";
                }
                else if (c == 'f')
                {
                    output += "w0";
                }
                else if (c == 'F')
                {
                    output += "w1";
                }
                else if (c == 'g')
                {
                    output += "r0";
                }
                else if (c == 'G')
                {
                    output += "r1";
                }
                else if (c == 'h')
                {
                    output += "30";
                }
                else if (c == 'H')
                {
                    output += "31";
                }
                else if (c == 'i')
                {
                    output += "p0";
                }
                else if (c == 'I')
                {
                    output += "p1";
                }
                else if (c == 'j')
                {
                    output += "10";
                }
                else if (c == 'j')
                {
                    output += "11";
                }
                else if (c == 'k')
                {
                    output += "u0";
                }
                else if (c == 'K')
                {
                    output += "u1";
                }
                else if (c == 'l')
                {
                    output += "90";
                }
                else if (c == 'L')
                {
                    output += "91";
                }
                else if (c == 'm')
                {
                    output += "80";
                }
                else if (c == 'M')
                {
                    output += "81";
                }
                else if (c == 'n')
                {
                    output += "=0";
                }
                else if (c == 'N')
                {
                    output += "=1";
                }
                else if (c == 'o')
                {
                    output += "v0";
                }
                else if (c == 'O')
                {
                    output += "v1";
                }
                else if (c == 'p')
                {
                    output += "70";
                }
                else if (c == 'P')
                {
                    output += "71";
                }
                else if (c == 'q')
                {
                    output += "20";
                }
                else if (c == 'Q')
                {
                    output += "21";
                }
                else if (c == 'r')
                {
                    output += ":0";
                }
                else if (c == 'R')
                {
                    output += ":1";
                }
                else if (c == 's')
                {
                    output += "z0";
                }
                else if (c == 'S')
                {
                    output += "z1";
                }
                else if (c == 't')
                {
                    output += ".0";
                }
                else if (c == 'T')
                {
                    output += ".1";
                }
                else if (c == 'u')
                {
                    output += "60";
                }
                else if (c == 'U')
                {
                    output += "61";
                }
                else if (c == 'v')
                {
                    output += "c0";
                }
                else if (c == 'V')
                {
                    output += "c1";
                }
                else if (c == 'w')
                {
                    output += "e0";
                }
                else if (c == 'W')
                {
                    output += "e1";
                }
                else if (c == 'x')
                {
                    output += "a0";
                }
                else if (c == 'X')
                {
                    output += "a1";
                }
                else if (c == 'y')
                {
                    output += "m0";
                }
                else if (c == 'Y')
                {
                    output += "m1";
                }
                else if (c == 'z')
                {
                    output += "f0";
                }
                else if (c == 'Z')
                {
                    output += "f1";
                }

                else if (c == '1')
                {
                    output += "d0";
                }
                else if (c == '2')
                {
                    output += "i0";
                }
                else if (c == '3')
                {
                    output += "o0";
                }
                else if (c == '4')
                {
                    output += "/0";
                }
                else if (c == '5')
                {
                    output += "h0";
                }
                else if (c == '6')
                {
                    output += "g0";
                }
                else if (c == '7')
                {
                    output += "j0";
                }
                else if (c == '8')
                {
                    output += "k0";
                }
                else if (c == '9')
                {
                    output += "n0";
                }
                else if (c == '0')
                {
                    output += "q0";
                }

                else if (c == '.')
                {
                    output += "t0";
                }
                else if (c == '/')
                {
                    output += "s0";
                }
                else if (c == ':')
                {
                    output += "y0";
                }
                else if (c == '=')
                {
                    output += "b0";
                }
            }
            

            return output;
        }


    }
}