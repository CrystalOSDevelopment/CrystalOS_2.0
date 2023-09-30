using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.Applications.Solitaire;
using CrystalOS2.Applications.Task_Scheduler;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_tut.Applications.Calculator;

namespace CrystalOS2.Applications.Browser
{
    public class Browser : App
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Browser.Browser.bmp")] public static byte[] based;
        public static Bitmap Base = new Bitmap(based);

        public static bool is_html = false;
        public static bool is_head = false;
        public static bool is_style = false;
        public static bool is_body = false;

        public static string title = "";

        public string input = "";

        public int desk_ID { get; set; }

        public int x = 100;
        public int y = 100;

        public string name
        {
            get { return "Browser"; }
        }

        public bool minimised { get; set; }
        public int z { get; set; }
        public bool movable = false;

        public void App()
        {
            #region core
            ImprovedVBE.DrawImageAlpha(Base, x, y);
            //ImprovedVBE._DrawACSIIString(input, x + 73, y + 3, 16777215);
            #region decoder
            string[] lines = input.Split('\n');
            foreach (string d in lines)
            {
                string s = d.Remove(d.Length - 1);
                s = s.TrimStart();
                if (s == "<!doctype html>")
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
                        if (s.EndsWith("<style>"))
                        {
                            is_style = true;
                        }
                        if (is_style)
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
            if (Task_Manager.indicator == Task_Manager.calculators.Count - 1)
            {

            }
            else
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x && Kernel.X < x + Base.Width)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + Base.Height)
                        {
                            z = 999;
                        }
                    }
                }
            }
            #endregion core

            #region mechanical
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (Kernel.X > x + 722 && Kernel.X < x + 750)//780 or add 30 to gain back
                {
                    if (Kernel.Y > y + 7 && Kernel.Y < y + 30)
                    {
                        //Bool_Manager.Text_Editor_Opened = false;
                        Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                    }
                }
                if (movable == false)
                {
                    if (Kernel.X > x && Kernel.X < x + 667)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 33)
                        {
                            int f = (int)Kernel.X;
                            int g = (int)Kernel.Y;
                            movable = true;
                            //string saves = Task_Manager.Tasks[Task_Manager.indicator].Item5;
                        }
                    }
                }
            }

            if (movable == true)
            {
                x = (int)Kernel.X;
                y = (int)Kernel.Y;
                if (MouseManager.MouseState == MouseState.Right)
                {
                    movable = false;
                }
            }
            #endregion mechanical
        }
    }
}
