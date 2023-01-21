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
using SoundTest.SystemFiles;
using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.HAL.BlockDevice.Registers;
using System.Linq;
using CrystalOS.Applications.Programmers_Dream;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using SoundTest.Applications.Task_Scheduler;
using SoundTest.Graphic_engines._3d_render;
using SoundTest.Applications.Calendar;

namespace SoundTest
{
    public class Kernel : Sys.Kernel
    {
        /*
        //[ManifestResourceStream(ResourceName = "SoundTest.Startup.wav")] public static byte[] music;
        [ManifestResourceStream(ResourceName = "SoundTest.Startup.wav")] public static byte[] music2;
        public static MemoryAudioStream memAudioStream = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, music2);
        [ManifestResourceStream(ResourceName = "SoundTest.bad_apple.wav")] public static byte[] Bad_Apple;
        public static MemoryAudioStream bad_apple = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, Bad_Apple);
        */
        //public static MemoryAudioStream startupsound = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, music);
        public static AC97 driver = AC97.Initialize(4096);
        public static VBECanvas vbe = new VBECanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
        //Canvas vbe;

        public static bool startmusic = false;

        [ManifestResourceStream(ResourceName = "SoundTest.SystemFiles.Menu.bmp")] public static byte[] Autumn;
        public static Bitmap img = new Bitmap(Autumn);
        [ManifestResourceStream(ResourceName = "SoundTest.Icons.Cursor.bmp")] public static byte[] Cursor;
        public static Bitmap cursor = new Bitmap(Cursor);
        ImprovedVBE vbedr = new ImprovedVBE();
        public static string saved = "90_Style";

        protected override void BeforeRun()
        {
            vbedr.init();
            //vbe = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            //var memAudioStream = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, music);
            var mixer = new AudioMixer();
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
                Task_Manager.Task_manager();
                Calendar.calendar();
                CrystalOS.Applications.About.About_code.About(Int_Manager.About_X, Int_Manager.About_X);
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
                SoundTest.Applications.Run.Run.Run_Window();
                Programmers_Choice.Core();
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