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
            if (den <= 0 || den == null) { throw new Exception ("DENOMINATOR NO POT SER UN NULL NI UN NUMERO NEGATIU"); }
            if (sign != '+' && sign != '-') { throw new Exception("SIGN HA DE CONTENIR UN + O UN -"); }
            this.a_num = num;
            this.a_den = den;
            this.a_sign = sign;
        }

        public Fraction (Fraction f)
        {
            this.a_num = f.a_num;
            this.a_den = f.a_den;
            this.a_sign = f.a_sign;
        }

        public Fraction():this(0,1,'-')
        {

        }
        #endregion

        #region propietats
        public int Numerator 
        { 
            get {
                 return a_num; }
            set {
                if (value < 0) throw new Exception("No pot ser un numero negatiu");
                a_num = value; 
            }
        }

        public int Denominator
        {
            get { return a_den; }
            set {
                if (value <= 0) throw new Exception("No pot ser un denominator negatiu o igual 0");
                a_den = value; 
            }
        }

        public char Sign
        {
            get { return a_sign; }
            set {
                if (value != '+' && value != '-') throw new Exception("Sign ha de ser + o -");
                a_sign = value; 
            }
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
            //int Aux;
            //Aux = a % b;
            //a = b;
            //b = Aux;
            //while (Aux > 0)
            //{
            //    Aux = a % b;
            //    if (Aux != 0)
            //    {
            //        a = b;
            //        b = Aux;
            //    }
            //}
            //return b;

            int num = 0;
            while (b > 0)
            {
                num = b;
                b = a % b;
                a = num;
            }
            
            return a;

        }

        #endregion

        #region Metodos i Instancias

        public void Simplify()
        {
            int num, den;
            num = a_num / MCD(a_num, a_den);
            den = a_den / MCD(a_num, a_den);
            a_num = num;
            a_den = den;
        }

        public void Add (Fraction f)
        {
            int num2, den2;
            this.a_num = a_num * f.a_den;
            num2 = f.a_num * this.a_den;
            this.a_den = a_den * f.a_den;
            den2 = this.a_den;
            if (this.a_sign == '+' && f.a_sign == '+') a_num += num2;
            else if (this.a_sign == '+' && f.a_sign == '-')
            {
                a_num = a_num - num2;
                if (num2 > this.a_num)
                {
                    this.Sign = '-';
                }
            }
            else if (this.a_sign == '-' && f.a_sign == '-')
            {
                a_num = a_num + num2;
            }
            else if (this.a_sign == '-' && f.a_sign == '+')
            {
                a_num = a_num - num2;
                if (this.a_num > num2)
                {
                    a_num = -a_num;
                }
            }
            num2 = a_num;
            Simplify();
        }

        public void Multiply(Fraction f)
        {
            a_num *= f.a_num;
            a_den *= f.a_den;
            if (this.a_sign == '-' && f.a_sign == '+' && this.a_sign == '+'&& f.a_sign == '-')
            {
                a_num = -a_num;
            }
            Simplify();
        }

        public void Divide(Fraction f)
        {
            int aux, aux2, num2, den2;
            aux = a_num;
            a_num = a_den;
            a_den = aux;

            aux2 = f.a_num;
            num2= f.a_den;
            den2 = aux2;

            this.a_num *= num2;
            this.a_den *= den2;

            if (this.a_sign == '-' && f.a_sign == '+' && this.a_sign == '+' && f.a_sign == '-')
            {
                a_num = -a_num;
                a_den = -a_den;
            }
            Simplify();
        }

        #endregion

        #region Static Method
        public static bool Equivalents(Fraction f1, Fraction f2)
        {
            bool equals = false;
            f1.Simplify();
            f2.Simplify();
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
                num1 = num1;
            }
            else if (f1.a_sign == '-' && f2.a_sign == '+')
            {
                num1 = num1 + num2;
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
            char sign = '+';
            return new Fraction(numerator, 1, sign);
        }

        public static explicit operator double(Fraction f)
        {
            return f.RealValue;
        }
        #endregion

        #region operators

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1 == f2;
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int num1, num2, den, den2;
            num1 = f1.a_num * f2.a_den;
            num2 = f2.a_num * f1.a_den;
            den = f1.a_den * f2.a_den;
            den2 = den;
            char sign = '+';
            if (f1.a_sign == '+' && f2.a_sign == '+') num1 += num2;
            else if (f1.a_sign == '+' && f2.a_sign == '-')
            {
                num1 = num1 - num2;
                if (f2.a_num > f1.a_num)
                {
                    sign = '-';
                }
            }
            else if (f1.a_sign == '-' && f2.a_sign == '-')
            {
                num1 = num1 - num2;
                sign = '-';
            }
            else if (f1.a_sign == '-' && f2.a_sign == '+')
            {
                num1 = num1 - num2;
                if (f1.a_num > f2.a_num)
                {
                    sign = '-';
                }
            }
            return new Fraction(num1, den, sign);
        }

        public static Fraction operator -(Fraction f)
        {
            char sign = f.a_sign;
            return new Fraction(f.a_num, f.a_den, sign = '-');
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int num1, num2, den, den2;
            num1 = f1.a_num * f2.a_den;
            num2 = f2.a_num * f1.a_den;
            den = f1.a_den * f2.a_den;
            den2 = den;
            char sign = ' ';
            if (f1.a_sign == '+' && f2.a_sign == '+') num1 = num1 - num2;
            if (f1.a_sign == '+' && f2.a_sign == '-')
            {
                num1 = num1 + num2;
                if (f2.a_num > f1.a_num)
                {
                    sign = '+';
                }
            }
            else if (f1.a_sign == '-' && f2.a_sign == '-')
            {
                num1 = num1 - num2;
                sign = '+';
                if(f1.a_num > f2.a_num) sign = '-';
            }
            else if (f1.a_sign == '-' && f2.a_sign == '+')
            {
                num1 = num1 - num2;
                if (f1.a_num > f2.a_num)
                {
                    sign = '-';
                }
            }
            else num1 = num1 + num2;
            num2 = num1;
            return new Fraction(num1, den, sign);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int num1, den;
            num1 = f1.a_num * f2.a_num;
            den = f1.a_den * f2.a_den;
            char sign = '+';
            if (f1.a_sign == '-' && f2.a_sign == '+' && f1.a_sign == '+' && f2.a_sign == '-')
            {
                sign = '-';
            }

            return new Fraction(num1, den, sign);
        }

        public static Fraction operator !(Fraction f)
        {
            int num = f.a_den, den = f.a_num;
            return new Fraction(num, den, f.a_sign);
        }

        public static Fraction operator ++(Fraction f)
        {
            return new Fraction(f.a_num + 1, f.a_den + 1, f.a_sign);
        }

        public static Fraction operator --(Fraction f)
        {
            return new Fraction(f.a_num - 1, f.a_den - 1, f.a_sign);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            int aux, aux2, num1 = f1.a_den, num2 = f2.a_num, den = f1.a_den, den2 = f2.a_den;
            char sign = '+';
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
                sign = '-';
            }
            return new Fraction(num1, den, sign);
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            string output = "";

            if (this.a_num%this.a_den == 0)
            {
                if (this.a_num == 0)
                {
                    output = "0";
                }
                else
                {
                    output = $"{this.a_sign}{this.a_num/this.a_den}";
                }
                
            }
            else
            {
                output = $"{this.a_sign}{this.a_num}/{this.a_den}";
            }
            return output;
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
