namespace RoboTupiniquimConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Robô Tupiniquim 2025");
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Insira os comandos que serão executados: ");
            Console.WriteLine("----------------------------------------------------");

            string comandos = Console.ReadLine();

            char [] matrizComandos = new char [comandos.Length];

            for (int i = 0; i < comandos.Length; i++)
            {
                matrizComandos [i] = comandos[i];
            }

            for (int i = 0; i < comandos.Length; i++)
            {
                Console.WriteLine(matrizComandos[i]);
            }
            Console.ReadLine();
        }
    }
}
