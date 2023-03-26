using Cosmos.HAL.BlockDevice.Registers;
using Cosmos.System;
using Cosmos.System.Audio.IO;
using Cosmos.System.FileSystem.Listing;
using Cosmos.System.Graphics;
using CrystalOS.Applications;
using CrystalOS.Applications.Programmers_Dream;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using CrystalOS2.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalOS2.Applications.File_Explorer
{
    public class File_Explorer
    {
        public static string files = "";
        public static string folders = "";
        public static bool movable = false;
        public static bool readwrite = true;
        public static List<DirectoryEntry> getDirFiles(string path)
        {
            List<DirectoryEntry> l = new List<DirectoryEntry>();
            foreach (DirectoryEntry d in Kernel.fs.GetDirectoryListing(path.ToUpper()))
            {
                if (d.mEntryType == DirectoryEntryTypeEnum.File)
                {
                    l.Add(d);
                }
            }
            return l;
        }
        public static List<DirectoryEntry> getDirFolders(string path)
        {
            List<DirectoryEntry> l = new List<DirectoryEntry>();
            foreach (DirectoryEntry d in Kernel.fs.GetDirectoryListing(path.ToUpper()))
            {
                if (d.mEntryType == DirectoryEntryTypeEnum.Directory)
                {
                    l.Add(d);
                }
            }
            return l;
        }
        public static List<Tuple<int, int, string, string>> fandf_locations = new List<Tuple<int, int, string, string>>();
        public static string files_full = "";
        public static string folders_full = "";

        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.File_Explorer.Unknown.bmp")] public static byte[] Unknown;
        public static Bitmap unknown = new Bitmap(Unknown);
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.File_Explorer.Folder.bmp")] public static byte[] Folder;
        public static Bitmap folder_ico = new Bitmap(Folder);
        [ManifestResourceStream(ResourceName = "CrystalOS2.Applications.File_Explorer.Explorer.bmp")] public static byte[] File_Explorer_base;
        public static Bitmap file_explorer_base = new Bitmap(File_Explorer_base);

        public static string[] s;
        public static string[] f;
        public static string[] s_full;
        public static string[] f_full;
        public static string source = "0:\\";
        public static bool hell = true;

        public static List<Tuple<string[], string[], string[], string[]>> container = new List<Tuple<string[], string[], string[], string[]>>();

        public static void file_explorer(Canvas c, int x, int y)
        {
            source = Task_Manager.Tasks[Task_Manager.indicator].Item5;
            if (Bool_Manager.File_Explorer_Opened == true)
            {
                ImprovedVBE.DrawImageAlpha2(file_explorer_base, x, y);
                ImprovedVBE._DrawACSIIString(source, x + 278, y + 37, 0);

                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > x + 842 && MouseManager.X < x + 885)
                    {
                        if (MouseManager.Y > y + 10 && MouseManager.Y < y + 46)
                        {
                            //Bool_Manager.File_Explorer_Opened = false;
                            Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                            container.RemoveAt(Task_Manager.filemgr_counter);
                        }
                    }
                    if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == false)
                    {
                        if (MouseManager.X > x && MouseManager.X < x + 742)
                        {
                            if (MouseManager.Y > y && MouseManager.Y < y + 55)
                            {
                                int f = (int)MouseManager.X;
                                int g = (int)MouseManager.Y;
                                //string saves = Task_Manager.Tasks[Task_Manager.indicator].Item5;
                                Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                                Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string>("explorer", f, g, true, source));
                                string[] q = container[Task_Manager.filemgr_counter].Item1;
                                string[] w = container[Task_Manager.filemgr_counter].Item2;
                                string[] r = container[Task_Manager.filemgr_counter].Item3;
                                string[] t = container[Task_Manager.filemgr_counter].Item4;
                                container.RemoveAt(Task_Manager.filemgr_counter);
                                container.Insert(0, new Tuple<string[], string[], string[], string[]>(q, w, r, t));
                            }
                        }
                    }
                }
                if (readwrite == true)
                {
                    files = "";
                    files_full = "";
                    folders = "";
                    folders_full = "";
                    foreach (DirectoryEntry d in getDirFiles(source))
                    {
                        files += d.mName + "\n";
                        files_full += d.mFullPath + "\n";
                    }
                    foreach (DirectoryEntry d in getDirFolders(source))
                    {
                        folders += d.mName + "\n";
                        folders_full += d.mFullPath + "\n";
                    }
                    //files.Remove(files.Length - 1);
                    //folders.Remove(folders.Length - 1);
                    s = files.Split('\n');
                    s_full = files_full.Split('\n');
                    f_full = folders_full.Split('\n');
                    f = folders.Split('\n');

                    try
                    {
                        container.RemoveAt(Task_Manager.filemgr_counter);
                    }
                    catch
                    {

                    }

                    container.Insert(Task_Manager.filemgr_counter, new Tuple<string[], string[], string[], string[]>(s, s_full, f, f_full));
                }
                else { }

                int x1 = /*x + */220;
                int y1 = /*y +*/ 64;
                int counter = 0;

                if (container[Task_Manager.filemgr_counter].Item1.Count() > 0)
                {
                    foreach (string str in container[Task_Manager.filemgr_counter].Item1)
                    {
                        //107, 41
                        if (!str.Equals(""))
                        {
                            if (y1 + y + 80 < y + 428)//214
                            {
                                if (str != "")
                                {
                                    ImprovedVBE.DrawImageAlpha2(unknown, x1 + 20 + x, y1 + y);
                                    ImprovedVBE._DrawACSIIString(str, x1 + x, y1 + 30 + y, 16777215);
                                    if (hell == true)
                                    {
                                        fandf_locations.Add(new Tuple<int, int, string, string>(x1, y1, container[Task_Manager.filemgr_counter].Item2[counter], str));
                                    }
                                    counter++;

                                    y1 += 50;//80
                                }
                            }
                            else
                            {
                                x1 += 60;
                                y1 = /*y + */64;
                                ImprovedVBE.DrawImageAlpha2(unknown, x1 + 20 + x, y1 + y);
                                ImprovedVBE._DrawACSIIString(str, x1 + x, y1 + 30 + y, 16777215);
                                if (hell == true)
                                {
                                    fandf_locations.Add(new Tuple<int, int, string, string>(x1, y1, container[Task_Manager.filemgr_counter].Item2[counter], str));
                                }
                                counter++;
                            }
                        }
                    }
                }
                counter = 0;

                if (container[Task_Manager.filemgr_counter].Item3.Count() > 0)
                {
                    foreach (string str in container[Task_Manager.filemgr_counter].Item3)
                    {
                        //107, 41
                        if (!container[Task_Manager.filemgr_counter].Item4.Equals(""))
                        {
                            if (y1 + y + 80 < y + 428)
                            {
                                if (str != "")
                                {
                                    ImprovedVBE.DrawImageAlpha2(folder_ico, x1 + 20 + x, y1 + y);
                                    ImprovedVBE._DrawACSIIString(str, x1 + x, y1 + 30 + y, 16777215);
                                    if (hell == true)
                                    {
                                        fandf_locations.Add(new Tuple<int, int, string, string>(x1, y1, container[Task_Manager.filemgr_counter].Item4[counter], str));
                                    }
                                    counter++;
                                    y1 += 50;
                                }
                            }
                            else
                            {
                                x1 += 90;
                                y1 = /*y + */64;
                                ImprovedVBE.DrawImageAlpha2(folder_ico, x1 + 20 + x, y1 + y);
                                ImprovedVBE._DrawACSIIString(str, x1  + x, y1 + 30 + y, 16777215);
                                if (hell == true)
                                {
                                    fandf_locations.Add(new Tuple<int, int, string, string>(x1, y1, container[Task_Manager.filemgr_counter].Item4[counter], str));
                                }
                                counter++;
                            }
                        }
                    }
                }

                

                if (Task_Manager.Tasks[Task_Manager.indicator].Item4 == true)
                {
                    int f = (int)MouseManager.X;
                    int g = (int)MouseManager.Y;
                    Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                    Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string>("explorer", f, g, true, source));
                    string[] q = container[Task_Manager.filemgr_counter].Item1;
                    string[] w = container[Task_Manager.filemgr_counter].Item2;
                    string[] r = container[Task_Manager.filemgr_counter].Item3;
                    string[] t = container[Task_Manager.filemgr_counter].Item4;
                    container.RemoveAt(Task_Manager.filemgr_counter);
                    container.Insert(0, new Tuple<string[], string[], string[], string[]>(q, w, r, t));
                    if (MouseManager.MouseState == MouseState.Right)
                    {
                        Task_Manager.Tasks.RemoveAt(0);
                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string>("explorer", f, g, false, source));
                        string[] q2 = container[Task_Manager.filemgr_counter].Item1;
                        string[] w2 = container[Task_Manager.filemgr_counter].Item2;
                        string[] r2 = container[Task_Manager.filemgr_counter].Item3;
                        string[] t2 = container[Task_Manager.filemgr_counter].Item4;
                        container.RemoveAt(0);
                        container.Insert(0, new Tuple<string[], string[], string[], string[]>(q2, w2, r2, t2));

                        Task_Manager.indicator = 0;
                        Task_Manager.counter = 0;
                        Task_Manager.foo = 0;
                        Task_Manager.editor_counter = 0;
                        Task_Manager.filemgr_counter = 0;
                        hell = true;
                        readwrite = true;
                        //Task_Manager.Tasks.Reverse();
                        //movable = false;
                    }
                }

                //ImprovedVBE.DrawFilledRectangle(500, fandf_locations[1].Item1 + x, fandf_locations[1].Item2 + y, fandf_locations[1].Item4.Length * 12, fandf_locations[1].Item2 + 67);

                if (MouseManager.MouseState == MouseState.Left)
                {
                    foreach (Tuple<int, int, string, string> f in fandf_locations)
                    {
                        if (MouseManager.X > f.Item1 + x && MouseManager.X < f.Item1 + f.Item4.Length * 12 + x)
                        {
                            if (MouseManager.Y > f.Item2 + y && MouseManager.Y < f.Item2 + 67 + y)
                            {
                                try
                                {

                                    try
                                    {

                                        //Text_Editor.Text_Editor.content = "";
                                        //Text_Editor.Text_Editor.content = File.ReadAllText(f.Item3);
                                        //if(Bool_Manager.Text_Editor_Opened != true)
                                        //{
                                        //}

                                        if (f.Item3.ToLower().EndsWith(".txt"))
                                        {
                                            Bool_Manager.Text_Editor_Opened = true;
                                            string shit = File.ReadAllText(f.Item3);
                                            Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string>("text_editor", 100, 100, false, shit));
                                        }
                                        else if (f.Item3.ToLower().EndsWith(".bmp"))
                                        {
                                            Bitmap test = new Bitmap(f.Item3);
                                            ImprovedVBE.DrawImageAlpha(test, 500, 50);
                                        }
                                        else
                                        {
                                            ImprovedVBE._DrawACSIIString("Loading: " + f.Item3, 300, 0, 16777215);
                                            string shit = File.ReadAllText(f.Item3);
                                            Programmers_Choice.Graphical_Exec(shit);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        //StringManager.StringWriter(c, e.Message, 0, 30);
                                        source = f.Item3;
                                        //readwrite = true;
                                        files = "";
                                        files_full = "";
                                        folders = "";
                                        folders_full = "";
                                        foreach (DirectoryEntry d in getDirFiles(source))
                                        {
                                            files += d.mName + "\n";
                                            files_full += d.mFullPath + "\n";
                                        }
                                        foreach (DirectoryEntry d in getDirFolders(source))
                                        {
                                            folders += d.mName + "\n";
                                            folders_full += d.mFullPath + "\n";
                                        }
                                        //files.Remove(files.Length - 1);
                                        //folders.Remove(folders.Length - 1);
                                        s = files.Split('\n');
                                        s_full = files_full.Split('\n');
                                        f_full = folders_full.Split('\n');
                                        string[] g = folders.Split('\n');

                                        Task_Manager.Tasks.RemoveAt(Task_Manager.indicator);
                                        Task_Manager.Tasks.Insert(0, new Tuple<string, int, int, bool, string>("explorer", x, y, false, f.Item3));
                                        string[] q = s;
                                        string[] w = s_full;
                                        string[] r = g;
                                        string[] t = f_full;
                                        container.RemoveAt(Task_Manager.filemgr_counter);
                                        container.Insert(0, new Tuple<string[], string[], string[], string[]>(files.Split('\n'), files_full.Split('\n'), folders_full.Split('\n'), folders.Split('\n')));
                                        fandf_locations.Clear();
                                        hell = true;
                                        readwrite = true;
                                        container.Clear();
                                        //Task_Manager.indicator = 0;
                                    }
                                }
                                catch (Exception e2)
                                {
                                    ImprovedVBE._DrawACSIIString("Failed to load: " + f.Item3, x + 235, y + 24, 16777215);
                                }
                            }
                        }
                    }
                    if (MouseManager.X > x + 422 && MouseManager.X < x + 443)
                    {
                        if (MouseManager.Y > y + 22 && MouseManager.Y < y + 36)
                        {
                            source = source.Substring(0, source.LastIndexOf('\\'));
                            if (source == "0:")
                            {
                                source += "\\";
                            }
                            readwrite = true;
                            hell = true;
                            fandf_locations.Clear();
                            files = "";
                            files_full = "";
                            folders = "";
                            folders_full = "";

                        }
                    }
                    if (MouseManager.X > x + 104 && MouseManager.X < x + 159)
                    {
                        if (MouseManager.Y > y + 20 && MouseManager.Y < y + 38)
                        {
                            Bool_Manager.Create_App = true;
                        }
                    }
                    if (MouseManager.X > x + 160 && MouseManager.X < x + 231)
                    {
                        if (MouseManager.Y > y + 20 && MouseManager.Y < y + 38)
                        {
                            Bool_Manager.Create_App = true;
                        }
                    }
                    /*
                    if (MouseManager.X > x + 105 && MouseManager.X < x + 205)
                    {
                        if (MouseManager.Y > y + 40 && MouseManager.Y < y + 75)
                        {
                            Text_Editor.Text_Editor.content = File.ReadAllText("0:\\Root.txt");
                        }
                    }
                    */

                }
            }
            //StringManager.StringWriter(c, files, 300, 10);
        }


        public static void DrawPixelfortext(int x, int y, int color)
        {
            //16777215 white
            if (y * 1920 == 0)
            {
                y = 1;
                file_explorer_base.rawData[x * y] = color;
            }
            else
            {
                file_explorer_base.rawData[(y * 1920) - (1920 - x)] = color;
            }
        }

        static string ASC16Base64 = "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AAB4zMzM2MzGxsbMAAAAAAAA/sbGwMDAwMDAwAAAAAAAAAAA/mxsbGxsbGwAAAAAAAAA/sZgMBgwYMb+AAAAAAAAAAAAftjY2NjYcAAAAAAAAAAAZmZmZmZ8YGDAAAAAAAAAAHbcGBgYGBgYAAAAAAAAAH4YPGZmZjwYfgAAAAAAAAA4bMbG/sbGbDgAAAAAAAA4bMbGxmxsbGzuAAAAAAAAHjAYDD5mZmZmPAAAAAAAAAAAAH7b29t+AAAAAAAAAAAAAwZ+29vzfmDAAAAAAAAAHDBgYHxgYGAwHAAAAAAAAAB8xsbGxsbGxsYAAAAAAAAAAP4AAP4AAP4AAAAAAAAAAAAYGH4YGAAA/wAAAAAAAAAwGAwGDBgwAH4AAAAAAAAADBgwYDAYDAB+AAAAAAAADhsbGBgYGBgYGBgYGBgYGBgYGBgYGNjY2HAAAAAAAAAAABgYAH4AGBgAAAAAAAAAAAAAdtwAdtwAAAAAAAAAOGxsOAAAAAAAAAAAAAAAAAAAAAAAABgYAAAAAAAAAAAAAAAAAAAAGAAAAAAAAAAADwwMDAwM7GxsPBwAAAAAANhsbGxsbAAAAAAAAAAAAABw2DBgyPgAAAAAAAAAAAAAAAAAfHx8fHx8fAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";
        static MemoryStream ASC16FontMS = new MemoryStream(Convert.FromBase64String(ASC16Base64));
        public static void _DrawACSIIString(string s, int x, int y, int color)
        {
            string[] lines = s.Split('\n');
            for (int l = 0; l < lines.Length; l++)
            {
                for (int c = 0; c < lines[l].Length; c++)
                {
                    int offset = (Encoding.ASCII.GetBytes(lines[l][c].ToString())[0] & 0xFF) * 16;
                    ASC16FontMS.Seek(offset, SeekOrigin.Begin);
                    byte[] fontbuf = new byte[16];
                    ASC16FontMS.Read(fontbuf, 0, fontbuf.Length);

                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((fontbuf[i] & (0x80 >> j)) != 0)
                            {
                                DrawPixelfortext((int)((x + j) + (c * 8)), (int)(y + i + (l * 16)), color);
                            }
                        }
                    }
                }
            }
        }
    }
}
