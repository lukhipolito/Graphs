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

        /// <summary>
        /// Dijkstra is an optimal algorithm for finding the shortest path in a digraph that has all positive ark values.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static List<double> Dijkstra(AdjacencyList dg, int startIndex)
        {
            List<int?> parent = new List<int?>();
            List<double> costs = new List<double>();
            List<int> stack = new List<int>();
            dg.Digraph.ForEach(_ => { parent.Add(null); costs.Add(double.MaxValue); });
            costs[startIndex] = 0;
            parent[startIndex] = startIndex;
            stack.Add(startIndex);
            while (stack.Any())
            {
                int node = stack.First();
                stack.Remove(node);
                foreach(var ark in dg.WeightedDigraph.OrderBy(x => x.value).Where(x => x.initialNode == node))
                {
                    if (costs[ark.finalNode] == double.MaxValue)
                    {
                        parent[ark.finalNode] = ark.initialNode;
                        costs[ark.finalNode] = costs[ark.initialNode] + ark.value;
                        stack.Add(ark.finalNode);
                    }
                    else if (costs[ark.finalNode] > costs[ark.initialNode] + ark.value)
                    {
                        parent[ark.finalNode] = ark.initialNode;
                        costs[ark.finalNode] = costs[ark.initialNode] + ark.value;
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
            List<int?> middleIndex = new List<int?>();
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

            var dgAux = dg;
            dgAux.WeightedDigraph.RemoveAll(x => startersIndex.Contains(x.initialNode) || endersIndex.Contains(x.finalNode));

            middleIndex = BFS(dgAux, startersIndex.Last());
            middleIndex.RemoveAll(x => startersIndex.Contains((int)x) || endersIndex.Contains((int)x));

            for (int i = startersIndex.Count; i < middleIndex.Count + startersIndex.Count; i++)
                topologicOrdenation[i] = (int)middleIndex[i-startersIndex.Count];


            for (int i = middleIndex.Count + startersIndex.Count; i < middleIndex.Count + startersIndex.Count + endersIndex.Count; i++)
                topologicOrdenation[i] = endersIndex[i-middleIndex.Count - startersIndex.Count];

            return topologicOrdenation;
        }

        /// <summary>
        /// Minimal path finder algorithm when not all arks have positive values.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static List<double> Bellman_Ford(AdjacencyList dg, int startIndex)
        {
            List<int?> parent = new List<int?>();
            List<double> dist = new List<double>();
            dg.Digraph.ForEach(x => {
                parent.Add(null);
                dist.Add(double.MaxValue);
            });
            parent[startIndex] = startIndex;
            dist[startIndex] = 0;

            for (int i=0; i<dg.Digraph.Count; i++)
            {
                foreach(var ark in dg.WeightedDigraph)
                {
                    RELAX(ark, ref parent, ref dist);
                }
            }
            if (verifyCicloNegativo(dg, ref dist))
                return dist;
            else
                return new List<double>();
        }

        private static void RELAX(Ark ark, ref List<int?> _parent, ref List<double> _dist)
        {
            if (_dist[ark.finalNode] > _dist[ark.initialNode] + ark.value)
            {
                _dist[ark.finalNode] = _dist[ark.initialNode] + ark.value;
                _parent[ark.finalNode] = ark.initialNode;
            }
        }

        private static bool verifyCicloNegativo(AdjacencyList dg, ref List<double> dist)
        {
            foreach (var ark in dg.WeightedDigraph)
            {
                if (dist[ark.finalNode] > dist[ark.initialNode] + ark.value)
                    return false;
            }
            return true;
        }

        public static List<int> Kruskal(AdjacencyList dg)
        {
            List<int> boss = new List<int>();
            List<Ark> aaa = new List<Ark>();
            for (int i = 0; i < dg.Digraph.Count; i++)
                boss.Add(i);
            while (true)
            {
                int v0 = 0, w0 = 0;
                double minCost = double.MaxValue;
                for (int node = 0; node < dg.Digraph.Count; node++)
                {
                    for(List<int> a = dg.Digraph[node]; a.Any(); a.RemoveAt(0))
                    {
                        var ark = dg.WeightedDigraph.Where(_ar => _ar.initialNode == node).OrderBy(_ar => _ar.value).First();
                        if (boss[node] != boss[ark.finalNode] && minCost > ark.value)
                        {
                            minCost = ark.value;
                            v0 = node;
                            w0 = ark.finalNode;
                        }
                    }
                    aaa.Add(dg.WeightedDigraph.FirstOrDefault(ab => ab.initialNode == v0 && ab.finalNode == w0));
                }
                aaa.RemoveAll(_a => _a == null);
                aaa = aaa.Distinct().ToList();
                if (minCost == double.MaxValue)
                    break;

                
                int y = boss[w0];
                int x = boss[v0];
                for(int i = 0; i<dg.Digraph.Count; i++)
                {
                    if (boss[i] == y)
                        boss[i] = x;
                }
            }
            return boss;
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
