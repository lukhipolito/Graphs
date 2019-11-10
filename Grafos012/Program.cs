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

            lst.AddArk(0, 2, 7);
            lst.AddArk(0, 3, 2);
            lst.AddArk(0, 4, 4);
            lst.AddArk(1, 2, 0);
            lst.AddArk(2, 4, 1);
            lst.AddArk(3, 4, 1);
            lst.AddArk(3, 5, 3);
            lst.AddArk(4, 1, 4);
            lst.AddArk(4, 5, 1);
            lst.AddArk(5, 1, 2);

            var pre = Common.Helper.Dijkstra(lst, 0);

            lst.Show();

            Console.WriteLine("Pre vector: ");
            for (int i = 0; i< pre.Count; i++)
            {
                Console.Write($"[{i}] ");
            }
            Console.WriteLine();
            pre.ForEach(x =>
            {
                Console.Write($" {x}  ");
            });

            System.Console.ReadKey();
        }
    }
}
