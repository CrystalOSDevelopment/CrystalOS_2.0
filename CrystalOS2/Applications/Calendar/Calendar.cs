using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.Applications.Solitaire;
using CrystalOS.SystemFiles;
using CrystalOS2.Applications.Task_Scheduler;
using IL2CPU.API.Attribs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_tut.Applications.Calculator;

namespace CrystalOS2.Applications.Calendar
{
    public class Calendar : App
    {
        public static Canvas c;
        public static int day = DateTime.Today.Day;
        public static int month = DateTime.UtcNow.Month;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Calendar.Calendar.bmp")] public static byte[] calendar_base;
        public static Bitmap Calendar_base = new Bitmap(calendar_base);

        public static int dayofweek = 0;

        public int desk_ID { get; set; }

        public int x = 100;
        public int y = 100;

        public string name
        {
            get { return "Cale..."; }
        }

        public bool minimised { get; set; }
        public int z { get; set; }
        public bool movable = false;

        public static int offset = 0;
        public static int yearoffset = 0;

        public void App()
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

                ImprovedVBE._DrawACSIIString("Current date: " + (DateTime.UtcNow.Year + yearoffset).ToString() + ". " + (DateTime.UtcNow.Month + offset).ToString() + ". " + DateTime.UtcNow.Day.ToString(), x + 76, y + 400, 0);

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x && Kernel.X < x + 730)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 20)
                        {
                            movable = true;
                        }
                    }
                    if (Kernel.X > x + 735 && Kernel.X < x + 745)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 20)
                        {
                            Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                        }
                    }

                    if (Kernel.X > x + 48 && Kernel.X < x + 56)
                    {
                        if (Kernel.Y > y + 395 && Kernel.Y < y + 412)
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
                    if (Kernel.X > x + 21 && Kernel.X < x + 39)
                    {
                        if (Kernel.Y > y + 395 && Kernel.Y < y + 412)
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
            if (Task_Manager.indicator == Task_Manager.calculators.Count - 1)
            {

            }
            else
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > x && Kernel.X < x + Calendar_base.Width)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + Calendar_base.Height)
                        {
                            z = 999;
                        }
                    }
                }
            }
        }
    }
}
