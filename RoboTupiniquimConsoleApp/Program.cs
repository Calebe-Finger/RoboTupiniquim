namespace RoboTupiniquimConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {  
                Console.Clear();

                int posicaoX = 0;
                int posicaoY = 0;
                int apontando = 1;

                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Robô Tupiniquim 2025");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Qual é a posição atual do robô: ");
                Console.WriteLine("S - Para Sair: ");
                Console.WriteLine("----------------------------------------------------");

                string coordenadaInicial = Console.ReadLine();
                coordenadaInicial = coordenadaInicial.ToUpper();

                if (coordenadaInicial == "S")
                    break;

                else if (coordenadaInicial.Length > 2 || coordenadaInicial.Length == 1)
                {
                    Console.WriteLine("Por favor insira apenas dois numeros referentes a coordenada inicial: ");
                    continue;
                }

                else if (coordenadaInicial == "")
                    Console.WriteLine("Os valores iniciais serão definidos como 0:0");

                else
                {
                    posicaoX = (Convert.ToInt32(coordenadaInicial[0])) - 48;
                    posicaoY = (Convert.ToInt32(coordenadaInicial[1])) - 48;
                }

                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Para onde ele está virado: ");
                Console.WriteLine("N - norte");
                Console.WriteLine("S - sul");
                Console.WriteLine("L - leste");
                Console.WriteLine("O - oeste");
                Console.WriteLine("----------------------------------------------------");

                coordenadaInicial = Console.ReadLine();
                coordenadaInicial = coordenadaInicial.ToUpper();

                if (coordenadaInicial == "")
                {
                    Console.WriteLine("O sentido inicial será definido como norte (N)");
                    coordenadaInicial = "N";
                }

                else if (coordenadaInicial.Length > 1)
                {
                    Console.WriteLine("Por favor insira apenas uma letra referente ao sentido inicial: ");
                    continue;
                }

                else if (coordenadaInicial == "N")
                {
                    apontando = 1;
                }

                else if (coordenadaInicial == "L")
                {
                    apontando = 2;
                }

                else if (coordenadaInicial == "S")
                {
                    apontando = 3;
                }

                else if (coordenadaInicial == "O")
                {
                    apontando = 4;
                }

                else
                {
                    Console.WriteLine("Por favor, insira um sentido válido: 'N', 'S', 'L' ou 'O'");
                }

                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Insira os comandos que serão executados: ");
                Console.WriteLine("M - mover");
                Console.WriteLine("E - esquerda");
                Console.WriteLine("D - direita");
                Console.WriteLine("----------------------------------------------------");

                string comandos = Console.ReadLine();
                comandos = comandos.ToUpper();

                if (comandos == "")
                {
                    Console.WriteLine("Por favor, insira letras válidas: 'M', 'E' e 'D'");
                    continue;
                }
                else if (comandos.Contains('M') == false && comandos.Contains('E') == false
                    && comandos.Contains('D') == false)
                {
                    Console.WriteLine("Apenas são aceitos como comandos as letras 'M', 'E' e 'D'");
                    continue;
                }

                string[] matrizComandos = new string[comandos.Length];

                for (int i = 0; i < comandos.Length; i++)
                {
                    matrizComandos[i] = Convert.ToString(comandos[i]);
                }

                for (int i = 0; i < comandos.Length; i++)
                {
                    if (matrizComandos[i] == "M")
                    {
                        if (apontando == 1)
                        {
                            posicaoY++;
                        }

                        else if (apontando == 2)
                        {
                            posicaoX++;
                        }

                        else if (apontando == 3)
                        {
                            posicaoY--;
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

                    else if (matrizComandos[i] == "D")
                    {
                        apontando++;
                        if (apontando == 5)
                        {
                            apontando = 1;
                        }
                    }

                    else if (matrizComandos[i] == "E")
                    {
                        apontando--;
                        if (apontando == 0)
                        {
                            apontando = 4;
                        }
                    }
                }

                string stgApontando = null;
                string[] pontosCardiais = { null, "norte", "leste", "sul", "oeste" };

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
}
