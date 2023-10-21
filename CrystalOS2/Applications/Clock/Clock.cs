using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Cosmos.System.Graphics;
using Cosmos.Core.IOGroup;
using CrystalOS.SystemFiles;
using CrystalOS2.Applications.Task_Scheduler;
using CrystalOS2;
using IL2CPU.API.Attribs;

namespace CrystalOS2.Applications.Clock
{
    class Clock
    {
        public static bool moove_enabled = false;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.Clock.bmp")] public static byte[] calendar_base;
        public static Bitmap Clock_base = new Bitmap(calendar_base);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.1.bmp")] public static byte[] one;
        public static Bitmap first = new Bitmap(one);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.2.bmp")] public static byte[] two;
        public static Bitmap second = new Bitmap(two);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.3.bmp")] public static byte[] three;
        public static Bitmap third = new Bitmap(three);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.4.bmp")] public static byte[] four;
        public static Bitmap fourth = new Bitmap(four);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.5.bmp")] public static byte[] five;
        public static Bitmap Five = new Bitmap(five);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.6.bmp")] public static byte[] six;
        public static Bitmap Six = new Bitmap(six);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.7.bmp")] public static byte[] seven;
        public static Bitmap Seven = new Bitmap(seven);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.8.bmp")] public static byte[] eight;
        public static Bitmap Eight = new Bitmap(eight);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.9.bmp")] public static byte[] nine;
        public static Bitmap Nine = new Bitmap(nine);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.0.bmp")] public static byte[] zero;
        public static Bitmap Zero = new Bitmap(zero);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Clock.numbers.two_dot.bmp")] public static byte[] two_dot;
        public static Bitmap Two_dot = new Bitmap(two_dot);

        public static bool movable = false;
        public static void init(int x, int y, int width, int height)
        {
            if (Bool_Manager.Clock == true)
            {

                /*
        if (Mouse.Click())
        {
            if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 53)
            {
                if (MouseManager.Y > y + 3 && MouseManager.Y < y + 20)
                {
                    moove_enabled = true;
                }
            }*
                *
                if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 30)
                {
                    if (MouseManager.Y > y + 3 && MouseManager.Y < y + 20)
                    {
                        Int_Manager.dialogbox_x = (int)MouseManager.X - 20;
                        Int_Manager.dialogbox_y = (int)MouseManager.Y - 10;
                    }
                }
                /
            }
                
                int heigh = y + 64;
                ImprovedVBE.DrawFilledRectangle(0, x, y, width, height);
                ImprovedVBE.DrawFilledRectangle(7372944, x + 1, y + 1, width - 2, height - 2);
                ImprovedVBE.DrawFilledRectangle(139, x + 3, y + 3, width - 6, 16);
                ImprovedVBE._DrawACSIIString("Clock", x + 5, y + 3, 16777215);
                //ImprovedVBE.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                ImprovedVBE.DrawFilledRectangle(139, x + width - 51, y + 5, 20, 12);
                ImprovedVBE.DrawFilledRectangle(139, x + width - 26, y + 5, 20, 12);
                //
                ImprovedVBE.DrawFilledRectangle(16777215, x + 3, y + 21, width - 6, height - 23);

                ImprovedVBE._DrawACSIIString("12", x + 91, y + 28, 0);//((x + width)/2) - 4
                ImprovedVBE._DrawACSIIString("3", x + width - 28, y + 100, 0);//20
                ImprovedVBE._DrawACSIIString("6", x + 95, y + 172, 0);//26
                ImprovedVBE._DrawACSIIString("9", x + 20, y + 100, 0);
                ImprovedVBE.DrawFilledRectangle(0, x + 128, y + 33, 15, 15);
                ImprovedVBE.DrawFilledRectangle(0, x + 162, y + 68, 15, 15);
                ImprovedVBE.DrawFilledRectangle(0, x + 162, y + 134, 15, 15);
                ImprovedVBE.DrawFilledRectangle(0, x + 135, y + 169, 15, 15);
                //
                ImprovedVBE.DrawFilledRectangle(0, x + 52, y + 33, 15, 15);
                ImprovedVBE.DrawFilledRectangle(0, x + 18, y + 68, 15, 15);
                ImprovedVBE.DrawFilledRectangle(0, x + 18, y + 134, 15, 15);
                ImprovedVBE.DrawFilledRectangle(0, x + 52, y + 169, 15, 15);
                //drawHand(ImprovedVBE, (uint)0.ToArgb(), (int)(x + width / 2), (int)(y + height / 2) + 8, 15, 15);
                /*
                drawHand(0, (int)(x + width / 2), (int)(y + height / 2), DateTime.Now.Hour, 40);
                drawHand(0, (int)(x + width / 2), (int)(y + height / 2), DateTime.Now.Minute, 60);
                drawHand(15539236, (int)(x + width / 2), (int)(y + height / 2), DateTime.Now.Second, 80);
                *

                drawHand(0, x + width / 2, y + height / 2 + 8, DateTime.UtcNow.Minute, 50);
                drawHand(15539236, x + width / 2, y + height / 2 + 8, DateTime.UtcNow.Second, 70);
                if (DateTime.UtcNow.Second == 0 || DateTime.UtcNow.Second == 00)
                {
                    ImprovedVBE.DrawLine(15539236, x + width / 2, y + height / 2 - 62, x + width / 2, y + height / 2 + 8);//55
                }
                if (DateTime.UtcNow.Second == 45)
                {
                    ImprovedVBE.DrawLine(15539236, x + width / 2 - 70, y + height / 2 + 8, x + width / 2, y + height / 2 + 8);
                }
                #region hourhand
                if (DateTime.UtcNow.Hour == 1 || DateTime.UtcNow.Hour == 13)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 5, 30);
                }
                if (DateTime.UtcNow.Hour == 2 || DateTime.UtcNow.Hour == 14)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 10, 30);
                }
                if (DateTime.UtcNow.Hour == 3 || DateTime.UtcNow.Hour == 15)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 15, 30);
                }
                if (DateTime.UtcNow.Hour == 4 || DateTime.UtcNow.Hour == 16)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 20, 30);
                }
                if (DateTime.UtcNow.Hour == 5 || DateTime.UtcNow.Hour == 17)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 25, 30);
                }
                if (DateTime.UtcNow.Hour == 6 || DateTime.UtcNow.Hour == 18)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 30, 30);
                }
                if (DateTime.UtcNow.Hour == 7 || DateTime.UtcNow.Hour == 19)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 35, 30);
                }
                if (DateTime.UtcNow.Hour == 8 || DateTime.UtcNow.Hour == 20)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 40, 30);
                }
                if (DateTime.UtcNow.Hour == 9 || DateTime.UtcNow.Hour == 21 || DateTime.UtcNow.Minute == 45)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 45, 30);
                }
                if (DateTime.UtcNow.Hour == 10 || DateTime.UtcNow.Hour == 22)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 50, 30);
                }
                if (DateTime.UtcNow.Hour == 11 || DateTime.UtcNow.Hour == 23)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 55, 30);
                }
                if (DateTime.UtcNow.Hour == 0 || DateTime.UtcNow.Minute == 0)
                {
                    drawHand(0, x + width / 2, y + height / 2 + 8, 0, 30);
                }
                #endregion hourhand
                //
                */
                ImprovedVBE.DrawImageAlpha(Clock_base, x, y);

                int starting_point = x + 92; //x + 89;

                foreach(char c in DateTime.UtcNow.Hour.ToString() + " : " + DateTime.UtcNow.Minute.ToString())
                {
                    if(c == '1')
                    {
                        ImprovedVBE.DrawImageAlpha(first, starting_point, y + 89);
                        starting_point += 20;
                    }
                    if (c == '2')
                    {
                        ImprovedVBE.DrawImageAlpha(second, starting_point, y + 89);
                        starting_point += 26;
                    }
                    if (c == '3')
                    {
                        ImprovedVBE.DrawImageAlpha(third, starting_point, y + 89);
                        starting_point += 27;
                    }
                    if (c == '4')
                    {
                        ImprovedVBE.DrawImageAlpha(fourth, starting_point, y + 89);
                        starting_point += 29;
                    }
                    if (c == '5')
                    {
                        ImprovedVBE.DrawImageAlpha(Five, starting_point, y + 89);
                        starting_point += 27;
                    }
                    if (c == '6')
                    {
                        ImprovedVBE.DrawImageAlpha(Six, starting_point, y + 89);
                        starting_point += 26;
                    }
                    if (c == '7')
                    {
                        ImprovedVBE.DrawImageAlpha(Seven, starting_point, y + 89);
                        starting_point += 26;
                    }
                    if (c == '8')
                    {
                        ImprovedVBE.DrawImageAlpha(Eight, starting_point, y + 89);
                        starting_point += 26;
                    }
                    if (c == '9')
                    {
                        ImprovedVBE.DrawImageAlpha(Nine, starting_point, y + 89);
                        starting_point += 26;
                    }
                    if (c == '0')
                    {
                        ImprovedVBE.DrawImageAlpha(Zero, starting_point, y + 89);
                        starting_point += 28;
                    }
                    if (c == ':')
                    {
                        ImprovedVBE.DrawImageAlpha(Two_dot, starting_point, y + 89);
                        starting_point += 18;
                    }
                }

                //ImprovedVBE._DrawACSIIString(DateTime.UtcNow.Hour.ToString() + " : " + DateTime.UtcNow.Minute.ToString(), x + 89, y + 84, 16777215);

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > Int_Manager.Clock_X + 59 && MouseManager.X < Int_Manager.Clock_X + 76)
                    {
                        if (MouseManager.Y > Int_Manager.Clock_Y + 106 && MouseManager.Y < Int_Manager.Clock_Y + 122)
                        {
                            Bool_Manager.Clock = false;
                        }
                    }
                    else if (MouseManager.X > Int_Manager.Clock_X + 37 && MouseManager.X < Int_Manager.Clock_X + 263)
                    {
                        if (MouseManager.Y > Int_Manager.Clock_Y + 40 && MouseManager.Y < Int_Manager.Clock_Y + 143)
                        {
                            movable = true;
                        }
                    }
                }
                if (movable == true)
                {
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        Int_Manager.Clock_X = (int)MouseManager.X - 37;
                        Int_Manager.Clock_Y = (int)MouseManager.Y - 40;
                        movable = false;
                    }
                    else
                    {
                        Int_Manager.Clock_X = (int)MouseManager.X - 37;
                        Int_Manager.Clock_Y = (int)MouseManager.Y - 40;
                    }
                }
            }
        }
        /*
        public static void drawHand(int color2, int xStart, int yStart, int angle, int radius)
        {
            int[] sine = new int[16] { 0, 27, 54, 79, 104, 128, 150, 171, 190, 201, 221, 233, 243, 250, 254, 255 };
            int xEnd, yEnd, quadrant, x_flip, y_flip;

            quadrant = angle / 15;

            switch (quadrant)
            {
                case 0: x_flip = 1; y_flip = -1; break;
                case 1: angle = Math.Abs(angle - 30); x_flip = y_flip = 1; break;
                case 2: angle = angle - 30; x_flip = -1; y_flip = 1; break;
                case 3: angle = Math.Abs(angle - 60); x_flip = y_flip = -1; break;
                default: x_flip = y_flip = 1; break;
            }

            xEnd = xStart;
            yEnd = yStart;

            if (angle > sine.Length) return;

            xEnd += x_flip * (sine[angle] * radius >> 8);
            yEnd += y_flip * (sine[15 - angle] * radius >> 8);

            ImprovedVBE.DrawLine(color2, xStart, yStart, xEnd, yEnd);
        }*/
    }
}