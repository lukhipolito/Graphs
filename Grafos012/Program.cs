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
            AdjacencyList lst = new AdjacencyList(7);

            lst.AddUndirectedArk(0, 2, 5);
            lst.AddUndirectedArk(0, 3, 8);
            lst.AddUndirectedArk(2, 3, 10);
            lst.AddUndirectedArk(2, 1, 16);
            lst.AddUndirectedArk(2, 4, 3);
            lst.AddUndirectedArk(3, 4, 2);
            lst.AddUndirectedArk(3, 5, 18);
            lst.AddUndirectedArk(4, 1, 30);
            lst.AddUndirectedArk(4, 5, 12);
            lst.AddUndirectedArk(4, 6, 14);
            lst.AddUndirectedArk(1, 6, 26);
            lst.AddUndirectedArk(5, 6, 4);

            var pre = Common.Helper.Kruskal(lst);

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
