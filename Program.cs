using System;

class PedraPapelTesoura
{
    static void Main(string[] args)
    {
        bool trocarJogador = true;

        while (trocarJogador)
        {
            Console.Write("Qual o seu nome? ");
            string nome = Console.ReadLine();

            Console.WriteLine($"Olá {nome}, escolha entre pedra, papel ou tesoura");

            int vitorias = 0, derrotas = 0, empates = 0;

            bool jogarNovamente = true;
            Random random = new Random();

            while (jogarNovamente)
            {
                int Jogador = LerEscolha();

                int Computador = random.Next(1, 4);

                Console.WriteLine("Você escolheu: " + ConverterEscolha(Jogador));
                Console.WriteLine("O computador escolheu: " + ConverterEscolha(Computador));

                if (Jogador == Computador)
                {
                    Console.WriteLine("Empate!");
                    empates++;
                }
                else if ((Jogador == 1 && Computador == 3) ||
                         (Jogador == 2 && Computador == 1) ||
                         (Jogador == 3 && Computador == 2))
                {
                    Console.WriteLine("Você ganhou!");
                    vitorias++;
                }
                else
                {
                    Console.WriteLine("Você perdeu!");
                    derrotas++;
                }

                Console.Write("Deseja jogar novamente? (s/n): ");
                string resposta = Console.ReadLine().ToLower();
                jogarNovamente = resposta == "s";
            }

            Console.WriteLine($"\nEstatísticas do {nome}:");
            Console.WriteLine($"Vitórias: {vitorias}");
            Console.WriteLine($"Derrotas: {derrotas}");
            Console.WriteLine($"Empates: {empates}\n");

            Console.Write("Deseja trocar de jogador? (s/n): ");
            string trocar = Console.ReadLine().ToLower();
            trocarJogador = trocar == "s";
        }

        Console.WriteLine("Obrigado por jogar!");
    }

    static int LerEscolha()
    {
        int escolha;
        bool valido;

        do
        {
            Console.WriteLine("1 = Pedra");
            Console.WriteLine("2 = Papel");
            Console.WriteLine("3 = Tesoura");
            Console.Write("Escolha: ");

            valido = int.TryParse(Console.ReadLine(), out escolha);

            if (!valido || escolha < 1 || escolha > 3)
            {
                Console.WriteLine("Entrada inválida! Digite 1, 2 ou 3.\n");
                valido = false;
            }

        } while (!valido);

        return escolha;
    }

    static string ConverterEscolha(int escolha)
    {
        switch (escolha)
        {
            case 1: return "Pedra";
            case 2: return "Papel";
            case 3: return "Tesoura";
            default: return "Opção inválida";
        }
    }
}