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

namespace CrystalOS2.Applications.Task_Scheduler
{
    public class Task_Manager
    {
        public static List<Tuple<string, int, int, bool, string>> Tasks = new List<Tuple<string, int, int, bool, string>>();
        public static int indicator = 0;
        public static bool reversed = false;
        public static int x = 4;
        public static int y = 79;
        public static List<int> data = new List<int>();
        public static int counter = 0;
        public static int foo = 0;
        public static int editor_counter = 0;
        public static int filemgr_counter = 0;

        public static Canvas c;

        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Task_manager.bmp")] public static byte[] Solitaire;
        public static Bitmap based = new Bitmap(Solitaire);
        public static void Task_manager()
        {
            //ImprovedVBE.DrawImageAlpha(based, 0, 50);
            for (indicator = 0; indicator < Tasks.Count; indicator++) //Tuple<string, int, int, bool, string> t in 
            {
                if (Tasks[indicator].Item1 == "settings")
                {
                    CrystalOS.NewFolder.NewFolder.Settings.settings(Tasks[indicator].Item2, Tasks[indicator].Item3);
                }
                else if (Tasks[indicator].Item1 == "calculator")
                {
                    Youtube_tut.Applications.Calculator.Calculator.calculator(Tasks[indicator].Item2, Tasks[indicator].Item3);
                }
                else if (Tasks[indicator].Item1 == "text_editor")
                {
                    CrystalOS.Applications.Text_Editor.Text_Editor.text_editor(Tasks[indicator].Item2, Tasks[indicator].Item3);
                    editor_counter++;
                }
                else if (Tasks[indicator].Item1 == "explorer")
                {
                    File_Explorer.File_Explorer.file_explorer(c, Tasks[indicator].Item2, Tasks[indicator].Item3);
                    filemgr_counter++;
                }
                else if (Tasks[indicator].Item1 == "terminal")
                {
                    Terminal_Core.Terminal();
                }
                else
                {
                    //ImprovedVBE.DrawFilledRectangle(120, t.Item2, t.Item3, data[counter], data[counter+1]);
                    try
                    {
                        Window_Layout.Draw_Window(Tasks[indicator].Item1, Tasks[indicator].Item2, Tasks[indicator].Item3, data[counter], data[counter + 1]);
                    }
                    catch(Exception e)
                    {
                        //ImprovedVBE._DrawACSIIString(e.Message, 0, 0, 16777215);
                    }
                    counter += 2;
                    foo += 1;
                }
                //indicator++;
                //ImprovedVBE._DrawACSIIString(t.Item1, x, y, 16777215);
                //ImprovedVBE._DrawACSIIString(t.Item4.ToString(), x + 200, y, 16777215);
                //y += 25;
            }
            File_Explorer.File_Explorer.hell = false;
            File_Explorer.File_Explorer.readwrite = false;
            //x = 4;
            //y = 79;
            indicator = 0;
            counter = 0;
            foo = 0;
            editor_counter = 0;
            filemgr_counter = 0;
        }
    }
}
