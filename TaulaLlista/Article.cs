using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaulaLlista
{
    internal class Article
    {
        private int codi;
        private string descripcio;
        private double preu;

        public Article(int codi, string descripcio, double preu)
        {
            this.codi = codi;
            this.descripcio = descripcio;
            this.preu = preu;
        }

        public int Codi
        {
            get { return codi; }
            set { codi = value; }
        }

        public string desc
        {
            get { return descripcio; }
            set { descripcio = value; }
        }

        public double Preu
        {
            get { return preu; }
            set { preu = value; }
        }

        public void IncrementarPreu(double increment)
        {
            preu += increment;
        }
    }
}
