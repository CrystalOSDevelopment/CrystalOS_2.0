using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTest.Applications.Calendar
{
    public static class Calendar
    {
        public static VBECanvas c;
        public static int day = DateTime.Today.Day;
        public static int month = DateTime.UtcNow.Month;
        [ManifestResourceStream(ResourceName = "SoundTest.Applications.Calendar.Calendar.bmp")] public static byte[] calendar_base;
        public static Bitmap Calendar_base = new Bitmap(calendar_base);

        public static void calendar()
        {
            ImprovedVBE.DrawImageAlpha(Calendar_base, 0, 50);
            ImprovedVBE._DrawACSIIString(month.ToString(), 128, 89, 16777215);
            ImprovedVBE._DrawACSIIString(day.ToString(), 278, 89, 16777215);
            int basex = 3 + 107 * 6;
            int basey = 137;

            for (int i = 1; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + 1; i++)
            {
                if (day == i)
                {
                    ImprovedVBE.DrawFilledRectangle(c, 4808134, basex - 1, basey - 1, 104, 65);
                }
                ImprovedVBE._DrawACSIIString(i.ToString(), basex, basey, 16777215);
                basex += 107;
                if (basex >= 107 * 7)
                {
                    basey += 68;
                    basex = 3;
                }
            }
        }
    }
}
