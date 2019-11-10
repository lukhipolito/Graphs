using Grafos012.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos012
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyList lst = new AdjacencyList(6);

            lst.AddLine(0, 2);
            lst.AddLine(0, 3);
            lst.AddLine(0, 4);
            lst.AddLine(1, 2);
            lst.AddLine(1, 4);
            lst.AddLine(2, 4);
            lst.AddLine(3, 4);
            lst.AddLine(3, 5);
            lst.AddLine(4, 5);
            lst.AddLine(5, 1);

            var pre = Common.Helper.BFS(lst, 0);

            lst.Show();

            Console.WriteLine("Pre vector: ");
            pre.ForEach(x =>
            {
                Console.Write($"[{pre.FindIndex(p => p == x)}] ");
            });
            Console.WriteLine();
            pre.ForEach(x =>
            {
                Console.Write($" {x}  ");
            });

            System.Console.ReadKey();
        }
    }
}
