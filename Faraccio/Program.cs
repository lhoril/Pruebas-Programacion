namespace Fraccio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(2, 3, '+');
            Fraction f2 = new Fraction(12, 7, '-');
            Fraction f3;
            bool isEqual = Fraction.Equivalents(f1, f2);
            if (isEqual == true)
            {
                Console.WriteLine("Les dos fraccions son iguals");
            }
            else
            {
                Console.WriteLine("Les dos fraccions son diferents");
            }
            Console.WriteLine("DADES "  + f1.Sign + " " + f1.Numerator + "/" + f1.Denominator + " AND REAL VALUE " + Math.Round(f1.RealValue,2));
            Console.WriteLine("DADES " + f2.Sign + " " + f2.Numerator + "/"  + f2.Denominator + " AND REAL VALUE " + Math.Round(f2.RealValue,2));
            Console.WriteLine("BEFORE ADDITION f1 = " + f1 + " AND f2 = " + f2);
            f3 = Fraction.Add(f1, f2);
            Console.WriteLine("AFTER ADDITION f1 = " + f1.ToString() + " f2 = " + f2.ToString() + " AND f3 = " + f3);
            f3 = Fraction.Multiply(f1, f2);
            Console.WriteLine("AFTER ADDITION f1 = " + f1.ToString() + " f2 = " + f2.ToString() + " AND f3 = " + f3);
            f3 = Fraction.Divide(f1, f2);
            Console.WriteLine("AFTER ADDITION f1 = " + f1.ToString() + " f2 = " + f2.ToString() + " AND f3 = " + f3);

            f1.Add(f2);
            Console.WriteLine("AFTER ADDITION f1 = " + f1 + " f2 = " + f2);
            f1.Multiply(f2);
            Console.WriteLine("AFTER ADDITION f1 = " + f1 + " f2 = " + f2);
            f1.Divide(f2);
            Console.WriteLine("AFTER ADDITION f1 = " + f1 + " f2 = " + f2);
            f1.simplify();
            Console.WriteLine("AFTER ADDITION f1 = " + f1);

        }
    }
}