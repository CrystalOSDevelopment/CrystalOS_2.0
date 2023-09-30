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
using Youtube_tut.Applications.Calculator;
using CrystalOS.Applications.Menu;

namespace CrystalOS2.Applications.Task_Scheduler
{
    public class Task_Manager
    {
        public static List<Tuple<string, int, int, bool, string, bool, int>> Tasks = new List<Tuple<string, int, int, bool, string, bool, int>>();

        public static List<App> calculators = new List<App>();

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

        public static int left = ImprovedVBE.width / 2 - 98;
        public static int right = ImprovedVBE.width / 2 + 10;
        public static bool leftorright = false;

        public static bool clicked = false;
        public static int cycle = 0;
        public static void Task_manager()
        {
            //ImprovedVBE.DrawImageAlpha(based, 0, 50);
            /*
            foreach(Tuple<string, int, int, bool, string, bool, int> t in Tasks) //Tuple<string, int, int, bool, string> t in 
            {
                if (t.Item6 == true && t.Item7 == CrystalOS2.Applications.MultiDesk.Core.Current_Desktop)
                {

                    if (t.Item1 == "settings")
                    {
                        CrystalOS.NewFolder.NewFolder.Settings.settings(t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
                            if (MouseManager.MouseState == MouseState.Left)
                            {
                                if (Kernel.X > left && Kernel.X < left + 100)
                                {
                                    if (Kernel.Y > 5 && Kernel.Y < 30)
                                    {
                                        Task_Manager.Tasks.Insert(indicator, new Tuple<string, int, int, bool, string, bool, int>("settings", t.Item2, t.Item3, false, t.Item5, false, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                                        Task_Manager.Tasks.RemoveAt(indicator + 1);
                                    }
                                }
                            }
                            left -= 80;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                            if (MouseManager.MouseState == MouseState.Left)
                            {
                                if (Kernel.X > right && Kernel.X > right + 100)
                                {
                                    if (Kernel.Y > 5 && Kernel.Y < 30)
                                    {
                                        Task_Manager.Tasks.Insert(indicator, new Tuple<string, int, int, bool, string, bool, int>("settings", t.Item2, t.Item3, false, t.Item5, false, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                                        Task_Manager.Tasks.RemoveAt(indicator + 1);
                                    }
                                }
                            }
                            right += 80;
                            leftorright = true;
                        }
                    }
                    /*
                    else if (t.Item1 == "calculator")
                    {
                        Task_Manager.calculators.Add(new Calculator());
                        //Youtube_tut.Applications.Calculator.Calculator.calculator(t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1.Remove(5), left + 12, 7, 16777215);
                            left -= 80;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1.Remove(5), right + 12, 7, 16777215);
                            right += 80;
                            leftorright = true;
                        }
                    }
                    /
                    else if (t.Item1 == "text_editor")
                    {
                        CrystalOS.Applications.Text_Editor.Text_Editor.text_editor(t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1.Remove(5), left + 12, 7, 16777215);
                            left -= 80;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1.Remove(5), right + 12, 7, 16777215);
                            right += 80;
                            leftorright = true;
                        }
                        editor_counter++;
                    }
                    else if (t.Item1 == "explorer")
                    {
                        File_Explorer.File_Explorer.file_explorer(c, t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
                            left -= 80;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                            right += 80;
                            leftorright = true;
                        }
                        filemgr_counter++;
                    }
                    else if (t.Item1 == "terminal")
                    {
                        Terminal_Core.Terminal();
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
                            left -= 80;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                            right += 80;
                            leftorright = true;
                        }
                    }
                    else if (t.Item1 == "Calendar")
                    {
                        Calendar.Calendar.calendar(t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
                            left -= 80;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                            right += 80;
                            leftorright = true;
                        }
                    }
                    else if (t.Item1 == "Browser")
                    {
                        Browser.Browser.Browser_app(t.Item2, t.Item3, t.Item5);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
                            left -= 80;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                            right += 80;
                            leftorright = true;
                        }
                    }
                    else if (t.Item1 == "Gameboy")
                    {

                        Game_selector.Game_selector_(t.Item2, t.Item3);

                        //ProjectDMG.ProjectDMG gameboy = new ProjectDMG.ProjectDMG();
                        //gameboy.EXECUTE();
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
                            left -= 80;
                            leftorright = false;
                        }
                        else
                        {
                            ImprovedVBE.DrawImageAlpha(Button, right, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                            right += 80;
                            leftorright = true;
                        }
                    }
                    else
                    {
                        /*
                        string[] pos = t.Item5.Split(" ");
                        int x = int.Parse(pos[0]);
                        int y = int.Parse(pos[1]);
                        if(t.Item1.Length > 8)
                        {
                            if (leftorright == true)
                            {
                                ImprovedVBE.DrawImageAlpha(Button, left, 5);
                                ImprovedVBE._DrawACSIIString(t.Item1.Remove(8), left + 12, 7, 16777215);//Fix this modafoka, because sometimes it is possible that it out of ranges
                                left -= 80;
                                leftorright = false;
                            }
                            else
                            {
                                ImprovedVBE.DrawImageAlpha(Button, right, 5);
                                ImprovedVBE._DrawACSIIString(t.Item1.Remove(8), right + 12, 7, 16777215);
                                right += 80;
                                leftorright = true;
                            }
                        }
                        if (t.Item1.Length < 8)
                        {
                            if (leftorright == true)
                            {
                                ImprovedVBE.DrawImageAlpha(Button, left, 5);
                                ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);//Fix this modafoka, because sometimes it is possible that it out of ranges
                                left -= 80;
                                leftorright = false;
                            }
                            else
                            {
                                ImprovedVBE.DrawImageAlpha(Button, right, 5);
                                ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                                right += 80;
                                leftorright = true;
                            }
                        }

                        Window_Layout.Draw_Window(t.Item1, t.Item2, t.Item3, x, y);

                        ImprovedVBE._DrawACSIIString("Debugger: " + x + ", " + y, 600, 300, 0);
                        */


                        //Graphics_programing1.current_namespace = "";
                        //Graphics_programing1.is_started = false;
                        //Graphics_programing1.Windows.Clear();

                        //Graphics_programing1.graphic_window_exec(t.Item5);

                        /*
                        //ImprovedVBE.DrawFilledRectangle(120, t.Item2, t.Item3, data[counter], data[counter+1]);
                        try
                        {
                            //Window_Layout.Draw_Window(t.Item1, t.Item2, t.Item3, data[counter], data[counter + 1]);
                            if (leftorright == true)
                            {
                                ImprovedVBE.DrawImageAlpha(Button, left, 5);
                                ImprovedVBE._DrawACSIIString(t.Item1.Remove(8), left + 12, 7, 16777215);
                                left -= 80;
                                leftorright = false;
                            }
                            else
                            {
                                ImprovedVBE.DrawImageAlpha(Button, right, 5);
                                ImprovedVBE._DrawACSIIString(t.Item1.Remove(8), right + 12, 7, 16777215);
                                right += 80;
                                leftorright = true;
                            }
                            Graphics_programing1.graphic_window_exec(t.Item5);
                        }
                        catch(Exception e)
                        {
                            //ImprovedVBE._DrawACSIIString(e.Message, 1, 1, 16777215);
                        }
                        counter += 2;
                        foo += 1;
                        /
                    }
                }
                if (t.Item6 == false)
                {

                    if (t.Item1 == "settings")
                    {
                        //CrystalOS.NewFolder.NewFolder.Settings.settings(t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
                            if (leftorright == true)
                            {
                                ImprovedVBE.DrawImageAlpha(Button, left, 5);
                                ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
                                if (MouseManager.MouseState == MouseState.Left)
                                {
                                    if (Kernel.X > left && Kernel.X < left + 100)
                                    {
                                        if (Kernel.Y > 5 && Kernel.Y < 30)
                                        {
                                            Task_Manager.Tasks.Insert(indicator, new Tuple<string, int, int, bool, string, bool, int>("settings", t.Item2, t.Item3, false, t.Item5, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
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
                                ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                                if (MouseManager.MouseState == MouseState.Left)
                                {
                                    if (Kernel.X > right && Kernel.X > right + 100)
                                    {
                                        if (Kernel.Y > 5 && Kernel.Y < 30)
                                        {
                                            Task_Manager.Tasks.Insert(indicator, new Tuple<string, int, int, bool, string, bool, int>("settings", t.Item2, t.Item3, false, t.Item5, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
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
                            ImprovedVBE._DrawACSIIString(t.Item1, right + 12, 7, 16777215);
                            if (MouseManager.MouseState == MouseState.Left)
                            {
                                if (Kernel.X > left && Kernel.X < left + 100)
                                {
                                    if (Kernel.Y > 5 && Kernel.Y < 30)
                                    {
                                        Task_Manager.Tasks.RemoveAt(0);
                                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string, bool, int>("settings", t.Item2, t.Item3, false, t.Item5, true, CrystalOS2.Applications.MultiDesk.Core.Current_Desktop));
                                    }
                                }
                            }
                            right += 109;
                            leftorright = true;
                        }
                    }
                    else if (t.Item1 == "calculator")
                    {
                        //Youtube_tut.Applications.Calculator.Calculator.calculator(t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1.Remove(8), left + 12, 7, 16777215);
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
                    else if (t.Item1 == "text_editor")
                    {
                        //CrystalOS.Applications.Text_Editor.Text_Editor.text_editor(t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1.Remove(8), left + 12, 7, 16777215);
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
                        editor_counter++;
                    }
                    else if (t.Item1 == "explorer")
                    {
                        //File_Explorer.File_Explorer.file_explorer(c, t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
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
                        filemgr_counter++;
                    }
                    else if (t.Item1 == "terminal")
                    {
                        //Terminal_Core.Terminal();
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
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
                    else if (t.Item1 == "Calendar")
                    {
                        //Calendar.Calendar.calendar(t.Item2, t.Item3);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
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
                    else if (t.Item1 == "Browser")
                    {
                        //Browser.Browser.Browser_app(t.Item2, t.Item3, t.Item5);
                        if (leftorright == true)
                        {
                            ImprovedVBE.DrawImageAlpha(Button, left, 5);
                            ImprovedVBE._DrawACSIIString(t.Item1, left + 12, 7, 16777215);
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
                    else
                    {
                        //Graphics_programing1.current_namespace = "";
                        //Graphics_programing1.is_started = false;
                        
                        //Graphics_programing1.Windows.Clear();

                        //Graphics_programing1.graphic_window_exec(t.Item5);
                    }
                }
                //indicator++;
                //ImprovedVBE._DrawACSIIString(t.Item1, x, y, 16777215);
                //ImprovedVBE._DrawACSIIString(t.Item4.ToString(), x + 200, y, 16777215);
                //y += 25;
            }
            */
            int y_y = 100;

            //ImprovedVBE._DrawACSIIString(Task_Manager.calculators.Count.ToString(), 100, y_y, 0);

            for (int i = 0; i < calculators.Count; i++)
            {
                for (int j = 0; j < calculators.Count - i - 1; j++)
                {
                    if (calculators[j].z > calculators[j + 1].z)
                    {
                        // Swap objects
                        App temp = calculators[j];
                        calculators[j] = calculators[j + 1];
                        calculators[j + 1] = temp;
                    }
                }
            }
            for(int i = 0; i < calculators.Count; i++)
            {
                calculators[i].z = i;
            }
            Menumgr.z_axis = calculators.Count + 1;
            foreach (var c in Task_Manager.calculators)
            {
                if (c.desk_ID == Applications.MultiDesk.Core.Current_Desktop)
                {
                    if (c.minimised == false)
                    {
                        c.App();
                    }
                    if (leftorright == true)
                    {
                        ImprovedVBE.DrawImageAlpha(Button, left, 5);
                        ImprovedVBE._DrawACSIIString(c.name, left + 12, 7, 16777215);

                        if (MouseManager.MouseState == MouseState.Left)
                        {
                            clicked = true;
                        }
                        if(clicked == true)
                        {
                            if(MouseManager.MouseState == MouseState.None)
                            {
                                if (Kernel.X > left && Kernel.X < left + 70)
                                {
                                    if (Kernel.Y > 5 && Kernel.Y < 30)
                                    {
                                        if (c.minimised == true)
                                        {
                                            c.minimised = false;
                                            clicked = false;
                                        }
                                        else
                                        {
                                            c.minimised = true;
                                            clicked = false;
                                        }
                                    }
                                }
                            }
                        }
                        left -= 80;
                        leftorright = false;
                    }
                    else
                    {
                        ImprovedVBE.DrawImageAlpha(Button, right, 5);
                        ImprovedVBE._DrawACSIIString(c.name, right + 12, 7, 16777215);
                        if (MouseManager.MouseState == MouseState.Left)
                        {
                            clicked = true;
                        }
                        if (clicked == true)
                        {
                            if (MouseManager.MouseState == MouseState.None)
                            {
                                if (Kernel.X > right && Kernel.X < right + 70)
                                {
                                    if (Kernel.Y > 5 && Kernel.Y < 30)
                                    {
                                        if (c.minimised == true)
                                        {
                                            c.minimised = false;
                                            clicked = false;
                                        }
                                        else
                                        {
                                            c.minimised = true;
                                            clicked = false;
                                        }
                                    }
                                }
                            }
                        }
                        right += 80;
                        leftorright = true;
                    }
                }

                indicator++;
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

            left = ImprovedVBE.width / 2 - 98;
            right = ImprovedVBE.width / 2 + 10;
            leftorright = false;

            //The task_Manager app itself
            #region start
            if(Bool_Manager.Taskman == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > Int_Manager.Calculator_X + 623 && Kernel.X < Int_Manager.Calculator_X + 644)
                    {
                        if (Kernel.Y > Int_Manager.Calculator_Y + 8 && Kernel.Y < Int_Manager.Calculator_Y + 24)
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

                foreach (Tuple<string, int, int, bool, string, bool, int> s in Tasks)
                {
                    if(MouseManager.MouseState == MouseState.Left)
                    {
                        if (Kernel.X > Int_Manager.Calculator_X && Kernel.X < Int_Manager.Calculator_X + 650)
                        {
                            if (Kernel.Y > Int_Manager.Calculator_Y + a && Kernel.Y < Int_Manager.Calculator_Y + a + 20)
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
                    if (Kernel.X > Int_Manager.Calculator_X + 541 && Kernel.X < Int_Manager.Calculator_X + 642)
                    {
                        if (Kernel.Y > Int_Manager.Calculator_Y + 351 && Kernel.Y < Int_Manager.Calculator_Y + 393)
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
                        Int_Manager.Calculator_X = (int)Kernel.X;
                        Int_Manager.Calculator_Y = (int)Kernel.Y;
                        movable = false;
                    }
                    else
                    {
                        Int_Manager.Calculator_X = (int)Kernel.X;
                        Int_Manager.Calculator_Y = (int)Kernel.Y;
                    }
                }
            }
            #endregion start
            cycle++;
            if (MouseManager.MouseState == MouseState.None && cycle > 25)
            {
                clicked = false;
                cycle = 0;
            }
        }
    }
}
