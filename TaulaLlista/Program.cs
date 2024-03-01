namespace TaulaLlista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaulaLLista t1 = new TaulaLLista();
            TaulaLLista t1Copia = new TaulaLLista(t1);
            t1.Afegeix(1);
            Console.WriteLine(t1.Capacitat);
            Console.WriteLine(t1.Nelem);
            Console.WriteLine(t1Copia.Capacitat);
            Console.WriteLine(t1Copia.Nelem);
        }
    }
}