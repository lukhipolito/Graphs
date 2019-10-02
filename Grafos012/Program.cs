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

            lst.AddLine(0, 2);
            lst.AddLine(0, 3);
            lst.AddLine(0, 4);

            lst.AddLine(2, 4);

            lst.AddLine(3, 4);
            lst.AddLine(3, 5);

            lst.AddLine(4, 5);

            lst.AddLine(5, 6);
            lst.AddLine(5, 1);

            lst.AddLine(1, 2);
            lst.AddLine(1, 4);
            lst.AddLine(1, 6);
            lst.AddLine(1, 1);

            lst.Show();

            Console.WriteLine("Distance between nodes");
            for (int i = 0; i < 7; i++)
            {
                var a = Common.Helper.BFS(lst, i);
                Common.Helper.show(a, i);
            }

            System.Console.ReadKey();
        }
    }
}
