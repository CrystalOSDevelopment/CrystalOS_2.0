using Cosmos.System.Graphics;
using CrystalOS2;
using System;
using System.Collections.Generic;
using System.Drawing;

public static class PolygonFiller
{
    public static void FillPolygon(List<Point> vertices, Color fillColor)
    {
        // Find the minimum and maximum y-values of the polygon
        int minY = int.MaxValue;
        int maxY = int.MinValue;
        foreach (var vertex in vertices)
        {
            if (vertex.Y < minY)
                minY = vertex.Y;
            if (vertex.Y > maxY)
                maxY = vertex.Y;
        }

        // Create a bitmap to store the filled polygon
        int width = GetPolygonWidth(vertices);
        Bitmap bitmap = new Bitmap((uint)width, (uint)(maxY - minY + 1), ColorDepth.ColorDepth32);

        // Initialize the scanlines with the maximum x-value
        int[] scanlines = new int[maxY - minY + 1];
        for (int i = 0; i < scanlines.Length; i++)
            scanlines[i] = int.MaxValue;

        // Fill the scanlines with the x-values from the polygon edges
        for (int i = 0; i < vertices.Count; i++)
        {
            Point currentVertex = vertices[i];
            Point nextVertex = vertices[(i + 1) % vertices.Count];

            if (currentVertex.Y != nextVertex.Y)
            {
                int yStart = Math.Min(currentVertex.Y, nextVertex.Y);
                int yEnd = Math.Max(currentVertex.Y, nextVertex.Y);
                int xStart = Math.Min(currentVertex.X, nextVertex.X);
                int xEnd = Math.Max(currentVertex.X, nextVertex.X);

                float slope = (float)(xEnd - xStart) / (yEnd - yStart);
                float x = xStart;

                for (int y = yStart; y <= yEnd; y++)
                {
                    int scanlineIndex = y - minY;

                    if (x < scanlines[scanlineIndex])
                        scanlines[scanlineIndex] = (int)x;

                    x += slope;
                }
            }
        }

        // Fill the polygon using the scanlines
        for (int y = minY; y < maxY; y++)
        {
            int xStart = scanlines[y];
            int xEnd = width;

            // Skip if the scanline is empty
            if (xStart == int.MaxValue)
                continue;

            // Find the end of the scanline
            int scanlineEndIndex = y;
            while (scanlineEndIndex < scanlines.Length && scanlines[scanlineEndIndex] != int.MaxValue)
                scanlineEndIndex++;

            xEnd = scanlineEndIndex < scanlines.Length ? scanlines[scanlineEndIndex] : width;

            // Fill the scanline with the specified color
            for (int x = xStart; x < xEnd; x++)
                ImprovedVBE.DrawPixelfortext(x, y, fillColor.ToArgb());
        }
    }

    private static int GetPolygonWidth(List<Point> vertices)
    {
        int minWidth = int.MaxValue;
        int maxWidth = int.MinValue;
        foreach (var vertex in vertices)
        {
            if (vertex.X < minWidth)
                minWidth = vertex.X;
            if (vertex.X > maxWidth)
                maxWidth = vertex.X;
        }
        return maxWidth - minWidth + 1;
    }
}