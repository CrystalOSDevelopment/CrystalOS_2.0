using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.Applications.Text_Editor;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SoundTest.SystemFiles
{
    public class Lock_Screen
    {
        [ManifestResourceStream(ResourceName = "SoundTest.SystemFiles.Lock_Screen.bmp")] public static byte[] Menu;
        public static Bitmap screen = new Bitmap(Menu);
        public static string username = "";
        public static string password = "";
        public static bool usernameinput = true;
        public static bool passwordinput = false;
        public static bool trylogin = false;
        public static void lock_screen()
        {
            if(Bool_Manager.is_locked == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > 864 && MouseManager.X < 1591)
                    {
                        if (MouseManager.Y > 429 && MouseManager.Y < 507)
                        {
                            usernameinput = true;
                            passwordinput = false;
                        }

                        if (MouseManager.Y > 571 && MouseManager.Y < 649)
                        {
                            usernameinput = false;
                            passwordinput = true;
                        }
                    }
                    if(MouseManager.X > 1453 && MouseManager.X < 1589)
                    {
                        if(MouseManager.Y > 1004 && MouseManager.Y < 1057)
                        {
                            Bool_Manager.wallp = Kernel.saved;
                            Bool_Manager.is_locked = false;
                            trylogin = false;
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
                                return;
                            }
                        }
                        if (key.Key == ConsoleKeyEx.Enter)
                        {
                            passwordinput = true;
                            usernameinput = false;
                            return;
                        }
                        else
                        {
                            username += key.KeyChar;
                            return;
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
                                password = password.Remove(password.Length - 1);
                                return;
                            }
                        }
                        if (key.Key == ConsoleKeyEx.Enter)
                        {
                            trylogin = true;
                            return;
                        }
                        else
                        {
                            password += key.KeyChar;
                            return;
                        }
                    }
                }

                if(trylogin == true)
                {
                    //Identify user!
                    Bool_Manager.wallp = Kernel.saved;
                    Bool_Manager.is_locked = false;
                    trylogin = false;
                }

                ImprovedVBE._DrawACSIIString(username, 870, 458, 0);
                ImprovedVBE._DrawACSIIString(password, 870, 600, 0);
            }
            //ImprovedVBE.DrawImage(screen, 0, 0);
        }
    }
}
