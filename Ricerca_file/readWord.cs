using System;
using System.IO;
using System.Linq;
using System.Text;
namespace Ricerca_file.Properties
{
    public class readWord
    {
       

        public void ReadWord()
        {
            using StreamReader reader = new StreamReader("../../../29765-8.txt");
            using StreamWriter writer = new StreamWriter("../../../nuovo12.txt");
            while (!reader.EndOfStream)
                {
                string readLine = reader.ReadLine();
                string[] words = readLine.Split(' ','.',',',';','[',']','(',')');
                if(words.Length==1&words[0]!=""&words[0].Length>4&words[0].Length<6&!words[0].Contains('-') & !words[0].Contains('('))
                {
                    writer.WriteLine(words[0]);
                }
            }
        }
    }
}