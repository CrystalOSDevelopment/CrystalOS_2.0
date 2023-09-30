using Cosmos.System;
using CrystalOS2.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Applications.Programmers_Dream
{
    class Window_processor
    {
        public static void Window(string title, int x, int y, int width, int height)
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

            /*
            foreach(string s in source.Split("\n"))
            {
                if (s.Contains("UI.Elements.Label("))
                {
                    ImprovedVBE._DrawACSIIString(s.Remove(0, Count(s) + 18), x + 2, y + 32, 16777215);
                }
            }
            */
            foreach(Tuple<string, int, int, string> t in Graphics_programing1.labels)
            {
                ImprovedVBE._DrawACSIIString(t.Item4, x + t.Item2, y + t.Item3, 16777215);
            }
            
        }

        public static int Count(string s)
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
