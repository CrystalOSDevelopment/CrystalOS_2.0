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

namespace CrystalOS.Applications.Text_Editor
{
    public class Text_Editor
    {
        public static string content = "";
        public static string modified_content = "";
        public static string content2 = "";
        public static int numbers_of_chars = 0; //36 max chars
        //public static int[] prev_num = new int[36];
        public static List<int> prev_num = new List<int>();
        public static int total_chars = 0;
        public static bool movable = false;
        public static bool get_last_length = true;
        public static int i = 0;
        public static List<int> line = new List<int>();

        public static int count = 0;

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Text_Editor.Text_Editor.bmp")] public static byte[] text_editor_base;
        public static Bitmap Text_Editor_base = new Bitmap(text_editor_base);

        public static void text_editor(int x, int y)
        {
            ImprovedVBE.DrawImageAlpha(Text_Editor_base, x, y);

            content = Task_Manager.Tasks[Task_Manager.indicator].Item5;
            if (Bool_Manager.Text_Editor_Opened == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x + 722 && Kernel.X < x + 750)//780 or add 30 to gain back
                    {
                        if (Kernel.Y > y + 7 && Kernel.Y < y + 30)
                        {
                            //Bool_Manager.Text_Editor_Opened = false;
                            line.RemoveAt(Task_Manager.editor_counter);
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                        }
                    }
                    if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == false)
                    {
                        if (Kernel.X > x && Kernel.X < x + 667)
                        {
                            if (Kernel.Y > y && Kernel.Y < y + 33)
                            {
                                int f = (int)Kernel.X;
                                int g = (int)Kernel.Y;
                                //string saves = Task_Manager.Tasks[Task_Manager.indicator].Item5;
                                Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("text_editor", f, g, true, content, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                                int var = line[Task_Manager.editor_counter];
                                line.RemoveAt(Task_Manager.editor_counter);
                                line.Insert(0, var);
                            }
                        }
                    }
                }
                if (Task_Manager.Tasks[0].Item1 == "text_editor" && Task_Manager.indicator == 0)
                {
                    KeyEvent key;
                    if (KeyboardManager.TryReadKey(out key))
                    {
                        if (key.Key == ConsoleKeyEx.Backspace)
                        {
                            if (Text_Editor.content.Length != 0)
                            {
                                Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                Task_Manager.Tasks.RemoveAt(0);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("text_editor", x, y, false, content, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                            }
                        }
                        else if (key.Key == ConsoleKeyEx.Enter)
                        {
                            Text_Editor.content += "\n";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("text_editor", x, y, false, content, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                        }
                        else
                        {
                            Text_Editor.content += key.KeyChar;
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("text_editor", x, y, false, content, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                        }

                        if (count >= 0)
                        {
                            if (count <= 22)
                            {
                                
                                count++;
                            }
                            if (count > 22)
                            {
                                line[Task_Manager.editor_counter] -= 1;
                            }
                        }
                        else
                        {
                            count++;
                        }
                        
                    }
                }

                i = 0;
                modified_content = "";
                foreach (char character in Task_Manager.Tasks[Task_Manager.indicator].Item5)
                {
                    if (i == 70)//36
                    {
                        modified_content += "\n";
                        i = 0;
                    }
                    if (character == '\n')
                    {
                        modified_content += character;
                        i = 0;
                    }
                    else
                    {
                        modified_content += character;
                        i++;
                    }
                }

                count = line[Task_Manager.editor_counter];
                int a = 3;
                int b = 39;
                foreach (string s in modified_content.Split('\n'))
                {
                    if (count >= 0 && count <= 22)
                    {
                        ImprovedVBE._DrawACSIIString(s, x + a, y + b, 16777215);
                        b += 20;
                    }
                    count++;
                    //line[Task_Manager.editor_counter]
                }

                if (MouseManager.MouseState == MouseState.Left)
                {

                    if(Kernel.X > x + 734 && Kernel.X < x + 750)
                    {
                        //223
                        if(Kernel.Y > y + 36 && Kernel.Y < y + 259)
                        {
                            line[Task_Manager.editor_counter] -= 1;
                        }
                        else if (Kernel.Y > y + 259 && Kernel.Y < y + 500)
                        {
                            line[Task_Manager.editor_counter] += 1;
                        }
                    }
                }
                //60

                /*
                                if (KeyboardManager.TryReadKey(out key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        if (Text_Editor.content.Length != 0)
                                        {
                                            Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                            return;
                                        }
                                    }
                                    if (key.Key == ConsoleKeyEx.Enter)
                                    {
                                        Text_Editor.content += "\n";
                                        return;
                                    }
                                    else
                                    {
                                        Text_Editor.content += key.KeyChar;
                                        return;
                                    }
                                }
                                if (KeyboardManager.TryReadKey(out key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        if (Text_Editor.content.Length != 0)
                                        {
                                            Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                            return;
                                        }
                                    }
                                    if (key.Key == ConsoleKeyEx.Enter)
                                    {
                                        Text_Editor.content += "\n";
                                        return;
                                    }
                                    else
                                    {
                                        Text_Editor.content += key.KeyChar;
                                        return;
                                    }
                                }
                                if (KeyboardManager.TryReadKey(out key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        if (Text_Editor.content.Length != 0)
                                        {
                                            Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                            return;
                                        }
                                    }
                                    if (key.Key == ConsoleKeyEx.Enter)
                                    {
                                        Text_Editor.content += "\n";
                                        return;
                                    }
                                    else
                                    {
                                        Text_Editor.content += key.KeyChar;
                                        return;
                                    }
                                }
                                if (KeyboardManager.TryReadKey(out key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        if (Text_Editor.content.Length != 0)
                                        {
                                            Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                            return;
                                        }
                                    }
                                    if (key.Key == ConsoleKeyEx.Enter)
                                    {
                                        Text_Editor.content += "\n";
                                        return;
                                    }
                                    else
                                    {
                                        Text_Editor.content += key.KeyChar;
                                        return;
                                    }
                                }
                                if (KeyboardManager.TryReadKey(out key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        if (Text_Editor.content.Length != 0)
                                        {
                                            Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                            return;
                                        }
                                    }
                                    if (key.Key == ConsoleKeyEx.Enter)
                                    {
                                        Text_Editor.content += "\n";
                                        return;
                                    }
                                    else
                                    {
                                        Text_Editor.content += key.KeyChar;
                                        return;
                                    }
                                }
                                if (KeyboardManager.TryReadKey(out key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        if (Text_Editor.content.Length != 0)
                                        {
                                            Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                            return;
                                        }
                                    }
                                    if (key.Key == ConsoleKeyEx.Enter)
                                    {
                                        Text_Editor.content += "\n";
                                        return;
                                    }
                                    else
                                    {
                                        Text_Editor.content += key.KeyChar;
                                        return;
                                    }
                                }
                                if (KeyboardManager.TryReadKey(out key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        if (Text_Editor.content.Length != 0)
                                        {
                                            Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                            return;
                                        }
                                    }
                                    if (key.Key == ConsoleKeyEx.Enter)
                                    {
                                        Text_Editor.content += "\n";
                                        return;
                                    }
                                    else
                                    {
                                        Text_Editor.content += key.KeyChar;
                                        return;
                                    }
                                }
                                if (KeyboardManager.TryReadKey(out key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        if (Text_Editor.content.Length != 0)
                                        {
                                            Applications.Text_Editor.Text_Editor.content = Applications.Text_Editor.Text_Editor.content.Remove(Applications.Text_Editor.Text_Editor.content.Length - 1);
                                            return;
                                        }
                                    }
                                    if (key.Key == ConsoleKeyEx.Enter)
                                    {
                                        Text_Editor.content += "\n";
                                        return;
                                    }
                                    else
                                    {
                                        Text_Editor.content += key.KeyChar;
                                        return;
                                    }
                                }
                                */
                if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
                {
                    int f = (int)Kernel.X;
                    int g = (int)Kernel.Y;
                    Task_Manager.Tasks.RemoveAt(0);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("text_editor", f, g, true, content, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                    int var = line[Task_Manager.editor_counter];
                    line.RemoveAt(Task_Manager.editor_counter);
                    line.Insert(0, var);
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("text_editor", f, g, false, content, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                        int var2 = line[Task_Manager.editor_counter];
                        line.RemoveAt(Task_Manager.editor_counter);
                        line.Insert(0, var2);
                        //Task_Manager.Tasks.Reverse();
                        //movable = false;
                    }
                }

                content = "";
                content2 = "";
            }
        }
    }
}