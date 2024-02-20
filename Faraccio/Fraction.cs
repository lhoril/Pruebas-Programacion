using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fraccio
{
    public class Fraction
    {
        private int a_num;
        private int a_den;
        private char a_sign;

        #region Constructors
        public Fraction(int num, int den, char sign) 
        {
            if (num < 0) { throw new Exception ("NUMERATOR NO POT SER UN NUMERO NEGATIU"); }
            if (den < 0 || den == null) { throw new Exception ("DENOMINATOR NO POT SER UN NULL NI UN NUMERO NEGATIU"); }
            if (sign != '+' && sign != '-') { throw new Exception("SIGN HA DE CONTENIR UN + O UN -"); }
            this.a_num = num;
            this.a_den = den;
            this.a_sign = sign;
        }

        public Fraction (Fraction f)
        {
            f. a_num = this.a_num;
            f.a_den = this.a_den;
            f.a_sign = this.a_sign;
        }

        public Fraction():this(0,1,'-')
        {
           
        }
        #endregion

        #region propietats
        public int Numerator 
        { 
            get { return a_num; }
            set { a_num = value; }
        }

        public int Denominator
        {
            get { return a_den; }
            set { a_den = value; }
        }

        public char Sign
        {
            get { return a_sign; }
            set { a_sign = value; }
        }

        public double RealValue
        {
            get { 
                double result = (double)this.a_num / this.a_den; 

                if(this.a_sign == '-')
                { 
                 result = -result;
                }
                return result;
            }
        }
        #endregion

        #region Private Methods

        private int MCD(int a, int b)
        {
            int Aux;
            Aux = a % b;
            a = b;
            b = Aux;
            while (Aux > 0)
            {
                Aux = a % b;
                if (Aux != 0)
                {
                    a = b;
                    b = Aux;
                }
            }
            return b;
        }

        #endregion

        #region Metodos i Instancias

        public void simplify()
        {
            a_num = a_num / MCD(a_num, a_den);
            a_den = a_den / MCD(a_num, a_den);
            
        }

        public void Add (Fraction f)
        {
            this.a_num = a_num * f.a_den;
            f.a_num = f.a_num * this.a_den;
            this.a_den = a_den * f.a_den;
            f.a_den = this.a_den;
            if (this.a_sign == '+' && f.a_sign == '+') a_num += f.a_num;
            else if (this.a_sign == '+' && f.a_sign == '-')
            {
                a_num = a_num - f.a_num;
                if (f.a_num > this.a_num)
                {
                    a_num = -a_num;
                }
            }
            else if (this.a_sign == '-' && f.a_sign == '-')
            {
                a_num = a_num - f.a_num;
                a_num = - a_num;
            }
            else if (this.a_sign == '-' && f.a_sign == '+')
            {
                a_num = a_num - f.a_num;
                if (this.a_num > f.a_num)
                {
                    a_num = -a_num;
                }
            }
            f.a_num = a_num;
            simplify();
        }

        public void Multiply(Fraction f)
        {
            a_num *= f.a_num;
            a_den *= f.a_den;
            if (this.a_sign == '-' && f.a_sign == '+' && this.a_sign == '+'&& f.a_sign == '-')
            {
                a_num = -a_num;
            }
            simplify();
        }

        public void Divide(Fraction f)
        {
            int aux, aux2;
            aux = a_num;
            a_num = a_den;
            a_den = aux;

            aux2 = f.a_num;
            f.a_num = f.a_den;
            f.a_den = aux2;

            this.a_num *= f.a_num;
            this.a_den *= f.a_den;

            if (this.a_sign == '-' && f.a_sign == '+' && this.a_sign == '+' && f.a_sign == '-')
            {
                a_num = -a_num;
                a_den = -a_den;
            }
            simplify();
        }

        #endregion

        #region Static Method
        public static bool Equivalents(Fraction f1, Fraction f2)
        {
            bool equals = false;
            f1.simplify();
            f2.simplify();
            if (f1.a_num == f2.a_num && f1.a_den == f2.a_den)
            {
                equals = true;
            }

            return equals;
        }

        public static Fraction Add(Fraction f1, Fraction f2)
        {
            int num1, num2, den, den2;
            num1 = f1.a_num * f2.a_den;
            num2 = f2.a_num * f1.a_den;
            den = f1.a_den * f2.a_den;
            den2 = den;
            if (f1.a_sign == '+' && f2.a_sign == '+') num1 += num2;
            else if (f1.a_sign == '+' && f2.a_sign == '-')
            {
                num1 = num1 - num2;
                if (f2.a_num > f1.a_num)
                {
                    num1 = -num1;
                }
            }
            else if (f1.a_sign == '-' && f2.a_sign == '-')
            {
                num1 = num1 - num2;
                num1 = -num1;
            }
            else if (f1.a_sign == '-' && f2.a_sign == '+')
            {
                num1 = num1 - num2;
                if (f1.a_num > f2.a_num)
                {
                    num1 = -num1;
                }
            }
            num2 = num1;
            return new Fraction(num1, den, f1.Sign);
        }

        public static Fraction Multiply(Fraction f1, Fraction f2)
        {
            int num1, den;
            num1 = f1.a_num * f2.a_num;
            den = f1.a_den * f2.a_den;
            if (f1.a_sign == '-' && f2.a_sign == '+' && f1.a_sign == '+' && f2.a_sign == '-')
            {
                num1 = -num1;
            }

            return new Fraction(num1, den, f1.Sign);
        }

        public static Fraction Divide(Fraction f1, Fraction f2)
        {
            int aux, aux2, num1 = f1.a_den, num2 = f2.a_num, den = f1.a_den, den2 = f2.a_den;
            aux = num1;
            num1 = den;
            den = aux;

            aux2 = num2;
            num2 = den2;
            den2 = aux2;

            num1 = num1 * num2;
            den = den * den2;

            if (f1.a_sign == '-' && f2.a_sign == '+' && f1.a_sign == '+' && f2.a_sign == '-')
            {
                num1 = -num1;
                den = -den;
            }
            return new Fraction(num1, den, f1.a_sign);
        }


        #endregion

        #region Conversions

        public static implicit operator Fraction (int numerator)
        {
            string num = numerator.ToString();
            char sign = '+';
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == 1) sign = num[i];
                else num.Append(num[i]);
            }
            numerator = Convert.ToInt32(num);
            return new Fraction(numerator, 0, sign);
        }

        #endregion


        #region Propietats

        //public static Fraction operator !()

        #endregion

        #region Overrides

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Sign);
            sb.Append(this.a_num + "/");
            sb.Append(this.a_den);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            bool areEqual = true;
            if (this is null) areEqual = obj is null;
            else if (obj is Fraction f)
            {
                areEqual = Fraction.Equivalents(this, f);
            }
            else areEqual = false;
            return areEqual;
        }

        #endregion
    }
}
