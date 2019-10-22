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
            AdjacencyList lst = new AdjacencyList(13);

            lst.AddArk(0, 1, 1);
            lst.AddArk(0, 5, 1);
            lst.AddArk(0, 6, 1);

            lst.AddArk(2, 0, 1);
            lst.AddArk(2, 3, 1);

            lst.AddArk(3, 5, 1);

            lst.AddArk(5, 4, 1);

            lst.AddArk(8, 7, 1);

            lst.AddArk(7, 6, 1);

            lst.AddArk(6, 4, 1);
            lst.AddArk(6, 9, 1);

            lst.AddArk(9, 10, 1);
            lst.AddArk(9, 11, 1);
            lst.AddArk(9, 12, 1);

            lst.AddArk(11, 12, 1);

            lst.Show();

            Console.WriteLine("Topologic Ordenation");
            //for (int i = 0; i < 30; i++)
            //{
            //    var a = Common.Helper.TopologicOrdenation(lst, i);
            //    Common.Helper.show(a, i);
            //}
            var a = Common.Helper.TopologicOrdenation(lst);
            Common.Helper.show(a);

            System.Console.ReadKey();
        }
    }
}
