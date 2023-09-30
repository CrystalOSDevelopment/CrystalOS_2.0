using Cosmos.System.Graphics;
using CrystalOS2;
using System;
using System.Drawing;

public class Teapot
{
    private static float rotationAngleZ = 0;
    private static float rotationAngleY = 0;
    private static float rotationAngleX = 0;

    public static void Main()
    {
        // Create a bitmap to render the cube
        Bitmap bitmap = new Bitmap(200, 200, ColorDepth.ColorDepth32);

        // Define the 3D points of the cube
        Vector3[] cubePoints = new Vector3[]
        {
            new Vector3(1.000000f, -1.000000f, -1.000000f),
       new Vector3(1.000000f, 1.000000f, -1.000000f),
       new Vector3(1.000000f, -1.000000f, 1.000000f),
       new Vector3(1.000000f, 1.000000f, 1.000000f),
       new Vector3(-1.000000f, -1.000000f, -1.000000f),
       new Vector3(-1.000000f, 1.000000f, -1.000000f),
       new Vector3(-1.000000f, -1.000000f, 1.000000f),
       new Vector3(-1.000000f, 1.000000f, 1.000000f),
       new Vector3(-0.720000f, 0.120000f, -1.400000f),
       new Vector3(0.300000f, 0.000000f, 5.000000f),
       new Vector3(-0.600000f, -0.600000f, -1.400000f),
       new Vector3(-0.300000f, 0.000000f, 5.000000f),
       new Vector3(-1.200000f, 0.200000f, 1.000000f),
       new Vector3(-0.600000f, 0.600000f, -1.400000f),
       new Vector3(-1.200000f, -0.200000f, -1.000000f),
       new Vector3(-1.200000f, 0.200000f, -1.000000f),
       new Vector3(1.200000f, -0.200000f, 1.000000f),
       new Vector3(1.200000f, -0.200000f, -1.000000f),
       new Vector3(1.200000f, 0.200000f, -1.000000f),
       new Vector3(1.200000f, 0.200000f, 1.000000f),
       new Vector3(-1.200000f, -0.200000f, 1.000000f),
       new Vector3(0.600000f, 0.600000f, -1.400000f),
       new Vector3(0.600000f, -0.600000f, -1.400000f),
       new Vector3(-4.200000f, 0.060000f, 1.000000f),
       new Vector3(-4.200000f, -0.060000f, 1.000000f),
       new Vector3(-4.200000f, -0.060000f, -1.000000f),
       new Vector3(-4.200000f, 0.060000f, -1.000000f),
       new Vector3(4.200000f, -0.060000f, 1.000000f),
       new Vector3(4.200000f, -0.060000f, -1.000000f),
       new Vector3(4.200000f, 0.060000f, -1.000000f),
       new Vector3(4.200000f, 0.060000f, 1.000000f),
       new Vector3(4.200000f, -0.180000f, 1.000000f),
       new Vector3(4.200000f, -0.180000f, -1.000000f),
       new Vector3(4.200000f, 0.180000f, -1.000000f),
       new Vector3(4.200000f, 0.180000f, 1.000000f),
       new Vector3(4.500000f, -0.180000f, 1.000000f),
       new Vector3(4.500000f, -0.180000f, -1.000000f),
       new Vector3(4.500000f, 0.180000f, -1.000000f),
       new Vector3(4.500000f, 0.180000f, 1.000000f),
       new Vector3(-4.200000f, 0.180000f, 1.000000f),
       new Vector3(-4.200000f, -0.180000f, 1.000000f),
       new Vector3(-4.200000f, -0.180000f, -1.000000f),
       new Vector3(-4.200000f, 0.180000f, -1.000000f),
       new Vector3(-4.500000f, 0.180000f, 1.000000f),
       new Vector3(-4.500000f, -0.180000f, 1.000000f),
       new Vector3(-4.500000f, -0.180000f, -1.000000f),
       new Vector3(-4.500000f, 0.180000f, -1.000000f),
       new Vector3(4.350000f, -0.180000f, 3.000000f),
       new Vector3(4.350000f, 0.180000f, 3.000000f),
       new Vector3(-4.350000f, 0.180000f, 3.000000f),
       new Vector3(-4.350000f, -0.180000f, 3.000000f),
       new Vector3(0.000000f, -0.700000f, 3.000000f),
       new Vector3(-0.720000f, -0.120000f, -1.400000f),
       new Vector3(0.720000f, -0.120000f, -1.400000f),
       new Vector3(0.720000f, 0.120000f, -1.400000f)
        };

        rotationAngleZ += 0.01f; // Adjust the rotation speed as needed
        rotationAngleY += 0.01f; // Adjust the rotation speed as needed
        rotationAngleX += 0.01f; // Adjust the rotation speed as needed

        // Rotate the cube around the z-axis
        Vector3[] rotatedPoints = RotateZ(cubePoints, rotationAngleZ);

        // Rotate the cube around the y-axis
        rotatedPoints = RotateY(rotatedPoints, rotationAngleY);

        // Rotate the cube around the x-axis
        rotatedPoints = RotateX(rotatedPoints, rotationAngleX);

        // Render the rotated cube
        RenderCube(bitmap, rotatedPoints, Color.Red, 500, 100);

        // Rendering the wireframme
        RenderCube_Wireframe(bitmap, rotatedPoints, Color.Green, 500, 100);
    }
    static void RenderCube_Wireframe(Bitmap bitmap, Vector3[] points, Color color, int x, int y)
    {
        // Define the order of connecting points to form the cube
        int[][] cubeSides = new int[][]
        {
            new int[] {21, 52, 12},
       new int[] {6, 13, 8},
       new int[] {5, 23, 1},
       new int[] {7, 1, 3},
       new int[] {4, 6, 8},
       new int[] {4, 12, 10},
       new int[] {17, 20, 10},
       new int[] {20, 4, 10},
       new int[] {17, 52, 3},
       new int[] {7, 3, 52},
       new int[] {16, 14, 9},
       new int[] {7, 15, 5},
       new int[] {20, 30, 19},
       new int[] {18, 23, 54},
       new int[] {4, 19, 2},
       new int[] {1, 17, 3},
       new int[] {13, 25, 21},
       new int[] {13, 21, 12},
       new int[] {12, 52, 10},
       new int[] {8, 13, 12},
       new int[] {27, 42, 43},
       new int[] {15, 27, 16},
       new int[] {21, 26, 15},
       new int[] {16, 24, 13},
       new int[] {31, 34, 30},
       new int[] {18, 28, 17},
       new int[] {17, 31, 20},
       new int[] {19, 29, 18},
       new int[] {32, 49, 35},
       new int[] {29, 32, 28},
       new int[] {31, 32, 35},
       new int[] {29, 34, 33},
       new int[] {38, 36, 37},
       new int[] {34, 37, 33},
       new int[] {35, 38, 34},
       new int[] {33, 36, 32},
       new int[] {43, 44, 40},
       new int[] {25, 42, 26},
       new int[] {27, 40, 24},
       new int[] {25, 40, 41},
       new int[] {44, 46, 45},
       new int[] {40, 44, 50},
       new int[] {42, 47, 43},
       new int[] {41, 46, 42},
       new int[] {44, 47, 46},
       new int[] {32, 36, 48},
       new int[] {39, 35, 49},
       new int[] {39, 48, 36},
       new int[] {45, 51, 50},
       new int[] {40, 51, 41},
       new int[] {45, 41, 51},
       new int[] {45, 50, 44},
       new int[] {18, 29, 28},
       new int[] {17, 28, 31},
       new int[] {4, 2, 6},
       new int[] {18, 55, 19},
       new int[] {15, 11, 5},
       new int[] {19, 22, 2},
       new int[] {2, 14, 6},
       new int[] {16, 53, 15},
       new int[] {53, 9, 54},
       new int[] {19, 30, 29},
       new int[] {15, 26, 27},
       new int[] {16, 27, 24},
       new int[] {13, 24, 25},
       new int[] {21, 25, 26},
       new int[] {7, 21, 15},
       new int[] {7, 5, 1},
       new int[] {21, 7, 52},
       new int[] {1, 18, 17},
       new int[] {17, 10, 52},
       new int[] {4, 20, 19},
       new int[] {20, 31, 30},
       new int[] {4, 8, 12},
       new int[] {43, 47, 44},
       new int[] {6, 16, 13},
       new int[] {40, 50, 51},
       new int[] {41, 45, 46},
       new int[] {42, 46, 47},
       new int[] {2, 22, 14},
       new int[] {19, 55, 22},
       new int[] {18, 54, 55},
       new int[] {18, 1, 23},
       new int[] {5, 11, 23},
       new int[] {15, 53, 11},
       new int[] {16, 9, 53},
       new int[] {16, 6, 14},
       new int[] {9, 14, 22},
       new int[] {22, 55, 9},
       new int[] {55, 54, 9},
       new int[] {54, 23, 11},
       new int[] {11, 53, 54},
       new int[] {34, 38, 37},
       new int[] {38, 39, 36},
       new int[] {39, 49, 48},
       new int[] {35, 39, 38},
       new int[] {33, 37, 36},
       new int[] {25, 41, 42},
       new int[] {27, 43, 40},
       new int[] {31, 35, 34},
       new int[] {29, 33, 32},
       new int[] {32, 48, 49},
       new int[] {27, 26, 42},
       new int[] {31, 28, 32},
       new int[] {29, 30, 34},
       new int[] {25, 24, 40},
        };

        // Loop through each side of the cube
        for (int i = 0; i < cubeSides.Length; i++)
        {
            int[] sidePoints = cubeSides[i];

            // Get the current point and the next point in the side
            int currentPointIndex = sidePoints[0];
            int nextPointIndex = sidePoints[1];

            // Convert 3D point to 2D point for both points
            Point currentPoint = ConvertTo2D(points[currentPointIndex], (int)bitmap.Width, (int)bitmap.Height, x, y);
            Point nextPoint = ConvertTo2D(points[nextPointIndex], (int)bitmap.Width, (int)bitmap.Height, x, y);

            // Plot the 2D point for current point
            ImprovedVBE.DrawFilledRectangle(255, currentPoint.X, currentPoint.Y, 2, 2);

            // Connect current point to next point
            ImprovedVBE.line(currentPoint.X, currentPoint.Y, nextPoint.X, nextPoint.Y, ImprovedVBE.colourToNumber(0, 0, 255));
        }
    }

    static void RenderCube(Bitmap bitmap, Vector3[] points, Color color, int x, int y)
    {
        // Define the order of connecting points to form the cube
        int[][] cubeSides = new int[][]
{
            new int[] {21, 52, 12},
       new int[] {6, 13, 8},
       new int[] {5, 23, 1},
       new int[] {7, 1, 3},
       new int[] {4, 6, 8},
       new int[] {4, 12, 10},
       new int[] {17, 20, 10},
       new int[] {20, 4, 10},
       new int[] {17, 52, 3},
       new int[] {7, 3, 52},
       new int[] {16, 14, 9},
       new int[] {7, 15, 5},
       new int[] {20, 30, 19},
       new int[] {18, 23, 54},
       new int[] {4, 19, 2},
       new int[] {1, 17, 3},
       new int[] {13, 25, 21},
       new int[] {13, 21, 12},
       new int[] {12, 52, 10},
       new int[] {8, 13, 12},
       new int[] {27, 42, 43},
       new int[] {15, 27, 16},
       new int[] {21, 26, 15},
       new int[] {16, 24, 13},
       new int[] {31, 34, 30},
       new int[] {18, 28, 17},
       new int[] {17, 31, 20},
       new int[] {19, 29, 18},
       new int[] {32, 49, 35},
       new int[] {29, 32, 28},
       new int[] {31, 32, 35},
       new int[] {29, 34, 33},
       new int[] {38, 36, 37},
       new int[] {34, 37, 33},
       new int[] {35, 38, 34},
       new int[] {33, 36, 32},
       new int[] {43, 44, 40},
       new int[] {25, 42, 26},
       new int[] {27, 40, 24},
       new int[] {25, 40, 41},
       new int[] {44, 46, 45},
       new int[] {40, 44, 50},
       new int[] {42, 47, 43},
       new int[] {41, 46, 42},
       new int[] {44, 47, 46},
       new int[] {32, 36, 48},
       new int[] {39, 35, 49},
       new int[] {39, 48, 36},
       new int[] {45, 51, 50},
       new int[] {40, 51, 41},
       new int[] {45, 41, 51},
       new int[] {45, 50, 44},
       new int[] {18, 29, 28},
       new int[] {17, 28, 31},
       new int[] {4, 2, 6},
       new int[] {18, 55, 19},
       new int[] {15, 11, 5},
       new int[] {19, 22, 2},
       new int[] {2, 14, 6},
       new int[] {16, 53, 15},
       new int[] {53, 9, 54},
       new int[] {19, 30, 29},
       new int[] {15, 26, 27},
       new int[] {16, 27, 24},
       new int[] {13, 24, 25},
       new int[] {21, 25, 26},
       new int[] {7, 21, 15},
       new int[] {7, 5, 1},
       new int[] {21, 7, 52},
       new int[] {1, 18, 17},
       new int[] {17, 10, 52},
       new int[] {4, 20, 19},
       new int[] {20, 31, 30},
       new int[] {4, 8, 12},
       new int[] {43, 47, 44},
       new int[] {6, 16, 13},
       new int[] {40, 50, 51},
       new int[] {41, 45, 46},
       new int[] {42, 46, 47},
       new int[] {2, 22, 14},
       new int[] {19, 55, 22},
       new int[] {18, 54, 55},
       new int[] {18, 1, 23},
       new int[] {5, 11, 23},
       new int[] {15, 53, 11},
       new int[] {16, 9, 53},
       new int[] {16, 6, 14},
       new int[] {9, 14, 22},
       new int[] {22, 55, 9},
       new int[] {55, 54, 9},
       new int[] {54, 23, 11},
       new int[] {11, 53, 54},
       new int[] {34, 38, 37},
       new int[] {38, 39, 36},
       new int[] {39, 49, 48},
       new int[] {35, 39, 38},
       new int[] {33, 37, 36},
       new int[] {25, 41, 42},
       new int[] {27, 43, 40},
       new int[] {31, 35, 34},
       new int[] {29, 33, 32},
       new int[] {32, 48, 49},
       new int[] {27, 26, 42},
       new int[] {31, 28, 32},
       new int[] {29, 30, 34},
       new int[] {25, 24, 40},
};

        // Loop through each side of the cube
        for (int i = 0; i < cubeSides.Length; i++)
        {
            int[] sidePoints = cubeSides[i];

            // Get the 3 points in the side
            int point1Index = sidePoints[0];
            int point2Index = sidePoints[1];
            int point3Index = sidePoints[2];

            // Convert 3D points to 2D points for the triangle
            Point point1 = ConvertTo2D(points[point1Index], (int)bitmap.Width, (int)bitmap.Height, x, y);
            Point point2 = ConvertTo2D(points[point2Index], (int)bitmap.Width, (int)bitmap.Height, x, y);
            Point point3 = ConvertTo2D(points[point3Index], (int)bitmap.Width, (int)bitmap.Height, x, y);

            // Connect the 3 points together using a triangle
            Graphics.DrawFilledTriangle(point1, point2, point3, ImprovedVBE.colourToNumber(255, 255, 255));
        }
    }

    static Point ConvertTo2D(Vector3 point3D, int width, int height, int x1, int y1)
    {
        // Apply scaling and translation to the 3D point
        int x = (int)(point3D.X * width / 4 + width / 2);
        int y = (int)(point3D.Y * height / 4 + height / 2);

        return new Point(x + x1, y + y1);
    }

    static Vector3[] RotateZ(Vector3[] points, float angle)
    {
        Vector3[] rotatedPoints = new Vector3[points.Length];

        // Loop through each point and rotate it around the z-axis
        for (int i = 0; i < points.Length; i++)
        {
            float x = points[i].X * (float)Math.Cos(angle) - points[i].Y * (float)Math.Sin(angle);
            float y = points[i].X * (float)Math.Sin(angle) + points[i].Y * (float)Math.Cos(angle);
            rotatedPoints[i] = new Vector3(x, y, points[i].Z);
        }

        return rotatedPoints;
    }

    static Vector3[] RotateY(Vector3[] points, float angle)
    {
        Vector3[] rotatedPoints = new Vector3[points.Length];

        // Loop through each point and rotate it around the y-axis
        for (int i = 0; i < points.Length; i++)
        {
            float x = points[i].X * (float)Math.Cos(angle) + points[i].Z * (float)Math.Sin(angle);
            float z = -points[i].X * (float)Math.Sin(angle) + points[i].Z * (float)Math.Cos(angle);
            rotatedPoints[i] = new Vector3(x, points[i].Y, z);
        }

        return rotatedPoints;
    }

    static Vector3[] RotateX(Vector3[] points, float angle)
    {
        Vector3[] rotatedPoints = new Vector3[points.Length];

        // Loop through each point and rotate it around the x-axis
        for (int i = 0; i < points.Length; i++)
        {
            float y = points[i].Y * (float)Math.Cos(angle) - points[i].Z * (float)Math.Sin(angle);
            float z = points[i].Y * (float)Math.Sin(angle) + points[i].Z * (float)Math.Cos(angle);
            rotatedPoints[i] = new Vector3(points[i].X, y, z);
        }

        return rotatedPoints;
    }
}