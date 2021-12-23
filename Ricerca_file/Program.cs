using System;
using System.IO;
using System.Reflection;

namespace Ricerca_file
{
    class Program
    {

        static void Main(string[] args)
        {
            Line input = Start_up();
            while(true)
            {
                input.WriteLinePath();

                input.Input();
                input.ReadLine();
             
                Console.ReadKey();

            }
            
        
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            //Console.WriteLine("GetFolderPath: {0}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            //var prefix = Console.ReadLine();
            //Console.WriteLine(prefix[0]);
            // string[] a = new string[3] { "CD", @"G:\Il mio Drive", "all" };
            //Line Input = new Line();
            //Input.ReadLine(a);
            //Input.PrintPrefix();

            //string[] b = new string[1] { "dfdg" };
            //Input.ReadLine(b);
            // Input.PrintPrefix();
            //Console.Read();




        }
        static Line Start_up()
        {
            Console.WriteLine("Welcome");
            Line input = new Line();
            Main_menu();
            return input;

        }
        static void Main_menu()
        {
            Console.WriteLine("CD to change path");
            Console.WriteLine("RF to reseach file");
            Console.WriteLine("RKW to research key word");
            Console.WriteLine("RFD to research into directory");
        }
       
        
    }
}
