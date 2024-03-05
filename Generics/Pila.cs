using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Pila <TipusBase>
    {
        TipusBase[] dades;
        int nElements;
        const int MIDAXDEFECTE = 10;

        #region Constructor
        public Pila():this(MIDAXDEFECTE)
        {

        }
        public Pila(int mida)
        {

        }
        #endregion

        public void Add(TipusBase element)
        {

        }

        public TipusBase Desempila()
        {
            dades[0] = default;
            return dades[0];
        }
        public void Empila(TipusBase element)
        {

        }



        #region propietats
        public TipusBase Cim
        {
            get { return dades[0]; }
        }

        public bool EsBuida
        {
            get { return nElements == 0; }
        }

        public bool EsPlena
        {
            get { return nElements >= 1; }
        }

        #endregion

        #region Overrides

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            StringBuilder pila = new StringBuilder();

            //CAPACITAT 5/10: amb espais i linies entre mig
            //PILA PLENA : 
            //PILA BUIDA : -
            if (nElements == dades.Length)
            {
                pila.Append("PILA PLENA : ");
            }
            else if (nElements > 0)
            {
                 pila.Append($"CAPACITAT {nElements}/{dades.Length}");
            }
            else
            {
                pila.Append("PILA BUIDA :");
            }
            for (int i = 0; i < this.dades.Length; i++)
            {
                pila.Append("");
            }

            return base.ToString();
        }
        #endregion

    }
}
