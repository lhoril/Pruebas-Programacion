using System.Text;

namespace Prueba_1_arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string msg = "HELLO";
            string msgFina;
            StringBuilder msgCorrecte = new StringBuilder("HELLO ");
            for (int i  = 0; i < 10;i++) msgCorrecte.Append("XYZ");
            msgCorrecte.Remove(0, 3);
            msgFina = msgCorrecte.ToString();
            Console.WriteLine(msgFina);
            //for (int i = 0; i < msg.Length; i++) { Console.WriteLine(msg[i]); }
            //msg = "BYE BYE";
            //for(int i = 0;i < msg.Length; i++) { Console.WriteLine(msg[i]); }
            //for (int j = 0;j < 100; j++) { msg = msg + "X"; } Aixo es incorrecte per una generacio de memoria innecessaria.
        }
    }
}