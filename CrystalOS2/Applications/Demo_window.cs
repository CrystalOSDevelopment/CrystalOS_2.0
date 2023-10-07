using Cosmos.System;
using Cosmos.System.Graphics;
using CrystalOS2.Applications.Task_Scheduler;
using CrystalOS2.Applications.Word_Processor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Youtube_tut.Applications.Calculator;

namespace CrystalOS2.Applications
{
    class Demo_window : App
    {
        public bool movable = false;

        public int desk_ID { get; set; }

        public string name { get; set; }

        public bool minimised { get; set; }
        public int z { get; set; }
        public int x = 0;
        public int y = 0;

        public int x_1 = 0;
        public int y_1 = 0;
        public int width = 402;
        public int height = 402;
        public int[] canvas;
        public int[] back_canvas;
        public bool once = true;
        public Bitmap window;

        public string source = "";
        public int CurrentColor = ImprovedVBE.colourToNumber(255, 255, 255);

        public static int Last(string s, char searc_char)
        {
            int i = 0;
            int temp = 0;
            if (s.Contains(searc_char))
            {
                foreach (char c in s)
                {
                    if (c == searc_char)
                    {
                        i = temp;
                    }
                    temp++;
                }
            }
            return i;
        }
        public static int Count(string s)
        {
            int i = 0;
            foreach (char c in s)
            {
                if (c == '\n')
                {
                    i++;
                }
            }
            return i;
        }

        public static int FirstLast(string s)
        {
            int i = 0;
            foreach(char c in s)
            {
                if(c != ' ')
                {
                    return i;
                }
                i++;
            }
            return i;
        }

        public List<UI_Elements> Elements = new List<UI_Elements>();

        public void App()
        {
            #region mechanical
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (Kernel.X > x + 406 && Kernel.X < x + 448)
                {
                    if (Kernel.Y > y && Kernel.Y < y + 17)
                    {
                        Task_Manager.calculators.RemoveAt(Task_Manager.indicator);
                    }
                }
                if (movable == false)
                {
                    if (Kernel.X > x && Kernel.X < x + 352)
                    {
                        if (Kernel.Y > y && Kernel.Y < y + 18)
                        {
                            movable = true;
                        }
                    }
                }
            }
            if (movable == true)
            {
                x = (int)Kernel.X;
                y = (int)Kernel.Y;
                if (MouseManager.MouseState == MouseState.Right)
                {
                    movable = false;
                }
            }
            #endregion core

            if (once == true)
            {
                //This is the part where we set the values of the windows (propeties)
                foreach (string s in source.Split('\n'))
                {
                    if (s.ToLower().Contains("namespace"))
                    {
                        string title = s.Remove(0, 10);
                        title = title.Replace("{", "");
                        name = title;
                    }
                    else if (s.ToLower().Contains("graphics.width"))
                    {
                        width = int.Parse(s.ToLower().Replace("graphics.width", "").Replace(" ", "").Replace("=", ""));
                    }
                    else if (s.ToLower().Contains("graphics.height"))
                    {
                        height = int.Parse(s.ToLower().Replace("graphics.height", "").Replace(" ", "").Replace("=", ""));
                    }
                }
                canvas = new int[width * height];
                back_canvas = new int[width * height];
                window = new Bitmap((uint)width, (uint)height, ColorDepth.ColorDepth32);

                #region corners
                DrawFilledEllipse(10, 10, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
                DrawFilledEllipse(width - 11, 10, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
                DrawFilledEllipse(10, height - 10, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
                DrawFilledEllipse(width - 11, height - 10, 10, 10, ImprovedVBE.colourToNumber(255, 255, 255));
                #endregion corners

                #region base
                DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 255, 255), 0, 10, width, height - 20);
                DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 255, 255), 5, 0, width - 10, 15);
                DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 255, 255), 5, height - 15, width - 10, 15);

                //DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 255, 255), x + 10, y, width + 20, height);

                DrawGradientLeftToRight();

                canvas = Word_processor.draw_text(name, 2, 2, ImprovedVBE.colourToNumber(255, 255, 255), canvas, width, height);
                #endregion base

                #region core 
                string command = "";
                foreach(string s in source.Split('\n'))
                {
                    if (s.EndsWith(";") || s.ToLower().StartsWith("namespace") || s.ToLower().StartsWith("/app mode = graphical") || s.Replace(" ", "") == "{" || s.Replace(" ", "") == "}")
                    {
                        command += s.Replace(";", "");

                        if (command.ToLower().Contains("graphics.drawtext(\""))
                        {
                            int FirstOcc = command.IndexOf('\"');
                            int LastOcc = Last(command, '\"');

                            string content = command.Remove(0, FirstOcc + 1);
                            content = content.Remove(content.IndexOf('\"'));
                            int x_pos = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[0]);
                            int y_pos = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[1]);

                            if (command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',').Length == 5)
                            {
                                int red_gun = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[2]);
                                int green_gun = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[3]);
                                int blue_gun = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[4]);

                                UI_Elements elements = new UI_Elements();
                                elements.X = x_pos;
                                elements.Y = y_pos + 20;
                                elements.t = Types.Label;
                                elements.R = red_gun;
                                elements.G = green_gun;
                                elements.B = blue_gun;
                                elements.content = content;

                                Elements.Add(elements);

                                //canvas = Word_processor.draw_text(content, x_pos, y_pos + 20, ImprovedVBE.colourToNumber(red_gun, green_gun, blue_gun), canvas, width, height);
                            }
                            else
                            {
                                UI_Elements elements = new UI_Elements();
                                elements.X = x_pos;
                                elements.Y = y_pos + 20;
                                elements.t = Types.Label;
                                elements.R = 0;
                                elements.B = 0;
                                elements.G = 0;
                                elements.content = content;

                                Elements.Add(elements);
                                //canvas = Word_processor.draw_text(content, x_pos, y_pos + 20, ImprovedVBE.colourToNumber(0, 0, 0), canvas, width, height);
                            }
                        }
                        else if (command.ToLower().Contains("ui_elements.button("))
                        {
                            int FirstOcc = command.IndexOf('\"');
                            int LastOcc = Last(command, '\"');

                            string content = command.Remove(0, FirstOcc + 1);
                            content = content.Remove(content.IndexOf('\"'));


                            string ID = command.Remove(0, command.IndexOf('\"') + 1);
                            ID = ID.Remove(0, ID.IndexOf('\"') + 1);
                            ID = ID.Replace(" ", "");
                            ID = ID.Remove(0, 2);
                            ID = ID.Remove(ID.IndexOf('\"'));

                            int x_pos = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[0]);
                            int y_pos = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[1]);
                            int w = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[2]);
                            int h = int.Parse(command.Remove(0, Last(command, '\"') + 1).Replace(" ", "").Replace(")", "").Remove(0, 1).Split(',')[3]);

                            //canvas = Word_processor.draw_text(content, 50, 100 + 20, ImprovedVBE.colourToNumber(0, 0, 0), canvas, width, height);

                            UI_Elements elements = new UI_Elements();
                            elements.X = x_pos;
                            elements.Y = y_pos + 20;
                            elements.Width = w;
                            elements.Height = h;
                            elements.t = Types.Button;
                            elements.R = 255;
                            elements.G = 255;
                            elements.B = 255;
                            elements.content = content;

                            Elements.Add(elements);

                            //Button(x_pos, y_pos, w, h, ImprovedVBE.colourToNumber(255, 255, 255), content);
                        }
                        else if (command.ToLower().Contains("graphics.appcolor("))
                        {
                            //Gotta fix this one asap
                            string colors = command.Replace(" ", "");
                            colors = colors.Remove(0, 18);
                            colors = colors.Remove(colors.Length - 1);

                            int r = int.Parse(colors.Split(',')[0]);
                            int g = int.Parse(colors.Split(',')[1]);
                            int b = int.Parse(colors.Split(',')[2]);

                            backgroundCol(ImprovedVBE.colourToNumber(r, g, b), CurrentColor);
                            CurrentColor = ImprovedVBE.colourToNumber(r, g, b);

                        }
                        command = "";
                    }
                    else
                    {
                        command += s;
                    }
                }

                //Button(50, 100, 100, 25, ImprovedVBE.colourToNumber(255, 255, 255), "Click me!");

                Task_Manager.calculators.RemoveAll(p => p.name == name);
                Task_Manager.calculators.Add(this);
                #endregion core
                window.RawData = canvas;
                back_canvas = canvas;
                once = false;
            }

            foreach (UI_Elements u in Elements)
            {
                if (u.t == Types.Label)
                {
                    canvas = Word_processor.draw_text(u.content, u.X, u.Y, ImprovedVBE.colourToNumber(u.R, u.G, u.B), canvas, width, height);
                }
                else if (u.t == Types.Button)
                {
                    if(MouseManager.MouseState != MouseState.None)
                    {
                        if(Kernel.X > x + u.X && Kernel.X < x + u.X + u.Width)
                        {
                            if(Kernel.Y > y + u.Y && Kernel.Y < y + u.Y + u.Height)
                            {
                                Button(u.X, u.Y, u.Width, u.Height, ImprovedVBE.colourToNumber(255 - u.R, 255 - u.G, 255 - u.B), u.content);
                            }
                        }
                    }
                    else
                    {
                        Button(u.X, u.Y, u.Width, u.Height, ImprovedVBE.colourToNumber(u.R, u.G, u.B), u.content);
                    }
                }
            }
            window.RawData = canvas;

            //ImprovedVBE.DrawImageArray(width, height, canvas, 300, 300);
            ImprovedVBE.DrawImageAlpha(window, x, y);
            canvas = back_canvas;
        }

        public void DrawFilledEllipse(int xCenter, int yCenter, int yR, int xR, int color)
        {
            /*
            int r = (color & 0xff0000) >> 16;
            int g = (color & 0x00ff00) >> 8;
            int b = (color & 0x0000ff);

            float blendFactor = 0.5f;
            float inverseBlendFactor = 1 - blendFactor;
            */
            for (int y = -yR; y <= yR; y++)
            {
                for (int x = -xR; x <= xR; x++)
                {
                    if ((x * x * yR * yR) + (y * y * xR * xR) <= yR * yR * xR * xR)
                    {
                        /*
                        int r3 = (cover.RawData[(yCenter + y) * width + xCenter + x] & 0xff0000) >> 16;
                        int g3 = (cover.RawData[(yCenter + y) * width + xCenter + x] & 0x00ff00) >> 8;
                        int b3 = (cover.RawData[(yCenter + y) * width + xCenter + x] & 0x0000ff);
                        //Color c = Color.FromArgb(cover.RawData[j * width + i]);

                        int r2 = (int)(inverseBlendFactor * r3 + blendFactor * r);
                        int g2 = (int)(inverseBlendFactor * g3 + blendFactor * g);
                        int b2 = (int)(inverseBlendFactor * b3 + blendFactor * b);
                        */
                        if (xCenter + x > 0 && xCenter + x < width - 1 && yCenter + y > 0 && yCenter + y < height)
                        {
                            canvas[(yCenter + y) * width + xCenter + x] = color;
                        }

                        //DrawPixelfortext(xCenter + x, yCenter + y, GetGradientColor(x, 0, width, height));

                        //DrawPixelfortext(xCenter + x, yCenter + y, color);
                    }
                }
            }
        }

        public void DrawFilledRectangle(int color, int X, int Y, int Width, int Height)
        {
            /*
            int r = (color & 0xff0000) >> 16;
            int g = (color & 0x00ff00) >> 8;
            int b = (color & 0x0000ff);

            float blendFactor = 0.5f;
            float inverseBlendFactor = 1 - blendFactor;

            for (int j = Y; j < Y + Height; j++)
            {
                for (int i = X; i < X + Width; i++)
                {
                    int r3 = (cover.RawData[j * width + i] & 0xff0000) >> 16;
                    int g3 = (cover.RawData[j * width + i] & 0x00ff00) >> 8;
                    int b3 = (cover.RawData[j * width + i] & 0x0000ff);
                    //Color c = Color.FromArgb(cover.RawData[j * width + i]);

                    int r2 = (int)(inverseBlendFactor * r3 + blendFactor * r);
                    int g2 = (int)(inverseBlendFactor * g3 + blendFactor * g);
                    int b2 = (int)(inverseBlendFactor * b3 + blendFactor * b);

                    DrawPixelfortext(i, j, colourToNumber(r2, g2, b2));
                }
            }*/

            if (X < width && Y < height)
            {
                int[] line = new int[Width];
                if (X < 0)
                {
                    line = new int[Width + X];
                }
                else if (X + Width > width)
                {
                    line = new int[Width - (X + Width - width)];
                }
                Array.Fill(line, color);

                for (int i = Y; i < Y + Height; i++)
                {
                    Array.Copy(line, 0, canvas, (i * width) + X, line.Length);
                }
            }

        }
        public int GetGradientColor(int x, int y, int width, int height)
        {
            int r = (int)((double)x / width * 255);
            int g = (int)((double)y / height * 255);
            int b = 255;

            return ImprovedVBE.colourToNumber(r, g, b);
        }
        public void DrawGradientLeftToRight()
        {
            int gradientColorStart = GetGradientColor(0, 0, width, height); int gradientColorEnd = GetGradientColor(width - 1, 0, width, height);

            int rStart = Color.FromArgb(gradientColorStart).R; int gStart = Color.FromArgb(gradientColorStart).G; int bStart = Color.FromArgb(gradientColorStart).B;

            int rEnd = Color.FromArgb(gradientColorEnd).R; int gEnd = Color.FromArgb(gradientColorEnd).G; int bEnd = Color.FromArgb(gradientColorEnd).B;

            for (int i = 0; i < canvas.Length; i++)
            {
                if(x_1 == width - 1)
                {
                    x_1 = 0;
                }
                else
                {
                    x_1++;
                }
                int r = (int)((double)x_1 / width * (rEnd - rStart)) + rStart; int g = (int)((double)x_1 / width * (gEnd - gStart)) + gStart; int b = (int)((double)x_1 / width * (bEnd - bStart)) + bStart;
                if (canvas[i] == ImprovedVBE.colourToNumber(255, 255, 255))
                {
                    canvas[i] = ImprovedVBE.colourToNumber(r, g, b);
                }
                if(i / width > 20)
                {
                    break;
                }
            }
        }

        public void backgroundCol(int newCol, int oldCol)
        {
            for(int i = 20 * width + 1; i < canvas.Length; i++)
            {
                if(canvas[i] == oldCol)
                {
                    canvas[i] = newCol;
                }
            }
        }

        public void Button(int X_Point, int Y_Point, int Width_of_Btn, int Height_of_Btn, int color, string con)
        {
            DrawFilledRectangle(color, X_Point, Y_Point, Width_of_Btn, Height_of_Btn);
            DrawFilledEllipse(X_Point, Y_Point + Height_of_Btn / 2, Height_of_Btn / 2, Height_of_Btn / 2, color);
            DrawFilledEllipse(X_Point + Width_of_Btn, Y_Point + Height_of_Btn / 2, Height_of_Btn / 2, Height_of_Btn / 2, color);
            /*
            #region corners
            DrawFilledEllipse(X_Point + 10, Y_Point + 10, 10, 10, color);
            DrawFilledEllipse(X_Point + Width_of_Btn - 11, Y_Point + 10, 10, 10, color);
            DrawFilledEllipse(X_Point + 10, Y_Point + Height_of_Btn - 10, 10, 10, color);
            DrawFilledEllipse(X_Point + Width_of_Btn - 11, Y_Point + Height_of_Btn - 10, 10, 10, color);
            #endregion corners

            #region base
            DrawFilledRectangle(color, X_Point, Y_Point + 10, Width_of_Btn, Height_of_Btn - 20);
            DrawFilledRectangle(color, X_Point + 5, Y_Point + 1, Width_of_Btn - 10, 15);
            DrawFilledRectangle(color, X_Point + 5, Y_Point + Height_of_Btn - 15, Width_of_Btn - 10, 15);
            */

            canvas = Word_processor.draw_text(con.Remove(5), X_Point + ((Width_of_Btn / 2) - (con.Remove(5).Length * 14 / 2)), Y_Point + ((Height_of_Btn / 2) - 7), ImprovedVBE.colourToNumber(255, 255, 255) - color, canvas, width, 0);
            //DrawFilledRectangle(ImprovedVBE.colourToNumber(255, 255, 255), x + 10, y, width + 20, height);
            //#endregion base
        }
    }

    public class UI_Elements
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ID { get; set; }
        public string content { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public Types t { get; set; }

        public void Render()
        {

        }
    }

    public enum Types
    {
        Label,
        Button,
    }
}
