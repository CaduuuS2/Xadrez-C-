using Xadrez.br.com.xadrez.domain;
using Xadrez.br.com.xadrez.enums;
using Xadrez.br.com.xadrez.service;

namespace Xadrez.br.com.xadrez.services
{
    public class MenuService
    {
        public void MenuInicio()
        {
            string jogadorUm = null;
            string jogadorDois = null;
            List<Jogador> jogadores = null;
            bool parametroPrimeiroFor = true;
            for (int i = 5; i > 0; i--)
            {
                if (parametroPrimeiroFor)
                {
                    bool nomesIguais = true;
                    parametroPrimeiroFor = false;
                    Console.WriteLine("Seja bem vindo ao Xadrez.NET");
                    Console.WriteLine(" ");
                    Console.WriteLine("Para iniciar uma partida insira o nome dos dois participantes.");
                    Console.Write("Primeiro jogador: ");
                    jogadorUm = Console.ReadLine();
                    while (nomesIguais)
                    {
                        Console.Write("Segundo jogador: ");
                        jogadorDois = Console.ReadLine();
                        if (jogadorUm != jogadorDois)
                        {
                            jogadores = Sorteio(jogadorUm, jogadorDois);
                            Console.Clear();
                            nomesIguais = false;
                        }
                        else
                        {
                            MensagemNomeInvalido();
                            nomesIguais = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Xadrez.NET");
                    Console.WriteLine($"Primeiro jogador: {jogadorUm}");
                    Console.WriteLine($"Segundo jogador: {jogadorDois}");
                    Console.WriteLine($"{jogadores[0].Nome} jogará com as peças {jogadores[0].Cor} e {jogadores[1].Nome} com as {jogadores[1].Cor}.");
                    Console.WriteLine(" ");
                    Console.Write("A partida começará em: ");
                    Console.Write($"{i}");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            TabuleiroService tabuleiro = new TabuleiroService();
            tabuleiro.partida(jogadores);
        }

        public List<Jogador> Sorteio(string jogadorUmNome, string jogadorDoisNome)
        {
            Random sorteio = new Random();
            int numero = sorteio.Next(1, 100);
            if (numero <= 50)
            {
                Jogador jogadorUm = new Jogador(jogadorUmNome, EnumCores.Brancas);
                Jogador jogadorDois = new Jogador(jogadorDoisNome, EnumCores.Pretas);
                return new List<Jogador> { jogadorUm, jogadorDois };
            }
            else
            {
                Jogador jogadorUm = new Jogador(jogadorUmNome, EnumCores.Pretas);
                Jogador jogadorDois = new Jogador(jogadorDoisNome, EnumCores.Brancas);
                return new List<Jogador> { jogadorUm, jogadorDois };
            }
        }

        public void MensagemNomeInvalido()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|       *** Nomes iguais! Tente novamente! ***       |");
            Console.WriteLine("+----------------------------------------------------+");
        }
    }
}
