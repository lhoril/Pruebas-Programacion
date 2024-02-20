using System.Text;

namespace Possible_hash
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string paraula = "NOA";
            int numStringHash = CODE(paraula);
            DECODE(numStringHash);
        }

        public static int CODE(string stringToChar)
        {
            int numero = 0;
            string numeros, paraula = stringToChar;
            char[] chars;

            foreach (char letters in paraula)
            {
                numero += (int)letters;
            }

            numeros = Convert.ToString(numero);
            chars = numeros.ToCharArray();
            numero = 0;

            foreach (char letters in chars)
            {
                numero += (int)letters;
            }

            return numero;
        }

        public static void DECODE(int StringHash)
        {
            string sb;
            int numHash = 0;

            for (int i = 'A'; i <= 'Z'; i++)
            {
                for (int j = 'A'; j <= 'Z'; j++)
                {
                    for (int k = 'A'; k <= 'Z'; k++)
                    {

                        sb = ($"{(char)i}{(char)j}{(char)k}");
                        numHash = CODE(sb);
                        if (numHash == StringHash) Console.WriteLine($"possible hash {numHash} {sb} ");
                    }
                }
            }
        }


    }
}