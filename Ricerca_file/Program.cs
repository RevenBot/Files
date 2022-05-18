using System;
using System.IO;
using System.Reflection;
using Ricerca_file.Properties;

namespace Ricerca_file
{
    class Program
    {

        static void Main(string[] args)
        {
            Line input = Start_up();
            do
            {

                input.Input();
           

            } while (true);
            
        }
        static Line Start_up()
        {
            Console.WriteLine("Welcome");
            Line input = new Line();
            return input;
        }
 
       
        
    }
}
