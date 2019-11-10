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
            this.initialNod = _v;
            this.finalNod = _w;
            this.value = _weight;
        }

        public double value { get; set; }

        public int initialNod { get; set; }

        public int finalNod { get; set; }

    }
}
