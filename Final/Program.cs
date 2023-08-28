using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal class Program
    {
        //tablero del juego
        static int[,] tablero = new int[3, 3];

        //simbolos jug1 y jug2
        static string [] simbolo = { " ", "X", "O" };



        static void Main(string[] args)
        {
            bool terminado = false;

            DibujarTablero();
            Console.WriteLine("Jugador 1 = X\nJugador 2 = O");

            do
            {
                PreguntarPosicion(1);
                DibujarTablero();

                terminado= ComprobarGanador();

                if(terminado == true)
                {
                    Console.WriteLine("El jugador 1 ha ganado");
                }
                else
                {
                    terminado = ComprobarEmpate();
                    if (terminado == true)
                    {
                        Console.WriteLine("Esto es un empate");
                    }
                    else
                    {
                        PreguntarPosicion(2);
                        DibujarTablero();
                        terminado = ComprobarGanador();

                        if(terminado == true)
                        {
                            Console.WriteLine("El jugador 2 ha ganado");
                        }

                    }
                }



            } while (terminado == false);
        }

        static void DibujarTablero()
        {

            Console.WriteLine();
            Console.WriteLine("-------------");

            for (int fila= 0; fila<3; fila++) 
            {
                Console.Write("|");

                for(int columna= 0; columna<3; columna++)
                {

                    Console.Write(" {0} |" , simbolo[tablero[fila, columna]]);

                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        static void PreguntarPosicion(int jugador)
        {
            int fila, columna;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno de jugador " + jugador);

                do
                {
                    Console.WriteLine("Seleccione la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());


                } while ((fila<1) || (fila>3));
                do
                {
                    Console.WriteLine("Seleccione la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((columna < 1) || (columna > 3));

                if (tablero[fila-1,columna-1] != 0)
                {
                    Console.WriteLine("Casilla ocupada");
                }

            } while (tablero[fila - 1, columna - 1] != 0);

            tablero[fila - 1, columna - 1] = jugador;
        }

        static bool ComprobarGanador()
        {

            bool taTeTi= false;

            for(int fila= 0; fila<3; fila++)
            {
                if ((tablero[fila,0] == tablero[fila,1]) &&
                    (tablero[fila, 0] == tablero[fila, 2]) &&
                    (tablero[fila, 0] != 0))
                {
                    taTeTi = true;
                }
            }
            for (int columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna]) &&
                    (tablero[0, columna] == tablero[2, columna]) &&
                    (tablero[0, columna] != 0))
                {
                    taTeTi = true;
                }
            }

            if ((tablero[0, 0] == tablero[1, 1]) &&
                (tablero[0, 0] == tablero[2, 2]) &&
                (tablero[0, 0] != 0))
            {
                taTeTi = true;
            }

            if ((tablero[0, 2] == tablero[1, 1]) &&
                (tablero[0, 2] == tablero[2, 0]) &&
                (tablero[0, 2] != 0))
            {
                taTeTi = true;
            }

            return taTeTi;
        }

        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;

            for(int fila=0; fila<3; fila++)
            {
                for(int columna= 0; columna<3; columna++)
                {
                    if ((tablero[fila, columna] == 0))
                    {
                        hayEspacio = true;
                    }
                }
            }
            return !hayEspacio;
        }
    }
}
