using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTest.Applications.Task_Scheduler
{
    public class Task_Manager
    {
        public static List<Tuple<string, int, int, bool, string>> Tasks = new List<Tuple<string, int, int, bool, string>>();
        public static int indicator = 0;
        public static bool reversed = false;
        public static int x = 4;
        public static int y = 79;

        [ManifestResourceStream(ResourceName = "SoundTest.SystemFiles.Task_manager.bmp")] public static byte[] Solitaire;
        public static Bitmap based = new Bitmap(Solitaire);
        public static void Task_manager()
        {
            //ImprovedVBE.DrawImageAlpha(based, 0, 50);
            foreach (Tuple<string, int, int, bool, string> t in Tasks)
            {
                if(t.Item1 == "settings")
                {
                    CrystalOS.NewFolder.NewFolder.Settings.settings(t.Item2, t.Item3);
                }
                else if (t.Item1 == "calculator")
                {
                    CrystalOS.Applications.Calculator.Calculator.calculator(t.Item2, t.Item3);
                }
                else if (t.Item1 == "text_editor")
                {
                    CrystalOS.Applications.Text_Editor.Text_Editor.text_editor(t.Item2, t.Item3);
                }
                indicator++;
                //ImprovedVBE._DrawACSIIString(t.Item1, x, y, 16777215);
                //ImprovedVBE._DrawACSIIString(t.Item4.ToString(), x + 200, y, 16777215);
                //y += 25;
            }
            //x = 4;
            //y = 79;
            indicator = 0;
        }
    }
}
