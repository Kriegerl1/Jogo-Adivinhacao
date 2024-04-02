namespace Jogo_De_Adivinhacao_ConsoleApp
{
    internal class Program
    {
        static int chances;
        static int numeroChutado, numero;
        static int pontuacao = 1000;
        static int[] numeros = new int[30];

        static void Main(string[] args)
        {
            numero = 0;
            Console.WriteLine("Jogo de adivinhação | Academia de Programação 2024!\n");

            seletorDeDificuldade();
            int adivinhar = geradorDeNumeroAleatorio(numeros);
            jogoDeAdivinhar(adivinhar, numeros);
        }

        private static void jogoDeAdivinhar(int adivinhar, int[] numeros)
        {


            do
            {
                placar(adivinhar);
                numeroChutado = valor<int>($"Digite um número entre < 0 à {numeros.Length} >: ");

                if (numeroChutado == adivinhar)
                {
                    Console.WriteLine("Acertou!\nTU É BRABO MENÓ!");
                }
                else
                {
                    Console.WriteLine("Você errou!");
                    respostaErrada(adivinhar);
                }

            } while (chances != 0);
        }

        private static void placar(int adivinhar)
        {
            Console.Write($"\n\n\t\tSua pontuação: {pontuacao}Pts.");
            Console.Write($"\t\tVocê tem: {chances} chutes.");
            Console.WriteLine($"\t\tO Numero correto é: {adivinhar}\n\n");
        }

        private static void respostaErrada(int adivinhar)
        {
            int calculoErro = Math.Abs((numeroChutado - adivinhar) / 2) * 10;
            pontuacao -= calculoErro;
            chances--;
            Console.Write($"\tVocê perdeu {calculoErro} pontos.");
            Console.WriteLine($"\t\tVocê ainda tem:{chances}.");
            valor<string>("ENTER para continuar!");
            Console.Clear();
        }

        private static int geradorDeNumeroAleatorio(int[] numeros)
        {

            for (int i = 0; i < numeros.Length; i++)
            {
                numero++;
            }
            Random rdn = new();
            int adivinhar = rdn.Next(numero);
            return adivinhar;
        }

        private static void seletorDeDificuldade()
        {
            int dificuldade = valor<int>("Escolha a dificuldade:\n1 - Fácil.\n2 - Médio.\n3 - Difícil.");

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
