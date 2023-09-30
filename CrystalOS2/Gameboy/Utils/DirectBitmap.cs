﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Cosmos.System.Graphics;
using CrystalOS2;

namespace ProjectDMG {
    public class DirectBitmap {
        public Bitmap Bitmap { get; private set; }
        public static int Height = 768;//144
        public static int Width = 1024;//160

        public DirectBitmap() {
            Bitmap = new Bitmap((uint)Width, (uint)Height, ColorDepth.ColorDepth32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPixel(int x, int y, int colour) {
            x = x * 3 + PPU.x;
            y = y * 3 + PPU.y;
            int index = x + (y * Width);
            ImprovedVBE.cover.RawData[index] = colour;
            ImprovedVBE.cover.RawData[index + 1] = colour;
            ImprovedVBE.cover.RawData[index + 2] = colour;
            y++;
            index = x + (y * Width);
            ImprovedVBE.cover.RawData[index] = colour;
            ImprovedVBE.cover.RawData[index + 1] = colour;
            ImprovedVBE.cover.RawData[index + 2] = colour;
            y++;
            index = x + (y * Width);
            ImprovedVBE.cover.RawData[index] = colour;
            ImprovedVBE.cover.RawData[index + 1] = colour;
            ImprovedVBE.cover.RawData[index + 2] = colour;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetPixel(int x, int y) {
            int index = x + (y * Width);
            return Bitmap.RawData[index];
        }
    }
}