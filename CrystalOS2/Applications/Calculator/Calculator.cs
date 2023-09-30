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
using Kernel = CrystalOS2.Kernel;

namespace Youtube_tut.Applications.Calculator
{
    public interface App
    {
        void App();
        int desk_ID { get; }
        string name { get; }

        bool minimised { get; set; }

        int z { get; set; }
    }
    public class Calculator : App
    {
        public int a = 0;
        public string equasion = "";
        public string[] numbers;
        public int pressedsince;
        public bool movable = false;
        public bool isclicked = false;
        public string name
        {
            get { return "Calc..."; }
        }

        public bool minimised { get; set; }

        public int desk_ID { get; set; }

        public int x = 0;
        public int y = 0;
        public int z { get; set; }

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Calculator.Calculator.bmp")] public static byte[] calculator_base;
        public static Bitmap Calculator_base = new Bitmap(calculator_base);

        public void App()
        {
            ImprovedVBE.DrawImageAlpha(Calculator_base, x, y);

            ImprovedVBE._DrawACSIIString(equasion, x + 6, y + 27, 16777215);
            if (Task_Manager.indicator == Task_Manager.calculators.Count - 1)
            {
                KeyEvent key;
                if (KeyboardManager.TryReadKey(out key))
                {
                    //if the keyboard input matches for example with 1, then it adds to the before extracted equasion a "1"
                    //Then it removes the first task which is the currently executed one
                    //And after that, it inserts it back to 0 with the new data in place of the old one
                    if (key.KeyChar == '1')
                    {
                        equasion += "1";
                        //Task_Manager.Tasks.RemoveAt(0);
                        //Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("calculator", x, y, false, equasion, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                    }
                    if (key.KeyChar == '2')
                    {
                        equasion += "2";
                    }
                    if (key.KeyChar == '3')
                    {
                        equasion += "3";
                    }
                    if (key.KeyChar == '4')
                    {
                        equasion += "4";
                    }
                    if (key.KeyChar == '5')
                    {
                        equasion += "5";
                    }
                    if (key.KeyChar == '6')
                    {
                        equasion += "6";
                    }
                    if (key.KeyChar == '7')
                    {
                        equasion += "7";
                    }
                    if (key.KeyChar == '8')
                    {
                        equasion += "8";
                    }
                    if (key.KeyChar == '9')
                    {
                        equasion += "9";
                    }
                    if (key.KeyChar == '0')
                    {
                        equasion += "0";
                    }
                    if (key.Key == ConsoleKeyEx.NumDivide)
                    {
                        equasion += "/";
                    }
                    if (key.Key == ConsoleKeyEx.NumMultiply)
                    {
                        equasion += "*";
                    }
                    if (key.Key == ConsoleKeyEx.NumMinus)
                    {
                        equasion += "-";
                    }
                    if (key.Key == ConsoleKeyEx.NumPlus)
                    {
                        equasion += "+";
                    }

                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        if (equasion.Contains("+"))
                        {
                            equasion = equasion.Replace('+', ' ');
                            numbers = equasion.Split(' ');

                            int num1 = int.Parse(numbers[0]);
                            int num2 = int.Parse(numbers[1]);

                            int result = num1 + num2;

                            equasion = result.ToString();
                        }
                        if (equasion.Contains("-"))
                        {
                            equasion = equasion.Replace('-', ' ');
                            numbers = equasion.Split(' ');
                            int num1 = int.Parse(numbers[0]);
                            int num2 = int.Parse(numbers[1]);

                            int result = num1 - num2;

                            equasion = result.ToString();
                        }
                        if (equasion.Contains("*"))
                        {
                            equasion = equasion.Replace('*', ' ');
                            numbers = equasion.Split(' ');
                            int num1 = int.Parse(numbers[0]);
                            int num2 = int.Parse(numbers[1]);

                            int result = num1 * num2;

                            equasion = result.ToString();
                        }
                        if (equasion.Contains("/"))
                        {
                            equasion = equasion.Replace('/', ' ');
                            numbers = equasion.Split(' ');
                            int num1 = int.Parse(numbers[0]);
                            int num2 = int.Parse(numbers[1]);

                            int result = num1 / num2;

                            equasion = result.ToString();
                        }
                    }
                }

                if (MouseManager.MouseState == MouseState.Left)
                {
                    isclicked = true;
                }

                if (MouseManager.MouseState == MouseState.None && isclicked == true)
                {
                    //Identifies which part of the screen was pressed, recognises, whether it fits into the given x, y range
                    //If so: doing similar like in the keyboard part
                    if (Kernel.X > x + 5 && Kernel.X < x + 29)
                    {
                        if (Kernel.Y > y + 69 && Kernel.Y < y + 103)
                        {
                            equasion = "";
                        }
                    }
                    if (Kernel.X > x + 34 && Kernel.X < x + 58)
                    {
                        if (Kernel.Y > y + 69 && Kernel.Y < y + 103)
                        {
                            if (equasion.Length != 0)
                            {
                                equasion = equasion.Remove(equasion.Length - 1);
                            }
                        }
                    }
                    if (Kernel.X > x + 63 && Kernel.X < x + 87)
                    {
                        if (Kernel.Y > y + 69 && Kernel.Y < y + 103)
                        {
                            equasion += "+";
                        }
                    }
                    if (Kernel.X > x + 92 && Kernel.X < x + 116)
                    {
                        if (Kernel.Y > y + 69 && Kernel.Y < y + 103)
                        {
                            equasion += "-";
                        }
                    }
                    if (Kernel.X > x + 121 && Kernel.X < x + 145)
                    {
                        if (Kernel.Y > y + 69 && Kernel.Y < y + 103)
                        {
                            equasion += "*";
                        }
                    }

                    if (Kernel.X > x + 5 && Kernel.X < x + 29)
                    {
                        if (Kernel.Y > y + 114 && Kernel.Y < y + 148)
                        {
                            equasion += "7";
                        }
                    }
                    if (Kernel.X > x + 34 && Kernel.X < x + 58)
                    {
                        if (Kernel.Y > y + 114 && Kernel.Y < y + 148)
                        {
                            equasion += "8";
                        }
                    }
                    if (Kernel.X > x + 63 && Kernel.X < x + 87)
                    {
                        if (Kernel.Y > y + 114 && Kernel.Y < y + 148)
                        {
                            equasion += "9";
                        }
                    }
                    if (Kernel.X > x + 92 && Kernel.X < x + 116)
                    {
                        if (Kernel.Y > y + 114 && Kernel.Y < y + 148)
                        {
                            equasion += "/";
                        }
                    }

                    if (Kernel.X > x + 5 && Kernel.X < x + 29)
                    {
                        if (Kernel.Y > y + 153 && Kernel.Y < y + 187)
                        {
                            equasion += "4";
                        }
                    }
                    if (Kernel.X > x + 34 && Kernel.X < x + 58)
                    {
                        if (Kernel.Y > y + 153 && Kernel.Y < y + 187)
                        {
                            equasion += "5";
                        }
                    }
                    if (Kernel.X > x + 63 && Kernel.X < x + 87)
                    {
                        if (Kernel.Y > y + 153 && Kernel.Y < y + 187)
                        {
                            equasion += "6";
                        }
                    }

                    if (Kernel.X > x + 5 && Kernel.X < x + 29)
                    {
                        if (Kernel.Y > y + 192 && Kernel.Y < y + 226)
                        {
                            equasion += "1";
                        }
                    }
                    if (Kernel.X > x + 34 && Kernel.X < x + 58)
                    {
                        if (Kernel.Y > y + 192 && Kernel.Y < y + 226)
                        {
                            equasion += "2";
                        }
                    }
                    if (Kernel.X > x + 63 && Kernel.X < x + 87)
                    {
                        if (Kernel.Y > y + 192 && Kernel.Y < y + 226)
                        {
                            equasion += "3";
                        }
                    }

                    if (Kernel.X > x + 34 && Kernel.X < x + 58)
                    {
                        if (Kernel.Y > y + 231 && Kernel.Y < y + 265)
                        {
                            equasion += "0";
                        }
                    }

                    if (Kernel.X > x + 121 && Kernel.X < x + 145 || Kernel.X > x + 93 && Kernel.X < x + 121)
                    {
                        if (Kernel.Y > y + 114 && Kernel.Y < y + 187 || Kernel.Y > y + 153 && Kernel.Y < y + 187)
                        {
                            if (equasion.Contains("+"))
                            {
                                equasion = equasion.Replace('+', ' ');
                                numbers = equasion.Split(' ');

                                int num1 = int.Parse(numbers[0]);
                                int num2 = int.Parse(numbers[1]);

                                int result = num1 + num2;

                                equasion = result.ToString();
                            }
                            if (equasion.Contains("-"))
                            {
                                equasion = equasion.Replace('-', ' ');
                                numbers = equasion.Split(' ');
                                int num1 = int.Parse(numbers[0]);
                                int num2 = int.Parse(numbers[1]);

                                int result = num1 - num2;

                                equasion = result.ToString();
                            }
                            if (equasion.Contains("*"))
                            {
                                equasion = equasion.Replace('*', ' ');
                                numbers = equasion.Split(' ');
                                int num1 = int.Parse(numbers[0]);
                                int num2 = int.Parse(numbers[1]);

                                int result = num1 * num2;

                                equasion = result.ToString();
                            }
                            if (equasion.Contains("/"))
                            {
                                equasion = equasion.Replace('/', ' ');
                                numbers = equasion.Split(' ');
                                int num1 = int.Parse(numbers[0]);
                                int num2 = int.Parse(numbers[1]);

                                int result = num1 / num2;

                                equasion = result.ToString();
                            }
                        }
                    }
                    isclicked = false;
                }
            }
            else
            {
                if(MouseManager.MouseState == MouseState.Left)
                {
                    if(Kernel.X > x && Kernel.X < x + Calculator_base.Width)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + Calculator_base.Height)
                        {
                            z = 999;
                        }
                    }
                }
            }

            if (MouseManager.MouseState == MouseState.Left)
            {
                if (Kernel.X > x + 106 && Kernel.X < x + 148)
                {
                    if (Kernel.Y > y && Kernel.Y < y + 17)
                    {
                        Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                    }
                }
                if (movable == false)
                {
                    if (Kernel.X > x && Kernel.X < x + 50)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 18)
                        {
                            x = (int)Kernel.X;
                            y = (int)Kernel.Y;
                            movable = true;
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

        }
    }
}
