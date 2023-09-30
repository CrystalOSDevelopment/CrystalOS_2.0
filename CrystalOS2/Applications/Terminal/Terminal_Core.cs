using Cosmos.HAL.Network;
using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Network.Config;
using CrystalOS.Applications.Solitaire;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using CrystalOS2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalOS2.Applications.Task_Scheduler;
using Kernel = CrystalOS2.Kernel;

namespace CrystalOS.Applications.Terminal
{
    public class Terminal_Core
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Terminal.Terminal.bmp")] public static byte[] Terminal_base;
        public static Bitmap term_base = new Bitmap(Terminal_base);
        public static List<string> prev_commands = new List<string>();
        public static int number_of_command = 0;
        public static string content = "c:\\";
        public static string command_input = "";
        public static string displayed = "c:\\";
        public static string last_line;
        public static string lines;
        public static bool offed = false;
        public static bool movable = false;
        public static void Terminal()
        {
            displayed = Task_Manager.Tasks[Task_Manager.indicator].Item5;
            ImprovedVBE.DrawImageAlpha(term_base, Task_Manager.Tasks[Task_Manager.indicator].Item2, Task_Manager.Tasks[Task_Manager.indicator].Item3);
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (Kernel.X > Task_Manager.Tasks[Task_Manager.indicator].Item2 + 605 && Kernel.X < Task_Manager.Tasks[Task_Manager.indicator].Item2 + 649)
                {
                    if (Kernel.Y > Task_Manager.Tasks[Task_Manager.indicator].Item3 && Kernel.Y < Task_Manager.Tasks[Task_Manager.indicator].Item3 + 17)
                    {
                        //Bool_Manager.Terminal_Opened = false;
                        Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                    }
                }
                if (movable == false)
                {
                    if (Kernel.X > Task_Manager.Tasks[Task_Manager.indicator].Item2 && Kernel.X < Task_Manager.Tasks[Task_Manager.indicator].Item2 + 552)
                    {
                        if (Kernel.Y > Task_Manager.Tasks[Task_Manager.indicator].Item3 && Kernel.Y < Task_Manager.Tasks[Task_Manager.indicator].Item3 + 18)
                        {
                            int f = (int)Kernel.X;
                            int g = (int)Kernel.Y;
                            //string saves = Task_Manager.Tasks[Task_Manager.indicator].Item5;
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("terminal", f, g, true, displayed, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                        }
                    }
                }
            }

            int i = 0;
            foreach (char ch in displayed)
            {
                if (ch == '\n')
                {
                    i++;
                }
                else
                {

                }
            }

            int charcount = 0;
            foreach (char ch in displayed)
            {
                if (i > 24)
                {
                    if (ch == '\n')
                    {
                        displayed = displayed.Remove(0, charcount + 1);
                        i -= 1;
                        charcount = 0;
                    }
                    else
                    {
                        charcount += 1;
                    }
                }
            }

            ImprovedVBE._DrawACSIIString(displayed, Task_Manager.Tasks[Task_Manager.indicator].Item2 + 4, Task_Manager.Tasks[Task_Manager.indicator].Item3 + 21, 0);

            #region core
            if (Task_Manager.Tasks[0].Item1 == "terminal" && Task_Manager.indicator == 0)
            {
                KeyEvent key;

                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (command_input.Length != 0)
                        {
                            //displayed = displayed.Remove(displayed.Length - 1);
                            Tuple<string, int, int, bool, string, bool, int> s = Task_Manager.Tasks[Task_Manager.indicator];
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                            string mod = s.Item5.Remove(s.Item5.Length - 1);
                            Task_Manager.Tasks.Insert(Task_Manager.indicator, new Tuple<string, int, int, bool, string, bool, int>(s.Item1, s.Item2, s.Item3, s.Item4, mod, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                            command_input = command_input.Remove(command_input.Length - 1);
                        }
                    }
                    else if (key.Key == ConsoleKeyEx.Enter)
                    {
                        Commands(command_input);
                        prev_commands.Add(command_input);
                        Tuple<string, int, int, bool, string, bool, int> s = Task_Manager.Tasks[Task_Manager.indicator];
                        Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                        Task_Manager.Tasks.Insert(Task_Manager.indicator, new Tuple<string, int, int, bool, string, bool, int>(s.Item1, s.Item2, s.Item3, s.Item4, displayed, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                    }
                    else
                    {
                        command_input += key.KeyChar;
                        //displayed += key.KeyChar;
                        Tuple<string, int, int, bool, string, bool, int> s = Task_Manager.Tasks[Task_Manager.indicator];
                        Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                        string mod = s.Item5;
                        mod += key.KeyChar;
                        Task_Manager.Tasks.Insert(Task_Manager.indicator, new Tuple<string, int, int, bool, string, bool, int>(s.Item1, s.Item2, s.Item3, s.Item4, mod, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                    }
                }
            }

            #endregion core

            if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
            {
                int f = (int)Kernel.X;
                int g = (int)Kernel.Y;
                Task_Manager.Tasks.RemoveAt(0);
                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("terminal", f, g, true, displayed, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                if (MouseManager.MouseState == MouseState.Right)
                {
                    Task_Manager.Tasks.RemoveAt(0);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("terminal", f, g, false, displayed, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                    //Task_Manager.Tasks.Reverse();
                    //movable = false;
                }
            }

            /*
            if (movable == true)
            {
                Task_Manager.Tasks[Task_Manager.indicator].Item2 = (int)Kernel.X;
                Task_Manager.Tasks[Task_Manager.indicator].Item3 = (int)Kernel.Y;
                if (MouseManager.MouseState == MouseState.Right)
                {
                    movable = false;
                }
            }
            */


            //lines = displayed.Split('\n');
            /*
            if(lines.Length > 25)
            {

                for(int i = 0; i < lines.Length - 24; i++)
                {
                    lines[0 + i] = "";
                }

                displayed = "";
                int num = 0;
                foreach (string s in lines)
                {
                    if (num < 25)
                    {
                        displayed += s + "\n";
                    }
                    if (num == 25)
                    {
                        displayed += s;
                    }
                    num++;
                }

            }
            */
        }

        public static void Commands(string command)
        {
            if (command.StartsWith("echo "))
            {
                /*
                string trimmed = command.Remove(0, 5);
                displayed += "\n" + trimmed + "\n" + content;
                command_input = "";
                */
                if(offed == false)
                {
                    string trimmed = command.Remove(0, 5);
                    displayed += "\n" + trimmed + "\n" + content;
                    command_input = "";
                }
                if(offed == true)
                {
                    string trimmed = command.Remove(0, 5);
                    displayed += "\n" + trimmed + "\n";
                    command_input = "";
                }
            }
            else if (command == "-echo off")
            {
                
                displayed += "\n";
                offed = true;
                command_input = "";
            }
            else if (command == "-echo on")
            {

                displayed += "\n" + content ;
                offed = false;
                command_input = "";
            }
            else if (command == "Clear" || command == "clear")
            {
                displayed = "";
                command_input = "";
                if(offed == false)
                {
                    displayed += content;
                }
            }
            else if (command.StartsWith("read "))
            {
                displayed += "\n";
                string[] values = command.Split(' ');
                string filename = values[1];
                string length = "1";
                try
                {
                    length = values[2];
                    if(length == "full")
                    {
                        foreach (string text in File.ReadAllLines("0:\\" + filename))
                        {
                            displayed += text + "\n";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < int.Parse(length); i++)
                        {
                            displayed += File.ReadAllLines("0:\\" + filename)[i] + "\n";
                        }
                    }
                }
                catch
                {
                    foreach(string text in File.ReadAllLines("0:\\" + filename))
                    {
                        displayed += text + "\n";
                    }
                }
                if (offed == false)
                {
                    displayed += content;
                }
                command_input = "";
            }
            else if (command.StartsWith("mkfile "))
            {
                string trimmed = command.Remove(0, 7);
                displayed += "\nAttempting to create file... ";
                try
                {
                    try
                    {
                        trimmed = trimmed.Replace("/", "\\");
                    }
                    catch
                    {

                    }
                    File.Create("0:\\" + trimmed);
                    if (offed == false)
                    {
                        displayed += "(Success!)\n" + content;
                    }
                    else
                    {
                        displayed += "(Success!)\n";
                    }
                }
                catch
                {
                    if(offed == false)
                    {
                        displayed += "\nFailed to create file: " + trimmed + "\n" + content;
                    }
                    else
                    {
                        displayed += "\nFailed to create file: " + trimmed + "\n";

                    }
                }
                command_input = "";
            }
            else if (command.StartsWith("mkfolder "))
            {
                string trimmed = command.Remove(0, 9);
                displayed += "\nAttempting to create folder... ";
                try
                {
                    try
                    {
                        trimmed = trimmed.Replace("/", "\\");
                    }
                    catch
                    {

                    }
                    Directory.CreateDirectory("0:\\" + trimmed);
                    if (offed == false)
                    {
                        displayed += "(Success!)\n" + content;
                    }
                    else
                    {
                        displayed += "(Success!)\n";
                    }
                }
                catch
                {
                    if (offed == false)
                    {
                        displayed += "\nFailed to folder file: " + trimmed + "\n" + content;
                    }
                    else
                    {
                        displayed += "\nFailed to folder file: " + trimmed + "\n";

                    }
                }
                command_input = "";
            }
            else if (command.StartsWith("delfile "))
            {
                string trimmed = command.Remove(0, 8);
                displayed += "\nAttempting to delete file... ";
                try
                {
                    try
                    {
                        trimmed = trimmed.Replace("/", "\\");
                    }
                    catch
                    {

                    }
                    File.Delete("0:\\" + trimmed);
                    if (offed == false)
                    {
                        displayed += "(Success!)\n" + content;
                    }
                    else
                    {
                        displayed += "(Success!)\n";
                    }
                }
                catch
                {
                    if (offed == false)
                    {
                        displayed += "\nFailed to delete file: " + trimmed + "\n" + content;
                    }
                    else
                    {
                        displayed += "\nFailed to delete file: " + trimmed + "\n";

                    }
                }
                command_input = "";
            }
            else if (command.StartsWith("delfolder "))
            {
                string trimmed = command.Remove(0, 10);
                displayed += "\nAttempting to delete folder... ";
                try
                {
                    try
                    {
                        trimmed = trimmed.Replace("/", "\\");
                    }
                    catch
                    {

                    }
                    Directory.Delete("0:\\" + trimmed);
                    if (offed == false)
                    {
                        displayed += "(Success!)\n" + content;
                    }
                    else
                    {
                        displayed += "(Success!)\n";
                    }
                }
                catch
                {
                    if (offed == true)
                    {
                        displayed += "\nFailed to delete folder: " + trimmed + "\n" + content;
                    }
                    else
                    {
                        displayed += "\nFailed to delete folder: " + trimmed + "\n";

                    }
                }
                command_input = "";
            }
            else if (command.StartsWith("beep") || command.StartsWith("Beep"))
            {
                try
                {
                    string[] info = command.Split(' ');
                    PCSpeaker.Beep((uint)int.Parse(info[1]), (uint)int.Parse(info[2]));
                }
                catch
                {
                    PCSpeaker.Beep(830, 1);
                }
                if (offed == false)
                {
                    displayed += "\n" + content;
                }
                else
                {
                    displayed += "\n";
                }
                command_input = "";
            }
            else if (command == "help" || command == "Help")
            {
                displayed += "\n-echo off ----- Removes directory entry indicator\n";
                displayed += "-echo on  ----- Readds directory entry indicator\n";//48
                displayed += "echo      ----- Displays text after echo command\n";//2
                displayed += "clear     ----- Clears the terminal\n";//2
                displayed += "read      ----- Read from a specified file\n";//37 - 34 - 35   fn read_length    (\nif read_length is empty it will read the entire file)
                displayed += "mkfile/delfile ----- Creates/Deletes a file\n";//21
                displayed += "mkfolder/delfolder ----- Creates/Deletes a folder\n";
                displayed += "beep      ----- Makes a beeping sound(PCSpeaker)\n";
                displayed += "help      ----- Shows all the commands available\n";
                //Maximum character width is 39
                if (offed == false)
                {
                    displayed += content;
                }
                else
                {

                }
                command_input = "";
            }
            else if (command == "version")
            {
                displayed += "\nCrystal Terminal Version 1.0\nAll rights reserved(c)\n";
                if (offed == false)
                {
                    displayed += content;
                }
                else
                {

                }
                command_input = "";
            }
            else
            {
                if (offed == false)
                {
                    displayed += "\n" + "Bad command or file name!" + "\n" + content;
                    command_input = "";
                }
                if (offed == true)
                {
                    displayed += "\n" + "Bad command or file name!" + "\n";
                    command_input = "";
                }
            }
        }
    }
}