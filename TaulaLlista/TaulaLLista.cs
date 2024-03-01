using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaulaLlista
{
    internal class TaulaLLista
    {
        public object[] dades;
        public int nElements;

        #region Constructor

        public TaulaLLista() 
        { 
            this.dades = new object[5];
        }
        public TaulaLLista(int mida)
        {
            this.dades = new object[mida];
        }
        public TaulaLLista(TaulaLLista t1)
        {
            this.dades = t1.dades;
        }

        #endregion

        #region metodes

        public int Afegeix(object element)
        {
            

            return num;
        }

        public object[] AfegeixRang(object[] elements)
        {
            
        }

        #endregion

        #region Propietats

        public int Capacitat
        {
            get { return this.dades.Length; }
        }    

        public int Nelem
        {
            get { return this.nElements; }
        }

        #endregion
    }
}
