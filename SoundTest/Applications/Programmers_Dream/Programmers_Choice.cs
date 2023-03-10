using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using CrystalOS.SystemFiles;
using IL2CPU.API.Attribs;
using SoundTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace CrystalOS.Applications.Programmers_Dream
{
    public class Programmers_Choice
    {
        public static string content = "";
        public static string modified_content = "";
        public static string content2 = "";
        public static int numbers_of_chars = 0; //36 max chars
        //public static int[] prev_num = new int[36];
        public static List<int> prev_num = new List<int>();
        public static int total_chars = 0;
        public static bool movable = false;
        public static bool get_last_length = true;
        public static int i = 0;
        public static string[] instruction_list;
        public static List<Tuple<string, string>> var_value_string = new List<Tuple<string, string>>();
        public static List<Tuple<string, int>> var_value_int = new List<Tuple<string, int>>();
        public static List<string> Things_to_Display = new List<string>();
        public static bool get_script_and_run = false;
        public static string[] text;
        public static List<string> modified_text = new List<string>();
        public static bool allowedtopass = true;
        public static string hell = "";

        [ManifestResourceStream(ResourceName = "SoundTest.Applications.Programmers_Dream.programmers_Dream.bmp")] public static byte[] Programmers_Dream;
        public static Bitmap programmers_dream = new Bitmap(Programmers_Dream);
        public static void Core()
        {
            if (Bool_Manager.Programmers_choice == true)
            {
                ImprovedVBE.DrawImageAlpha(programmers_dream, 0, 30);
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X > 1875 && MouseManager.X < 1919)
                    {
                        if (MouseManager.Y > 30 && MouseManager.Y < 47)
                        {
                            Bool_Manager.Programmers_choice = false;
                        }
                    }
                    /*
                    if (movable == false)
                    {
                        if (MouseManager.X > Int_Manager.Text_Editor_X && MouseManager.X < Int_Manager.Text_Editor_X + 352)
                        {
                            if (MouseManager.Y > Int_Manager.Text_Editor_Y && MouseManager.Y < Int_Manager.Text_Editor_Y + 18)
                            {
                                movable = true;
                            }
                        }
                    }
                    */
                }
            if(MouseManager.MouseState == MouseState.Left)
            {
                if(MouseManager.X > 297 && MouseManager.X < 384)//184, 248
                {
                    if(MouseManager.Y > 30 + 42 && MouseManager.Y < 30 + 61)
                    {
                        try
                        {
                            get_script_and_run = true;
                            if (get_script_and_run == true)
                            {
                                Things_to_Display.Clear();
                                CSharp(content);
                                get_script_and_run = false;
                            }
                        }
                        catch (Exception e)
                        {
                            ImprovedVBE._DrawACSIIString(e.Message, 4, 884, 16777215);
                        }
                    }
                }
                if(MouseManager.X > 10 && MouseManager.X < 115)
                {
                    if(MouseManager.Y > 52 && MouseManager.Y < 78)
                    {
                        //Add & remove method
                    }
                }
                if(MouseManager.X > 126 && MouseManager.X < 166)
                {
                    if(MouseManager.Y > 52 && MouseManager.Y < 78)
                    {
                        if (File.Exists("0:\\CoolProgram.txt"))
                        {
                            File.Delete("0:\\CoolProgram.txt");
                        }
                        File.Create("0:\\CoolProgram.txt");
                        File.WriteAllText("0:\\CoolProgram.txt", content);
                    }
                }
            }
            if (allowedtopass == true)
            {

                KeyEvent key;
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (content.Length != 0)
                        {
                            content = content.Remove(content.Length - 1);
                            return;
                        }
                    }
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        content += "\n";
                        return;
                    }
                    else
                    {
                        content += key.KeyChar;
                        return;
                    }
                }
            }
            if (movable == true)
            {
                Int_Manager.Text_Editor_X = (int)MouseManager.X;
                Int_Manager.Text_Editor_Y = (int)MouseManager.Y;
                if (MouseManager.MouseState == MouseState.Right)
                {
                    movable = false;
                }
            }

            int i = 0;
            if (content2 == content)
            {

            }
            else
            {
                modified_content = "";
                foreach (char character in content)
                {
                    if (i == 115)
                    {
                        modified_content += "\n" + character;
                        i = 0;
                    }
                    if (character == '\n')
                    {
                        modified_content += character;
                        i = 0;
                    }
                    else
                    {
                        modified_content += character;
                        i++;
                    }
                }
                content2 = content;
            }
            //Text displayer 4, 102
            ImprovedVBE._DrawACSIIString(modified_content, 4, 115, 16777215);
            try
            {
                int x = 4;
                int y = 836;//884

                foreach (string s in Things_to_Display)
                {
                    ImprovedVBE._DrawACSIIString(s, x, y, 16777215);
                    y += 12;
                }
            }
            catch (Exception e)
            {
                 ImprovedVBE._DrawACSIIString(e.Message, 4, 884, 16777215);
            }
            var_value_string.Clear();
            var_value_int.Clear();
            modified_text.Clear();
            ImprovedVBE._DrawACSIIString(hell, 500, 884, 16777215);
            }
        }

        public static void CSharp(string script)
        {
            try
            {
                instruction_list = script.Split("\n");

                for (int i = 0; i < instruction_list.Count(); i++)
                {
                    //string next_instruction = instruction_list[i + 1];
                    string current_instruction = instruction_list[i];
                    if ((instruction_list[i].StartsWith("Read(") || instruction_list[i].StartsWith("read(")) && instruction_list[i].EndsWith(")"))
                    {
                        allowedtopass = false;
                        string prev_string = ";";
                        string input = "";
                        while (!input.Contains('\n'))
                        {
                            KeyEvent key;
                            if (KeyboardManager.TryReadKey(out key))
                            {
                                if (key.Key == ConsoleKeyEx.Backspace)
                                {
                                    if (input.Length != 0)
                                    {
                                        input = content.Remove(input.Length - 1);
                                        //return;
                                    }
                                }
                                if (key.Key == ConsoleKeyEx.Enter)
                                {
                                    input += "\n";
                                    //return;
                                }
                                else
                                {
                                    input += key.KeyChar;
                                    //return;
                                }
                            }

                            if (prev_string != input)
                            {
                                foreach (string s in Things_to_Display.GetRange(Things_to_Display.Count - 1, 1))
                                {
                                    if (s == prev_string)
                                    {
                                        Things_to_Display.RemoveAt(Things_to_Display.Count - 1);
                                    }
                                }
                                prev_string = input;
                                Things_to_Display.Add(input);
                            }
                            else
                            {

                            }
                        }
                        allowedtopass = true;
                    }
                    if ((instruction_list[i].StartsWith("ReadKey(") || instruction_list[i].StartsWith("readkey(")) && instruction_list[i].EndsWith(")"))
                    {
                        allowedtopass = false;
                        string prev_string = ";";
                        string input = "";
                        while (input == "")
                        {
                            KeyEvent key;
                            if (KeyboardManager.TryReadKey(out key))
                            {
                                //return;
                                input += key.KeyChar;
                                /*
                                if (key.Key == ConsoleKeyEx.Backspace)
                                {
                                    if (input.Length != 0)
                                    {
                                        input = content.Remove(input.Length - 1);
                                        //return;
                                    }
                                }
                                if (key.Key == ConsoleKeyEx.Enter)
                                {
                                    input += "\n";
                                    //return;
                                }
                                else
                                {
                                    input += key.KeyChar;
                                    //return;
                                }
                                */
                            }
                            /*
                            if (prev_string != input)
                            {
                                foreach (string s in Things_to_Display.GetRange(Things_to_Display.Count - 1, 1))
                                {
                                    if (s == prev_string)
                                    {
                                        Things_to_Display.RemoveAt(Things_to_Display.Count - 1);
                                    }
                                }
                                prev_string = input;
                                Things_to_Display.Add(input);
                            }
                            else
                            {

                            }
                            */
                        }
                        allowedtopass = true;
                    }
                    if (instruction_list[i].Contains("="))
                    {
                        string replaced = instruction_list[i];
                        //replaced = replaced.Replace(" = ", " ");
                        string[] substring = replaced.Split(" = ");
                        int x = 4;
                        int y = 884;
                        int x1 = 64;
                        int y2 = 884;

                        for (int a = 0; a < substring.Length; a += 2)
                        {
                            //StringManager.StringWriter(c, substring[a], x, y);
                            y += 12;
                            try
                            {
                                string cleaned = substring[a + 1].Replace("\"", "");
                                string value = cleaned;//substring[a + 1];
                                int result = 0;
                                result = int.Parse(value);
                                var_value_int.Add(new Tuple<string, int>(substring[a], result));
                            }
                            catch
                            {
                                string cleaned = substring[a + 1].Replace("\"", "");
                                var_value_string.Add(new Tuple<string, string>(substring[a], cleaned/*substring[a + 1]*/));
                            }
                            //var_value_string.Add(new Tuple<string, string>(substring[a], substring[a + 1]));
                        }
                        /*
                        foreach(Tuple<string, string> s in var_value_string)
                        {
                            StringManager.StringWriter(c, s.Item1, x, y);
                            y2 += 12;
                            StringManager.StringWriter(c, s.Item2, x1, y2);
                            y2 += 12;
                        }
                        /*
                        for (int j = 0; j < substring.Count() - 1; j++)
                        {
                            try
                            {
                                string value = substring[j + 1];
                                int result = 0;
                                result = int.Parse(value);
                                var_value_int.Add(new Tuple<string, int>(substring[j], result));
                            }
                            catch
                            {
                                var_value_string.Add(new Tuple<string, string>(substring[j], substring[j + 1]));
                            }
                        }
                        */
                    }
                    if ((instruction_list[i].StartsWith("Print(") || instruction_list[i].StartsWith("print(")) && instruction_list[i].EndsWith(")"))
                    {
                        string instruction = instruction_list[i].Remove(0, 6);
                        string s = instruction.Remove(instruction.Length - 1);
                        //StringManager.StringWriter(c, s, 4, 884);
                        //s = s.Remove(s.Length - 1);

                        if (s.Contains(" + "))
                        {
                            text = s.Split(" + ");
                            string cont = "";
                            for (int num = 0; num < text.Length; num++)
                            {
                                if (text[num].StartsWith("\"") && text[num].EndsWith("\""))
                                {
                                    cont += text[num].Replace("\"", "");
                                }
                                else
                                {
                                    foreach (Tuple<string, string> strings in var_value_string)
                                    {
                                        if (strings.Item1 == text[num])
                                        {
                                            cont += strings.Item2;
                                            //StringManager.StringWriter(c, strings.Item2, 4, 884);
                                        }
                                    }
                                    foreach (Tuple<string, int> ints in var_value_int)
                                    {
                                        if (ints.Item1 == text[num])
                                        {
                                            cont += ints.Item2;
                                        }
                                    }
                                }
                            }

                            Things_to_Display.Add(cont);
                            cont = "";
                        }
                        else
                        {
                            foreach (Tuple<string, string> strings in var_value_string)
                            {
                                if (strings.Item1 == s)
                                {
                                    Things_to_Display.Add(strings.Item2);
                                    //StringManager.StringWriter(c, strings.Item2, 4, 884);
                                }
                            }
                            foreach (Tuple<string, int> ints in var_value_int)
                            {
                                if (ints.Item1 == s)
                                {
                                    Things_to_Display.Add(ints.Item2.ToString());
                                }
                            }
                        }
                        /*
                        foreach(string foo in Things_to_Display)
                        {
                            int x = 4;
                            int y = 884;
                            StringManager.StringWriter(c, foo, x, y);
                            y += 12;
                        }
                        */

                    }
                    if ((instruction_list[i].StartsWith("Print(\"") || instruction_list[i].StartsWith("print(\"")) /*&& instruction_list[i].EndsWith("\")")*/)
                    {
                        string instruction = instruction_list[i];
                        string s = instruction.Remove(0, 6);//7
                        s = s.Remove(s.Length - 1);//2

                        text = s.Split(" + ");
                        string cont = "";
                        for (int num = 0; num < text.Length; num++)
                        {
                            if (text[num].StartsWith("\"") && text[num].EndsWith("\""))
                            {
                                cont += text[num].Replace("\"", "");
                            }
                            else
                            {
                                foreach (Tuple<string, string> strings in var_value_string)
                                {
                                    if (strings.Item1 == text[num])
                                    {
                                        cont += strings.Item2;
                                        //StringManager.StringWriter(c, strings.Item2, 4, 884);
                                    }
                                }
                                foreach (Tuple<string, int> ints in var_value_int)
                                {
                                    if (ints.Item1 == text[num])
                                    {
                                        cont += ints.Item2;
                                    }
                                }
                            }
                        }

                        Things_to_Display.Add(cont);
                        cont = "";
                    }
                    if ((instruction_list[i].StartsWith("FileSystem.CreateFile(\"") || instruction_list[i].StartsWith("filesystem.createfile(\"")) && instruction_list[i].EndsWith("\")"))
                    {
                        string s = instruction_list[i].Remove(0, 23);
                        s = s.Remove(s.Length - 2);
                        s = s.Replace("C:/", "0:\\");
                        s = s.Replace("/", "\\");
                        if (File.Exists(s))
                        {
                            Things_to_Display.Add("Failed: The file you want to create(" + s + ") already exist!");
                        }
                        else
                        {
                            if (s.StartsWith("C:/"))
                            {
                                //s = s.Replace("C:/", "0:\\");
                                //s = s.Replace("/", "\\");
                                File.Create(s);
                            }
                            if (s.StartsWith("0:\\"))
                            {
                                if (!s.Contains("/"))
                                {
                                    File.Create(s);
                                }
                                else
                                {
                                    Things_to_Display.Add("Failed: Invalid file format! -> " + s);
                                }
                            }
                        }
                    }
                    if ((instruction_list[i].StartsWith("FileSystem.RemoveFile(\"") || instruction_list[i].StartsWith("filesystem.removefile(\"")) && instruction_list[i].EndsWith("\")"))
                    {
                        string s = instruction_list[i].Remove(0, 23);
                        s = s.Remove(s.Length - 2);
                        s = s.Replace("C:/", "0:\\");
                        s = s.Replace("/", "\\");
                        if (!File.Exists(s))
                        {
                            Things_to_Display.Add("Failed: Unable to delete " + s + " because it no longer exist!");
                        }
                        else
                        {
                            if (s.StartsWith("C:/"))
                            {
                                //s = s.Replace("C:/", "0:\\");
                                //s = s.Replace("/", "\\");
                                File.Delete(s);
                            }
                            else if (s.StartsWith("0:\\"))
                            {
                                if (!s.Contains("/"))
                                {
                                    File.Delete(s);
                                }
                                else
                                {
                                    Things_to_Display.Add("Failed: Invalid file format! -> " + s);
                                }
                            }
                        }
                    }
                    if ((instruction_list[i].StartsWith("FileSystem.CreateFolder(\"") || instruction_list[i].StartsWith("filesystem.createfolder(\"")) && instruction_list[i].EndsWith("\")"))
                    {
                        string s = instruction_list[i].Remove(0, 25);
                        s = s.Remove(s.Length - 2);
                        s = s.Replace("C:/", "0:\\");
                        s = s.Replace("/", "\\");
                        if (Directory.Exists(s))
                        {
                            Things_to_Display.Add("Failed: The directory you want to create(" + s + ") already exist!");
                        }
                        else
                        {
                            if (s.StartsWith("C:/"))
                            {
                                //s = s.Replace("C:/", "0:\\");
                                //s = s.Replace("/", "\\");
                                Directory.CreateDirectory(s);
                            }
                            if (s.StartsWith("0:\\"))
                            {
                                if (!s.Contains("/"))
                                {
                                    Directory.CreateDirectory(s);
                                }
                                else
                                {
                                    Things_to_Display.Add("Failed: Invalid target format! -> " + s);
                                }
                            }
                        }
                    }
                    if ((instruction_list[i].StartsWith("FileSystem.RemoveFolder(\"") || instruction_list[i].StartsWith("filesystem.removefolder(\"")) && instruction_list[i].EndsWith("\")"))
                    {
                        string s = instruction_list[i].Remove(0, 25);
                        s = s.Remove(s.Length - 2);
                        s = s.Replace("C:/", "0:\\");
                        s = s.Replace("/", "\\");
                        if (!Directory.Exists(s))
                        {
                            Things_to_Display.Add("Failed: Unable to delete " + s + " because it no longer exist!");
                        }
                        else
                        {
                            if (s.StartsWith("C:/"))
                            {
                                //s = s.Replace("C:/", "0:\\");
                                //s = s.Replace("/", "\\");
                                Directory.Delete(s);
                            }
                            else if (s.StartsWith("0:\\"))
                            {
                                if (!s.Contains("/"))
                                {
                                    Directory.Delete(s);
                                }
                                else
                                {
                                    Things_to_Display.Add("Failed: Invalid target format! -> " + s);
                                }
                            }
                        }
                    }
                    if ((instruction_list[i].StartsWith("FileSystem.ReadFromFile(\"") || instruction_list[i].StartsWith("filesystem.readfromfile(\"")) && instruction_list[i].EndsWith("\")"))
                    {
                        //25
                        string cleaned = instruction_list[i].Remove(0, 25);
                        cleaned = cleaned.Remove(cleaned.Length - 2);
                        string content = File.ReadAllText(cleaned);
                        string modified_text = "";
                        foreach(char ch in content)
                        {
                            if(ch == '\n')
                            {
                                Things_to_Display.Add(modified_text);
                            }
                        }
                    }
                    if (instruction_list[i].StartsWith("**") || instruction_list[i].StartsWith("--"))
                    {

                    }
                }
            }
            catch(Exception e)
            {
                ImprovedVBE._DrawACSIIString(e.Message, 4, 884, 16777215);
            }
        }
    }
}
