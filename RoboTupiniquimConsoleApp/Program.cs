namespace RoboTupiniquimConsoleApp
{
    internal class Program
    {

        static string coordenadaInicial;
        static string sentidoInicial;
        static bool rodarCodigo = true;
        static bool repetirCodigo = false;
        static string comandos = "";                        
        static string stgApontando = "";
        static int posicaoX = 0;
        static int posicaoY = 0;
        static int apontando = 1;

        static void Main(string[] args)
        {
            while (rodarCodigo)      //verifica se o código deve ser rodado
            {
                repetirCodigo = false;
                Console.Clear();

                ExibirCabecalho();

                ValidacaoCoordenadaInicial();

                if (rodarCodigo == false)       //verifica de o código deve continuar sendo rodado
                    break;

                if (repetirCodigo)              //verifica se o código deve ser repetido
                    continue;

                DefinirValoresPosXY();

                ExibirCabecalhoSentido();

                if (repetirCodigo)
                    continue;

                ValidarSentidoInicial();

                TestarSentidoInicial();            //Testa qual é o sentido inicial

                ExibirCabecalhoComandos();

                ValidacaoComandos();                        

                if (repetirCodigo)
                    continue;

                string[] matrizComandos = new string[comandos.Length];

                for (int i = 0; i < comandos.Length; i++)
                {
                    matrizComandos[i] = Convert.ToString(comandos[i]);
                }

                TratandoMatrizComandos(matrizComandos);          //Move o robo e muda sua direção.

                DandoNomeApontando(apontando);          //Da nome a variavel apontando para poder escreve-la

                Console.WriteLine($"O robô está na localização {posicaoX}:{posicaoY}, virado para o {stgApontando}");
                Console.ReadLine();
                
            }
        }







        static void ExibirCabecalho()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Robô Tupiniquim 2025");
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Qual é a posição atual do robô: ");
            Console.WriteLine("S - Para Sair: ");
            Console.WriteLine("----------------------------------------------------");

            coordenadaInicial = Console.ReadLine();
        }

        static void ValidacaoCoordenadaInicial()
        {
            coordenadaInicial = coordenadaInicial.ToUpper();

            if (coordenadaInicial == "S")
                rodarCodigo = false;

            else if (coordenadaInicial.Length > 2 || coordenadaInicial.Length == 1)
            {
                Console.WriteLine("Por favor insira apenas dois numeros referentes a coordenada inicial: ");
                repetirCodigo = true;
            }
        }

        static void DefinirValoresPosXY()
        {
            if (coordenadaInicial == "")
                Console.WriteLine("Os valores iniciais serão definidos como 0:0");

            else
            {
                posicaoX = (Convert.ToInt32(coordenadaInicial[0])) - 48;
                posicaoY = (Convert.ToInt32(coordenadaInicial[1])) - 48;
            }
        }

        static void ExibirCabecalhoSentido()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Para onde ele está virado: ");
            Console.WriteLine("N - norte");
            Console.WriteLine("S - sul");
            Console.WriteLine("L - leste");
            Console.WriteLine("O - oeste");
            Console.WriteLine("----------------------------------------------------");

            sentidoInicial = Console.ReadLine();
            sentidoInicial = sentidoInicial.ToUpper();
        }

        static void ValidarSentidoInicial()
        {
            if (sentidoInicial == "")
            {
                Console.WriteLine("O sentido inicial será definido como norte (N)");
                sentidoInicial = "N";
            }

            else if (sentidoInicial.Length > 1)
            {
                Console.WriteLine("Por favor insira apenas uma letra referente ao sentido inicial: ");
                repetirCodigo = true;
            }
        }

        static void TestarSentidoInicial()
        {
            if (sentidoInicial == "N")
            {
                apontando = 1;
            }

            else if (sentidoInicial == "L")
            {
                apontando = 2;
            }

            else if (sentidoInicial == "S")
            {
                apontando = 3;
            }

            else if (sentidoInicial == "O")
            {
                apontando = 4;
            }

            else
            {
                Console.WriteLine("Por favor, insira um sentido válido: 'N', 'S', 'L' ou 'O'");
            }
        }

        static void ExibirCabecalhoComandos()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Insira os comandos que serão executados: ");
            Console.WriteLine("M - mover");
            Console.WriteLine("E - esquerda");
            Console.WriteLine("D - direita");
            Console.WriteLine("----------------------------------------------------");

            comandos = Console.ReadLine();
            comandos = comandos.ToUpper();
        }

        static void ValidacaoComandos()
        {
            if (comandos == "")
            {
                Console.WriteLine("Por favor, insira letras válidas: 'M', 'E' e 'D'");
                Console.ReadLine();
                repetirCodigo = true;
            }
            else if (comandos.Contains('M') == false && comandos.Contains('E') == false
                && comandos.Contains('D') == false)
            {
                Console.WriteLine("Apenas são aceitos como comandos as letras 'M', 'E' e 'D'");
                Console.ReadLine();
                repetirCodigo = true;
            }
        }

        static void TratandoMatrizComandos(string[] matrizComandos)
        {
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
        }

        static void DandoNomeApontando(int apontando)
        {
            string[] pontosCardiais = { null, "norte", "leste", "sul", "oeste" };

            for (int i = 1; i < 5; i++)
            {
                if (apontando == i)
                {
                    stgApontando = pontosCardiais[i];
                }
            }
        }
    }
}
