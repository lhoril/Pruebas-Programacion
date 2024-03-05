using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaulaLlista
{
    internal class Cercle
    {
        public double x;
        public double y;
        public double radi;
        public double preuM2;

        public Cercle (double x, double y, double r, double preuM2)
        {
            this.x = x;
            this.y = y;
            this.radi = r;
            this.preuM2 = preuM2;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double R
        {
            get { return radi; }
            set { radi = value; }
        }

        public double PreuM2
        {
            get { return preuM2*Math.PI*radi*radi;}
        }
    }
}
