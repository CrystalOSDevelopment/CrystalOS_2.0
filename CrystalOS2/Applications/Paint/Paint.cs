using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using CrystalOS2;
using CrystalOS2.Applications.Task_Scheduler;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_tut.Applications.Calculator;

namespace CrystalOS2.Applications.Paint
{
    public class Paint : App
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Paint.Paint.bmp")] public static byte[] calendar_base;
        public static Bitmap paint_base = new Bitmap(calendar_base);

        public static string tool_selected = "pen";
        public static int color = 0;

        public static bool activated = false;
        public static int x1 = 0;
        public static int y1 = 0;

        public int desk_ID { get; set; }

        public int x = 100;
        public int y = 100;

        public string name
        {
            get { return "Paint"; }
        }

        public bool minimised { get; set; }
        public int z { get; set; }
        public bool movable = false;

        //shape id, x, y, width, height, color
        public List<Tuple<string, int, int, int, int, int>> shapes = new List<Tuple<string, int, int, int, int, int>>();

        public void App()
        {
            if(Bool_Manager.Paint == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x + 623 && Kernel.X < x + 644)
                    {
                        if (Kernel.Y > y + 8 && Kernel.Y < y + 24)
                        {
                            shapes.Clear();
                            Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                        }
                    }
                }

                ImprovedVBE.DrawImageAlpha(paint_base, x, y);

                #region tool_sector
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.Y > y + 25 && Kernel.Y < y + 52)
                    {
                        if (Kernel.X > x + 69 && Kernel.X < x + 98)
                        {
                            tool_selected = "pen";
                        }
                        if (Kernel.X > x + 108 && Kernel.X < x + 137)
                        {
                            tool_selected = "rectangle";
                        }
                        if (Kernel.X > x + 146 && Kernel.X < x + 175)
                        {
                            tool_selected = "eraser";
                        }
                    }
                }
                #endregion tool_sector

                #region color_sector
                if (MouseManager.MouseState != MouseState.Left)
                {
                    if (Kernel.Y > y + 60 && Kernel.Y < y + 72)
                    {
                        if (Kernel.X > x + 557 && Kernel.X < x + 579)
                        {
                            color = 16711680;
                        }
                        if (Kernel.X > x + 582 && Kernel.X < x + 604)
                        {
                            color = 16731392;
                        }
                        if (Kernel.X > x + 607 && Kernel.X < x + 629)
                        {
                            color = 16758784;
                        }
                    }
                    if (Kernel.Y > y + 75 && Kernel.Y < y + 87)
                    {
                        if (Kernel.X > x + 557 && Kernel.X < x + 579)
                        {
                            color = 16774400;
                        }
                        if (Kernel.X > x + 582 && Kernel.X < x + 604)
                        {
                            color = 10419968;
                        }
                        if (Kernel.X > x + 607 && Kernel.X < x + 629)
                        {
                            color = 4390656;
                        }
                    }
                    //Good until this point
                    if (Kernel.Y > y + 90 && Kernel.Y < y + 102)
                    {
                        if (Kernel.X > x + 557 && Kernel.X < x + 579)
                        {
                            color = 53844;
                        }
                        if (Kernel.X > x + 582 && Kernel.X < x + 604)
                        {
                            color = 65489;
                        }
                        if (Kernel.X > x + 607 && Kernel.X < x + 629)
                        {
                            color = 242410;
                        }
                    }
                    if (Kernel.Y > y + 105 && Kernel.Y < y + 117)
                    {
                        if (Kernel.X > x + 557 && Kernel.X < x + 579)
                        {
                            color = 18431;
                        }
                        if (Kernel.X > x + 582 && Kernel.X < x + 604)
                        {
                            color = 10354943;
                        }
                        if (Kernel.X > x + 607 && Kernel.X < x + 629)
                        {
                            color = 16711925;
                        }
                    }
                    if (Kernel.Y > y + 120 && Kernel.Y < y + 132)
                    {
                        if (Kernel.X > x + 557 && Kernel.X < x + 579)
                        {
                            color = 0;
                        }
                        if (Kernel.X > x + 582 && Kernel.X < x + 604)
                        {
                            color = 16777215;
                        }
                    }
                }
                #endregion color_sector

                #region drawing_sector
                if (tool_selected == "pen")
                {
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (Kernel.X > x + 17 && Kernel.X < x + 17 + 510 && Kernel.Y > y + 58 && Kernel.Y < y + 58 + 316)
                        {
                            if (shapes.Any(m => m.Item1 == "point" && m.Item2 == (int)Kernel.X && m.Item3 == (int)Kernel.Y && m.Item6 == color))
                            {

                            }
                            else
                            {
                                shapes.Add(new Tuple<string, int, int, int, int, int>("point", (int)Kernel.X - x, (int)Kernel.Y - y, 1, 1, color));
                            }
                        }
                    }

                }
                if (tool_selected == "rectangle")
                {
                    if (activated == false)
                    {
                        if (MouseManager.MouseState == MouseState.Left)
                        {
                            activated = true;
                            x1 = (int)Kernel.X - x;
                            y1 = (int)Kernel.Y - y;
                            /*
                            if (Kernel.X > x + 17 && Kernel.X < x + 17 + 510 && Kernel.Y > y + 58 && Kernel.Y < y + 58 + 316)
                            {
                                if (shapes.Any(m => m.Item1 == "point" && m.Item2 == (int)Kernel.X && m.Item3 == (int)Kernel.Y && m.Item6 == 0))
                                {

                                }
                                else
                                {
                                    shapes.Add(new Tuple<string, int, int, int, int, int>("point", (int)Kernel.X - x, (int)Kernel.Y - y, 1, 1, 0));
                                }
                            }*/
                        }
                    }
                    if (activated == true)
                    {
                        if (MouseManager.MouseState == MouseState.None)
                        {
                            if (Kernel.X > x + 17 && Kernel.X < x + 17 + 510 && Kernel.Y > y + 58 && Kernel.Y < y + 58 + 316)
                            {
                                if (shapes.Any(m => m.Item1 == "rectangle" && m.Item2 == (int)Kernel.X && m.Item3 == (int)Kernel.Y && m.Item6 == color))
                                {

                                }
                                else
                                {
                                    shapes.Add(new Tuple<string, int, int, int, int, int>("rectangle", x1, y1, (int)Kernel.X - x, (int)Kernel.Y - y, color));
                                }
                            }
                            activated = false;
                        }
                    }
                }
                int a = 0;
                foreach (Tuple<string, int, int, int, int, int> t in shapes)
                {
                    if (t.Item1 == "point")
                    {
                        ImprovedVBE.DrawPixelfortext(x + t.Item2, y + t.Item3, t.Item6);
                    }
                    if (t.Item1 == "rectangle")
                    {
                        ImprovedVBE.DrawFilledRectangle(t.Item6, x + t.Item2, y + t.Item3, t.Item4 - t.Item2, t.Item5 - t.Item3);
                    }
                }
                #endregion drawing_section
            }

            if (MouseManager.MouseState == MouseState.Left)
            {
                if (Kernel.X > x && Kernel.X < x + 420)
                {
                    if (Kernel.Y > y && Kernel.Y < y + 20)
                    {
                        movable = true;
                    }
                }
            }
            if (movable == true)
            {
                if (MouseManager.MouseState == MouseState.Right)
                {
                    x = (int)Kernel.X;
                    y = (int)Kernel.Y;
                    movable = false;
                }
                else
                {
                    x = (int)Kernel.X;
                    y = (int)Kernel.Y;
                }
            }

            if (Task_Manager.indicator == Task_Manager.calculators.Count - 1)
            {

            }
            else
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x && Kernel.X < x + paint_base.Width)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + paint_base.Height)
                        {
                            z = 999;
                        }
                    }
                }
            }
        }
    }
}

/*
 using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using CrystalOS2.Applications.Task_Scheduler;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Applications.Paint
{
    public class Paint
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Paint.Paint.bmp")] public static byte[] calendar_base;
        public static Bitmap paint_base = new Bitmap(calendar_base);

        public static string tool_selected = "pen";
        public static int color = 0;

        public static bool activated = false;
        public static int x1 = 0;
        public static int y1 = 0;

        public static bool movable = false;

        //shape id, x, y, width, height, color
        public static List<List<Tuple<string, int, int, int, int, int>>> shapes = new List<List<Tuple<string, int, int, int, int, int>>>();
        //public static List<Tuple<string, int, int, int, int, int>> shapes = new List<Tuple<string, int, int, int, int, int>>();

        public static void Paint_app(int x, int y)
        {
            if(Bool_Manager.Paint == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x + 623 && Kernel.X < x + 644)
                    {
                        if (Kernel.Y > y + 8 && Kernel.Y < y + 24)
                        {
                            shapes.Clear();
                            Bool_Manager.Paint = false;
                        }
                    }
                }

                ImprovedVBE.DrawImageAlpha(paint_base, x, y);

                #region tool_sector
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.Y > y + 25 && Kernel.Y < y + 52)
                    {
                        if (Kernel.X > x + 69 && Kernel.X < x + 98)
                        {
                            tool_selected = "pen";
                        }
                        if (Kernel.X > x + 108 && Kernel.X < x + 137)
                        {
                            tool_selected = "rectangle";
                        }
                        if (Kernel.X > x + 146 && Kernel.X < x + 175)
                        {
                            tool_selected = "eraser";
                        }
                    }
                }
                #endregion tool_sector

                #region color_sector
                if (MouseManager.MouseState != MouseState.Left)
                {
                    if (Kernel.Y > y + 60 && Kernel.Y < y + 72)
                    {
                        if (Kernel.X > x + 557 && Kernel.Y < x + 579)
                        {
                            color = 16711680;
                        }
                        if (Kernel.X > x + 582 && Kernel.Y < x + 604)
                        {
                            color = 16731392;
                        }
                        if (Kernel.X > x + 607 && Kernel.Y < x + 629)
                        {
                            color = 16758784;
                        }
                    }
                    if (Kernel.Y > y + 75 && Kernel.Y < y + 87)
                    {
                        if (Kernel.X > x + 557 && Kernel.Y < x + 579)
                        {
                            color = 16774400;
                        }
                        if (Kernel.X > x + 582 && Kernel.Y < x + 604)
                        {
                            color = 10419968;
                        }
                        if (Kernel.X > x + 607 && Kernel.Y < x + 629)
                        {
                            color = 4390656;
                        }
                    }
                    //Good until this point
                    if (Kernel.Y > y + 90 && Kernel.Y < y + 102)
                    {
                        if (Kernel.X > x + 557 && Kernel.Y < x + 579)
                        {
                            color = 53844;
                        }
                        if (Kernel.X > x + 582 && Kernel.Y < x + 604)
                        {
                            color = 65489;
                        }
                        if (Kernel.X > x + 607 && Kernel.Y < x + 629)
                        {
                            color = 242410;
                        }
                    }
                    if (Kernel.Y > y + 105 && Kernel.Y < y + 117)
                    {
                        if (Kernel.X > x + 557 && Kernel.Y < x + 579)
                        {
                            color = 18431;
                        }
                        if (Kernel.X > x + 582 && Kernel.Y < x + 604)
                        {
                            color = 10354943;
                        }
                        if (Kernel.X > x + 607 && Kernel.Y < x + 629)
                        {
                            color = 16711925;
                        }
                    }
                    if (Kernel.Y > y + 120 && Kernel.Y < y + 132)
                    {
                        if (Kernel.X > x + 557 && Kernel.Y < x + 579)
                        {
                            color = 0;
                        }
                        if (Kernel.X > x + 582 && Kernel.Y < x + 604)
                        {
                            color = 16777215;
                        }
                    }
                }
                #endregion color_sector

                #region drawing_sector
                if (tool_selected == "pen")
                {
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (Kernel.X > x + 17 && Kernel.X < x + 17 + 510 && Kernel.Y > y + 58 && Kernel.Y < y + 58 + 316)
                        {
                            if (shapes[Task_Manager.Paint_app].Any(m => m.Item1 == "point" && m.Item2 == (int)Kernel.X && m.Item3 == (int)Kernel.Y && m.Item6 == color))
                            {

                            }
                            else
                            {

                                //shapes.Add(Tuple<string, int, int, int, int, int>("point", (int)Kernel.X - x, (int)Kernel.Y - y, 1, 1, color));
                                shapes[Task_Manager.Paint_app].Add(new Tuple<string, int, int, int, int, int>("point", (int)Kernel.X - x, (int)Kernel.Y - y, 1, 1, color));
                            }
                        }
                    }

                }
                if (tool_selected == "rectangle")
                {
                    if (activated == false)
                    {
                        if (MouseManager.MouseState == MouseState.Left)
                        {
                            activated = true;
                            x1 = (int)Kernel.X - x;
                            y1 = (int)Kernel.Y - y;
                            /*
                            if (Kernel.X > x + 17 && Kernel.X < x + 17 + 510 && Kernel.Y > y + 58 && Kernel.Y < y + 58 + 316)
                            {
                                if (shapes.Any(m => m.Item1 == "point" && m.Item2 == (int)Kernel.X && m.Item3 == (int)Kernel.Y && m.Item6 == 0))
                                {

                                }
                                else
                                {
                                    shapes.Add(new Tuple<string, int, int, int, int, int>("point", (int)Kernel.X - x, (int)Kernel.Y - y, 1, 1, 0));
                                }
                            }
                        }
                    }
                    if (activated == true)
{
    if (MouseManager.MouseState == MouseState.None)
    {
        if (Kernel.X > x + 17 && Kernel.X < x + 17 + 510 && Kernel.Y > y + 58 && Kernel.Y < y + 58 + 316)
        {
            if (shapes[Task_Manager.Paint_app].Any(m => m.Item1 == "rectangle" && m.Item2 == (int)Kernel.X && m.Item3 == (int)Kernel.Y && m.Item6 == color))
            {

            }
            else
            {
                //shapes.Add(new Tuple<string, int, int, int, int, int>("rectangle", x1, y1, (int)Kernel.X - x, (int)Kernel.Y - y, color));
                shapes[Task_Manager.Paint_app].Add(new Tuple<string, int, int, int, int, int>("rectangle", x1, y1, (int)Kernel.X - x, (int)Kernel.Y - y, color));
            }
        }
        activated = false;
    }
}
                }
                int a = 0;
foreach (Tuple<string, int, int, int, int, int> t in shapes[Task_Manager.Paint_app])
{
    if (t.Item1 == "point")
    {
        ImprovedVBE.DrawPixelfortext(x + t.Item2, y + t.Item3, t.Item6);
    }
    if (t.Item1 == "rectangle")
    {
        ImprovedVBE.DrawFilledRectangle(t.Item6, x + t.Item2, y + t.Item3, t.Item4 - t.Item2, t.Item5 - t.Item3);
    }
}
                #endregion drawing_section
            }

            if (MouseManager.MouseState == MouseState.Left)
{
    if (Kernel.X > Int_Manager.Calculator_X && Kernel.X < Int_Manager.Calculator_X + 420)
    {
        if (Kernel.Y > Int_Manager.Calculator_Y && Kernel.Y < Int_Manager.Calculator_Y + 20)
        {
            movable = true;
        }
    }
}
if (movable == true)
{
    if (MouseManager.MouseState == MouseState.Right)
    {
        x = (int)Kernel.X;
        y = (int)Kernel.Y;
        movable = false;
    }
    else
    {
        x = (int)Kernel.X;
        y = (int)Kernel.Y;
    }
}
        }
    }
}

 
 */