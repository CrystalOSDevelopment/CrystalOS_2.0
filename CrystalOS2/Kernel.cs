using Cosmos.Core;
using Cosmos.Core.Memory;
using Cosmos.HAL;
using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using CrystalOS.Applications.About;
using CrystalOS.Applications.Menu;
using CrystalOS.Applications.Programmers_Dream;
using CrystalOS.SystemFiles;
using CrystalOS2;
using CrystalOS2._3d_demo;
using CrystalOS2._3d_graphics;
using CrystalOS2.Applications;
using CrystalOS2.Applications.Calendar;
using CrystalOS2.Applications.Clock;
using CrystalOS2.Applications.MultiDesk;
using CrystalOS2.Applications.Paint;
using CrystalOS2.Applications.Task_Scheduler;
using CrystalOS2.Applications.Video_Player;
using CrystalOS2.Applications.Word_Processor;
using CrystalOS2.SystemFiles.Boot;
using IL2CPU.API.Attribs;
using ProjectDMG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using TextureMapper.GFFFontRenderer;
using Youtube_tut.Applications.Calculator;
using Sys = Cosmos.System;

namespace CrystalOS2
{
    public class Kernel : Sys.Kernel
    {
        #region resources
        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Menu.bmp")] public static byte[] Autumn;
        public static Bitmap img = new Bitmap(Autumn);
        [ManifestResourceStream(ResourceName = "CrystalOS2.Icons.Cursor.bmp")] public static byte[] Cursor;
        public static Bitmap cursor = new Bitmap(Cursor);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Icons.Cursor2.bmp")] public static byte[] Cursor2;
        public static Bitmap cursor2 = new Bitmap(Cursor2);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Icons.Cursor3.bmp")] public static byte[] Cursor3;
        public static Bitmap cursor3 = new Bitmap(Cursor3);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Icons.Cursor4.bmp")] public static byte[] Cursor4;
        public static Bitmap cursor4 = new Bitmap(Cursor4);

        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Search.bmp")] public static byte[] search;
        public static Bitmap Search = new Bitmap(search);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Icons.my_pc.bmp")] public static byte[] icon_def;
        public static Bitmap Icon = new Bitmap(icon_def);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Icons.Folder.bmp")] public static byte[] files;
        public static Bitmap Folder = new Bitmap(files);

        [ManifestResourceStream(ResourceName = "CrystalOS2.Icons.notes.bmp")] public static byte[] notes;
        public static Bitmap Text = new Bitmap(notes);

        [ManifestResourceStream(ResourceName = "CrystalOS2.test.btf")] public static byte[] font1;
        #endregion resources

        public static string saved = "90_Style";

        public static string sel_curs = "bas3";

        public static List<Tuple<string, string, int, int, Bitmap>> icons = new List<Tuple<string, string, int, int, Bitmap>>();

        public VBECanvas canvas = new VBECanvas(new Mode(1280, 800, ColorDepth.ColorDepth32));

        BallerFont font;
        protected override void BeforeRun()
        {
            int x = 0;
            int y = 0;
            icons.Add(new Tuple<string, string, int, int, Bitmap>("My pc", "About", x, y, Icon));
            y += 65;
            icons.Add(new Tuple<string, string, int, int, Bitmap>("My files", "FS", x, y, Folder));
            y += 65;

            MouseManager.ScreenWidth = 1024;
            MouseManager.ScreenHeight = 768;

            font = FontRenderer.LoadFont(fontBytes);

            X = 10;
            Kernel.Y = 10;
            canvas.Display();
        }


        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Word_Processor.Font_rendering.ballerosfont.gff")]
        public static byte[] fontBytes;


        public static int FPS = 0;

        public static int LastS = -1;
        public static int Ticken = 0;

        ProjectDMG.ProjectDMG gameboy = new ProjectDMG.ProjectDMG();

        public static int gamenum = 0;

        public static void Update()
        {
            if (LastS == -1)
            {
                LastS = DateTime.UtcNow.Second;
            }
            if (DateTime.UtcNow.Second - LastS != 0)
            {
                if (DateTime.UtcNow.Second > LastS)
                {
                    FPS = Ticken / (DateTime.UtcNow.Second - LastS);
                }
                LastS = DateTime.UtcNow.Second;
                Ticken = 0;
            }
            Ticken++;
        }

        public static int a = 0;
        public static bool movable = false;
        public static bool power_on = true;
        public static bool show_gb = false;

        public static uint X = 10;
        public static uint Y = 10;

        public static bool Keyboard_cur = true;

        public static int kernel_cycle = 0;
        public static int indic = 0;
        public static bool magnify = false;
        protected override void Run()
        {
            Update();

            Boot_Login btl = new Boot_Login();

            #region Keyboard_Cursor
            KeyEvent k;
            if(KeyboardManager.AltPressed == true || KeyboardManager.ControlPressed)
            {
                if (KeyboardManager.TryReadKey(out k))
                {
                    if (k.Key == ConsoleKeyEx.F1)
                    {
                        Keyboard_cur = false;
                    }
                    if (k.Key == ConsoleKeyEx.F2)
                    {
                        Keyboard_cur = true;
                    }

                    if (k.Key == ConsoleKeyEx.F11)
                    {
                        magnify = true;
                    }
                    if (k.Key == ConsoleKeyEx.F12)
                    {
                        magnify = false;
                    }

                    if (k.Key == ConsoleKeyEx.F3)
                    {
                        Core core = new Core();
                        core.x = Menumgr.z + 50;
                        core.y = Menumgr.c + 50;
                        core.desk_ID = CrystalOS2.Applications.MultiDesk.Core.Current_Desktop;
                        core.minimised = false;

                        Task_Manager.calculators.Add(core);
                        /*
                        if (Core.Current_Desktop == 0)
                        {
                            Core.Current_Desktop = 9;
                        }
                        else
                        {
                            Core.Current_Desktop--;
                        }
                        */
                    }
                    if (k.Key == ConsoleKeyEx.F4)
                    {
                        if (Core.Current_Desktop == 9)
                        {
                            Core.Current_Desktop = 0;
                        }
                        else
                        {
                            Core.Current_Desktop++;
                        }
                    }

                    if (k.Key == ConsoleKeyEx.H)
                    {
                        //Magnifyer goes here
                        
                    }
                }
            }
            #endregion Keyboard_Cursor

            if (Bool_Manager.is_locked == false)
            {
                ImprovedVBE._DrawACSIIString(DateTime.UtcNow.Hour.ToString() + ":" + DateTime.UtcNow.Minute.ToString(), 964, 2, 16777215);
                ImprovedVBE._DrawACSIIString("fps: " + FPS, 87, 2, ImprovedVBE.colourToNumber(255, 255, 255));
                foreach (Tuple<string, string, int, int, Bitmap> s in icons)
                {
                    ImprovedVBE.DrawImageAlpha2(s.Item5, s.Item3 + 5, s.Item4 + 30);
                    ImprovedVBE._DrawACSIIString(s.Item1, s.Item3 + 5, (int)(s.Item4 + 35 + s.Item5.Height), 16777215);
                }
                if ((Bool_Manager.Text_Editor_Opened == false && Bool_Manager.Programmers_choice == false && Bool_Manager.Terminal_Opened == false && show_gb == false) || Keyboard_cur == true)
                {
                    KeyEvent key;
                    if (KeyboardManager.TryReadKey(out key))
                    {
                        if (key.Key == ConsoleKeyEx.Escape)
                        {

                            Bool_Manager.wallp = "Lock_Screen";
                            Bool_Manager.is_locked = true;
                        }
                        if (key.Key == ConsoleKeyEx.LCtrl)
                        {
                            Bool_Manager.Run_Window = true;
                        }

                        if (Keyboard_cur == true)
                        {
                            if (key.Key == ConsoleKeyEx.D)
                            {
                                X += 4;
                                kernel_cycle = 0;
                            }
                            if (key.Key == ConsoleKeyEx.A)
                            {
                                X -= 4;
                                kernel_cycle = 0;
                            }
                            if (key.Key == ConsoleKeyEx.S)
                            {
                                Y += 4;
                                kernel_cycle = 0;
                            }
                            if (key.Key == ConsoleKeyEx.W)
                            {
                                Y -= 4;
                                kernel_cycle = 0;
                            }
                        }
                    }

                    kernel_cycle++;
                }
                if(Keyboard_cur == false)
                {
                    Kernel.X = MouseManager.X;
                    Kernel.Y = MouseManager.Y;
                }
                if(kernel_cycle < 1005)
                {   
                    Applications.Run.Run.Run_Window();
                    Programmers_Choice.Core();

                    try
                    {
                        Task_Manager t = new Task_Manager();
                        t.Task_manager();
                        Clock.init(Int_Manager.Clock_X, Int_Manager.Clock_Y, 200, 200);
                        //CrystalOS.Applications.About.About_code.About(Int_Manager.About_X, Int_Manager.About_Y);
                        //Paint.Paint_app(Int_Manager.Paint_X, Int_Manager.Paint_Y);
                       // Calendar.calendar(Int_Manager.Calendar_X, Int_Manager.Calendar_Y);

                        //Word_processor.Core();

                        if (Boot_Login.opened == "yes")
                        {
                            Player_base.Player();
                        }

                        if (power_on == true)
                        {
                            gameboy.POWER_ON();
                            power_on = false;
                        }

                        if (show_gb == true)
                        {

                            #region move
                            if (MouseManager.MouseState == MouseState.Left)
                            {
                                if (X > PPU.x + 3 * 160 - 18 && X < PPU.x + 3 * 160 - 2)
                                {
                                    if (Kernel.Y > PPU.y - 18 && Kernel.Y < PPU.y - 2)
                                    {
                                        show_gb = false;
                                    }
                                }
                                if (movable == false)
                                {
                                    if (X > PPU.x && X < PPU.x + 3 * 142)
                                    {
                                        if (Kernel.Y > PPU.y - 20 && Kernel.Y < PPU.y)
                                        {
                                            movable = true;
                                        }
                                    }
                                }
                            }

                            if (movable == true)
                            {
                                PPU.x = (int)X;
                                PPU.y = (int)Kernel.Y + 20;
                                if (MouseManager.MouseState == MouseState.Right)
                                {
                                    movable = false;
                                }
                            }
                            #endregion move

                            #region window
                            //ImprovedVBE.DrawFilledRectangle(16777215, PPU.x - 1, PPU.y - 20, 162, 165);
                            ImprovedVBE.DrawFilledRectangle(120, PPU.x - 1, PPU.y - 20, 162 * 3 - 4, 165 * 3 - 42);
                            ImprovedVBE.DrawFilledRectangle(16724530, PPU.x + 3 * 160 - 18, PPU.y - 18, 16, 16);
                            ImprovedVBE._DrawACSIIString("Gameboy", PPU.x + 2, PPU.y - 18, 16777215);
                            #endregion window

                            gameboy.EXECUTE();
                        }
                    }
                    catch (Exception ex)
                    {
                        ImprovedVBE._DrawACSIIString("Debugger: " + ex.Message + "\nTask len: " + Task_Manager.Tasks.Count, 600, 50, 0);
                    }
                    
                    if (MouseManager.MouseState == MouseState.Left)
                    {
                        if (X > 40 && X < 70 && Kernel.Y > 0 && Kernel.Y < 30)
                        {
                            ImprovedVBE.DrawImageAlpha(Search, 0, 32);
                        }
                    }
                    //CrystalOS.Applications.Solitaire.Solitaire.Solitaire_core();
                    CrystalOS.Applications.Menu.Menumgr.MenuManager();
                }
                
            }

            //ImprovedVBE.DrawFilledEllipse(100, 100, 100, 50, ImprovedVBE.colourToNumber(255, 255, 255));
            //ImprovedVBE.DrawFilledEllipse(100, 100, 11, 11, ImprovedVBE.colourToNumber(255, 255, 255));
            //Demo_window.App();
            //ImprovedVBE.DrawGradient();

            if (magnify == true)
            {
                Bitmap magnified = new Bitmap(300, 300, ColorDepth.ColorDepth32);
                int startoff = 0;
                if(X < 50)
                {
                    startoff = (int)(((Y - 50) * ImprovedVBE.width + X) - X);
                }
                else
                {
                    startoff = (int)((Y - 50) * ImprovedVBE.width + X) - 50;
                }
                int index = 0;
                int lin = 101;
                for (int j = 1; j < lin;)
                {
                    try
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            magnified.RawData[index] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            magnified.RawData[index + 1] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            magnified.RawData[index + 2] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            index += 3;
                        }
                        for (int i = 0; i < 100; i++)
                        {
                            magnified.RawData[index] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            magnified.RawData[index + 1] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            magnified.RawData[index + 2] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            index += 3;
                        }
                        for (int i = 0; i < 100; i++)
                        {
                            magnified.RawData[index] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            magnified.RawData[index + 1] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            magnified.RawData[index + 2] = ImprovedVBE.cover.RawData[startoff + i + (j * ImprovedVBE.width)];
                            index += 3;
                        }
                        j++;
                    }
                    catch
                    {
                        j++;
                        lin++;
                    }
                }
                int val1 = (int)X - 150;
                if (Y < 150)
                {
                    if(val1 < 0)
                    {
                        ImprovedVBE.DrawImage(magnified, 0, 0);
                    }
                    else
                    {
                        ImprovedVBE.DrawImage(magnified, val1, 0);
                    }
                }
                else
                {
                    if(val1 < 0)
                    {
                        ImprovedVBE.DrawImage(magnified, 0, (int)Y - 150);
                    }
                    else
                    {
                        ImprovedVBE.DrawImage(magnified, val1, (int)Y - 150);
                    }
                }
            }

            if (sel_curs == "bas1")
            {
                ImprovedVBE.DrawImageAlpha2(cursor, (int)X, (int)Y);
            }
            else if (sel_curs == "bas2")
            {
                ImprovedVBE.DrawImageAlpha2(cursor2, (int)X, (int)Y);
            }
            else if (sel_curs == "bas3")
            {
                ImprovedVBE.DrawImageAlpha2(cursor3, (int)X, (int)Y);
            }
            else if (sel_curs == "bas4")
            {
                ImprovedVBE.DrawImageAlpha2(cursor4, (int)X, (int)Y);
            }

            if(kernel_cycle > 1000)
            {
                Program.Main();
            }

            btl.Boot_process(canvas);

            ImprovedVBE.display(canvas);
            canvas.Display();
            Heap.Collect();
        }
    }
}
