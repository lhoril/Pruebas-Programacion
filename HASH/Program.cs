using System.Text;

namespace HASH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string paraula = "NOA";
            char letter = FirstLetter(paraula);
            int numStringHash = CODE(paraula), numHash = DECODE(numStringHash, letter);
            if (numHash == numStringHash) Console.WriteLine($"el numero {numStringHash} hash del string {paraula} es igual al hash enviat {numHash}");
        }
        
        public static int CODE (string stringToChar)
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

        public static char FirstLetter(string stringToChar)
        {
            char firstLetter = ' ';
            int contador = 0;
            foreach (char letters in stringToChar)
            {
                contador++;
                if (contador == 1)
                {
                    firstLetter = letters;
                }
            }
            return firstLetter;
        }

        public static int DECODE (int StringHash, char letter)
        {
            string sb;
            int numHash = 0, numCorrecte = 0;

            for (int i = letter; i <= 'Z'; i++)
            {
                for (int j = 'A'; j <= 'Z'; j++)
                {
                    for(int k = 'A'; k <= 'Z'; k++)
                    {
                        
                        sb = ($"{(char)i}{(char)j}{(char)k}");
                        numHash = CODE(sb);
                        if(numHash == StringHash) numCorrecte = StringHash;
                    }
                }
            }
            return numCorrecte;
        }

        
    }
}