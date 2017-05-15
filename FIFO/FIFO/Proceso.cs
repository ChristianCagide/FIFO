using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO
{
    class Proceso
    {
        private static Random rand = new Random();
        public int ciclos { get; set; }
        public Proceso siguiente { get; set; }

        public Proceso()
        {
            ciclos = rand.Next(4, 15);
            siguiente = null;
        }

        public override string ToString()
        {
            return ciclos.ToString();
        }
    }
}
