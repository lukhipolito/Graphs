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
            this.initialNode = _v;
            this.finalNode = _w;
            this.value = _weight;
        }

        public double value { get; set; }

        public int initialNode { get; set; }

        public int finalNode { get; set; }

    }
}
