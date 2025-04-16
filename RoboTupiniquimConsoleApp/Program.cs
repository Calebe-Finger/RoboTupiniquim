﻿namespace RoboTupiniquimConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int posicaoX = 0;
            int posicaoY = 0;
            int apontando = 1;

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Robô Tupiniquim 2025");
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Insira os comandos que serão executados: ");
            Console.WriteLine("----------------------------------------------------");

            string comandos = Console.ReadLine();

            string [] matrizComandos = new string [comandos.Length];

            for (int i = 0; i < comandos.Length; i++)
            {
                matrizComandos[i] = Convert.ToString(comandos[i]);
            }

            for (int i = 0; i < comandos.Length; i++)
            {
                if (matrizComandos[i].ToUpper() == "M")
                {
                    if (apontando == 1)
                    {
                        posicaoY++;
                    }

                    else if (apontando == 2)
                    {
                        posicaoY--;
                    }

                    else if (apontando == 3)
                    {
                        posicaoX++;
                    }

                    else if (apontando == 4)
                    {
                        posicaoX--;
                    }

                    else
                    {
                        Console.WriteLine("Temos um problema na variável apontando...");
                    }
                }

                else if (matrizComandos[i].ToUpper() == "D")
                {
                    apontando++;
                    if (apontando == 5)
                    {
                        apontando = 1;
                    }
                }

                else if (matrizComandos[i].ToUpper() == "E")
                {
                    apontando--;
                    if (apontando == 0)
                    {
                        apontando = 4;
                    }
                }
            }

            string stgApontando = null;
            string [] pontosCardiais = {null, "norte", "leste", "sul", "oeste"};

            for (int i = 1; i < 5; i++)
            {
                if (apontando == i)
                {
                    stgApontando = pontosCardiais[i];
                }
            }

            Console.WriteLine($"O robô está na localização {posicaoX}:{posicaoY}, virado para o {stgApontando}");
    
                Console.ReadLine();
        }
    }
}
