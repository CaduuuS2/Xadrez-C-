using System.Text.RegularExpressions;
using Xadrez.br.com.xadrez.domain;
using Xadrez.br.com.xadrez.DTOs;
using Xadrez.br.com.xadrez.enums;
using Xadrez.br.com.xadrez.services;

namespace Xadrez.br.com.xadrez.service
{
    internal class TabuleiroService
    {

        bool _partidaEmAndamento = true;

        public TabuleiroService()
        {

        }

        public void partida(List<Jogador> jogadores)
        {
            Tabuleiro tabuleiro = new Tabuleiro(jogadores);
            Pecas[,] casas = tabuleiro.Casas;
            bool brancasVez = true;
            Jogador brancas;
            Jogador pretas;
            if (jogadores[0].Cor == EnumCores.Brancas)
            {
                brancas = jogadores[0];
                pretas = jogadores[1];
            }
            else
            {
                brancas = jogadores[1];
                pretas = jogadores[0];
            }
            while (_partidaEmAndamento)
            {
                Console.WriteLine($"Brancas: {brancas.Nome}");
                Console.WriteLine($"Pretas: {pretas.Nome}");
                Console.WriteLine(" ");
                for (int i = 0; i < 8; i++)
                {
                    string linha = $" 0{i + 1}|";
                    for (int j = 0; j < 8; j++)
                    {
                        if (casas[i, j].Nome != EnumPecas.Vazio)
                        {
                            linha = $"{linha}{casas[i, j].Id}|";
                        }
                        else
                        {
                            linha = $"{linha}  |";
                        }
                    }
                    Console.WriteLine("   +--+--+--+--+--+--+--+--+");
                    Console.WriteLine(linha);
                    if (i == 7)
                    {
                        Console.WriteLine("   +--+--+--+--+--+--+--+--+");
                        Console.WriteLine("    01 02 03 04 05 06 07 08");
                    }
                }
                if (brancasVez)
                {
                    brancasVez = false;
                    casas = Jogada(casas, brancas, pretas);
                }
                else
                {
                    brancasVez = true;
                    casas = Jogada(casas, pretas, brancas);
                }
            }
        }

        public Pecas[,] Jogada(Pecas[,] casas, Jogador jogadorAtual, Jogador jogadorProximo)
        {
            bool whilePergunta = true;
            while (whilePergunta)
            {
                Console.WriteLine(" ");
                Console.Write($"{jogadorAtual.Nome}, qual peça você gostaria de mover(x y/desistir)? ");
                string posicaoAtual = Console.ReadLine();
                if (posicaoAtual == "desistir")
                {
                    _partidaEmAndamento = false;
                    whilePergunta = false;
                    FimPartida(jogadorProximo, EnumVitorias.WO);
                }
                else if (PosicaoValida(posicaoAtual))
                {
                    Console.Write("Para qual posição(x y)? ");
                    string posicaoFinal = Console.ReadLine();
                    Console.WriteLine(" ");
                    if (PosicaoValida(posicaoFinal))
                    {
                        ValidarMovimentoRetornoDTO retornoSplit = SplitRespostaLance(casas, posicaoAtual, posicaoFinal, jogadorAtual);
                        if (retornoSplit.Autorizado)
                        {
                            Console.Clear();
                            whilePergunta = false;
                            return retornoSplit.Casas;
                        }
                        else if (retornoSplit.ReiXeque)
                        {
                            whilePergunta = true;
                            MensagemReiXeque();
                        }
                        else
                        {
                            whilePergunta = true;
                            MensagemPosicaoInvalida();
                        }
                    }
                }
            }
            return casas;
        }

        public ValidarMovimentoRetornoDTO SplitRespostaLance(Pecas[,] casas, string posicaoAtual, string posicaoFinal, Jogador jogadorAtual)
        {
            Tabuleiro referencia = new Tabuleiro();
            string[] posicaoAtualSplit = posicaoAtual.Split(" ");
            string[] posicaoFinalSplit = posicaoFinal.Split(" ");
            int[] posicaoFinalParse = { (int.Parse(posicaoFinalSplit[0]) - 1), (int.Parse(posicaoFinalSplit[1]) - 1) };
            int[] posicaoAtualParse = { (int.Parse(posicaoAtualSplit[0]) - 1), (int.Parse(posicaoAtualSplit[1]) - 1) };
            Pecas peca = casas[posicaoAtualParse[0], posicaoAtualParse[1]];
            if (peca.Nome != EnumPecas.Vazio)
            {
                return ValidarMovimento(casas, posicaoAtualParse, posicaoFinalParse, peca, jogadorAtual, referencia);
            }
            else
            {
                return new ValidarMovimentoRetornoDTO(casas, false, false);
            }
        }

        public void FimPartida(Jogador vencedor, EnumVitorias vitoria)
        {
            Console.Clear();
            Console.WriteLine($"Vitória por {vitoria}!");
            Console.WriteLine($"Parabéns {vencedor.Nome}! Vôcê é o vencedor desse duelo.");
            bool parametroWhile = true;
            while (parametroWhile)
            {
                Console.Write("Deseja voltar ao menu inicial(y/n)? ");
                string resposta = Console.ReadLine();
                if (resposta.Equals("y"))
                {
                    MenuService menu = new MenuService();
                    parametroWhile = false;
                    Console.Clear();
                    menu.MenuInicio();

                }
                else if (resposta.Equals("n"))
                {
                    Console.Clear();
                    Console.WriteLine(" ");
                    Console.WriteLine("Obrigado por jogarem Xadrez.NET :)");
                    Console.WriteLine(" ");
                    parametroWhile = false;
                }
                else
                {
                    parametroWhile = true;
                    Console.WriteLine("Resposta inválida! Tente novamente!");
                }
            }
        }
        public bool PosicaoValida(string posicao)
        {
            try
            {
                string[] posicaoSplit = posicao.Split(" ");
                if (Regex.IsMatch(posicaoSplit[0], @"^[1-8]$")
                    && Regex.IsMatch(posicaoSplit[1], @"^[1-8]$"))
                {
                    return true;
                }
                else
                {
                    MensagemPosicaoInvalida();
                    return false;
                }
            }
            catch (Exception e)
            {
                MensagemPosicaoInvalida();
                return false;
            }
        }
        public void MensagemPosicaoInvalida()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|     *** Posição inválida! Tente novamente! ***     |");
            Console.WriteLine("+----------------------------------------------------+");
        }

        public void MensagemReiXeque()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|       *** Rei em xeque! Tente novamente! ***       |");
            Console.WriteLine("+----------------------------------------------------+");
        }

        public ValidarMovimentoRetornoDTO ValidarMovimento(Pecas[,] casas, int[] posicao, int[] movimento, Pecas peca, Jogador jogadorAtual, Tabuleiro tabuleiro)
        {
            RetornoRegraDTO retorno = tabuleiro.RegraPeca(casas, posicao, movimento, peca, jogadorAtual);
            if (retorno.Autorizado)
            {
                Pecas pecaVazio = new Pecas(EnumPecas.Vazio);
                Pecas[,] casasAlteradas = CloneCasas(casas);
                casasAlteradas[movimento[0], movimento[1]] = peca;
                casasAlteradas[posicao[0], posicao[1]] = pecaVazio;

                if (!tabuleiro.XequeRei(casasAlteradas, jogadorAtual))
                {
                    return new ValidarMovimentoRetornoDTO(casasAlteradas, true, false);
                }
                else
                {
                    return new ValidarMovimentoRetornoDTO(casas, false, true);
                }
            }
            else
            {
                return new ValidarMovimentoRetornoDTO(casas, false, false);
            }
        }

        public Pecas[,] CloneCasas(Pecas[,] casas)
        {
            Pecas[,] casasClone = new Pecas[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    casasClone[i, j] = casas[i, j];
                }
            }
            return casasClone;
        }
    }
}

