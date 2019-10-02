using Grafos012.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos012.Common
{
    internal static class Helper
    {
        static bool VerifyPath(AdjacencyList dg, int x, int y)
        {

            return true;
        }

        static bool VerifyPath(Matrix mx, int x, int y)
        {

            return true;
        }

        public static List<int?> BFS (AdjacencyList dg, int startIndex)
        {
            List<int?> dist = new List<int?>();
            List<int> stack = new List<int>();

            dg.Digraph.ForEach(x => dist.Add(null));

            dist[startIndex] = 0;
            stack.Add(startIndex);
            while (stack.Any())
            {
                int aux = stack.First();
                stack.RemoveAt(0);
                foreach(var a in dg.Digraph[aux])
                {
                    if (dist[a] == null && !stack.Any(x => x == a))
                    {
                        dist[a] = dist[aux] + 1;
                        stack.Add(a);
                    }
                }
            }
            return dist;
        }

        public static void show(List<int?> lst, int i)
        {
            Console.Write(i.ToString() + " : ");
            foreach (var num in lst)
            {
                Console.Write((num !=null ? num.ToString() : "Infinito")+ "| ");
            }
            Console.WriteLine("");
        }
    }
}
