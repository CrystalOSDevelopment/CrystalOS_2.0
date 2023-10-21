using Cosmos.HAL.Audio;
using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.System.Audio;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL.BlockDevice.Registers;
using System.Diagnostics.Metrics;
using CrystalOS2.Graphic_engines;
using Cosmos.System;

namespace CrystalOS2.Applications.Video_Player
{
    class Player_base
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Video_Player.Player_Base.bmp")] public static byte[] bas;
        public static Bitmap basic = new Bitmap(bas);

        // Info
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Video_Player.Shrek.wav")] public static byte[] music;

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.Video_Player.video2.bvf")] public static byte[] video;

        [ManifestResourceStream(ResourceName = "CrystalOS2.test2.png")] public static byte[] image;
        //public static Bitmap frame;
        public static byte[] data = new byte[20054];

        public static bool first_startup = true;

        public static float timing = 0;
        public static int i = 0;

        public static int drifting = 0;
        public static int multiplyer = 1;
        public static int temp = 0;
        public static bool stop = false;

        public static bool enable = true;

        public static int x = 100;
        public static int y = 100;

        public static bool moove = false;
        public static bool pause = true;
        public static bool Clicked = false;

        public static uint pos = 0;

        public static void Player()
        {
            ImprovedVBE.DrawImageAlpha(basic, x, y);
            if(first_startup == true)
            {
                var mixer = new AudioMixer();
                var audioStream = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 1, true), 48000, music);
                var driver = AC97.Initialize(4096);
                mixer.Streams.Add(audioStream);

                var audioManager = new AudioManager()
                {
                    Stream = mixer,
                    Output = driver
                };

                if (pause == true)
                {
                    pos = (uint)(48000 * (time + 2));
                    audioManager.Disable();
                }
                else
                {
                    audioManager.Enable();
                    audioStream.Position = pos;
                }
                first_startup = false;
                //Array.Copy(video, 0, data, 0, 20053);
            }
            if(pause == false)
            {
                Update();
                if (time % 300 == 0 && time > 300)
                {
                    if (enable == true)
                    {
                        drifting += 5;
                        enable = false;
                    }
                }
                else if (time % 300 == 0 && time != 0)
                {
                    if(enable == true)
                    {
                        drifting += 3;
                        enable = false;
                    }
                }
                else
                {
                    enable = true;
                }
                if (counter < 11)
                {
                    if (i != (time * 20054 * 4) + counter * 20054)
                    {
                        if (time > 2)
                        {
                            i = ((time - (2 + drifting)) * 20054 * 10) + counter * 20054;
                        }
                    }
                    if (timing < 2)//17
                    {
                        timing += 0.7f;//0.7
                    }
                    else
                    {
                        if (i + 20053 <= video.Length)
                        {
                            Array.Copy(video, i, data, 0, 20053);
                            i += 20054;
                        }
                        else
                        {
                            stop = true;
                        }
                        timing = 0;
                        counter++;
                    }
                }
            }

            Bitmap frame = new Bitmap(data);
            ImprovedVBE.ScaleImage(frame, x + 13, y + 28);

            if((time - Get_Minutes(time) * 60) < 10)
            {
                ImprovedVBE._DrawACSIIString("Ellapsed time: " + Get_Minutes(time) + ":0" + (time - Get_Minutes(time) * 60), x + 11, y + 206, ImprovedVBE.colourToNumber(0, 255, 56));
            }
            else
            {
                ImprovedVBE._DrawACSIIString("Ellapsed time: " + Get_Minutes(time) + ":" + (time - Get_Minutes(time) * 60), x + 11, y + 206, ImprovedVBE.colourToNumber(0, 255, 56));
                //ImprovedVBE._DrawACSIIString("Position: " + pos, 16, 256, ImprovedVBE.colourToNumber(0, 255, 56));
            }

            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X > x + 345 && MouseManager.X < x + 386)
                {
                    if (MouseManager.Y > y + 96 && MouseManager.Y < y + 137)
                    {
                        Clicked = true;
                        
                    }
                }
            }
            if(MouseManager.MouseState == MouseState.None && Clicked == true)
            {
                if(pause == true)
                {
                    first_startup = true;
                    pause = false;
                }
                else
                {
                    first_startup = true;
                    pause = true;
                }
                Clicked = false;
            }

            if (moove == false)
            {
                if(MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > x && MouseManager.X < x + 370)
                    {
                        if (MouseManager.Y > y && MouseManager.Y < y + 20)
                        {
                            moove = true;
                        }
                    }
                }
            }
            if(moove == true)
            {
                x = (int)MouseManager.X - 10;
                y = (int)MouseManager.Y - 10;
                if(MouseManager.MouseState == MouseState.Right)
                {
                    moove = false;
                }
            }
            //PNG.FromPNG(image);
        }

        public static int FPS = 0;
        public static int LastS = -1;
        public static int Ticken = 0;
        public static int counter = 0;
        public static int time = 0;
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
                temp += counter;
                counter = 0;
                if(stop == false)
                {
                    time++;
                }
                timing = 0;
                LastS = DateTime.UtcNow.Second;
                Ticken = 0;
            }
            Ticken++;
        }

        public static int Get_Minutes(int time)
        {
            int minutes = 0;
            int temp = time;
            while(temp >= 60)
            {
                temp -= 60;
                minutes++;
            }
            return minutes;
        }
    }
}
