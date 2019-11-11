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
            AdjacencyList lst = new AdjacencyList(5);

            lst.AddArk(0, 1, 5);
            lst.AddArk(0, 2, 10);
            lst.AddArk(1, 3, 3);
            lst.AddArk(2, 4, 1);
            lst.AddArk(3, 4, 6);
            lst.AddArk(4, 1, -7);

            var pre = Common.Helper.Bellman_Ford(lst, 0);

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
