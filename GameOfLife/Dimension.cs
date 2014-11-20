using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Dimension
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Dimension(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

     
    }
}
