using System;
using System.IO;
using System.Text;
public class Line
{
	public Line()//default Constructor
	{
		prefix = "$";
        
	}
	public string prefix {get;set; }//Propertie return prefix with get or assegnament = with set
	public string[]input { get; set; }
	public void UpdatePrefix(string chagePrefix)// change prefix
    {
		this.prefix = chagePrefix;
    }
	public void PrintPrefix()
	{
		Console.Write(prefix+">>>");
	}
	public void ReadLine()
    {
		if (prefix.Equals("$")|| input[0].Equals(cd.getprefix))
		{
			
			if (input.Length == 1)
				if (input[0].Equals(cd.getprefix))
				{
					UpdatePrefix(cd.getprefix);

				}
				else if (input[0].Equals(researchFile.getprefix))
				{
					UpdatePrefix(researchFile.getprefix);

				}
				else if (input[0].Equals(researchFileAllDirectories.getprefix))
				{
					UpdatePrefix(researchFileAllDirectories.getprefix);
				}
				else if (input[0].Equals("RFD"))
				{
					//researchFile.GetFiles();
				}
				else
					ErrorFound();
		}
		else if (input[0].Equals("exit"))
        {
			prefix = "$";
		}
		else
			{
			if (prefix.Equals(cd.getprefix))
			{
				cd.ChangeCd(input);
			}
			else if (prefix.Equals(researchFile.getprefix))
				researchFile.SubCommand(input);
			
			else if (prefix.Equals(researchFileAllDirectories.getprefix))
				researchFileAllDirectories.ControlFile(input[0]);
	}

	//Console.WriteLine("entra>"+path.actualPath);

	//error nessuno dei campi e giusto dire cosa non va in input[0]
	//funzione exit
	

}
	public void Input()
	{
		Console.WriteLine();
		PrintPrefix();
		string line = Console.ReadLine();
		input = line.Split(" ");
	}

	public void WriteLinePath()
	{
		Console.WriteLine();
		Console.WriteLine("\t" + path.actualPath);
    }
	public void ErrorFound()
    {
		Console.WriteLine();
		Console.WriteLine("Errore nella formatazione del comando");
    }
	
	public static class path
	{
		public static string actualPath = AppDomain.CurrentDomain.BaseDirectory;
		public static string Setprefix()
		{
			return actualPath;
		}
		public static void UpdatePath(string changePath)
        {
			if (Directory.Exists(changePath))
				actualPath = changePath;
			else
				Console.WriteLine("Percoso sbagliato-Rifare");
			//Console.WriteLine(actualPath+"<<<<<<<<<<<");
		
		}
    }	
	public static class cd
	{
		public static string getprefix = "CD";
		
		public static void ChangeCd(string[] newCd)
        {
			
			string updateCd="";//CD without spaces so we add them
			for (int i=0;i<newCd.Length;i++)
			{
				if(i!=newCd.Length-1)
					updateCd+=newCd[i]+" ";
				else
				updateCd += newCd[i];

			}
			
			path.UpdatePath(updateCd);
		}
	}
	public static class researchFile
	{
		public static string getprefix = "RF";

		public static void PrintFiles(string[] arrayFiles, string filename)
        {
			if(arrayFiles.Length==0)
            {
				Console.WriteLine("Nessuno File con la parola {0}" , filename);
            }
			else
            {
				Console.WriteLine("File con la parola {0} sono {1}.",filename, arrayFiles.Length);
				foreach (string file in arrayFiles)
				{
					Console.WriteLine(file);
				}
			}
		}
		public static void SubCommand(string [] subCommand)
        {
			if (subCommand[0].Equals("/R"))
				ControlFile(subCommand[1]);
			else if (subCommand[0].Equals("/O"))
				OpenFile(subCommand);

        }
		public static void ControlFile(string fileName)
		{
			string pathFile = path.actualPath;
			string[] arrayFiles = Directory.GetFiles(pathFile, "*" + fileName + "*");
			PrintFiles(arrayFiles,fileName);
			
		}
		public static void OpenFile(string[] fileName)
        {
			Console.WriteLine("dsf");
			string updateCd = "";//CD without spaces so we add them
			for (int i = 1; i < fileName.Length; i++)
			{
				if (i != fileName.Length - 1)
					updateCd += fileName[i] + " ";
				else
					updateCd += fileName[i];

			}
			using (FileStream fs = File.Open(updateCd, FileMode.Open))
			{
				byte[] b = new byte[1024];
				UTF8Encoding temp = new UTF8Encoding(true);

				while (fs.Read(b, 0, b.Length) > 0)
				{
					Console.WriteLine(temp.GetString(b));
				}
			}

		}
	}
	public static class researchFileAllDirectories
	{
		public static string getprefix = "RFD";

		public static void PrintFiles(string[] arrayFiles, string filename)
		{
			if (arrayFiles.Length == 0)
			{
				Console.WriteLine("Nessuno File con la parola {0}", filename);
			}
			else
			{
				Console.WriteLine("File con la parola {0} sono {1}.", filename, arrayFiles.Length);
				foreach (string file in arrayFiles)
				{
					Console.WriteLine(file);
				}
			}
		}
		public static void ControlFile(string fileName)
		{
			
			string pathFile = path.actualPath;
			string[] arrayFiles = Directory.GetFiles(pathFile, "*" + fileName + "*",SearchOption.AllDirectories);
			PrintFiles(arrayFiles, fileName);

		}
	}
}
