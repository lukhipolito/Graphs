using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos012.Classes
{
    class AdjacencyList
    {
        public AdjacencyList(int _vertexNumber)
        {
            this.vertexNumber = _vertexNumber;
            this.lineNumber = 0;
            this.Digraph = new List<List<int>>();
            for (int i = 0; i < _vertexNumber; i++)
                this.Digraph.Add(new List<int>());
        }

        public int vertexNumber, lineNumber;

        public List<List<int>> Digraph;

        public void AddLine(int vertex, int num)
        {
            this.Digraph[vertex].Add(num);
            this.lineNumber++;
        }

        public void AddUndirectedLine(int vertex, int num)
        {
            this.AddLine(vertex, num);
            this.AddLine(num, vertex);
        }

        public void Show()
        {
            Console.WriteLine("Selected Digraph: ");
            for(int i=0; i < this.Digraph.Count; i++)
            {
                Console.Write((i)+": ");
                for(int j=0; j<this.Digraph[i].Count;j++)
                    Console.Write("-> "+ this.Digraph[i][j] + " ");
                Console.WriteLine(" ");
            }
        }
    }
}
