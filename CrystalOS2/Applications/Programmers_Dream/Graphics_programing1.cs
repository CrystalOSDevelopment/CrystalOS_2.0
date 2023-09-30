using CrystalOS2.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Applications.Programmers_Dream
{
    public class Graphics_programing1
    {
        public static List<Tuple<string, string, bool>> bools = new List<Tuple<string, string, bool>>();
        public static List<Tuple<string, string, string>> strings = new List<Tuple<string, string, string>>();
        public static List<Tuple<string, string, int>> ints = new List<Tuple<string, string, int>>();
        public static List<Tuple<string, string, int>> classes = new List<Tuple<string, string, int>>();

        public static List<Tuple<string, int, int, int, int>> Windows = new List<Tuple<string, int, int, int, int>>();

        #region UI_Elements
        public static List<Tuple<string, int, int, string>> buttons = new List<Tuple<string, int, int, string>>();
        public static List<Tuple<string, int, int, string>> labels = new List<Tuple<string, int, int, string>>();
        #endregion UI_Elements

        public static string current_namespace = "test";

        public static bool is_started = true;
        public static string[] scrip;
        public static bool is_stopped = false;
        public static bool get_ints = true;

        public static string filtered = "";
        public static bool start_main = false;
        public static void graphic_window_exec(string script)
        {
            if(is_stopped == false)
            {
                scrip = script.Split('\n');
                is_stopped = true;
            }

            int mains = 1;
            /*
            foreach (string line in lines)
            {
                if(line.Replace("    void ", "") == "Main()")
                {
                    mains++;
                }
                else
                {

                }
            }
            */

            if(mains > 1)
            {
                //error for same name
            }
            else if (mains == 1)
            {
                int curr_line = 0;
                int window_width = 300;
                int window_height = 150;
                foreach (string line in scrip)
                {
                    #region beginning of the program
                    if(is_started == false)
                    {
                        if (line.ToLower().StartsWith("namespace "))
                        {
                            string name = line.Remove(0, 10);
                            if (line.EndsWith("{"))
                            {
                                is_started = true;
                            }
                            current_namespace = name;
                        }
                        else if (line.ToLower().StartsWith("{") && current_namespace != "")
                        {
                            is_started = true;
                        }
                    }

                    #endregion beginning of the program

                    #region
                    if (is_started == true)
                    {
                        if (line.Replace("    ", "") == "") { }
                        else if (line.ToLower().Contains("void main()::window"))
                        {
                            Windows.Add(new Tuple<string, int, int, int, int>(current_namespace, 500, 500, window_width, window_height));
                            start_main = true;
                        }
                        else if (line.ToLower().Contains("Window.Width = "))
                        {
                            string value = line.Remove(0, 15);
                            value = value.Remove(value.Length - 1);
                            try
                            {
                                window_width = int.Parse(value);
                                Windows.RemoveAll(d => d.Item1 == current_namespace);
                                Windows.Add(new Tuple<string, int, int, int, int>(current_namespace, 50, 50, window_width, window_height));
                            }
                            catch
                            {
                                foreach (Tuple<string, string, int> t in ints)
                                {
                                    if (t.Item1 == current_namespace && t.Item2 == value)
                                    {
                                        Windows.RemoveAll(d => d.Item1 == current_namespace);
                                        Windows.Add(new Tuple<string, int, int, int, int>(current_namespace, 50, 50, window_width, window_height));
                                        window_width = t.Item3;
                                    }
                                }
                            }
                        }
                        else if (line.ToLower().Contains("Window.Height = "))
                        {
                            string value = line.Remove(0, 16);
                            value = value.Remove(value.Length - 1);
                            try
                            {
                                window_height = int.Parse(value);
                                Windows.RemoveAll(d => d.Item1 == current_namespace);
                                Windows.Add(new Tuple<string, int, int, int, int>(current_namespace, 50, 50, window_width, window_height));
                            }
                            catch
                            {
                                foreach (Tuple<string, string, int> t in ints)
                                {
                                    if (t.Item1 == current_namespace && t.Item2 == value)
                                    {
                                        window_height = t.Item3;
                                        Windows.RemoveAll(d => d.Item1 == current_namespace);
                                        Windows.Add(new Tuple<string, int, int, int, int>(current_namespace, 50, 50, window_width, window_height));
                                    }
                                }
                            }
                        }
                        else if (line.ToLower().Contains("int"))
                        {
                            if(get_ints == true)
                            {
                                string s = line.Replace(" ", "");
                                s = s.Remove(0, 3);
                                s = s.Remove(s.Length - 1);
                                var content = s.Split('=');

                                ints.RemoveAll(d => d.Item2 == content[0]);
                                ints.Add(new Tuple<string, string, int>(current_namespace, content[0], int.Parse(content[1])));
                            }

                            //ImprovedVBE._DrawACSIIString("Debugger: " + content[0] + ", " + content[1], 300, 50, 0);
                            //ImprovedVBE._DrawACSIIString("Debugger: " + line, 300, 50, 0);

                            /*
                            if (!ints.Contains(new Tuple<string, string, int>(current_namespace, content[0], int.Parse(content[1]))))
                            {
                                ints.Add(new Tuple<string, string, int>(current_namespace, content[0], int.Parse(content[1])));
                            }
                            */
                        }
                        else if (line.ToLower().Contains("string"))
                        {
                            if (get_ints == true)
                            {
                                string s = line.Replace(" ", "");
                                s = s.Remove(0, 3);
                                s = s.Remove(s.Length - 1);
                                s = s.Replace("\"", "");
                                var content = s.Split('=');

                                ints.RemoveAll(d => d.Item2 == content[0]);
                                strings.Add(new Tuple<string, string, string>(current_namespace, content[0], content[1]));
                            }

                            //ImprovedVBE._DrawACSIIString("Debugger: " + content[0] + ", " + content[1], 300, 50, 0);
                            //ImprovedVBE._DrawACSIIString("Debugger: " + line, 300, 50, 0);

                            /*
                            if (!ints.Contains(new Tuple<string, string, int>(current_namespace, content[0], int.Parse(content[1]))))
                            {
                                ints.Add(new Tuple<string, string, int>(current_namespace, content[0], int.Parse(content[1])));
                            }
                            */
                        }
                        else
                        {
                            if (line.ToLower().Contains("}"))
                            {
                                if(start_main == true)
                                {
                                    start_main = false;
                                }
                            }
                            else if(start_main == true)
                            {
                                filtered += line + "\n";
                            }
                        }

                        #region UI_elements
                        if (line.Contains("UI.Elements.Label("))
                        {
                            var s = line.Remove(0, count(line) + 18);
                            s = s.Remove(s.Length - 1);
                            int counter = 0;

                            while(s[counter + 1] != '\"')
                            {
                                counter++;
                            }

                            var sub = s.Substring(0, counter).Replace("\"", "");

                            labels.Add(new Tuple<string, int, int, string>(current_namespace, 10, 10, sub));
                        }
                        #endregion UI_elements
                    }
                    #endregion

                }
                //Add it to taskmanager
                get_ints = false;
            }
            else
            {
                //error: no main program found!
            }
            
        }

        public static int count(string s)
        {
            int pointer = 0;
            foreach (char c in s)
            {
                if (c != ' ')
                {
                    break;
                }
                else
                {
                    pointer++;
                }
            }
            return pointer;
        }
    }
}
