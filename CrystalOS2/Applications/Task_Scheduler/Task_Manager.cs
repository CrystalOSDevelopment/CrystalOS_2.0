using Cosmos.System.Graphics;
using CrystalOS.Applications.Programmers_Dream;
using IL2CPU.API.Attribs;
using CrystalOS2.SystemFiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalOS.Applications.Terminal;
using CrystalOS.SystemFiles;
using Cosmos.System;
using CrystalOS.Applications.Text_Editor;
using CrystalOS2.Applications.Calendar;
using CrystalOS2.Applications.Programmers_Dream;
using ProjectDMG;
using System.Diagnostics.Metrics;
using CrystalOS2.Gameboy;

namespace CrystalOS2.Applications.Task_Scheduler
{
    public class Task_Manager
    {
        public static List<Tuple<string, int, int, bool, string, bool>> Tasks = new List<Tuple<string, int, int, bool, string, bool>>();
        public static int indicator = 0;
        public static bool reversed = false;
        public static int x = 4;
        public static int y = 79;
        public static List<int> data = new List<int>();
        public static int counter = 0;
        public static int foo = 0;
        public static int editor_counter = 0;
        public static int filemgr_counter = 0;
        public static int Paint_app = 0;

        public static bool movable = false;

        public static int count = -1;

        public static Canvas c;

        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Task_manager.bmp")] public static byte[] Solitaire;
        public static Bitmap based = new Bitmap(Solitaire);

        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.button.bmp")] public static byte[] button;
        public static Bitmap Button = new Bitmap(button);

        public static int left = 810;
        public static int right = 973;
        public static bool leftorright = false;

        public static void Task_manager()
        {
            //ImprovedVBE.DrawImageAlpha(based, 0, 50);

            for(indicator = 0; indicator < Tasks.Count; indicator++) //Tuple<string, int, int, bool, string> t in 
            {
                if (Tasks[indicator].Item6 == true)
                {

                    if (Tasks[indicator].Item1 == "settings")
                    {
                        CrystalOS.NewFolder.NewFolder.Settings.settings(Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            if (MouseManager.MouseState == MouseState.Left)
                            {
                                if (MouseManager.X > left && MouseManager.X < left + 100)
                                {
                                    if (MouseManager.Y > 5 && MouseManager.Y < 30)
                                    {
                                        Task_Manager.Tasks.Insert(indicator, new Tuple<string, int, int, bool, string, bool>("settings", Tasks[indicator].Item2, Tasks[indicator].Item3, false, Tasks[indicator].Item5, false));
                                        Task_Manager.Tasks.RemoveAt(indicator + 1);
                                    }
                                }
                            }
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            if (MouseManager.MouseState == MouseState.Left)
                            {
                                if (MouseManager.X > right && MouseManager.X > right + 100)
                                {
                                    if (MouseManager.Y > 5 && MouseManager.Y < 30)
                                    {
                                        Task_Manager.Tasks.Insert(indicator, new Tuple<string, int, int, bool, string, bool>("settings", Tasks[indicator].Item2, Tasks[indicator].Item3, false, Tasks[indicator].Item5, false));
                                        Task_Manager.Tasks.RemoveAt(indicator + 1);
                                    }
                                }
                            }
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "calculator")
                    {
                        Youtube_tut.Applications.Calculator.Calculator.calculator(Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "text_editor")
                    {
                        CrystalOS.Applications.Text_Editor.Text_Editor.text_editor(Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                        editor_counter++;
                    }
                    else if (Tasks[indicator].Item1 == "explorer")
                    {
                        File_Explorer.File_Explorer.file_explorer(c, Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                        filemgr_counter++;
                    }
                    else if (Tasks[indicator].Item1 == "terminal")
                    {
                        Terminal_Core.Terminal();
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "Calendar")
                    {
                        Calendar.Calendar.calendar(Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "Browser")
                    {
                        Browser.Browser.Browser_app(Tasks[indicator].Item2, Tasks[indicator].Item3, Tasks[indicator].Item5);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "Gameboy")
                    {

                        Game_selector.Game_selector_(Tasks[indicator].Item2, Tasks[indicator].Item3);

                        //ProjectDMG.ProjectDMG gameboy = new ProjectDMG.ProjectDMG();
                        //gameboy.EXECUTE();
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else
                    {
                        /*
                        string[] pos = Tasks[indicator].Item5.Split(" ");
                        int x = int.Parse(pos[0]);
                        int y = int.Parse(pos[1]);
                        if(Tasks[indicator].Item1.Length > 8)
                        {
                            if (leftorright == true)
                            {
                                ImprovedVBE.DrawImageAlpha(Button, left, 5);
                                ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), left + 12, 7, 16777215);//Fix this modafoka, because sometimes it is possible that it out of ranges
                                left -= 109;
                                leftorright = false;
                            }
                            else
                            {
                                ImprovedVBE.DrawImageAlpha(Button, right, 5);
                                ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), right + 12, 7, 16777215);
                                right += 109;
                                leftorright = true;
                            }
                        }
                        if (Tasks[indicator].Item1.Length < 8)
                        {
                            if (leftorright == true)
                            {
                                ImprovedVBE.DrawImageAlpha(Button, left, 5);
                                ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);//Fix this modafoka, because sometimes it is possible that it out of ranges
                                left -= 109;
                                leftorright = false;
                            }
                            else
                            {
                                ImprovedVBE.DrawImageAlpha(Button, right, 5);
                                ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                                right += 109;
                                leftorright = true;
                            }
                        }

                        Window_Layout.Draw_Window(Tasks[indicator].Item1, Tasks[indicator].Item2, Tasks[indicator].Item3, x, y);

                        ImprovedVBE._DrawACSIIString("Debugger: " + x + ", " + y, 600, 300, 0);
                        */


                        //Graphics_programing1.current_namespace = "";
                        //Graphics_programing1.is_started = false;
                        //Graphics_programing1.Windows.Clear();

                        //Graphics_programing1.graphic_window_exec(Tasks[indicator].Item5);

                        /*
                        //ImprovedVBE.DrawFilledRectangle(120, Tasks[indicator].Item2, Tasks[indicator].Item3, data[counter], data[counter+1]);
                        try
                        {
                            //Window_Layout.Draw_Window(Tasks[indicator].Item1, Tasks[indicator].Item2, Tasks[indicator].Item3, data[counter], data[counter + 1]);
                            if (leftorright == true)
                            {
                                ImprovedVBE.DrawImageAlpha(Button, left, 5);
                                ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), left + 12, 7, 16777215);
                                left -= 109;
                                leftorright = false;
                            }
                            else
                            {
                                ImprovedVBE.DrawImageAlpha(Button, right, 5);
                                ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), right + 12, 7, 16777215);
                                right += 109;
                                leftorright = true;
                            }
                            Graphics_programing1.graphic_window_exec(Tasks[indicator].Item5);
                        }
                        catch(Exception e)
                        {
                            //ImprovedVBE._DrawACSIIString(e.Message, 1, 1, 16777215);
                        }
                        counter += 2;
                        foo += 1;
                        */
                    }
                }
                if (Tasks[indicator].Item6 == false)
                {

                    if (Tasks[indicator].Item1 == "settings")
                    {
                        //CrystalOS.NewFolder.NewFolder.Settings.settings(Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            if (leftorright == true)
                            {
                                ImprovedVBE.DrawImageAlpha(Button, left, 5);
                                ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                                if (MouseManager.MouseState == MouseState.Left)
                                {
                                    if (MouseManager.X > left && MouseManager.X < left + 100)
                                    {
                                        if (MouseManager.Y > 5 && MouseManager.Y < 30)
                                        {
                                            Task_Manager.Tasks.Insert(indicator, new Tuple<string, int, int, bool, string, bool>("settings", Tasks[indicator].Item2, Tasks[indicator].Item3, false, Tasks[indicator].Item5, true));
                                            Task_Manager.Tasks.RemoveAt(indicator + 1);
                                        }
                                    }
                                }
                                left -= 109;
                                leftorright = false;
                            }
                            else
                            {
                                ImprovedVBE.DrawImageAlpha(Button, right, 5);
                                ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                                if (MouseManager.MouseState == MouseState.Left)
                                {
                                    if (MouseManager.X > right && MouseManager.X > right + 100)
                                    {
                                        if (MouseManager.Y > 5 && MouseManager.Y < 30)
                                        {
                                            Task_Manager.Tasks.Insert(indicator, new Tuple<string, int, int, bool, string, bool>("settings", Tasks[indicator].Item2, Tasks[indicator].Item3, false, Tasks[indicator].Item5, true));
                                            Task_Manager.Tasks.RemoveAt(indicator + 1);
                                        }
                                    }
                                }
                            }
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            if (MouseManager.MouseState == MouseState.Left)
                            {
                                if (MouseManager.X > left && MouseManager.X < left + 100)
                                {
                                    if (MouseManager.Y > 5 && MouseManager.Y < 30)
                                    {
                                        Task_Manager.Tasks.RemoveAt(0);
                                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool>("settings", Tasks[indicator].Item2, Tasks[indicator].Item3, false, Tasks[indicator].Item5, true));
                                    }
                                }
                            }
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "calculator")
                    {
                        //Youtube_tut.Applications.Calculator.Calculator.calculator(Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "text_editor")
                    {
                        //CrystalOS.Applications.Text_Editor.Text_Editor.text_editor(Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1.Remove(8), right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                        editor_counter++;
                    }
                    else if (Tasks[indicator].Item1 == "explorer")
                    {
                        //File_Explorer.File_Explorer.file_explorer(c, Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                        filemgr_counter++;
                    }
                    else if (Tasks[indicator].Item1 == "terminal")
                    {
                        //Terminal_Core.Terminal();
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "Calendar")
                    {
                        //Calendar.Calendar.calendar(Tasks[indicator].Item2, Tasks[indicator].Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (Tasks[indicator].Item1 == "Browser")
                    {
                        //Browser.Browser.Browser_app(Tasks[indicator].Item2, Tasks[indicator].Item3, Tasks[indicator].Item5);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, left + 12, 7, 16777215);
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else
                    {
                        //Graphics_programing1.current_namespace = "";
                        //Graphics_programing1.is_started = false;
                        
                        //Graphics_programing1.Windows.Clear();

                        //Graphics_programing1.graphic_window_exec(Tasks[indicator].Item5);
                    }
                }
                //indicator++;
                //ImprovedVBE._DrawACSIIString(Tasks[indicator].Item1, x, y, 16777215);
                //ImprovedVBE._DrawACSIIString(Tasks[indicator].Item4.ToString(), x + 200, y, 16777215);
                //y += 25;
            }

            try
            {
                foreach (Tuple<string, int, int, int, int> t in Graphics_programing1.Windows)
                {
                    if (t.Item1.Length > 8)
                    {
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1.Remove(8), left + 12, 7, 16777215);//Fix this modafoka, because sometimes it is possible that it out of ranges
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1.Remove(8), right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }
                    if (t.Item1.Length < 8)
                    {
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);//Fix this modafoka, because sometimes it is possible that it out of ranges
                            left -= 109;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                            right += 109;
                            leftorright = true;
                        }
                    }

                    Window_processor.Window(t.Item1, t.Item2, t.Item3, 300, 150);
                }
            }
            catch { }

            File_Explorer.File_Explorer.hell = false;
            File_Explorer.File_Explorer.readwrite = false;
            //x = 4;
            //y = 79;
            indicator = 0;
            counter = 0;
            foo = 0;
            editor_counter = 0;
            filemgr_counter = 0;

            left = 810;
            right = 973;
            leftorright = false;

            //The task_Manager app itself
            #region start
            if(Bool_Manager.Taskman == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > Int_Manager.Calculator_X + 623 && MouseManager.X < Int_Manager.Calculator_X + 644)
                    {
                        if (MouseManager.Y > Int_Manager.Calculator_Y + 8 && MouseManager.Y < Int_Manager.Calculator_Y + 24)
                        {
                            count = -1;
                            Bool_Manager.Taskman = false;
                        }
                    }
                }
                ImprovedVBE.DrawImageAlpha(based, Int_Manager.Calculator_X, Int_Manager.Calculator_Y);

                int a = 45;

                if (count == 0)
                {
                    ImprovedVBE.DrawFilledRectangle(7030482, Int_Manager.Calculator_X + 1, Int_Manager.Calculator_Y + 43, 648, 20);
                }
                else if (count > 0)
                {
                    ImprovedVBE.DrawFilledRectangle(7030482, Int_Manager.Calculator_X + 1, Int_Manager.Calculator_Y + 43 + count * 20, 648, 20);
                }

                foreach (Tuple<string, int, int, bool, string, bool> s in Tasks)
                {
                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if (MouseManager.X > Int_Manager.Calculator_X && MouseManager.X < Int_Manager.Calculator_X + 650)
                        {
                            if (MouseManager.Y > Int_Manager.Calculator_Y + a && MouseManager.Y < Int_Manager.Calculator_Y + a + 20)
                            {
                                count = (a - 45) / 20;
                            }
                        }
                    }
                    ImprovedVBE._DrawACSIIString(s.Item1, Int_Manager.Calculator_X + 24, Int_Manager.Calculator_Y + a, 16777215);
                    ImprovedVBE._DrawACSIIString(s.Item4.ToString(), Int_Manager.Calculator_X + 287, Int_Manager.Calculator_Y + a, 16777215);
                    a += 20;
                }

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > Int_Manager.Calculator_X + 541 && MouseManager.X < Int_Manager.Calculator_X + 642)
                    {
                        if (MouseManager.Y > Int_Manager.Calculator_Y + 351 && MouseManager.Y < Int_Manager.Calculator_Y + 393)
                        {
                            try
                            {
                                Tasks.RemoveAt(count);
                                count -= 1;
                            }
                            catch(Exception e)
                            {
                                //ImprovedVBE._DrawACSIIString(e.Message, 500, 500, 16777215);
                            }
                        }
                    }
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
                        Int_Manager.Calculator_X = (int)MouseManager.X;
                        Int_Manager.Calculator_Y = (int)MouseManager.Y;
                        movable = false;
                    }
                    else
                    {
                        Int_Manager.Calculator_X = (int)MouseManager.X;
                        Int_Manager.Calculator_Y = (int)MouseManager.Y;
                    }
                }
            }
            #endregion start
        }
    }
}
