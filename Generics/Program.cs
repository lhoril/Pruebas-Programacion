using System.Text;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pila <int> pEnters = new Pila<int>();
            Pila<StringBuilder> pConsole = new Pila<StringBuilder> ();
            int numero;
            numero = null;
            pEnters.Empila(2);
            pEnters.Empila(3);
            numero = (int)pEnters.Cim;
        }
    }
}