using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace Jogo_De_Adivinhacao_ConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Jogo de adivinhação | Academia de Programação 2024!\n");
            iniciaJogo();
        }

        private static void iniciaJogo()
        {
            int chances = 0;
            int numeroChutado = ' ';
            int numero = 0;
            int pontuacao = 1000;
            int[] numeros = new int[30];

            seletorDeDificuldade(ref chances);
            int adivinhar = geradorDeNumeroAleatorio(ref numeros, ref numero);
            escolhaDoNumero(adivinhar, numeros, ref numeroChutado, ref pontuacao, ref chances);
        }

        static void escolhaDoNumero(int adivinhar, int[] numeros, ref int numeroChutado, ref int pontuacao, ref int chances)
        {


            do
            {
                placar(adivinhar, ref pontuacao, ref chances);
                numeroChutado = valor<int>($"Digite um número entre < 0 à {numeros.Length} >: ");

                if (numeroChutado == adivinhar)
                {
                    Console.WriteLine("\t\t\t\tACERTOU!\n\t\tTU É BRABO MENÓ!");
                    replayGame();

                }
                else
                {
                    Console.WriteLine("Você errou!");
                    respostaErrada(adivinhar, ref numeroChutado, ref pontuacao, ref chances);

                }

            } while (chances != 0);
        }

        private static void replayGame()
        {
            if (continua("Deseja jogar novamente? ( S / N )") == true)
            {
                iniciaJogo();
            }
            else
            {
                Console.WriteLine("Obrigado por jogar :)");
                Environment.Exit(0);
            }
        }

        static void placar(int adivinhar, ref int pontuacao, ref int chances)
        {
            Console.Write($"\n\n\t\tSua pontuação: {pontuacao}Pts.");
            Console.Write($"\t\tVocê tem: {chances} chutes.");
            Console.WriteLine($"\t\tO Numero correto é: {adivinhar}\n\n");
        }

        static void respostaErrada(int adivinhar, ref int numeroChutado, ref int pontuacao, ref int chances)
        {
            int calculoErro = Math.Abs((numeroChutado - adivinhar) / 2) * 10;
            pontuacao -= calculoErro;
            chances--;
            Console.Write($"\tVocê perdeu {calculoErro} pontos.");
            Console.WriteLine($"\t\tVocê gastou 1 chance.");
            valor<string>("ENTER para continuar!");
            Console.Clear();
        }

        static int geradorDeNumeroAleatorio(ref int[] numeros, ref int numero)
        {

            for (int i = 0; i < numeros.Length; i++)
            {
                numero++;
            }
            Random rdn = new();
            int adivinhar = rdn.Next(numero);
            return adivinhar;
        }

        static void seletorDeDificuldade(ref int chances)
        {
            int dificuldade = valor<int>("Escolha a dificuldade:\n\n\t\t1 - Fácil.\t2 - Médio.\t3 - Difícil.");

            switch (dificuldade)
            {
                case 1:
                    chances = 15;
                    break;

                case 2:
                    chances = 10;
                    break;

                case 3:
                    chances = 5;

                    break;

                default:
                    Console.WriteLine("Escolha uma dificuldade");
                    break;
            }
            Console.Clear();
        }

        // (numero chutado – numero aleatório) / 2 formula do erro
        static bool continua(string texto)
        {
            Console.WriteLine(texto);

            string A = Console.ReadLine().ToUpper();

            return A == "S";
        }


        static T valor<T>(string texto)
        {

            Console.WriteLine(texto);

            string input = Console.ReadLine();

            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido!");
                return valor<T>(texto);
            }
        }
    }
}
