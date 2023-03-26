using Cosmos.System.Audio.IO;
using Cosmos.System.Audio;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.HAL.Drivers.PCI.Audio;
using Cosmos.HAL.Audio;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.System;
using Cosmos.Core.Memory;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using CrystalOS.Applications;
using CrystalOS.NewFolder.NewFolder;
using CrystalOS.SystemFiles;
using CrystalOS2.SystemFiles;
using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.HAL.BlockDevice.Registers;
using System.Linq;
using CrystalOS.Applications.Programmers_Dream;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using CrystalOS2.Applications.Task_Scheduler;
using CrystalOS2.Graphic_engines._3d_render;
using CrystalOS2.Applications.Calendar;
using Console = System.Console;
using CrystalOS.Applications.Text_Editor;
using resolution.Applications;
using CrystalOS.Applications.Terminal;
using Cosmos.System.FileSystem.ISO9660;

namespace CrystalOS2
{
    public class Kernel : Sys.Kernel
    {
        /*
        //[ManifestResourceStream(ResourceName = "CrystalOS2.Startup.wav")] public static byte[] music;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Startup.wav")] public static byte[] music2;
        public static MemoryAudioStream memAudioStream = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, music2);
        [ManifestResourceStream(ResourceName = "CrystalOS2.bad_apple.wav")] public static byte[] Bad_Apple;
        public static MemoryAudioStream bad_apple = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, Bad_Apple);
        */
        //public static MemoryAudioStream startupsound = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, music);
        //2public static AC97 driver = AC97.Initialize(4096);
        public static Canvas vbe; //new Canvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
        //Canvas vbe;

        public static bool startmusic = false;

        [ManifestResourceStream(ResourceName = "CrystalOS2.SystemFiles.Menu.bmp")] public static byte[] Autumn;
        public static Bitmap img = new Bitmap(Autumn);
        [ManifestResourceStream(ResourceName = "CrystalOS2.Icons.Cursor.bmp")] public static byte[] Cursor;
        public static Bitmap cursor = new Bitmap(Cursor);
        ImprovedVBE vbedr = new ImprovedVBE();
        public static string saved = "90_Style";

        public static Sys.FileSystem.CosmosVFS fs;

        protected override void BeforeRun()
        {

            #region
            try
            {
                fs = new Sys.FileSystem.CosmosVFS();
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            }
            catch
            {
                Console.WriteLine("Failed to load the filesystem!");
            }

            #endregion

            try
            {
                File.Create("0:\\demo.run");
                File.WriteAllText("0:\\demo.run", "/app mode = graphical\ngraphic_window(500, 500, 300, 150)");
                string shit = File.ReadAllText("0:\\demo.run");
                Programmers_Choice.Graphical_Exec(shit);
                
                //File.Delete("0:\\CoolProgram.txt");
            }
            catch
            {
                Console.WriteLine("Reading failed!");
            }

            Console.ReadKey();

            vbe = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            vbedr.init();

            //vbe = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            //var memAudioStream = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, music);
            //2var mixer = new AudioMixer();
            //var audioStream = MemoryAudioStream.FromWave(music);
            //var driver = AC97.Initialize(4096);
            //mixer.Streams.Add(memAudioStream);
            //mixer.Streams.Add(bad_apple);

            MouseManager.ScreenWidth = 1920;
            MouseManager.ScreenHeight = 1080;

            MouseManager.X = 1920 / 2;
            MouseManager.Y = 1080 / 2;

        }

        public static int FPS = 0;

        public static int LastS = -1;
        public static int Ticken = 0;

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
        protected override void Run()
        {
            Update();
            ImprovedVBE._DrawACSIIString(FPS.ToString(), 150, 0, 16777215);
            /*
            if (startmusic == true)
            {
                var audioManager = new AudioManager()
                {
                    Stream = bad_apple, //mixer,
                    Output = driver
                };
                audioManager.Enable();
            }
            else
            {
                var audioManager = new AudioManager()
                {
                    Stream = memAudioStream, //mixer,
                    Output = driver
                };
                audioManager.Enable();
            }
            */
            if(Bool_Manager.is_locked == false)
            {
                //CrystalOS.Applications.MusicPlayer.AudioPlayer.Music_Player();
                //Calendar.calendar();
                //CrystalOS.Applications.Calculator.Calculator.calculator();

                //ImprovedVBE.DrawImage(img, 0, 0);
                if(Bool_Manager.Text_Editor_Opened == false && Bool_Manager.Programmers_choice == false)
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
                    }
                }
                CrystalOS2.Applications.Run.Run.Run_Window();
                Programmers_Choice.Core();
                try
                {
                    Task_Manager.Task_manager();
                    //Clock.init(1710, 30, 200, 200);
                    //Terminal_Core.Terminal();
                    CrystalOS.Applications.About.About_code.About(Int_Manager.About_X, Int_Manager.About_Y);
                }
                catch
                {

                }
                //CrystalOS.Applications.Solitaire.Solitaire.Solitaire_core();
                CrystalOS.Applications.Menu.Menumgr.MenuManager();
            }
            Lock_Screen.lock_screen();
            ImprovedVBE.DrawImageAlpha(cursor, (int)MouseManager.X, (int)MouseManager.Y);
            
            //ImprovedVBE._DrawACSIIString("FPS: " + FPS.ToString(), 500, 500, 16777215);
            ImprovedVBE._DrawACSIIString(DateTime.UtcNow.Hour.ToString() + " : " + DateTime.UtcNow.Minute.ToString(), 1850, 10, 16777215);
            vbedr.display(vbe);
            Update();
            vbe.Display();
            Heap.Collect();
        }
    }
}