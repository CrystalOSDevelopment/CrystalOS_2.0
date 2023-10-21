using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS2.Applications.Task_Scheduler;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Applications.Browser
{
    public class Browser
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Browser.Browser.bmp")] public static byte[] based;
        public static Bitmap Base = new Bitmap(based);

        public static bool is_html = false;
        public static bool is_head = false;
        public static bool is_style = false;
        public static bool is_body = false;

        public static string title = "";
        public static void Browser_app(int x, int y, string input)
        {
            ImprovedVBE.DrawImageAlpha(Base, x, y);
            //ImprovedVBE._DrawACSIIString(input, x + 73, y + 3, 16777215);
            #region decoder
            string[] lines = input.Split('\n');
            foreach(string d in lines)
            {
                string s = d.Remove(d.Length - 1);
                s = s.TrimStart();
                if(s == "<!doctype html>")
                {

                }
                else if (s.EndsWith("<html>".ToLower()))
                {
                    is_html = true;
                }
                if (is_html)
                {
                    if (s.EndsWith("<head>"))
                    {
                        is_head = true;
                    }
                    if (is_head)
                    {
                        if (s.EndsWith("</title>"))
                        {
                            string a = s.Replace("<title>", "");
                            a = a.Replace("</title>", "");
                            a = a.TrimStart();
                            ImprovedVBE._DrawACSIIString("- " + a, x + 73, y + 3, 16777215);
                        }
                        if(s.EndsWith("<style>"))
                        {
                            is_style = true;
                        }
                        if(is_style)
                        {
                            if (s.EndsWith("</style>"))
                            {
                                is_style = false;
                            }
                            if (s.StartsWith("/*"))
                            {

                            }
                            if (s.StartsWith("background-color:".ToLower()))
                            {
                                string temp = s.Remove(0, 17);
                                temp = temp.TrimStart();
                                temp = temp.Remove(temp.Length - 2);
                                ImprovedVBE._DrawACSIIString(temp, x + 150, y + 3, 16777215);
                                int color_code = int.Parse(temp);
                                ImprovedVBE.DrawFilledRectangle(7030482, x + 3, y + 51, 644, 346);
                            }
                        }
                    }

                    if (s.EndsWith("<body>"))
                    {
                        is_body = true;
                    }
                    if (is_body)
                    {
                        if (s.StartsWith("<p>"))
                        {

                        }
                    }
                }
            }
            #endregion decoder

            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X > x + 722 && MouseManager.X < x + 750)//780 or add 30 to gain back
                {
                    if (MouseManager.Y > y + 7 && MouseManager.Y < y + 30)
                    {
                        //Bool_Manager.Text_Editor_Opened = false;
                        Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                    }
                }
                if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == false)
                {
                    if (MouseManager.X > x && MouseManager.X < x + 667)
                    {
                        if (MouseManager.Y > y && MouseManager.Y < y + 33)
                        {
                            int f = (int)MouseManager.X;
                            int g = (int)MouseManager.Y;
                            //string saves = Task_Manager.Tasks[Task_Manager.indicator].Item5;
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("Browser", f, g, true, input, true));
                        }
                    }
                }
            }

            if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
            {
                int f = (int)MouseManager.X;
                int g = (int)MouseManager.Y;
                Task_Manager.Tasks.RemoveAt(0);
                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("Browser", f, g, true, input, true));
                if (MouseManager.MouseState == MouseState.Right)
                {
                    Task_Manager.Tasks.RemoveAt(0);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("Browser", f, g, false, input, true));
                    //Task_Manager.Tasks.Reverse();
                    //movable = false;
                }
            }
        }
    }
}
