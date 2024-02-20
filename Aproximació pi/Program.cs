namespace Aproximació_pi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = 1.0, num2 = 3.0, result = 0;
            double temp1 = num1, temp2 = num2, total = 1;

            for (int i = 1; i < 10; i++)
            {
                result = num1 / num2;
                total += result;
                temp1++;
                num1 = num1 * (temp1);
                temp2 += 2;
                num2 = num2 * (temp2);
            }
            Console.WriteLine(total*2);
            
        }
    }
}