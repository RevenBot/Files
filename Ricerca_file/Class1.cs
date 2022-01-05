using System;
using System.IO;
using System.Text;

namespace Ricerca_file
{
    public class Line
    {

        public string prefix { get; set; }//Propertie return prefix with get or assegnament = with set
        public string input { get; set; }
        public string commandL { get; set; }
        public string subLine { get; set; }
        public string[] localCommands = { "?", Cd.getprefix, ResearchFile.getprefix, researchFileAllDirectories.getprefix,
    ResearchKeyWord.getprefix,"Exit"};
        public string space = " ";
        public void ReadLine()
        {
            if (ControlCommand())
            {

                ConstructSubLine();
                if (commandL.Equals(localCommands[0]))
                {
                    PrintHelp();
                }
                if (commandL.Equals(Cd.getprefix, StringComparison.OrdinalIgnoreCase))
                {
                    prefix = Cd.getprefix;
                    Cd.ReadCommand(subLine);

                }
                else if (commandL.Equals(ResearchFile.getprefix, StringComparison.OrdinalIgnoreCase))
                {
                    prefix = ResearchFile.getprefix;
                    ResearchFile.ReadCommand(subLine);

                }
                else if (commandL.Equals(researchFileAllDirectories.getprefix, StringComparison.OrdinalIgnoreCase))
                {
                    prefix = researchFileAllDirectories.getprefix;
                    researchFileAllDirectories.ReadCommand(subLine);
                }
                else if (commandL.Equals(ResearchKeyWord.getprefix, StringComparison.OrdinalIgnoreCase))
                {
                    prefix = ResearchKeyWord.getprefix;
                    ResearchKeyWord.ReadCommand(subLine);
                }
                else if (commandL.Equals(localCommands[5],StringComparison.OrdinalIgnoreCase))
                {
                    Exit();
                }
            }
            else
            {
                ErrorFound();
            }


            //funzione exit
        }
        public void Input()
        {
            Console.WriteLine();
            Console.Write(Path.actualPath + " >> ");
            input = Console.ReadLine();
            ConstructCommand();
            ReadLine();

        }
        public void ConstructCommand()
        {
            int found = input.IndexOf(space);
            if (found > 0)
            {
                commandL = input.Substring(0, found);
            }
            else
            {
                commandL = input;
            }
        }
        public void ConstructSubLine()
        {
            int found = input.IndexOf(space);
            if (found > 0)
            {
                subLine = input[(found + 1)..];
            }
            else
            {
                subLine = null;
            }
            //subLine = input.Substring(found + 1);
        }
        public bool ControlCommand()
        {
            foreach (string localCommand in localCommands)
            {
                if (localCommand.Equals(commandL, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        private void PrintHelp()
        {
            Console.WriteLine("Commands: ");
            Console.WriteLine(" {0} -Help \n {1} -CD \n {2} -Research File \n {3} -Research File into the directories \n {4} -Research key word in file \n {5} -to close the app",
                localCommands[0],
                localCommands[1],
                localCommands[2],
                localCommands[3],
                localCommands[4],
                localCommands[5]);
        }
        public void ErrorFound()
        {   //Control what is wrong?
            Console.WriteLine("Command Not Found - Write <?> to see the commands");
        }
        public void Exit()
        {
            System.Environment.Exit(1);
        }

        public static class Path
        {
            public static string actualPath = AppDomain.CurrentDomain.BaseDirectory;
            public static string Setprefix()
            {
                return actualPath;
            }
            public static void UpdatePath(string changePath)
            {

                actualPath = changePath;
            }
        }
        public static class Cd
        {
            public static string getprefix = "CD";
            public static string newPath = "";
            public static string space = " ";
            public static void ReadCommand(string subCommand)
            {
                newPath = subCommand;
                if (ControlPath())
                {
                    ChangeCd();
                }
                else
                {
                    Console.WriteLine("Wrong Path");
                }
            }

            public static bool ControlPath()
            {
                if (Directory.Exists(newPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static void ChangeCd()
            {
                Path.UpdatePath(newPath);
            }
        }
        public static class ResearchFile
        {
            public static string getprefix = "RF";
            public static string[] localSubCommands = { "?", "/R", "/O", "/P" };
            public static string space = " ";
            public static string subInput { get; set; }
            public static string subCommand { get; set; }
            public static string subLine { get; set; }
            public static void ReadCommand(string input)
            {
                subInput = input;

                if (ConstructSubC() && ControlSubC())
                {
                    ConstructSubLine();
                    if (subCommand.Equals(localSubCommands[0], StringComparison.OrdinalIgnoreCase))
                    {
                        PrintHelp();
                    }
                    else if (subCommand.Equals(localSubCommands[1], StringComparison.OrdinalIgnoreCase))//search give name return fiiles with that name
                    {
                        ResearchingFile(subLine);
                    }

                    else if (subCommand.Equals(localSubCommands[2], StringComparison.OrdinalIgnoreCase))//open give path return a file open in console
                    {
                        OpenFileName(subLine);
                    }
                    else if (subCommand.Equals(localSubCommands[3], StringComparison.OrdinalIgnoreCase))//open give path return a file open in console
                    {
                        OpenFilePath(subLine);
                    }



                }
                else
                {
                    ErrorFound();
                }



            }


            private static bool ConstructSubC()
            {
                if (subInput != null)
                {
                    int found = subInput.IndexOf(space);
                    if (found > 0)
                    {
                        subCommand = subInput.Substring(0, found);
                        return true;
                    }
                    else
                    {
                        subCommand = subInput;//not space but enter so i can compare it
                        return true;
                    }
                }
                else
                    return false;
            }
            public static void ConstructSubLine()
            {
                int found = subInput.IndexOf(space);
                if (found > 0)
                {
                    subLine = subInput[(found + 1)..];
                }
                else
                {
                    subLine = null;
                }
            }

            private static bool ControlSubC()
            {
                foreach (string localSubC in localSubCommands)
                {
                    if (localSubC.Equals(subCommand, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;

            }
            private static void PrintHelp()
            {
                Console.WriteLine("Commands: ");
                Console.WriteLine(" {0} -Help \n {1} -Search file in the actual path \n {2} -Open file with name in the actual path \n {3} -Open file with path ",
                    localSubCommands[0],
                    localSubCommands[1],
                    localSubCommands[2],
                    localSubCommands[3]);

            }
            public static void ErrorFound()
            {   //Control what is wrong?
                Console.WriteLine("Command Not Found - Write <RF ?> to see the commands");
            }

            public static void ResearchingFile(string fileName)
            {

                if (fileName == null)
                {
                    Console.WriteLine("Missed name file");
                }
                else
                {
                    string pathFile = Path.actualPath;
                    string[] arrayFiles = Directory.GetFiles(pathFile, "*" + fileName + "*");// error if type a path
                    PrintFilesFound(arrayFiles, fileName);

                }


            }
            public static void PrintFilesFound(string[] arrayFiles, string filename)
            {
                if (arrayFiles.Length == 0)
                {
                    Console.WriteLine("No file contains {0}", filename);
                }
                else
                {
                    Console.WriteLine("File with {0} is/are {1}.", filename, arrayFiles.Length);
                    foreach (string file in arrayFiles)
                    {
                        Console.WriteLine(file);
                    }
                }
            }
            public static void OpenFileName(string nameFile)
            {
                if (nameFile == null)
                {
                    Console.WriteLine("Missed name file");
                }
                else
                {
                    if (File.Exists(Path.actualPath + nameFile))
                    {
                        using StreamReader reader = new StreamReader(Path.actualPath + nameFile);
                        while (!reader.EndOfStream)
                        {
                            string readLine = reader.ReadLine();
                            Console.Write(readLine);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File  {0}  not found ", nameFile);
                    }

                }



            }
            public static void OpenFilePath(string pathFile)
            {

                if (pathFile == null)
                {
                    Console.WriteLine("Missed path File");
                }
                else
                {
                    if (File.Exists(pathFile))
                    {
                        using FileStream ts = File.Open(pathFile, FileMode.Open);
                        byte[] b = new byte[1024];
                        UTF8Encoding temp = new UTF8Encoding(true);

                        while (ts.Read(b, 0, b.Length) > 0)
                        {
                            Console.WriteLine(temp.GetString(b));
                        }


                    }
                    else
                    {
                        Console.WriteLine("Path  {0}  not found ", pathFile);
                    }

                }
            }
        }
        public static class researchFileAllDirectories
        {
            public static string getprefix = "RFD";
            public static string[] localSubCommands = { "?", "/R", "/O" };
            public static string space = " ";
            public static string[] arrayFiles;
            public static string subInput { get; set; }
            public static string subCommand { get; set; }
            public static string subLine { get; set; }
            public static void ReadCommand(string Input)
            {
                subInput = Input;

                if (ConstructSubC() && ControlSubC())
                {
                    ConstructSubLine();
                    if (subCommand.Equals(localSubCommands[0], StringComparison.OrdinalIgnoreCase))
                    {
                        PrintHelp();
                    }
                    else if (subCommand.Equals(localSubCommands[1], StringComparison.OrdinalIgnoreCase))
                    {
                        ResearchFile(subLine);
                    }

                    else if (subCommand.Equals(localSubCommands[2], StringComparison.OrdinalIgnoreCase))
                    {
                        OpenFileArray(subLine);
                    }
                }
                else
                {
                    ErrorFound();
                }
            }
            private static bool ConstructSubC()
            {
                if (subInput != null)
                {
                    int found = subInput.IndexOf(space);
                    if (found > 0)
                    {
                        subCommand = subInput.Substring(0, found);
                        return true;
                    }
                    else
                    {
                        subCommand = subInput;//not space but enter so i can compare it
                        return true;
                    }
                }
                else
                    return false;
            }
            public static void ConstructSubLine()
            {
                int found = subInput.IndexOf(space);
                if (found > 0)
                {
                    subLine = subInput[(found + 1)..];
                }
                else
                {
                    subLine = null;
                }
            }

            private static bool ControlSubC()
            {
                foreach (string localSubC in localSubCommands)
                {
                    if (localSubC.Equals(subCommand, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;

            }
            private static void PrintHelp()
            {
                Console.WriteLine("Commands: ");
                Console.WriteLine(" {0} -Help \n {1} -Search file in directories \n {2} -Open file from array founded ",
                    localSubCommands[0],
                    localSubCommands[1],
                    localSubCommands[2]);

            }
            public static void ErrorFound()
            {   //Control what is wrong?
                Console.WriteLine("Command Not Found - Write <RFD ?> to see the commands");
            }
            public static void PrintFiles(string[] arrayFiles, string filename)
            {
                int count = 1;
                if (arrayFiles.Length == 0)
                {
                    Console.WriteLine("No file contains {0}", filename);
                }
                else
                {
                    Console.WriteLine("Files with {0} are {1}.", filename, arrayFiles.Length);
                    foreach (string file in arrayFiles)
                    {
                        Console.WriteLine("{0}- {1}", count++, file);
                    }
                }
            }
            public static void ResearchFile(string fileName)
            {
                if (fileName == null)
                {
                    Console.WriteLine("Missed File name");
                }
                else
                {
                    Console.WriteLine(fileName);
                    string pathFile = Path.actualPath;
                    arrayFiles = Directory.GetFiles(pathFile, "*" + fileName + "*", SearchOption.AllDirectories);
                    PrintFiles(arrayFiles, fileName);

                }

            }
            public static void OpenFileArray(string numFile)
            {
                if (numFile == null)
                {
                    Console.WriteLine("Missed number");
                }
                else
                {
                    int index = Convert.ToInt32(numFile);
                    if (arrayFiles != null)
                    {
                        string pathFile = arrayFiles[index - 1];

                        if (File.Exists(pathFile))
                        {

                            using (FileStream fs = File.Open(pathFile, FileMode.Open))
                            {
                                byte[] b = new byte[1024];
                                UTF8Encoding temp = new UTF8Encoding(true);

                                while (fs.Read(b, 0, b.Length) > 0)
                                {

                                    Console.WriteLine(temp.GetString(b));

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Path  {0}  not found ", pathFile);
                        }
                    }

                }
            }
        }
        public static class ResearchKeyWord
        {
            public static string getprefix = "RKW";
            public static string[] localSubCommands = { "?", "/R", "/O" };
            public static string space = " ";
            public static string[] arrayFiles;
            public static string actualWordS;
            public static string subInput { get; set; }
            public static string subCommand { get; set; }
            public static string subLine { get; set; }
            public static void ReadCommand(string input)
            {
                subInput = input;

                if (ConstructSubC() && ControlSubC())
                {
                    ConstructSubLine();

                    if (subCommand.Equals(localSubCommands[0], StringComparison.OrdinalIgnoreCase))
                    {
                        PrintHelp();
                    }
                    else if (subCommand.Equals(localSubCommands[1], StringComparison.OrdinalIgnoreCase))
                    {
                        ResearchFileKW(subLine);
                    }
                    else if (subCommand.Equals(localSubCommands[2], StringComparison.OrdinalIgnoreCase))
                    {
                        OpenFileArray(subLine);
                    }
                }
                else
                {
                    ErrorFound();
                }
            }
            private static bool ConstructSubC()
            {
                if (subInput != null)
                {
                    int found = subInput.IndexOf(space);
                    if (found > 0)
                    {
                        subCommand = subInput.Substring(0, found);
                        return true;
                    }
                    else
                    {
                        subCommand = subInput;//not space but enter so i can compare it
                        return true;
                    }
                }
                else
                    return false;
            }
            public static void ConstructSubLine()
            {
                int found = subInput.IndexOf(space);
                if (found > 0)
                {
                    subLine = subInput[(found + 1)..];
                }
                else
                {
                    subLine = null;
                }
            }

            private static bool ControlSubC()
            {
                foreach (string localSubC in localSubCommands)
                {
                    if (localSubC.Equals(subCommand, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;

            }
            private static void PrintHelp()
            {
                Console.WriteLine("Commands: ");
                Console.WriteLine(" {0} -Help \n {1} -Serch Word in this directory \n {2} -Open file from array founded ",
                    localSubCommands[0],
                    localSubCommands[1],
                    localSubCommands[2]);

            }
            public static void ErrorFound()
            {   //Control what is wrong?
                Console.WriteLine("Command Not Found - Write <RKW ?> to see the commands");
            }
            public static void ResearchFileKW(string keyWord)
            {
                if (keyWord == null)
                {
                    Console.WriteLine("Missed word name");
                }
                else
                {
                    actualWordS = keyWord;
                    int index = 0;
                    string pathDirectory = Path.actualPath;
                    arrayFiles = Directory.GetFiles(pathDirectory);
                    if (arrayFiles != null)
                    {
                        foreach (string file in arrayFiles)
                        {

                            using StreamReader reader = new StreamReader(file);

                            int countWordF = 0;
                            while (!reader.EndOfStream)
                            {
                                string readLine = reader.ReadLine();
                                for (int i = 0; i < readLine.Length; i++)
                                {
                                    int iEnd = actualWordS.Length + i;
                                    string word = null;
                                    if (iEnd <= readLine.Length)
                                    {
                                        for (int j = i; j < iEnd; j++)
                                        {
                                            word += readLine[j];
                                        }
                                        if (word.Equals(actualWordS, StringComparison.OrdinalIgnoreCase))
                                        {

                                            countWordF++;
                                        }

                                    }

                                }
                            }
                            index++;
                            Console.WriteLine("{0}-{1} with the word <{2}> repeated {3}  ", index, file, keyWord, countWordF);


                        }
                    }
                    else
                    {
                        Console.WriteLine("No files in the directory");
                    }
                }
            }
            public static void OpenFileArray(string numFile)
            {
                if (numFile == null)
                {
                    Console.WriteLine("Missed number");
                }
                else
                {
                    int index = Convert.ToInt32(numFile);
                    if (arrayFiles != null)
                    {
                        string pathFile = arrayFiles[index - 1];
                        int iW = 1;
                        if (File.Exists(pathFile))
                        {
                            using StreamReader reader = new StreamReader(pathFile);
                            while (!reader.EndOfStream)
                            {
                                string readLine = reader.ReadLine();
                                Console.Write("{0}  | ", iW++);
                                for (int i = 0; i < readLine.Length; i++)
                                {
                                    int iEnd = actualWordS.Length + i;
                                    string word = null;
                                    if (iEnd <= readLine.Length)
                                    {
                                        for (int j = i; j < iEnd; j++)
                                        {
                                            word += readLine[j];
                                        }
                                        if (word.Equals(actualWordS, StringComparison.OrdinalIgnoreCase))
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.Write(word);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            i = iEnd - 1;
                                        }
                                        else
                                        {

                                            Console.Write(readLine[i]);
                                        }

                                    }
                                    else
                                    {
                                        Console.Write(readLine[i]);
                                    }
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Path  {0}  not found ", pathFile);
                        }
                    }
                }

            }
        }
    }
}