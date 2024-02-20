using System;
using System.Drawing;

namespace GameOfLife
{
    internal class Program
    {
        const int AMPLADA = 50;
        const int ALÇADA = 25;
        const int PERCEMTATGE_DE_CASELLES_PLENES = 30;
        const ConsoleColor COLOR_FONS = ConsoleColor.DarkGray;
        const ConsoleColor COLOR_BUIDA = ConsoleColor.Gray;
        const ConsoleColor COLOR_PLENA = ConsoleColor.DarkYellow;
        const char CASELLA = '█';
        enum EstatDeLaCasella
        {
            Buida,
            Plena
        }

        static void Main(string[] args)
        {

            ConsoleKey tecla = ConsoleKey.Z;

            EstatDeLaCasella[][] taulell;
            taulell = new EstatDeLaCasella[ALÇADA][];

            for (int posicio = 0; posicio < ALÇADA; posicio++)
            {
                taulell[posicio] = new EstatDeLaCasella[AMPLADA];
            }
            //taulell[5][3] = EstatDeLaCasella.Plena;
            InicilitzaElTaulell(taulell);
            PintaElTaulell(taulell);
            tecla = Console.ReadKey().Key;
            while (tecla != ConsoleKey.D0)
            {
                CalculaLaGeneracioSeguent(taulell);
                PintaElTaulell(taulell);
                tecla = Console.ReadKey().Key;

            }

        }

        /// <summary>
        /// Calculem la nova generació del tauler
        /// </summary>
        /// <param name="taulell"></param>
        private static void CalculaLaGeneracioSeguent(EstatDeLaCasella[][] taulell)
        {
            //Creació de la taula auxiliar per calcular la nova generació.
            EstatDeLaCasella[][] novaGeneracio;
            novaGeneracio = new EstatDeLaCasella[ALÇADA][];
            for (int fila = 0; fila < ALÇADA; fila++)
            {
                novaGeneracio[fila] = new EstatDeLaCasella[AMPLADA];
            }
            //Recorrem totes les caselles del taulell per decidir a cada casella si hi haurà vida o no.
            for (int fila = 0; fila < ALÇADA; fila++)
            {
                for (int columna = 0; columna < AMPLADA; columna++)
                {
                    int numeroDeVeins;
                    numeroDeVeins = ComptaVeins(fila, columna, taulell);

                    if (taulell[fila][columna] == EstatDeLaCasella.Plena)
                    {
                        if (numeroDeVeins == 2 || numeroDeVeins == 3)
                        {
                            novaGeneracio[fila][columna] = EstatDeLaCasella.Plena;
                        }
                        else
                        {
                            novaGeneracio[fila][columna] = EstatDeLaCasella.Buida;
                        }
                    }
                    else
                    {
                        if (numeroDeVeins == 3)
                        {
                            novaGeneracio[fila][columna] = EstatDeLaCasella.Plena;
                        }
                        else
                        {
                            novaGeneracio[fila][columna] = EstatDeLaCasella.Buida;
                        }
                    }
                }

            }
            CopiaTauler(novaGeneracio, taulell);

        }
        /// <summary>
        /// COPIA EL CONTINGUT D'UNA MATRIU A DINS D'UNA ALTRA
        /// </summary>
        /// <param name="origen"> TAULA QUE TÉ LES DADES QUE CAL COPIAR. </param>
        /// <param name="destinacio"> TAULA ON COPIAREM LES DADES D'ORIGEN. </param>
        private static void CopiaTauler(EstatDeLaCasella[][] origen, EstatDeLaCasella[][] destinacio)
        {
            for (int fila = 0; fila < ALÇADA; fila++)
            {
                for (int columna = 0; columna < AMPLADA; columna++)
                {
                    destinacio[fila][columna] = origen[fila][columna];
                }
            }
        }

        /// <summary>
        /// PINTA EL CONTINGUT DEL TAULELL A LA CONSOLA
        /// </summary>
        /// <param name="taulell"></param>
        private static void PintaElTaulell(EstatDeLaCasella[][] taulell)
        {
            Console.BackgroundColor = COLOR_FONS;
            Console.Clear();
            for (int fila = 0; fila < ALÇADA; fila++)
            {
                for (int columna = 0; columna < AMPLADA; columna++)
                {
                    if (taulell[fila][columna] == EstatDeLaCasella.Buida)
                    {
                        Console.ForegroundColor = COLOR_BUIDA;
                    }
                    else
                        Console.ForegroundColor = COLOR_PLENA;

                    Console.SetCursorPosition(columna*2, fila);
                    Console.Write(CASELLA);
                    Console.SetCursorPosition(columna * 2 +1, fila);
                    Console.Write(CASELLA);
                }
            }
        }

        /// <summary>
        /// Inicialitza un tauler amb caselles buides i plenes.
        /// Hi haurà aproximadament un PERCENTATGE_DE_CASELLES_PLENES% de les caselles que estarán plenes
        /// </summary>
        /// <param name="taulell">taulell que cal inicialitzar </param>
        private static void InicilitzaElTaulell(EstatDeLaCasella[][] taulell)
        {
            Random r = new Random();
            for (int fila = 0; fila < ALÇADA; fila++)
            {
                for (int columna = 0; columna < AMPLADA; columna++)
                {

                    if (r.Next(100) < PERCEMTATGE_DE_CASELLES_PLENES)
                    {
                        taulell[fila][columna] = EstatDeLaCasella.Plena;
                    }
                    else
                    {
                        taulell[fila][columna] = EstatDeLaCasella.Buida;
                    }
                }
            }
        }
        /// <summary>
        /// Compta el número de veins que té una casella del taulell
        /// </summary>
        /// <param name="fila">Fila de la casella</param>
        /// <param name="columna">Columna de la casella</param>
        /// <param name="taulell">Taulell on cal mirar la casella</param>
        /// <returns>El nombre de veïins que té una casella</returns>
        private static int ComptaVeins(int fila, int columna, EstatDeLaCasella[][] taulell)
        {
            int veins = 0;

            veins = veins + NVeinsALaPosicio(fila - 1, columna - 1, taulell);
            veins = veins + NVeinsALaPosicio(fila - 1, columna, taulell);
            veins = veins + NVeinsALaPosicio(fila - 1, columna + 1, taulell);
            veins = veins + NVeinsALaPosicio(fila, columna - 1, taulell);
            veins = veins + NVeinsALaPosicio(fila, columna + 1, taulell);
            veins = veins + NVeinsALaPosicio(fila + 1, columna - 1, taulell);
            veins = veins + NVeinsALaPosicio(fila + 1, columna, taulell);
            veins = veins + NVeinsALaPosicio(fila + 1, columna + 1, taulell);


            return veins;

        }
        /// <summary>
        /// Retorna si una posició té un veí o cap.
        /// Si la posició cau fora del taulell retorna 0 (cap)
        /// </summary>
        /// <param name="fila">Fila de la posició</param>
        /// <param name="columna">Columna de la posició</param>
        /// <param name="taulell">Taulell on cal mirar la casella</param>
        /// <returns>Número de veïns que té la posició (0 o 1) </returns>
        private static int NVeinsALaPosicio(int fila, int columna, EstatDeLaCasella[][] taulell)
        {
            int nVeins = 0;

            if (fila < ALÇADA && fila >= 0)
                if (columna >= 0 && columna < AMPLADA)
                    if (taulell[fila][columna] == EstatDeLaCasella.Plena)
                        nVeins = 1;

            return nVeins;
        }
    }
}