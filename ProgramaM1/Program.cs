namespace ProgramaM1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tmp1;
            double tmp2;
            double num1 = 1.0;
            double num2 = 3.0;
            double resultat = 0.0;
            tmp1 = num1;
            tmp2 = num2;

            while (num1<10000000000)
            {
                resultat = 1 + (num1 / num2);
                num1 = num1 * (tmp1 + 1);
                num2 = num2 * (tmp2 + 2);
            }
            Console.WriteLine(resultat*2);
        }
    }
}