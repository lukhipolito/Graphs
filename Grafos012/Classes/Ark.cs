using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos012.Classes
{
    class Ark
    {
        public Ark(int _v, int _w, double _weight)
        {
            this.v = _v;
            this.w = _w;
            this.weight = _weight;
        }

        public double weight { get; set; }

        public int v { get; set; }

        public int w { get; set; }

    }
}
