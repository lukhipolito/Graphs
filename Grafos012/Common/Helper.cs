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

        public static List<int> TopologicOrdenation(AdjacencyList dg)
        {
            List<int> topologicOrdenation = new List<int>();
            List<int> auxListOut = new List<int>();
            List<int> auxListIn = new List<int>();
            dg.Digraph.ForEach(x => {
                auxListOut.Add(0);
                auxListIn.Add(0);
                topologicOrdenation.Add(0);
            });
            dg.WeightedDigraph.ForEach(x => {
                auxListOut[x.v]++;
                auxListIn[x.w]++;
            });
            List<int> startersIndex = new List<int>();
            List<int> middleIndex = new List<int>();
            List<int> endersIndex = new List<int>();

            for (int i = 0; i < auxListIn.Count; i++)
            {
                if (auxListIn[i] == 0)
                    startersIndex.Add(i);
                if (auxListOut[i] == 0)
                    endersIndex.Add(i);
            }

            for (int i = 0; i < startersIndex.Count; i++)
                topologicOrdenation[i] = startersIndex[i];

            foreach (var ark in dg.WeightedDigraph)
            {
                if (!topologicOrdenation.Contains(ark.w) && !endersIndex.Contains(ark.w) && !middleIndex.Contains(ark.w))
                {
                    middleIndex.Add(ark.w);
                }
            }

            for (int i = startersIndex.Count; i < middleIndex.Count + startersIndex.Count; i++)
                topologicOrdenation[i] = middleIndex[i-startersIndex.Count];


            for (int i = middleIndex.Count + startersIndex.Count; i < middleIndex.Count + startersIndex.Count + endersIndex.Count; i++)
                topologicOrdenation[i+1] = endersIndex[i-middleIndex.Count - startersIndex.Count];

            return topologicOrdenation;
        }

        public static void Bellman_Ford(AdjacencyList dg)
        {
            List<int> Pai = new List<int>();
            List<int> Dist = new List<int>();
            dg.Digraph.ForEach(x => {
                Pai.Add(int.MaxValue);
                Dist.Add(int.MaxValue);
            });

            for (int i=0; i<dg.Digraph.Count - 1; i++)
            {
                foreach(var ark in dg.WeightedDigraph)
                {
                    RELAX(ark, ref Pai, ref Dist);
                }
            }
            

        }

        private static void RELAX(Ark arc, ref List<int> _pai, ref List<int> _dist)
        {
            if (_dist[arc.w] > arc.weight)
            {
                _dist[arc.w] = (int)arc.weight;
                _pai[arc.w] = arc.v;
            }
        }

        private static bool verifyCicloNegativo(AdjacencyList dg)
        {
            foreach (var ark in dg.WeightedDigraph)
            {
                if (Dist[ark.w] > Dist[ark.v] + (int)ark.weight)
                    return false;
            }
            return true;
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

        public static void show(List<int> lst)
        {
            foreach (var num in lst)
            {
                Console.Write(num.ToString() + "| ");
            }
            Console.WriteLine("");
        }
    }
}
