using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using CrystalOS2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = CrystalOS2.Kernel;

namespace CrystalOS.Applications.MusicPlayer
{
    internal class AudioPlayer
    {
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.MusicPlayer.AudioPlayer.bmp")] public static byte[] AudioPlayer_base;
        public static Bitmap audioplayer_base = new Bitmap(AudioPlayer_base);
        public static bool movable = false;
        public static void Music_Player()
        {
            if(Bool_Manager.Music_Player_Opened == true)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (Kernel.X > Int_Manager.Music_Player_X + 406 && Kernel.X < Int_Manager.Music_Player_X + 555)
                    {
                        if (Kernel.Y > Int_Manager.Music_Player_Y && Kernel.Y < Int_Manager.Music_Player_Y + 17)
                        {
                            //Kernel.startmusic = false;
                            Bool_Manager.Music_Player_Opened = false;
                        }
                    }
                    if (Kernel.X > Int_Manager.Music_Player_X + 284 && Kernel.X < Int_Manager.Music_Player_X + 346)
                    {
                        if (Kernel.Y > Int_Manager.Music_Player_Y + 234 && Kernel.Y < Int_Manager.Music_Player_Y + 286)
                        {
                            //Kernel.startmusic = true;
                        }
                    }
                    if (movable == false)
                    {
                        if (Kernel.X > Int_Manager.Music_Player_X && Kernel.X < Int_Manager.Music_Player_X + 502)
                        {
                            if (Kernel.Y > Int_Manager.Music_Player_Y && Kernel.Y < Int_Manager.Music_Player_Y + 18)
                            {
                                movable = true;
                            }
                        }
                    }
                }

                ImprovedVBE.DrawImage(audioplayer_base, Int_Manager.Music_Player_X, Int_Manager.Music_Player_Y);

                if (movable == true)
                {
                    Int_Manager.Music_Player_X = (int)Kernel.X;
                    Int_Manager.Music_Player_Y = (int)Kernel.Y;
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        movable = false;
                    }
                    /*
                    if (Kernel.X > Int_Manager.Music_Player_X && Kernel.X < Int_Manager.Music_Player_X + 352)
                    {
                        if (Kernel.Y > Int_Manager.Music_Player_Y && Kernel.Y < Int_Manager.Music_Player_Y + 18)
                        {
                            movable = false;
                        }
                    }
                    */
                }
            }
        }
    }
}
