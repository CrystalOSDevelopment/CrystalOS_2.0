using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Applications.Calendar
{
    public static class Calendar
    {
        public static Canvas c;
        public static int day = DateTime.Today.Day;
        public static int month = DateTime.UtcNow.Month;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Calendar.Calendar.bmp")] public static byte[] calendar_base;
        public static Bitmap Calendar_base = new Bitmap(calendar_base);

        public static int dayofweek = 0;

        public static bool movable = false;
        public static int offset = 0;
        public static int yearoffset = 0;

        public static void calendar(int x, int y)
        {
            if(Bool_Manager.Calendar == true)
            {
                ImprovedVBE.DrawImageAlpha(Calendar_base, x, y);
                //ImprovedVBE._DrawACSIIString(month.ToString(), x + 128, y + 89, 16777215);
                //ImprovedVBE._DrawACSIIString(day.ToString(), x + 278, y + 89, 16777215);

                if (new DateTime(DateTime.UtcNow.Year + yearoffset, DateTime.UtcNow.Month + offset, 1).DayOfWeek == DayOfWeek.Saturday)
                {
                    dayofweek = 5;
                }
                else if (new DateTime(DateTime.UtcNow.Year + yearoffset, DateTime.UtcNow.Month + offset, 1).DayOfWeek == DayOfWeek.Monday)
                {
                    dayofweek = 0;
                }
                else if (new DateTime(DateTime.UtcNow.Year + yearoffset, DateTime.UtcNow.Month + offset, 1).DayOfWeek == DayOfWeek.Tuesday)
                {
                    dayofweek = 1;
                }
                else if (new DateTime(DateTime.UtcNow.Year + yearoffset, DateTime.UtcNow.Month + offset, 1).DayOfWeek == DayOfWeek.Wednesday)
                {
                    dayofweek = 2;
                }
                else if (new DateTime(DateTime.UtcNow.Year + yearoffset, DateTime.UtcNow.Month + offset, 1).DayOfWeek == DayOfWeek.Thursday)
                {
                    dayofweek = 3;
                }
                else if (new DateTime(DateTime.UtcNow.Year + yearoffset, DateTime.UtcNow.Month + offset, 1).DayOfWeek == DayOfWeek.Friday)
                {
                    dayofweek = 4;
                }
                else if (new DateTime(DateTime.UtcNow.Year + yearoffset, DateTime.UtcNow.Month + offset, 1).DayOfWeek == DayOfWeek.Sunday)
                {
                    dayofweek = 6;
                }
                int basex = x + 6 + (107 * dayofweek);
                int basey = y + 61;

                for (int i = 1; i < DateTime.DaysInMonth(DateTime.Now.Year + yearoffset, DateTime.Now.Month + offset) + 1; i++)
                {
                    if (basex >= x + 750)
                    {
                        basey += 66;
                        basex = x + 6;
                    }
                    if (day == i)
                    {
                        ImprovedVBE.DrawFilledRectangle(4808134, basex - 4, basey - 1, 107, 65);
                    }
                    ImprovedVBE._DrawACSIIString(i.ToString(), basex, basey, 16777215);
                    basex += 107;
                }

                ImprovedVBE._DrawACSIIString("Current date: " + (DateTime.UtcNow.Year + yearoffset).ToString() + ". " + (DateTime.UtcNow.Month + offset).ToString() + ". " + DateTime.UtcNow.Day.ToString(), Int_Manager.Calendar_X + 76, Int_Manager.Calendar_Y + 400, 0);

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > Int_Manager.Calendar_X && MouseManager.X < Int_Manager.Calendar_X + 730)
                    {
                        if (MouseManager.Y > Int_Manager.Calendar_Y && MouseManager.Y < Int_Manager.Calendar_Y + 20)
                        {
                            movable = true;
                        }
                    }
                    if (MouseManager.X > Int_Manager.Calendar_X + 735 && MouseManager.X < Int_Manager.Calendar_X + 745)
                    {
                        if (MouseManager.Y > Int_Manager.Calendar_Y && MouseManager.Y < Int_Manager.Calendar_Y + 20)
                        {
                            Bool_Manager.Calendar = false;
                        }
                    }

                    if (MouseManager.X > Int_Manager.Calendar_X + 48 && MouseManager.X < Int_Manager.Calendar_X + 56)
                    {
                        if (MouseManager.Y > Int_Manager.Calendar_Y + 395 && MouseManager.Y < Int_Manager.Calendar_Y + 412)
                        {
                            if(offset + DateTime.UtcNow.Month <= 12 && offset + DateTime.UtcNow.Month > 1)
                            {
                                offset++;
                            }
                            else
                            {
                                yearoffset++;
                                offset = 0;
                            }
                        }
                    }
                    if (MouseManager.X > Int_Manager.Calendar_X + 21 && MouseManager.X < Int_Manager.Calendar_X + 39)
                    {
                        if (MouseManager.Y > Int_Manager.Calendar_Y + 395 && MouseManager.Y < Int_Manager.Calendar_Y + 412)
                        {
                            if(offset + DateTime.UtcNow.Month != 1)
                            {
                                offset--;
                            }
                            else
                            {
                                yearoffset--;
                                offset = 0;
                            }
                        }
                    }
                }
                if (movable == true)
                {
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        Int_Manager.Calendar_X = (int)MouseManager.X;
                        Int_Manager.Calendar_Y = (int)MouseManager.Y;
                        movable = false;
                    }
                    else
                    {
                        Int_Manager.Calendar_X = (int)MouseManager.X;
                        Int_Manager.Calendar_Y = (int)MouseManager.Y;
                    }
                }
            }
        }
    }
}
