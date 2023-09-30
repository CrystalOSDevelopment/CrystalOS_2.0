
using Cosmos.System.Graphics;
using CrystalOS2;
using System;
using System.Drawing;
using Cosmos.System.Coroutines;

public class Cube
{
    private static float rotationAngleZ = 0;
    private static float rotationAngleY = 0;
    private static float rotationAngleX = 0;

    public static void Main()
    {
        // Create a bitmap to render the cube
        Bitmap bitmap = new Bitmap(400, 400, ColorDepth.ColorDepth32);

        // Define the 3D points of the cube
        Vector3[] cubePoints = new Vector3[]
        {
            new Vector3(-1, -1, -1), // Front bottom left
            new Vector3(-1, 1, -1), // Front top left
            new Vector3(1, 1, -1), // Front top right
            new Vector3(1, -1, -1), // Front bottom right
            new Vector3(-1, -1, 1), // Back bottom left
            new Vector3(-1, 1, 1), // Back top left
            new Vector3(1, 1, 1), // Back top right
            new Vector3(1, -1, 1) // Back bottom right
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
        RenderCube(bitmap, rotatedPoints, Color.Red);

        // Rendering the wireframme
        RenderCube_Wireframe(bitmap, rotatedPoints, Color.Green);
    }
    static void RenderCube_Wireframe(Bitmap bitmap, Vector3[] points, Color color)
    {
        // Define the order of connecting points to form the cube
        int[][] cubeSides = new int[][]
        {
        new int[] { 0, 1 },   // Front face
        new int[] { 1, 2 },   // Front face continued
        new int[] { 2, 3 },   // Front face continued
        new int[] { 3, 0 },   // Front face continued
        new int[] { 4, 5 },   // Back face
        new int[] { 5, 6 },   // Back face continued
        new int[] { 6, 7 },   // Back face continued
        new int[] { 7, 4 },   // Back face continued
        new int[] { 0, 4 },   // Top face
        new int[] { 1, 5 },   // Top face continued
        new int[] { 2, 6 },   // Right face
        new int[] { 3, 7 },   // Right face continued
        };

        // Loop through each side of the cube
        for (int i = 0; i < cubeSides.Length; i++)
        {
            int[] sidePoints = cubeSides[i];

            // Get the current point and the next point in the side
            int currentPointIndex = sidePoints[0];
            int nextPointIndex = sidePoints[1];

            // Convert 3D point to 2D point for both points
            Point currentPoint = ConvertTo2D(points[currentPointIndex], (int)bitmap.Width, (int)bitmap.Height);
            Point nextPoint = ConvertTo2D(points[nextPointIndex], (int)bitmap.Width, (int)bitmap.Height);

            // Connect current point to next point
            ImprovedVBE.line(currentPoint.X + 200, currentPoint.Y + 200, nextPoint.X + 200, nextPoint.Y + 200, ImprovedVBE.colourToNumber(0, 0, 255));
        }
    }

    static void RenderCube(Bitmap bitmap, Vector3[] points, Color color)
    {
        // Define the order of connecting points to form the cube
        int[][] cubeSides = new int[][]
        {
            new int[] { 0, 1, 2 },   // Front face
            new int[] { 2, 3, 0 },   // Front face continued
            new int[] { 4, 5, 6 },   // Back face
            new int[] { 6, 7, 4 },   // Back face continued
            new int[] { 0, 4, 1 },   // Top face
            new int[] { 1, 5, 2 },   // Top face continued
            new int[] { 2, 6, 3 },   // Right face
            new int[] { 3, 7, 0 },   // Right face continued
            new int[] { 0, 3, 4 },   // Left face
            new int[] { 4, 7, 0 },   // Left face continued
            new int[] { 1, 2, 5 },   // Bottom face
            new int[] { 5, 6, 1 },   // Bottom face continued
            new int[] { 7, 6, 3 },   // Top front face
            new int[] { 6, 5, 3 },   // Top front face continued
            new int[] { 4, 5, 1 },   // Missing face
            new int[] { 1, 2, 6 }    // Misplaced face
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
            Point point1 = ConvertTo2D(points[point1Index], (int)bitmap.Width, (int)bitmap.Height);
            Point point2 = ConvertTo2D(points[point2Index], (int)bitmap.Width, (int)bitmap.Height);
            Point point3 = ConvertTo2D(points[point3Index], (int)bitmap.Width, (int)bitmap.Height);

            // Connect the 3 points together using a triangle
            Graphics.DrawFilledTriangle(new Point(point1.X + 200, point1.Y + 200), new Point(point2.X + 200, point2.Y + 200), new Point(point3.X + 200, point3.Y + 200), ImprovedVBE.colourToNumber(255, 255, 255));
        }
    }

    static Point ConvertTo2D(Vector3 point3D, int width, int height)
    {
        // Apply scaling and translation to the 3D point
        int x = (int)(point3D.X * width / 4 + width / 2);
        int y = (int)(point3D.Y * height / 4 + height / 2);

        return new Point(x, y);
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

class Vector3
{
    public float X { get; }
    public float Y { get; }
    public float Z { get; }

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}


/*
using Cosmos.System.Graphics;
using CrystalOS2;
using System;
using System.Drawing;

public class Cube
{
    private static float rotationAngleZ = 0;
    private static float rotationAngleY = 0;
    private static float rotationAngleX = 0;

    public static void Main()
    {
        // Create a bitmap to render the cube
        Bitmap bitmap = new Bitmap(400, 400, ColorDepth.ColorDepth32);

        // Define the 3D points of the cube
        Vector3[] cubePoints = new Vector3[]
        {
            new Vector3(-1, -1, -1), // Front bottom left
            new Vector3(-1, 1, -1), // Front top left
            new Vector3(1, 1, -1), // Front top right
            new Vector3(1, -1, -1), // Front bottom right
            new Vector3(-1, -1, 1), // Back bottom left
            new Vector3(-1, 1, 1), // Back top left
            new Vector3(1, 1, 1), // Back top right
            new Vector3(1, -1, 1) // Back bottom right
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

        // Define the colors associated with each side
        Color[] sideColors = new Color[]
        {
            Color.Red, // Front face
            Color.Green, // Back face
            Color.Blue, // Top face
            Color.Yellow, // Right face
            Color.Magenta, // Left face
            Color.Cyan, // Bottom face
            Color.Orange, // Top front face
            Color.Cyan, // Missing face (changed to cyan)
            Color.Purple // Misplaced face
        };

        // Render the rotated cube
        RenderCube(bitmap, rotatedPoints, sideColors);
    }

    static void RenderCube(Bitmap bitmap, Vector3[] points, Color[] sideColors)
    {
        // Define the order of connecting points to form the cube
        int[][] cubeSides = new int[][]
        {
            new int[] { 0, 1, 2 },   // Front face
            new int[] { 2, 3, 0 },   // Front face continued
            new int[] { 4, 5, 6 },   // Back face
            new int[] { 6, 7, 4 },   // Back face continued
            new int[] { 0, 4, 7 },   // Top face (changed point order)
            new int[] { 7, 1, 0 },   // Top face continued (changed point order)
            new int[] { 2, 6, 3 },   // Right face
            new int[] { 3, 7, 2 },   // Right face continued
            new int[] { 0, 3, 4 },   // Left face
            new int[] { 4, 7, 3 },   // Left face continued
            new int[] { 1, 5, 2 },   // Bottom face (changed order)
            new int[] { 2, 5, 6 },   // Bottom face continued (changed order)
            new int[] { 7, 6, 3 },   // Top front face
            new int[] { 6, 5, 2 },   // Top front face continued
            new int[] { 4, 5, 1 },   // Missing face
            new int[] { 1, 2, 6 }    // Misplaced face
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
            Point point1 = ConvertTo2D(points[point1Index], (int)bitmap.Width, (int)bitmap.Height);
            Point point2 = ConvertTo2D(points[point2Index], (int)bitmap.Width, (int)bitmap.Height);
            Point point3 = ConvertTo2D(points[point3Index], (int)bitmap.Width, (int)bitmap.Height);

            // Get the color for the current side
            Color sideColor = sideColors[i];

            // Connect the 3 points together using a filled triangle with the side color
            Graphics.DrawFilledTriangle(point1, point2, point3, sideColor.ToArgb());
        }
    }

    static Point ConvertTo2D(Vector3 point3D, int width, int height)
    {
        // Apply scaling and translation to the 3D point
        int x = (int)(point3D.X * width / 4 + width / 2);
        int y = (int)(point3D.Y * height / 4 + height / 2);

        return new Point(x, y);
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

class Vector3
{
    public float X { get; }
    public float Y { get; }
    public float Z { get; }

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
*/