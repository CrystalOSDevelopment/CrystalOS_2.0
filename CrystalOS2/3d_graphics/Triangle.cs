using Cosmos.System.Graphics;
using CrystalOS2;
using System;
using System.Drawing;

class Graphics
{
    public static void DrawFilledTriangle(Point p1, Point p2, Point p3, int color)
    {
        // Get the bounding rectangle of the triangle
        int minX = Math.Min(p1.X, Math.Min(p2.X, p3.X));
        int maxX = Math.Max(p1.X, Math.Max(p2.X, p3.X));
        int minY = Math.Min(p1.Y, Math.Min(p2.Y, p3.Y));
        int maxY = Math.Max(p1.Y, Math.Max(p2.Y, p3.Y));

        int start_x = 0;
        int end_x = 0;

        int[] line = new int[1024];
        Array.Fill(line, color);

        // Iterate through each pixel within the bounding rectangle
        for (int y = minY; y < maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                if (IsPointInTriangle(x, y, p1, p2, p3))
                {
                    start_x = x;
                    break;
                }
            }
            for (int x = maxX; x > minX; x--)
            {
                if (IsPointInTriangle(x, y, p1, p2, p3))
                {
                    end_x = x;
                    break;
                }
            }
            if(end_x > start_x)
            {
                Array.Copy(line, 0, ImprovedVBE.cover.RawData, (y * 1024) + start_x, end_x - start_x);
            }
        }
    }

    static bool IsPointInTriangle(int x, int y, Point p1, Point p2, Point p3)
    {
        /*
        // Calculate the barycentric coordinates of the point
        float alpha = ((float)((p2.Y - p3.Y) * (x - p3.X) + (p3.X - p2.X) * (y - p3.Y)) /
            ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y)));
        float beta = ((float)((p3.Y - p1.Y) * (x - p3.X) + (p1.X - p3.X) * (y - p3.Y)) /
            ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y)));
        float gamma = 1.0f - alpha - beta;
        */

        /*
        int denom = (p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y);

        // Calculate the barycentric coordinates of the point
        float alpha = ((float)((p2.Y - p3.Y) * (x - p3.X) + (p3.X - p2.X) * (y - p3.Y))) / denom;
        float beta = ((float)((p3.Y - p1.Y) * (x - p3.X) + (p1.X - p3.X) * (y - p3.Y))) / denom;
        float gamma = 1.0f - alpha - beta;
        */

        
        int p2YMinusp3Y = p2.Y - p3.Y;
        int p3XMinusp2X = p3.X - p2.X;
        int denom = (p2YMinusp3Y) * (p1.X - p3.X) + (p3XMinusp2X) * (p1.Y - p3.Y);

        // Calculate the barycentric coordinates of the point
        float alpha = ((float)((p2YMinusp3Y) * (x - p3.X) + (p3XMinusp2X) * (y - p3.Y))) / denom;
        float beta = ((float)((p3.Y - p1.Y) * (x - p3.X) + (p1.X - p3.X) * (y - p3.Y))) / denom;
        float gamma = 1.0f - alpha - beta;

        // Check if the point is inside the triangle
        return alpha >= 0 && beta >= 0 && gamma >= 0;
        
    }
}