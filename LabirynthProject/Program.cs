using LabirynthProject;
using System;
using System.IO;

namespace Grafos_Projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIndex;
            int finalIndex;
            Digraph digraph = new Digraph();
            Console.WriteLine("Welcome to Morlocks tribe!");
            Console.WriteLine("you have to escape!");
            Console.WriteLine("Edit file 'labirinto.txt' at this machine's desktop then press any key to make an attempt to escape");
            Console.ReadKey();
            Console.WriteLine("Reading file....");
            var file = File.ReadAllLines(@"C:\Users\1722130054\Desktop\labirinto.txt");
            Digraph dc = new Digraph(Convert.ToInt32(file[0].Trim()));
            startIndex = Convert.ToInt32(file[1].Trim());
            finalIndex = Convert.ToInt32(file[2].Trim());

            Console.WriteLine("Creating labirynth environment....");
            for (int i = 3; i < file.Length; i++)
            {
                string first = file[i].Split(',')[0].Trim();
                string last = file[i].Split(',')[1].Trim();
                dc.addLine(Convert.ToInt32(first), Convert.ToInt32(last));
            }
            Console.WriteLine("Validating escape....");

            var a = digraph.DFS(dc, startIndex, finalIndex);

            Console.WriteLine("Número de caminhos possíveis: " + a.Count);
            Console.WriteLine("Melhor caminho: ");
            foreach(var line in a)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
