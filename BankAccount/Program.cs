using GestioBancaria;

internal class Program
{
    static void Main(string[] args)
    {
        BankAccount baFerran = null;
        BankAccount baArtur = null;
        try
        {
            baFerran = new BankAccount("3030303030", "Ferran", "Chic", 10000);
            Console.WriteLine(baFerran.ToString());
            baArtur = new BankAccount("40404040400", "Artur", "Jove");
            //Console.WriteLine(baFerran.NumeroDeCompte);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }

        //account.Donacio(30);

        //DateTime data = DateTime.Now;
        //Console.WriteLine(data.Year);
        //Console.WriteLine(data.Month);
        //Console.WriteLine(data.Day);
        //Console.WriteLine(data.Hour);
        //Console.WriteLine(data.Minute);
        //Console.WriteLine(data.Second);
    }
}