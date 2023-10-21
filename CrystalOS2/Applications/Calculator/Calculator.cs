using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using CrystalOS2;
using CrystalOS2.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_tut.Applications.Calculator
{
    public static class Calculator
    {
        public static string equasion = "";
        public static string[] numbers;
        public static int pressedsince;
        public static bool movable = false;
        public static bool isclicked = false;

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Calculator.Calculator.bmp")] public static byte[] calculator_base;
        public static Bitmap Calculator_base = new Bitmap(calculator_base);

        //Basically I copied the code from CrystaOS 2.0
        //The code is very easy to understand
        public static void calculator(int x, int y)
        {
            equasion = Task_Manager.Tasks[Task_Manager.indicator].Item5;//In the tasks list the 5th element was a string which contains the equasion
            ImprovedVBE.DrawImageAlpha(Calculator_base, x, y);//Then it renders the base of the calculator

            ImprovedVBE._DrawACSIIString(Task_Manager.Tasks[Task_Manager.indicator].Item5, x + 6, y + 27, 16777215);//After that, it dispays the equasion
            if (Task_Manager.Tasks[0].Item1 == "calculator" && Task_Manager.indicator == 0)
            {
                //In here, it's a bit complicated
                //First, it checks if the current app its's executing is the first in the tasks list
                //if so, it reads a keyboard input
                KeyEvent key;
                if (KeyboardManager.TryReadKey(out key))
                {
                    //if the keyboard input matches for example with 1, then it adds to the before extracted equasion a "1"
                    //Then it removes the first task which is the currently executed one
                    //And after that, it inserts it back to 0 with the new data in place of the old one
                    if (key.KeyChar == '1')
                    {
                        equasion += "1";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '2')
                    {
                        equasion += "2";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '3')
                    {
                        equasion += "3";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '4')
                    {
                        equasion += "4";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '5')
                    {
                        equasion += "5";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '6')
                    {
                        equasion += "6";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '7')
                    {
                        equasion += "7";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '8')
                    {
                        equasion += "8";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '9')
                    {
                        equasion += "9";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.KeyChar == '0')
                    {
                        equasion += "0";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.Key == ConsoleKeyEx.NumDivide)
                    {
                        equasion += "/";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.Key == ConsoleKeyEx.NumMultiply)
                    {
                        equasion += "*";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.Key == ConsoleKeyEx.NumMinus)
                    {
                        equasion += "-";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    if (key.Key == ConsoleKeyEx.NumPlus)
                    {
                        equasion += "+";
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                    }
                    //Same in case Enter was pressed
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        //Split the equasion by +; doing the math; displaying the new result
                        if (equasion.Contains("+"))
                        {
                            equasion = equasion.Replace('+', ' ');
                            numbers = equasion.Split(' ');

                            int num1 = int.Parse(numbers[0]);
                            int num2 = int.Parse(numbers[1]);

                            int result = num1 + num2;

                            equasion = result.ToString();
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                        if (equasion.Contains("-"))
                        {
                            equasion = equasion.Replace('-', ' ');
                            numbers = equasion.Split(' ');
                            int num1 = int.Parse(numbers[0]);
                            int num2 = int.Parse(numbers[1]);

                            int result = num1 - num2;

                            equasion = result.ToString();
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                        if (equasion.Contains("*"))
                        {
                            equasion = equasion.Replace('*', ' ');
                            numbers = equasion.Split(' ');
                            int num1 = int.Parse(numbers[0]);
                            int num2 = int.Parse(numbers[1]);

                            int result = num1 * num2;

                            equasion = result.ToString();
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                        if (equasion.Contains("/"))
                        {
                            equasion = equasion.Replace('/', ' ');
                            numbers = equasion.Split(' ');
                            int num1 = int.Parse(numbers[0]);
                            int num2 = int.Parse(numbers[1]);

                            int result = num1 / num2;

                            equasion = result.ToString();
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                }

                //In case no button was pressed, we can also take button inputs.
                //The concept is identical to what we saw in the menu part.

                if (MouseManager.MouseState == MouseState.Left)
                {
                    isclicked = true;
                }

                if (MouseManager.MouseState == MouseState.None && isclicked == true)
                {
                    //Identifies which part of the screen was pressed, recognises, whether it fits into the given x, y range
                    //If so: doing similar like in the keyboard part
                    if (MouseManager.X > x + 5 && MouseManager.X < x + 29)
                    {
                        if (MouseManager.Y > y + 69 && MouseManager.Y < y + 103)
                        {
                            equasion = "";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 34 && MouseManager.X < x + 58)
                    {
                        if (MouseManager.Y > y + 69 && MouseManager.Y < y + 103)
                        {
                            if (equasion.Length != 0)
                            {
                                equasion = equasion.Remove(equasion.Length - 1);
                                Task_Manager.Tasks.RemoveAt(0);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                            }
                        }
                    }
                    if (MouseManager.X > x + 63 && MouseManager.X < x + 87)
                    {
                        if (MouseManager.Y > y + 69 && MouseManager.Y < y + 103)
                        {
                            equasion += "+";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 92 && MouseManager.X < x + 116)
                    {
                        if (MouseManager.Y > y + 69 && MouseManager.Y < y + 103)
                        {
                            equasion += "-";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 121 && MouseManager.X < x + 145)
                    {
                        if (MouseManager.Y > y + 69 && MouseManager.Y < y + 103)
                        {
                            equasion += "*";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }

                    if (MouseManager.X > x + 5 && MouseManager.X < x + 29)
                    {
                        if (MouseManager.Y > y + 114 && MouseManager.Y < y + 148)
                        {
                            equasion += "7";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 34 && MouseManager.X < x + 58)
                    {
                        if (MouseManager.Y > y + 114 && MouseManager.Y < y + 148)
                        {
                            equasion += "8";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 63 && MouseManager.X < x + 87)
                    {
                        if (MouseManager.Y > y + 114 && MouseManager.Y < y + 148)
                        {
                            equasion += "9";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 92 && MouseManager.X < x + 116)
                    {
                        if (MouseManager.Y > y + 114 && MouseManager.Y < y + 148)
                        {
                            equasion += "/";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }

                    if (MouseManager.X > x + 5 && MouseManager.X < x + 29)
                    {
                        if (MouseManager.Y > y + 153 && MouseManager.Y < y + 187)
                        {
                            equasion += "4";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 34 && MouseManager.X < x + 58)
                    {
                        if (MouseManager.Y > y + 153 && MouseManager.Y < y + 187)
                        {
                            equasion += "5";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 63 && MouseManager.X < x + 87)
                    {
                        if (MouseManager.Y > y + 153 && MouseManager.Y < y + 187)
                        {
                            equasion += "6";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }

                    if (MouseManager.X > x + 5 && MouseManager.X < x + 29)
                    {
                        if (MouseManager.Y > y + 192 && MouseManager.Y < y + 226)
                        {
                            equasion += "1";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 34 && MouseManager.X < x + 58)
                    {
                        if (MouseManager.Y > y + 192 && MouseManager.Y < y + 226)
                        {
                            equasion += "2";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }
                    if (MouseManager.X > x + 63 && MouseManager.X < x + 87)
                    {
                        if (MouseManager.Y > y + 192 && MouseManager.Y < y + 226)
                        {
                            equasion += "3";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }

                    if (MouseManager.X > x + 34 && MouseManager.X < x + 58)
                    {
                        if (MouseManager.Y > y + 231 && MouseManager.Y < y + 265)
                        {
                            equasion += "0";
                            Task_Manager.Tasks.RemoveAt(0);
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                        }
                    }

                    if (MouseManager.X > x + 121 && MouseManager.X < x + 145 || MouseManager.X > x + 93 && MouseManager.X < x + 121)
                    {
                        if (MouseManager.Y > y + 114 && MouseManager.Y < y + 187 || MouseManager.Y > y + 153 && MouseManager.Y < y + 187)
                        {
                            if (equasion.Contains("+"))
                            {
                                equasion = equasion.Replace('+', ' ');
                                numbers = equasion.Split(' ');

                                int num1 = int.Parse(numbers[0]);
                                int num2 = int.Parse(numbers[1]);

                                int result = num1 + num2;

                                equasion = result.ToString();
                                Task_Manager.Tasks.RemoveAt(0);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                            }
                            if (equasion.Contains("-"))
                            {
                                equasion = equasion.Replace('-', ' ');
                                numbers = equasion.Split(' ');
                                int num1 = int.Parse(numbers[0]);
                                int num2 = int.Parse(numbers[1]);

                                int result = num1 - num2;

                                equasion = result.ToString();
                                Task_Manager.Tasks.RemoveAt(0);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                            }
                            if (equasion.Contains("*"))
                            {
                                equasion = equasion.Replace('*', ' ');
                                numbers = equasion.Split(' ');
                                int num1 = int.Parse(numbers[0]);
                                int num2 = int.Parse(numbers[1]);

                                int result = num1 * num2;

                                equasion = result.ToString();
                                Task_Manager.Tasks.RemoveAt(0);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                            }
                            if (equasion.Contains("/"))
                            {
                                equasion = equasion.Replace('/', ' ');
                                numbers = equasion.Split(' ');
                                int num1 = int.Parse(numbers[0]);
                                int num2 = int.Parse(numbers[1]);

                                int result = num1 / num2;

                                equasion = result.ToString();
                                Task_Manager.Tasks.RemoveAt(0);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", x, y, false, equasion, true));
                            }
                        }
                    }
                    isclicked = false;
                }

            }

            //This part does the movable/close button action
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X > x + 106 && MouseManager.X < x + 148)
                {
                    if (MouseManager.Y > y && MouseManager.Y < y + 17)
                    {
                        //Bool_Manager.Calculator_Opened = false;
                        Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);//Whith this, you remove the given app from the task manager tasks list
                    }
                }
                if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == false)
                {
                    if (MouseManager.X > x && MouseManager.X < x + 40)
                    {
                        if (MouseManager.Y > y && MouseManager.Y < y + 18)
                        {
                            int f = (int)MouseManager.X;
                            int g = (int)MouseManager.Y;
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);//Here, it removes it from the list and inserts back a new one with the bool now showing true
                            Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", f, g, true, equasion, true));
                        }
                    }
                }
            }

            if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)//In this part, since the 4th item is true, movability is enabled until you press the right button
            {
                int f = (int)MouseManager.X;
                int g = (int)MouseManager.Y;
                Task_Manager.Tasks.RemoveAt(0);
                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", f, g, true, equasion, true));
                if (MouseManager.MouseState == MouseState.Right)
                {
                    Task_Manager.Tasks.RemoveAt(0);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("calculator", f, g, false, equasion, true));
                    //Task_Manager.Tasks.Reverse();
                    //movable = false;
                }
                //Also, it is constantly placed on the top(0) of the tasks list
                /*
                if (MouseManager.X > Int_Manager.Settings_X && MouseManager.X < Int_Manager.Settings_X + 352)
                {
                    if (MouseManager.Y > Int_Manager.Settings_Y && MouseManager.Y < Int_Manager.Settings_Y + 18)
                    {
                        movable = false;
                    }
                }
                */
            }

        }
    }
}
