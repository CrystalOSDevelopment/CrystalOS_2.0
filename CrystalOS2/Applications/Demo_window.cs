using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_tut.Applications.Calculator;

namespace CrystalOS2.Applications
{
    class Demo_window
    {
        public static int x = 100;
        public static int y = 100;
        public static int width = 102;
        public static int height = 102;

        public static void App()
        {
            #region corners
            ImprovedVBE.DrawFilledEllipse(x, y, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
            ImprovedVBE.DrawFilledEllipse(x + width, y, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
            ImprovedVBE.DrawFilledEllipse(x, y + height, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
            ImprovedVBE.DrawFilledEllipse(x + width, y + height, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
            #endregion corners

            #region base
            ImprovedVBE.DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 255, 255), x, y - 9, width + 4, 21);
            ImprovedVBE.DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 255, 255), x, y + height - 9, width + 4, 21);

            ImprovedVBE.DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 255, 255), x - 10, y, width + 20, height);
            #endregion base
        }
    }
}
