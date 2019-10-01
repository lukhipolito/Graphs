using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos012.Classes
{
    class Matrix
    {
        public Matrix(int vertexNumber)
        {
            MatrixDataSet = new List<List<int>>();
            for(int i=0; i < vertexNumber; i++)
            {
                List<int> column = new List<int>();
                for (int j = 0; j < vertexNumber; j++)
                    column.Add(0);
                MatrixDataSet.Add(column);
            }
        }

        public void FillMatrix(int x, int y)
        {
            this.MatrixDataSet[x-1][y-1] = 1;
        }

        public void Show()
        {
            foreach(var x in this.MatrixDataSet)
            {
                Console.Write("/");
                foreach (var y in x)
                {
                    System.Console.Write(y);
                }
                System.Console.WriteLine("/");
            }
        }

        public List<List<int>> MatrixDataSet;
    }
}
