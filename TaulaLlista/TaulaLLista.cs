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
        private object[] dades;
        private int nElements;
        const int MIDAxDEFAULT = 10;

        #region Constructor

        public TaulaLLista() :this(MIDAxDEFAULT)
        { 
        }
        public TaulaLLista(int mida)
        {
            this.dades = new object[mida];
        }
        public TaulaLLista(TaulaLLista t1)
        {
            if (t1 is null) throw new Exception("LA TAULA ENTRADA NO POT SER NULL");
            this.nElements = t1.nElements;
            this.dades = new object[t1.dades.Length];
            for (int i = 0; i < this.nElements; i++) { this.dades[i] = t1.dades[i]; }
        }

        #endregion

        #region metodes

        public int Afegeix(object element)
        {
            if(element is null) throw new ArgumentNullException("NO ES POT AFEGIR UN ELEMENT NULL");
            if (nElements == Capacitat) DuplicaCapacitat();
            dades[nElements] = element;
            nElements++;
            return nElements -1;
        }

        private void DuplicaCapacitat()
        {
            object[] tTemp = new object[dades.Length * 2];
            for (int i = 0;i < dades.Length;i++) tTemp[i] = dades[i];
            dades = tTemp;
        }

        public void AfegeixRang(object[] elements)
        {
            if (elements == null) throw new ArgumentNullException("LA TAULA DE ELEMENTS NO POT SER NULL");
            foreach (object valor in elements) Afegeix(valor);
        }



        public void Insereix(object valor, int posicio)
        {
            object aux;
            if (valor is null) throw new ArgumentNullException("Els elements no pot ser null");
            if (posicio > nElements) throw new IndexOutOfRangeException("No es pot inserir més enllà del rang de elements");
            if (posicio < 0) throw new IndexOutOfRangeException("No es pot inserir en posicions més grans que la de la taula");

            for(int i = nElements-1; i > posicio; i--)
            {
                aux = this.dades[i];
                dades[i] = dades[i - 1];
                dades[i-1] = aux;
            }
        }

        public void Neteja()
        {
            for (int i = 0; i < nElements; i++)
            {
                this.dades[i] = default(object);
            }
            this.nElements = 0;
        }

        public bool conté (object Elem)
        {
            return Elem.Equals(this.dades);
        }

        public int IndexDe(object target)
        {
            bool trobat = false;
            int i = 0;
            while (!trobat && i < nElements)
            {
                trobat = object.Equals(dades[i], target);
                if (!trobat) i++;
            }
            if (!trobat) i = -1;
            return i;
        }

        public object EliminaA(int posicio)
        {
            object o;
            if ((posicio < 0) || (posicio >= nElements)) throw new IndexOutOfRangeException("Index fora de rang");
            else
            {
                o = dades[posicio];
                for(int i = posicio;i <= nElements; i++)
                {
                    dades[i] = dades[i +1];
                }
                dades[nElements -1] = default(object);
                nElements--;
                return o;
            }
        }

        public bool Elimina(object element)
        {
            bool trobat = false;
            int posicio = IndexDe(element);
            if(posicio != -1)
            {
                trobat = true;
            }
            return trobat;
        }



        #endregion

        #region Propietats
        public object this[int idx]
        {
            get
            {
                if (idx < 0 || idx >= nElements)
                    throw new Exception($"{idx} FORA DE RANG [" + 0 + "," + (nElements - 1) + "]");
                return dades[idx];
            }
            set
            {
                if (idx < 0 || idx >= nElements) throw new IndexOutOfRangeException($"{idx} FORA DE RANG [" + 0 + "," + (nElements - 1) + "]");
                if (value == null) throw new ArgumentNullException("NO PODEM ASSIGNAR VALORS NULLS");
                dades[idx] = value;
            }
        }

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
