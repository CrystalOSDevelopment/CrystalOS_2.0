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
        public static List<Tuple<string, int, int, int, int, int>> shapes = new List<Tuple<string, int, int, int, int, int>>();

        public static void Paint_app(int x, int y)
        {
            if(Bool_Manager.Paint == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > x + 623 && MouseManager.X < x + 644)
                    {
                        if (MouseManager.Y > y + 8 && MouseManager.Y < y + 24)
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
                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 52)
                    {
                        if (MouseManager.X > x + 69 && MouseManager.X < x + 98)
                        {
                            tool_selected = "pen";
                        }
                        if (MouseManager.X > x + 108 && MouseManager.X < x + 137)
                        {
                            tool_selected = "rectangle";
                        }
                        if (MouseManager.X > x + 146 && MouseManager.X < x + 175)
                        {
                            tool_selected = "eraser";
                        }
                    }
                }
                #endregion tool_sector

                #region color_sector
                if (MouseManager.MouseState != MouseState.Left)
                {
                    if (MouseManager.Y > y + 60 && MouseManager.Y < y + 72)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 16711680;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
                        {
                            color = 16731392;
                        }
                        if (MouseManager.X > x + 607 && MouseManager.Y < x + 629)
                        {
                            color = 16758784;
                        }
                    }
                    if (MouseManager.Y > y + 75 && MouseManager.Y < y + 87)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 16774400;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
                        {
                            color = 10419968;
                        }
                        if (MouseManager.X > x + 607 && MouseManager.Y < x + 629)
                        {
                            color = 4390656;
                        }
                    }
                    //Good until this point
                    if (MouseManager.Y > y + 90 && MouseManager.Y < y + 102)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 53844;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
                        {
                            color = 65489;
                        }
                        if (MouseManager.X > x + 607 && MouseManager.Y < x + 629)
                        {
                            color = 242410;
                        }
                    }
                    if (MouseManager.Y > y + 105 && MouseManager.Y < y + 117)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 18431;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
                        {
                            color = 10354943;
                        }
                        if (MouseManager.X > x + 607 && MouseManager.Y < x + 629)
                        {
                            color = 16711925;
                        }
                    }
                    if (MouseManager.Y > y + 120 && MouseManager.Y < y + 132)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 0;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
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
                        if (MouseManager.X > x + 17 && MouseManager.X < x + 17 + 510 && MouseManager.Y > y + 58 && MouseManager.Y < y + 58 + 316)
                        {
                            if (shapes.Any(m => m.Item1 == "point" && m.Item2 == (int)MouseManager.X && m.Item3 == (int)MouseManager.Y && m.Item6 == color))
                            {

                            }
                            else
                            {
                                shapes.Add(new Tuple<string, int, int, int, int, int>("point", (int)MouseManager.X - x, (int)MouseManager.Y - y, 1, 1, color));
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
                            x1 = (int)MouseManager.X - x;
                            y1 = (int)MouseManager.Y - y;
                            /*
                            if (MouseManager.X > x + 17 && MouseManager.X < x + 17 + 510 && MouseManager.Y > y + 58 && MouseManager.Y < y + 58 + 316)
                            {
                                if (shapes.Any(m => m.Item1 == "point" && m.Item2 == (int)MouseManager.X && m.Item3 == (int)MouseManager.Y && m.Item6 == 0))
                                {

                                }
                                else
                                {
                                    shapes.Add(new Tuple<string, int, int, int, int, int>("point", (int)MouseManager.X - x, (int)MouseManager.Y - y, 1, 1, 0));
                                }
                            }*/
                        }
                    }
                    if (activated == true)
                    {
                        if (MouseManager.MouseState == MouseState.None)
                        {
                            if (MouseManager.X > x + 17 && MouseManager.X < x + 17 + 510 && MouseManager.Y > y + 58 && MouseManager.Y < y + 58 + 316)
                            {
                                if (shapes.Any(m => m.Item1 == "rectangle" && m.Item2 == (int)MouseManager.X && m.Item3 == (int)MouseManager.Y && m.Item6 == color))
                                {

                                }
                                else
                                {
                                    shapes.Add(new Tuple<string, int, int, int, int, int>("rectangle", x1, y1, (int)MouseManager.X - x, (int)MouseManager.Y - y, color));
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
                if (MouseManager.X > Int_Manager.Paint_X && MouseManager.X < Int_Manager.Paint_X + 420)
                {
                    if (MouseManager.Y > Int_Manager.Paint_Y && MouseManager.Y < Int_Manager.Paint_Y + 20)
                    {
                        movable = true;
                    }
                }
            }
            if (movable == true)
            {
                if (MouseManager.MouseState == MouseState.Right)
                {
                    Int_Manager.Paint_X = (int)MouseManager.X;
                    Int_Manager.Paint_Y = (int)MouseManager.Y;
                    movable = false;
                }
                else
                {
                    Int_Manager.Paint_X = (int)MouseManager.X;
                    Int_Manager.Paint_Y = (int)MouseManager.Y;
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
                    if (MouseManager.X > x + 623 && MouseManager.X < x + 644)
                    {
                        if (MouseManager.Y > y + 8 && MouseManager.Y < y + 24)
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
                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 52)
                    {
                        if (MouseManager.X > x + 69 && MouseManager.X < x + 98)
                        {
                            tool_selected = "pen";
                        }
                        if (MouseManager.X > x + 108 && MouseManager.X < x + 137)
                        {
                            tool_selected = "rectangle";
                        }
                        if (MouseManager.X > x + 146 && MouseManager.X < x + 175)
                        {
                            tool_selected = "eraser";
                        }
                    }
                }
                #endregion tool_sector

                #region color_sector
                if (MouseManager.MouseState != MouseState.Left)
                {
                    if (MouseManager.Y > y + 60 && MouseManager.Y < y + 72)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 16711680;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
                        {
                            color = 16731392;
                        }
                        if (MouseManager.X > x + 607 && MouseManager.Y < x + 629)
                        {
                            color = 16758784;
                        }
                    }
                    if (MouseManager.Y > y + 75 && MouseManager.Y < y + 87)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 16774400;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
                        {
                            color = 10419968;
                        }
                        if (MouseManager.X > x + 607 && MouseManager.Y < x + 629)
                        {
                            color = 4390656;
                        }
                    }
                    //Good until this point
                    if (MouseManager.Y > y + 90 && MouseManager.Y < y + 102)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 53844;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
                        {
                            color = 65489;
                        }
                        if (MouseManager.X > x + 607 && MouseManager.Y < x + 629)
                        {
                            color = 242410;
                        }
                    }
                    if (MouseManager.Y > y + 105 && MouseManager.Y < y + 117)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 18431;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
                        {
                            color = 10354943;
                        }
                        if (MouseManager.X > x + 607 && MouseManager.Y < x + 629)
                        {
                            color = 16711925;
                        }
                    }
                    if (MouseManager.Y > y + 120 && MouseManager.Y < y + 132)
                    {
                        if (MouseManager.X > x + 557 && MouseManager.Y < x + 579)
                        {
                            color = 0;
                        }
                        if (MouseManager.X > x + 582 && MouseManager.Y < x + 604)
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
                        if (MouseManager.X > x + 17 && MouseManager.X < x + 17 + 510 && MouseManager.Y > y + 58 && MouseManager.Y < y + 58 + 316)
                        {
                            if (shapes[Task_Manager.Paint_app].Any(m => m.Item1 == "point" && m.Item2 == (int)MouseManager.X && m.Item3 == (int)MouseManager.Y && m.Item6 == color))
                            {

                            }
                            else
                            {

                                //shapes.Add(Tuple<string, int, int, int, int, int>("point", (int)MouseManager.X - x, (int)MouseManager.Y - y, 1, 1, color));
                                shapes[Task_Manager.Paint_app].Add(new Tuple<string, int, int, int, int, int>("point", (int)MouseManager.X - x, (int)MouseManager.Y - y, 1, 1, color));
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
                            x1 = (int)MouseManager.X - x;
                            y1 = (int)MouseManager.Y - y;
                            /*
                            if (MouseManager.X > x + 17 && MouseManager.X < x + 17 + 510 && MouseManager.Y > y + 58 && MouseManager.Y < y + 58 + 316)
                            {
                                if (shapes.Any(m => m.Item1 == "point" && m.Item2 == (int)MouseManager.X && m.Item3 == (int)MouseManager.Y && m.Item6 == 0))
                                {

                                }
                                else
                                {
                                    shapes.Add(new Tuple<string, int, int, int, int, int>("point", (int)MouseManager.X - x, (int)MouseManager.Y - y, 1, 1, 0));
                                }
                            }
                        }
                    }
                    if (activated == true)
{
    if (MouseManager.MouseState == MouseState.None)
    {
        if (MouseManager.X > x + 17 && MouseManager.X < x + 17 + 510 && MouseManager.Y > y + 58 && MouseManager.Y < y + 58 + 316)
        {
            if (shapes[Task_Manager.Paint_app].Any(m => m.Item1 == "rectangle" && m.Item2 == (int)MouseManager.X && m.Item3 == (int)MouseManager.Y && m.Item6 == color))
            {

            }
            else
            {
                //shapes.Add(new Tuple<string, int, int, int, int, int>("rectangle", x1, y1, (int)MouseManager.X - x, (int)MouseManager.Y - y, color));
                shapes[Task_Manager.Paint_app].Add(new Tuple<string, int, int, int, int, int>("rectangle", x1, y1, (int)MouseManager.X - x, (int)MouseManager.Y - y, color));
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
    if (MouseManager.X > Int_Manager.Calculator_X && MouseManager.X < Int_Manager.Calculator_X + 420)
    {
        if (MouseManager.Y > Int_Manager.Calculator_Y && MouseManager.Y < Int_Manager.Calculator_Y + 20)
        {
            movable = true;
        }
    }
}
if (movable == true)
{
    if (MouseManager.MouseState == MouseState.Right)
    {
        Int_Manager.Paint_X = (int)MouseManager.X;
        Int_Manager.Paint_Y = (int)MouseManager.Y;
        movable = false;
    }
    else
    {
        Int_Manager.Paint_X = (int)MouseManager.X;
        Int_Manager.Paint_Y = (int)MouseManager.Y;
    }
}
        }
    }
}

 
 */