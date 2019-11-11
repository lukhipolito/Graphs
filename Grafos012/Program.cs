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

            lst.AddArk(0, 1, 5);
            lst.AddArk(0, 3, -2);
            lst.AddArk(1, 2, 1);
            lst.AddArk(2, 3, 2);
            lst.AddArk(2, 4, 7);
            lst.AddArk(2, 5, 3);
            lst.AddArk(3, 4, 3);
            lst.AddArk(4, 5, 10);
            

            var pre = Common.Helper.Bellman_Ford(lst);

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
