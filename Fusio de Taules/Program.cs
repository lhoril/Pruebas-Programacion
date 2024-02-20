using System.Text;

namespace Fusio_de_Taules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] taula1 = { 3, 5, 6, 10, 12, 28 };
            int[] taula2 = { 1, 2, 3, 4, 5, 6, 7, 10, 12, 30 };
            List<int> resultat;
            resultat = ElementComuns(taula1 , taula2);
            EscriuResultat(resultat);
        }

        private static List<int> ElementComuns(int[] taula1, int[] taula2)
        {
            List<int> resultat = new List<int>();

            int posicio1 = 0, posicio2 = 0;

            while (posicio1 < taula1.Length && posicio2 < taula2.Length)
            {
                if (taula1[posicio1] == taula2[posicio2])
                {
                    resultat.Add(taula1[posicio1]);
                    posicio1++;
                    posicio2++;
                }
                else if (taula1[posicio1] < taula2[posicio2])
                {
                    posicio1++;
                }
                else
                {
                    posicio2++;
                }

            }
            for (; posicio1  < taula1.Length; posicio1++)
            {
                resultat.Add(taula1[posicio1]);
                posicio1++;
            }

            return resultat;
        }

        private static void EscriuResultat(List<int> resultat)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.Append('[');
            if (resultat.Count != 0)
            { 

                for (int posicio = 0; posicio < resultat.Count; posicio++)
                {
                    cadena.Append(resultat[posicio]);
                    cadena.Append(", ");
                }
                cadena.Remove(cadena.Length - 2, 2);
                cadena.Append(']');
            }
            else
            {
                cadena.Append("[]");
            }
            Console.WriteLine(cadena.ToString());
        }
    }
}