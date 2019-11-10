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
        /// <summary>
        /// DFS - Depth-First Search. Goes through every ark and every node to find the shortest path.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="startIndex"></param>
        public static List<int?> DFS (AdjacencyList dg)
        {
            int cont = 0;
            List<int?> pre = new List<int?>();
            dg.Digraph.ForEach(_ => pre.Add(null));
            for (int v = 0; v < dg.Digraph.Count; v++)
            {
                if (pre[v] == null)
                    DFS_Recursion(dg, v, ref pre, ref cont);
            }
            return pre;
        }

        private static void DFS_Recursion(AdjacencyList dg, int startIndex, ref List<int?> pre, ref int cont)
        {
            int finalIndex;
            pre[startIndex] = cont++;
            for (finalIndex = 0; finalIndex < dg.Digraph.Count; finalIndex++)
            {
                if (dg.Digraph[startIndex].Any(x => x == finalIndex) && pre[finalIndex] == null)
                    DFS_Recursion(dg, finalIndex, ref pre, ref cont);
            }
        }

        /// <summary>
        /// BFS - Broadth-First Search. Gets all nodes at the reach of current node.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static List<int?> BFS (AdjacencyList dg, int startIndex)
        {
            int cont = 0;
            List<int?> visit = new List<int?>();
            List<int> stack = new List<int>();
            dg.Digraph.ForEach(_ => visit.Add(null));
            visit[startIndex] = cont++;
            stack.Add(startIndex);
            while (stack.Any())
            {
                int v = stack.First();
                stack.RemoveAt(0);
                for (List<int> a = dg.Digraph[v]; a.Any(); a.RemoveAt(0))
                {
                    if (visit[a.First()] == null)
                    {
                        visit[a.First()] = cont++;
                        stack.Add(a.First());
                    }
                }
            }
            return visit;
        }

        /// <summary>
        /// BFS made in tree format. Saving information of each node's parent
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static List<int?> BFS_tree(AdjacencyList dg, int startIndex)
        {
            int cont = 0;
            List<int?> visit = new List<int?>();
            List<int?> parent = new List<int?>(); /////////
            List<int> stack = new List<int>();
            dg.Digraph.ForEach(_ => { visit.Add(null); parent.Add(null); });
            visit[startIndex] = cont++;
            parent[startIndex] = startIndex;
            stack.Add(startIndex);
            while (stack.Any())
            {
                int v = stack.First();
                stack.RemoveAt(0);
                for (List<int> a = dg.Digraph[v]; a.Any(); a.RemoveAt(0))
                {
                    if (visit[a.First()] == null)
                    {
                        visit[a.First()] = cont++;
                        parent[a.First()] = v; ///////////
                        stack.Add(a.First());
                    }
                }
            }
            return visit;
        }
        /// <summary>
        /// Digraph Distance calculation. The metrics in this method is quantity of nodes or 'steps'. Not a valued distance
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static List<int?>[] DIGRAPHdist(AdjacencyList dg, int startIndex)
        {
            List<int?> dist = new List<int?>();
            List<int?> parent = new List<int?>();
            List<int> stack = new List<int>();
            dg.Digraph.ForEach(_ => { dist.Add(null); parent.Add(null); });
            dist[startIndex] = 0;
            parent[startIndex] = startIndex;
            stack.Add(startIndex);
            while (stack.Any())
            {
                List<int> a;
                int v = stack.First();
                stack.RemoveAt(0);
                for (a = dg.Digraph.First(); a.Any(); a.RemoveAt(0))
                {
                    if (dist[a.First()] == null)
                    {
                        dist[a.First()] = dist[v] + 1;
                        parent[a.First()] = v;
                        stack.Add(a.First());
                    }
                }
            }
            return new List<int?>[] { dist, parent };
        }


        public static List<double?> Dijkstra(AdjacencyList dg, int starIndex)
        {
            List<int?> parent = new List<int?>();
            List<double?> costs = new List<double?>();
            List<Ark> PriorityStack = new List<Ark>();
            dg.Digraph.ForEach(_ => { parent.Add(null); costs.Add(null); });
            costs[starIndex] = 0;
            parent[starIndex] = starIndex;
            PriorityStack.Add(dg.WeightedDigraph.Where(x => x.initialNode == starIndex).OrderBy(x => x.value).First());
            while (PriorityStack.Any())
            {
                PriorityStack.OrderBy(x => x.value);
                var edge = PriorityStack.First();
                PriorityStack.Remove(edge);
                foreach (var ark in dg.WeightedDigraph.Where(x => x.initialNode == edge.finalNode))
                {
                    if (costs[ark.initialNode] == null)
                    {
                        parent[ark.initialNode] = edge.initialNode;
                        costs[ark.initialNode] = costs[edge.initialNode] + ark.value;
                        PriorityStack.Add(ark);
                    }
                    else if (costs[ark.finalNode] > costs[edge.finalNode] + ark.value || costs[ark.finalNode] == null)
                    {
                        parent[ark.finalNode] = edge.finalNode;
                        costs[ark.finalNode] = costs[edge.finalNode] + ark.value;
                    }
                }
            }
            return costs;
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
                auxListOut[x.initialNode]++;
                auxListIn[x.finalNode]++;
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
                if (!topologicOrdenation.Contains(ark.finalNode) && !endersIndex.Contains(ark.finalNode) && !middleIndex.Contains(ark.finalNode))
                {
                    middleIndex.Add(ark.finalNode);
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
            if (_dist[arc.finalNode] > arc.value)
            {
                _dist[arc.finalNode] = (int)arc.value;
                _pai[arc.finalNode] = arc.initialNode;
            }
        }

        private static bool verifyCicloNegativo(AdjacencyList dg)
        {
            //foreach (var ark in dg.WeightedDigraph)
            //{
            //    if (Dist[ark.w] > Dist[ark.v] + (int)ark.weight)
            //        return false;
            //}
            return true;
        }

        private static void Kruskal(AdjacencyList dg)
        {
            List<Ark> Boss = new List<Ark>();
            for (int v=0; v< dg.WeightedDigraph.Count; v++)
            {
                //Boss.Add(v);
            }
        }

        public static void Show(List<int?> lst, int i)
        {
            Console.Write(i.ToString() + " : ");
            foreach (var num in lst)
            {
                Console.Write((num !=null ? num.ToString() : "Infinity")+ "| ");
            }
            Console.WriteLine("");
        }

        public static void Show(List<int> lst)
        {
            foreach (var num in lst)
            {
                Console.Write(num.ToString() + "| ");
            }
            Console.WriteLine("");
        }
    }
}
