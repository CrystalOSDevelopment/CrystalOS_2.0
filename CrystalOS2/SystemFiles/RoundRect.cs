using Cosmos.System;
using CrystalOS2.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.SystemFiles
{
    public static class Window_Layout
    {
        public static List<Tuple<int, int, int, int, string, int, string>> buttons = new List<Tuple<int, int, int, int, string, int, string>>();
        public static List<Tuple<string, string>> buttons_funct = new List<Tuple<string, string>>();
        public static List<Tuple<string, int>> Integers = new List<Tuple<string, int>>();
        public static List<Tuple<string, int>> text = new List<Tuple<string, int>>();
        public static List<Tuple<string, string>> strings = new List<Tuple<string, string>>();
        public static List<Tuple<string, int>> instructions_list = new List<Tuple<string, int>>();
        public static List<Tuple<string, int>> ifs = new List<Tuple<string, int>>();
        public static void Draw_Window(string title, int x, int y, int width, int height)
        {
            #region window_style
            ImprovedVBE.DrawFilledRectangle(120, x, y, width, height);
            ImprovedVBE.DrawFilledRectangle(4605510, x + 1, y + 20, width - 2, height - 21);
            ImprovedVBE.DrawFilledRectangle(16724530, x + width - 18, y + 2, 16, 16);
            ImprovedVBE._DrawACSIIString(title, x + 2, y + 2, 16777215);
            #endregion window_style
            
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (Kernel.X > x + width - 18 && Kernel.X < x + width - 2)
                {
                    if (Kernel.Y > y + 2 && Kernel.Y < y + 18)
                    {
                        //Bool_Manager.Settings_Opened = false;
                        Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                    }
                }
                if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == false)
                {
                    if (Kernel.X > x && Kernel.X < x + width - 10)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 20)
                        {
                            int f = (int)Kernel.X;
                            int g = (int)Kernel.Y;
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>(title, f, g, true, "", true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                        }
                    }
                }
            }

            foreach(Tuple<int, int, int, int, string, int, string> item in buttons)
            {
                if (item.Item6 == Task_Manager.counter / 2)
                {
                    Draw_Button(x + item.Item1, y + item.Item2 + 20, item.Item3, item.Item4, item.Item5);

                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if(Kernel.X > x + item.Item1 && Kernel.X < x + item.Item1 + item.Item3)
                        {
                            if (Kernel.Y > y + item.Item2 + 20 && Kernel.Y < y + item.Item2 + item.Item4 + 20)
                            {
                                //string s = (item.Item7.Remove(0, 9));
                                //s = s.Remove(s.Length - 1);
                                //string[] bas = s.Split(", ");
                                //ImprovedVBE._DrawACSIIString(item.Item7, 500, 300, 16777215);
                                //ImprovedVBE._DrawACSIIString(bas[2], int.Parse(bas[0]), int.Parse(bas[1]), 16777215);

                                //ImprovedVBE.DrawFilledRectangle(16777215, x + item.Item1, y + item.Item2, item.Item3, item.Item4);

                                foreach(Tuple<string, string> script in buttons_funct)
                                {
                                    if(item.Item5 == script.Item1)
                                    {
                                        List<string> instructions = new List<string>();
                                        foreach (string p in script.Item2.Split("\n"))
                                        {
                                            instructions.Add(p);
                                        }
                                        for (int i = 0; i < instructions.Count; i++)
                                        {
                                            if (instructions[i].StartsWith("draw_txt("))
                                            {
                                                string s = (instructions[i].Remove(0, 9));
                                                s = s.Remove(s.Length - 1);
                                                string[] bas = s.Split(", ");
                                                if (!bas[2].Contains("\""))
                                                {
                                                    bool foundsg = false;
                                                    int found = 0;
                                                    foreach (Tuple<string, int> tuple2 in Window_Layout.Integers)
                                                    {
                                                        if (bas[2] == tuple2.Item1)
                                                        {
                                                            found = tuple2.Item2;
                                                            
                                                            foundsg = true;
                                                        }
                                                    }
                                                    bool foundsg2 = false;
                                                    string found2 = "";
                                                    if (!foundsg)
                                                    {
                                                        
                                                        foreach (Tuple<string, string> tuple2 in Window_Layout.strings)
                                                        {
                                                            if (bas[2] == tuple2.Item1)
                                                            {
                                                                found2 = tuple2.Item2;

                                                                foundsg2 = true;
                                                            }
                                                        }
                                                        ImprovedVBE._DrawACSIIString(found2, x + int.Parse(bas[0]), y + 20 + int.Parse(bas[1]), 16777215);
                                                    }
                                                    else
                                                    {
                                                        ImprovedVBE._DrawACSIIString(found.ToString(), x + int.Parse(bas[0]), y + 20 + int.Parse(bas[1]), 16777215);
                                                    }
                                                }
                                                else if (bas[2].Contains(" + "))
                                                {
                                                    string[] data = bas[2].Split(" + ");
                                                    string info = "";
                                                    foreach (string content in data)
                                                    {
                                                        if (content.Contains("\""))
                                                        {
                                                            info += content.Replace("\"", "");
                                                        }
                                                        else
                                                        {
                                                            bool foundsg = false;
                                                            foreach (Tuple<string, int> tuple2 in Window_Layout.Integers)
                                                            {

                                                                if (content == tuple2.Item1)
                                                                {
                                                                    info += tuple2.Item2.ToString();
                                                                    foundsg = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    ImprovedVBE._DrawACSIIString(info, x + int.Parse(bas[0]), y + 20 + int.Parse(bas[1]), 16777215);
                                                }
                                            }

                                            if (instructions[i].Contains(" += "))
                                            {
                                                string s = instructions[i];
                                                string[] data = s.Split(" += ");
                                                bool foundsg = false;
                                                int found = 0;
                                                int epszilon = 100;
                                                foreach (Tuple<string, int> tuple2 in Window_Layout.Integers)
                                                {
                                                    if (data[0] == tuple2.Item1)
                                                    {
                                                        found = tuple2.Item2;

                                                        foundsg = true;
                                                    }
                                                    //ImprovedVBE._DrawACSIIString(tuple2.Item1 + "     " + tuple2.Item2.ToString(), 1000, epszilon, 16777215);
                                                    epszilon += 20;
                                                }
                                                bool foundsg2 = false;
                                                int found2 = 0;
                                                foreach (Tuple<string, int> tuple2 in Window_Layout.Integers)
                                                {
                                                    if (data[1] == tuple2.Item1)
                                                    {
                                                        found2 = tuple2.Item2;

                                                        foundsg2 = true;
                                                    }
                                                }
                                                if (foundsg == true && foundsg2 == true)
                                                {
                                                    try
                                                    {
                                                        Window_Layout.Integers.RemoveAll(d => d.Item1 == data[0]);
                                                        Window_Layout.Integers.Add(new Tuple<string, int>(data[0], found + found2));
                                                    }
                                                    catch
                                                    {
                                                        
                                                    }
                                                }
                                                else if(foundsg2 == false)
                                                {
                                                    try
                                                    {
                                                        Window_Layout.Integers.RemoveAll(d => d.Item1 == data[0]);
                                                        Window_Layout.Integers.Add(new Tuple<string, int>(data[0], found + int.Parse(data[1])));
                                                    }
                                                    catch
                                                    {

                                                    }
                                                }
                                                else
                                                {
                                                    ImprovedVBE._DrawACSIIString("Not working", 1000, 50, 16777215);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for(int i = 0; i < Window_Layout.instructions_list.Count; i++)
            {
                foreach (Tuple<string, int> instructions in instructions_list)
                {
                    if(instructions.Item2 == Task_Manager.foo)
                    {
                        if (instructions.Item1.Contains(" += "))
                        {
                            string s = instructions.Item1;
                            string[] data = s.Split(" += ");
                            bool foundsg = false;
                            int found = 0;
                            int epszilon = 100;
                            foreach (Tuple<string, int> tuple2 in Window_Layout.Integers)
                            {
                                if (data[0] == tuple2.Item1)
                                {
                                    found = tuple2.Item2;

                                    foundsg = true;
                                }
                                //ImprovedVBE._DrawACSIIString(tuple2.Item1 + "     " + tuple2.Item2.ToString(), 1000, epszilon, 16777215);
                                epszilon += 20;
                            }
                            bool foundsg2 = false;
                            int found2 = 0;
                            foreach (Tuple<string, int> tuple2 in Window_Layout.Integers)
                            {
                                if (data[1] == tuple2.Item1)
                                {
                                    found2 = tuple2.Item2;

                                    foundsg2 = true;
                                }
                            }
                            if (foundsg == true && foundsg2 == true)
                            {
                                try
                                {
                                    Window_Layout.Integers.RemoveAll(d => d.Item1 == data[0]);
                                    Window_Layout.Integers.Add(new Tuple<string, int>(data[0], found + found2));
                                }
                                catch
                                {

                                }
                            }
                            else if (foundsg2 == false)
                            {
                                try
                                {
                                    Window_Layout.Integers.RemoveAll(d => d.Item1 == data[0]);
                                    Window_Layout.Integers.Add(new Tuple<string, int>(data[0], found + int.Parse(data[1])));
                                }
                                catch
                                {

                                }
                            }
                            else
                            {
                                ImprovedVBE._DrawACSIIString("Not working", 1000, 50, 16777215);
                            }
                        }
                    }
                }
            }

            foreach(Tuple<string, int> tuple in text)
            {
                if(tuple.Item2 == Task_Manager.foo)
                {
                    string s = (tuple.Item1.Remove(0, 9));
                    s = s.Remove(s.Length - 1);
                    string[] bas = s.Split(", ");
                    if (!bas[2].Contains("\""))
                    {
                        bool foundsg = false;
                        int found = 0;
                        foreach (Tuple<string, int> tuple2 in Window_Layout.Integers)
                        {
                            if (bas[2] == tuple2.Item1)
                            {
                                found = tuple2.Item2;
                                
                                foundsg = true;
                            }
                        }
                        ImprovedVBE._DrawACSIIString(found.ToString(), x + int.Parse(bas[0]), y + 20 + int.Parse(bas[1]), 16777215);
                    }
                    else if (bas[2].Contains(" + "))
                    {
                        string[] data = bas[2].Split(" + ");
                        string info = "";
                        foreach(string content in data)
                        {
                            if (content.Contains("\""))
                            {
                                info += content.Replace("\"", "");
                            }
                            else
                            {
                                bool foundsg = false;
                                int found = 0;
                                foreach (Tuple<string, int> tuple2 in Window_Layout.Integers)
                                {
                                    if (content == tuple2.Item1)
                                    {
                                        found = tuple2.Item2;

                                        foundsg = true;
                                    }
                                }
                                if (!foundsg)
                                {
                                    bool foundsg2 = false;
                                    string found2 = "";
                                    foreach (Tuple<string, string> tuple2 in Window_Layout.strings)
                                    {
                                        if (content == tuple2.Item1)
                                        {
                                            found2 = tuple2.Item2;

                                            foundsg2 = true;
                                        }
                                    }
                                    info += found2.ToString();
                                }
                                else
                                {
                                    info += found.ToString();
                                }
                            }
                        }
                        ImprovedVBE._DrawACSIIString(info, x + int.Parse(bas[0]), y + 20 + int.Parse(bas[1]), 16777215);

                    }
                    else
                    {
                        ImprovedVBE._DrawACSIIString(bas[2].Replace("\"", ""), x + int.Parse(bas[0]), y + 20 + int.Parse(bas[1]), 16777215);
                    }
                }
            }

            foreach(Tuple<string, int> t in ifs)
            {
                string[] lines = t.Item1.Split('\n');
                
            }

            if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
            {
                int f = (int)Kernel.X;
                int g = (int)Kernel.Y;
                Task_Manager.Tasks.RemoveAt(0);
                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>(title, f, g, true, "", true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                if (MouseManager.MouseState == MouseState.Right)
                {
                    Task_Manager.Tasks.RemoveAt(0);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>(title, f, g, false, "", true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                    Task_Manager.Tasks.Reverse();
                    //movable = false;
                }

                if (Kernel.X > x && Kernel.X < x + 352)
                {
                    if (Kernel.Y > y && Kernel.Y < y + 18)
                    {
                        //movable = false;
                    }
                }

            }
        }

        public static void Draw_Button(int x, int y, int width, int height, string text)
        {
            ImprovedVBE.DrawFilledRectangle(16777215, x, y, width, height);
            ImprovedVBE._DrawACSIIString(text, (x + width / 2) - (text.Length * 8 / 2), y + (height / 2) - 8, 0);
        }
    }
}
