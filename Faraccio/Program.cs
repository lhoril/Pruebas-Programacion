namespace Fraccio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(2, 3, '-');
            Fraction f2 = new Fraction(12, 7, '+');
            Fraction f3 = null;
            bool isEqual = Fraction.Equivalents(f1, f2);
            Console.WriteLine(isEqual);
            Console.WriteLine("BEFORE ADDITION f1 = " + f1 + " AND f2 = " + f2);
            f1.Add(f2);
            Console.WriteLine("AFTER ADDITION f1 = " + f1 + " AND F2 = " + f2);
            //f3 = Fraction.Add(f1, f2);
            f1.simplify();
            Console.WriteLine("AFTER ADDITION f1 = " + f1.ToString()[0] + " f2 =" + f2 + " AND f3 = " + f3);
        }
    }
}