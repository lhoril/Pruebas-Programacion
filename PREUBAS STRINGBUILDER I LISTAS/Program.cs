using System.Diagnostics;
using System.Text;

namespace PREUBAS_STRINGBUILDER_I_LISTAS
{
    internal class Program
    {
        static void Main(string[] args)
        {
           const string FILENAME = "FRASES.txt";
           List<string> frase = ProcessarText(FILENAME);
           MostrarFrases(frase);

        }

        public static List<string> ProcessarText(string fILENAME)
        {
            StreamReader sr = new StreamReader(fILENAME);
            StringBuilder paraules = new StringBuilder();
            string linia = sr.ReadLine();
            List<string> frases = new List<string>();
            while (linia != null)
            {
                if (linia != ".")
                {
                    paraules.Append(linia + " ");
                }
                else
                {
                    frases.Add(paraules.ToString());
                    paraules.Remove(0, paraules.Length);
                }
                linia = sr.ReadLine();
            }
            return frases;
        }

        public static void MostrarFrases(List<string> frases)
        {
            StringBuilder words = new StringBuilder();
            int contador = 0;

            for(int i = 0; i < frases.Count; i++)
            {
                Console.WriteLine($"FRASE NUMERO {i+1}: ");
                Console.WriteLine(frases[i]);
                words.Append(frases[i]);
                string[] fraseSeparada = words.ToString().Split(' ');
                foreach (string s in fraseSeparada) 
                {
                    if (s != "")
                    {
                        contador++;
                    }
                }
                Console.WriteLine($"NUMERO DE PARAULES DE LA FRASE: {contador}");
                Console.WriteLine("DESGLÓS DE PARAULES DE LA FRASE : ");
                DesglossarFrase(words.ToString());
                words.Remove(0, words.Length);
                Console.WriteLine("----------------------------------");
                contador = 0;
            }
        }

        public static void DesglossarFrase(string frase)
        {
            string[] fraseSeparada = frase.Split(' ');
            for (int i = 0; i < fraseSeparada.Length; i++)
            {
                Console.WriteLine(fraseSeparada[i]);
            }

        }
    }
}