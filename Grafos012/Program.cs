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

            lst.UndirectedAddLine(1, 2);
            lst.UndirectedAddLine(1, 3);
            lst.UndirectedAddLine(2, 4);
            lst.UndirectedAddLine(3, 4);
            lst.UndirectedAddLine(4, 5);
            lst.UndirectedAddLine(5, 6);

            lst.Show();
            System.Console.ReadKey();
        }
    }
}
