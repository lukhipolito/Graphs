using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabirynthProject
{
    public class Digraph
    {
        public Digraph()
        {
            lines = new List<List<int>>();
            cont = 0;
            reach = 0;
        }
        public Digraph(int lines)
        {
            this.lines = new List<List<int>>();
            for (int i = 0; i < lines; i++)
            {
                this.lines.Add(new List<int>());
            }
        }

        public List<List<int>> lines { get; set; }

        public void addLine(int x, int y)
        {
            lines[x].Add(y);
        }

        private static int cont = 0;
        private int reach;
        private static List<List<int>> lstCaminhos;
        private static int[] visit;

        public List<List<int>> DFS(Digraph G, int start, int final)
        {
            if (lstCaminhos == null)
            {
                lstCaminhos = new List<List<int>>();
                for (int i = 0; i< G.lines.Count; i++)
                {
                    lstCaminhos.Add(new List<int>());
                }
            }                        

            if (start == final)
            {
                return lstCaminhos;
            }

            int v;
            cont = 0;
            visit = new int[G.lines.Count];
            for (v = start; v < G.lines.Count; v++)
            {
                if (visit[v] == 0)
                    return DFSRecursivo(G, v, final, lstCaminhos);
            }
            return lstCaminhos;
                
        }
        List<List<int>> DFSRecursivo(Digraph G, int v, int final, List<List<int>> caminhos)
        {
            lstCaminhos = caminhos;
            int w;
            visit[v] = cont;
            cont++;
            for (w = 0; w < G.lines.Count; w++)
            {
                if (G.lines[v].Any() && visit[w] == 0)
                {
                    lstCaminhos[v].Add(w);
                     return DFSRecursivo(G, w, final, caminhos);
                }         
            }
            return lstCaminhos;         
        }

        bool verificaCaminho(Digraph G, int start, int end)
        {
            return false;
        }


    }
}
