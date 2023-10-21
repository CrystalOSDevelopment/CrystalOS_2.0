using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.Applications.Menu;
using CrystalOS.Applications.Programmers_Dream;
using CrystalOS.SystemFiles;
using CrystalOS2.Applications.Task_Scheduler;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Applications.Run
{
    public static class Run
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Run.Run.bmp")] public static byte[] Window;
        public static Bitmap base_Window = new Bitmap(Window);

        public static string line = "";
        public static void Run_Window()
        {
            if(MouseManager.MouseState == MouseState.Left)
            {
                if(MouseManager.X > 77 && MouseManager.X < 145)
                {
                    if(MouseManager.Y > 2 && MouseManager.Y < 26)
                    {
                        Bool_Manager.Run_Window = true;
                    }
                }
            }
            if(Bool_Manager.Run_Window == true)
            {
                ImprovedVBE.DrawImageAlpha(base_Window, 3, 32);
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > 374 && MouseManager.X < 389)
                    {
                        if (MouseManager.Y > 36 && MouseManager.Y < 48)
                        {
                            Bool_Manager.Run_Window = false;
                        }
                    }
                }

                ImprovedVBE._DrawACSIIString(line, 3 + 90, 32 + 92, 0);

                KeyEvent key;

                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (line.Length != 0)
                        {
                            line = line.Remove(line.Length - 1);
                        }
                    }
                    else if (key.Key == ConsoleKeyEx.Enter)
                    {
                        exec(line);
                    }
                    else
                    {
                        line += key.KeyChar;
                    }
                }
            }
        }
        public static void exec(string command)
        {
            if (command.ToLower() == "crystalver")
            {
                Bool_Manager.About_Opened = true;
                line = "";
                Bool_Manager.Run_Window = false;
            }
            else if (command.ToLower() == "cmd")
            {
                Bool_Manager.Terminal_Opened = true;
                Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("terminal", Menumgr.z, Menumgr.c, false, "C:\\", true));
                //Terminal_Core.displayed.Add("C:\\");
                Menumgr.c += 100;
                Menumgr.z += 100;
                line = "";
                Bool_Manager.Run_Window = false;
            }
            else if (command.ToLower().EndsWith(".txt"))
            {
                command = command.Replace("/", "\\");
                Bool_Manager.Text_Editor_Opened = true;
                string shit = File.ReadAllText(command);
                Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string, bool>("text_editor", 100, 100, false, shit, true));
                line = "";
                Bool_Manager.Run_Window = false;
            }
            else if (command.ToLower().StartsWith("cmd "))
            {

            }
            else if (command.ToLower() == "std")
            {
                Cosmos.System.Power.Shutdown();
            }
            else if (command.ToLower() == "rbt")
            {
                Cosmos.System.Power.Reboot();
            }
            else if (command.ToLower() == "log out" || command.ToLower() == "logout" || command.ToLower() == "lout")
            {

            }
            else
            {
                command = command.Replace("/", "\\");
                if (command.EndsWith(".run"))
                {
                    string shit = File.ReadAllText(command);
                    Programmers_Choice.Graphical_Exec(shit);
                }
                line = "";
                Bool_Manager.Run_Window = false;
            }
        }
    }
}
