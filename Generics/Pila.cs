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

        public void Desempila()
        {
            dades[0] = default;
        }
        public void Empila(TipusBase element)
        {

        }

        public TipusBase Cim
        {
            get { return dades[0]; }
        }
    }
}
