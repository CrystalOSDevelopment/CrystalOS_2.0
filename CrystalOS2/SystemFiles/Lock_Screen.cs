using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.Applications.About;
using CrystalOS.Applications.Text_Editor;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrystalOS2.SystemFiles
{
    public class Lock_Screen
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Lock_Screen.bmp")] public static byte[] Menu;
        public static Bitmap screen = new Bitmap(Menu);
        public static string username = "";
        public static string password = "";
        public static string hidden_pass = "";
        public static bool usernameinput = true;
        public static bool passwordinput = false;
        public static bool trylogin = false;
        public static void lock_screen()
        {
            if(Bool_Manager.is_locked == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > 829 && MouseManager.X < 1357)
                    {
                        if (MouseManager.Y > 440 && MouseManager.Y < 478)
                        {
                            usernameinput = true;
                            passwordinput = false;
                        }

                        if (MouseManager.Y > 511 && MouseManager.Y < 549)
                        {
                            usernameinput = false;
                            passwordinput = true;
                        }
                    }
                    if(MouseManager.X > 1453 && MouseManager.X < 1589)
                    {
                        if(MouseManager.Y > 1004 && MouseManager.Y < 1057)
                        {
                            trylogin = true;
                        }
                    }
                    if(MouseManager.X > 1615 && MouseManager.X < 1751)
                    {
                        if(MouseManager.Y > 1004 && MouseManager.Y < 1057)
                        {
                            Power.Shutdown();
                        }
                    }
                    if(MouseManager.X > 1777 && MouseManager.X < 1913)
                    {
                        if(MouseManager.Y > 1004 && MouseManager.Y < 1057)
                        {
                            Power.Reboot();
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

                if(trylogin == true)
                {
                    //Identify user!

                    string[] data = File.ReadAllLines(@"0:\System_Data.sys");
                    int counter = 1;
                    foreach(string s in data)
                    {
                        if(s == username)
                        {
                            if (data[counter] == Encoder(password))
                            {
                                About_code.username = username;
                                About_code.is_protected = "Yes";
                                Bool_Manager.wallp = data[counter + 1].Replace(" ", "_");
                                Kernel.saved = data[counter + 1].Replace(" ", "_");
                                Kernel.sel_curs = data[counter + 2];
                                password = "";
                                hidden_pass = "";
                                Bool_Manager.is_locked = false;
                                trylogin = false;
                            }
                        }
                        counter++;
                    }
                    trylogin = false;
                }
                try
                {
                    ImprovedVBE._DrawACSIIString(username, 829, 440, 0);
                    ImprovedVBE._DrawACSIIString(hidden_pass, 829, 511, 0);
                }
                catch
                {

                }

            }
            //ImprovedVBE.DrawImage(screen, 1, 1);
        }

        public static string Encoder(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (c == 'a')
                {
                    output += "l0";
                }
                else if (c == 'A')
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
