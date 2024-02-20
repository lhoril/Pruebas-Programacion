using System.Text;

namespace HASH2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string paraula = "ATACAR";
            char firstLetter = FirstLetter(paraula), lastLetter = LastLetter(paraula);
            int numStringHash = CODE(paraula), numHash = DECODE(numStringHash, firstLetter, lastLetter);
            if (numHash == numStringHash) Console.WriteLine($"el numero {numStringHash} hash del string {paraula} es igual al hash enviat {numHash}");
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

        public static char LastLetter(string stringToChar)
        {
            char lastLetter = ' ';
            int contador1 = 0, contador2 = 0;

            for (int i = 0; i < stringToChar.Length; i++)
            {
                contador2++;
            }
            foreach(char letters in stringToChar)
            {
                contador1++;
                if (contador1 == contador2)
                {
                    lastLetter = letters;
                }
            }
            return lastLetter;

        }

        public static int DECODE(int StringHash, char firstLetter, char lastLetter)
        {
            StringBuilder sb = new StringBuilder();
            int numHash = 0, numCorrecte = 0;

            for (int i = firstLetter; i <= 'Z'; i++)
            {
                for (int j = 'A'; j <= 'Z'; j++)
                {
                    for (int k = 'A'; k <= 'Z'; k++)
                    {

                        for (int l = 'A'; l <= 'Z'; l++)
                        {
                            for (int ñ = 'A'; ñ <= 'Z'; ñ++)
                            {
                                for (int a = lastLetter; a <= 'Z'; a++)
                                {
                                    sb.Append($"{(char)i}{(char)j}{(char)k}{(char)l}{(char)ñ}{(char)a}");
                                    numHash = CODE(sb.ToString());
                                    if (numHash == StringHash) numCorrecte = StringHash;
                                    sb.Clear();
                                }
                            }
                        }
                    }
                }
            }
            return numCorrecte;
        }
    }
}