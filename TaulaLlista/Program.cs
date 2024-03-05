using System.Security.Cryptography;

namespace TaulaLlista
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TaulaLLista t1 = new TaulaLLista();
            object[] objects = { 1, 23, 'a' };
            t1.Afegeix(1);
            t1.AfegeixRang(objects);
            TaulaLLista t1Copia = new TaulaLLista(t1);
            Console.WriteLine(t1.Capacitat);
            Console.WriteLine(t1.Nelem);
            Console.WriteLine(t1Copia.Capacitat);
            Console.WriteLine(t1Copia.Nelem + "Elements de copia Taulallista");
            Console.WriteLine(t1Copia.conté(1) + "Element que conté copia Taulallista True or False");
            Console.WriteLine(t1.UltimIndexDe(1) + "Ultim index on apareix l'element");
            Console.WriteLine(t1.IndexDe(1) + "Index on apoareix l'element");
            t1Copia.Insereix(1, 1);
            t1Copia.Inverteix();
            t1Copia.Elimina(1);
            Console.WriteLine(t1Copia.Nelem + "Elements de copia després de eliminar");
            object[] o = TaulaLLista.ToArray(t1Copia);
            foreach( object o2 in o ) if (o2 is not null)Console.WriteLine(o2);
            Console.WriteLine(t1.ToString());
            //object[] o = ToArray(t1);


            /* 
             CREAR 20 OBJECTES A L'ATZAR (CERCLE O ARTICLE)
             ARTICLES HAN DE TENIR CODI = AL VALOR  DE LA VARIABLE I
             NOM = ARTICLE-I
             PREU = I
             CERCLEES HAN DE TENIR
             CERCLES (I,I), RADI = I*2, PREU_METRE = I*3
             */
            //object o;
            // o = new Cercle....
            // o = new Article
            //TaulaLLista tAndromines = new TaulaLLista(5);
            //Random r = new Random();
            //for (int i = 0; i < 20; i++)
            //{
            //    if(r.Next(2)==0) o = new Cercle(i, i, i*2, i*3);
            //    else o = new Article(i, "ARTICLE-" + i, i);
            //    tAndromines.Afegeix(o);
            //}
            ////int posicio = r.Next(tAndromines.Nelem);
            ////object oAlazar = tAndromines[posicio];
            ////Article articleDeVeritat = (Article)oAlazar;

            ////Per accedir a accions corresponents a la clase de object a la que volem acudir necessitarem un casting (nom class) nomObject
            //for (int i = 0;i < tAndromines.Nelem;i++)
            //{
            //    Console.WriteLine($"OBJECTE {i} -->");
            //    Cercle unCercle; Article unArticle;
            //    if (tAndromines[i] is Cercle)
            //    {
            //        unCercle = (Cercle)tAndromines[i];
            //        Console.WriteLine(unCercle.PreuM2);
            //    }
            //    if (tAndromines[i] is Article)
            //    {
            //        unArticle = (Article)tAndromines[i];
            //        Console.WriteLine(unArticle.Preu);
            //    }
            //    else
            //    {
            //        Console.WriteLine("ETS ALGO RARO");
            //    }
            //}

        }
    }
}