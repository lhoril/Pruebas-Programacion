using System.Numerics;
namespace operadors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object[] objects = new object[8];
            objects[0] = 1;
            objects[1] = 'A';
            foreach (object o in objects)
            {
                Console.WriteLine(o);
            }
        }
    }
}