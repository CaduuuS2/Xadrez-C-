using System.Net.Http.Headers;
using System.Security.Cryptography;
using Xadrez.br.com.xadrez.DTOs;
using Xadrez.br.com.xadrez.enums;

namespace Xadrez.br.com.xadrez.domain
{
    internal class Tabuleiro
    {
        private List<Jogador> _jogadores;
        public Pecas[,] Casas { get; set; }

        //PecaVaziaInstância
        Pecas pecaVazio = new Pecas(EnumPecas.Vazio);

        public Tabuleiro()
        {

        }

        public Tabuleiro(List<Jogador> jogadores)
        {
            Pecas referencia = new Pecas();
            Pecas[,] casas = new Pecas[8, 8];
            casas = referencia.CriacaoPecas(casas);
            Casas = casas;
        }

        public RetornoRegraDTO RegraPeca(Pecas[,] casas, int[] posicao, int[] movimento, Pecas peca, Jogador jogador)
        {
            if (JogadorAtual(peca, jogador))
            {
                if (EnumPecas.Peao == peca.Nome)
                {
                    return RegraPeao(casas, peca, posicao, movimento);
                }
                else if (EnumPecas.Rei == peca.Nome)
                {
                    return RegraRei(casas, peca, posicao, movimento);
                }
                else if (EnumPecas.Cavalo == peca.Nome)
                {
                    return RegraCavalo(casas, peca, posicao, movimento);
                }
                else if (EnumPecas.Torre == peca.Nome)
                {
                    return RegraTorre(casas, peca, posicao, movimento);
                }
                else if (EnumPecas.Bispo == peca.Nome)
                {
                    return RegraBispo(casas, peca, posicao, movimento);
                }
                else if (EnumPecas.Rainha == peca.Nome)
                {
                    return RegraRainha(casas, peca, posicao, movimento);
                }
                else
                {
                    throw new Exception("Os parâmetros passados são inválidos.");
                }
            }
            else
            {
                return new RetornoRegraDTO(pecaVazio, false);
            }

        }

        private RetornoRegraDTO RegraPeao(Pecas[,] casas, Pecas peca, int[] posicao, int[] movimento)
        {
            if (peca.Cor == EnumCores.Brancas)
            {
                if ((posicao[0] + 1) == movimento[0])
                {
                    if (posicao[1] == movimento[1])
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else if ((posicao[1] - 1) == movimento[1])
                    {
                        if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                             && casas[movimento[0], movimento[1]].Cor == EnumCores.Pretas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else if ((posicao[1] + 1) == movimento[1])
                    {
                        if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                            && casas[movimento[0], movimento[1]].Cor == EnumCores.Pretas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else if ((posicao[0] + 2) == movimento[0] && posicao[0] == 1)
                {
                    if (posicao[1] == movimento[1])
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else
                {
                    return new RetornoRegraDTO(pecaVazio, false);
                }
            }
            else
            {
                if ((posicao[0] - 1) == movimento[0])
                {
                    if (posicao[1] == movimento[1])
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else if ((posicao[1] - 1) == movimento[1])
                    {
                        if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                             && casas[movimento[0], movimento[1]].Cor == EnumCores.Brancas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else if ((posicao[1] + 1) == movimento[1])
                    {
                        if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                            && casas[movimento[0], movimento[1]].Cor == EnumCores.Brancas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else if ((posicao[0] - 2) == movimento[0] && posicao[0] == 6)
                {
                    if (posicao[1] == movimento[1])
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else
                {
                    return new RetornoRegraDTO(pecaVazio, false);
                }
            }
        }

        private RetornoRegraDTO RegraRei(Pecas[,] casas, Pecas peca, int[] posicao, int[] movimento)
        {
            bool reiXeque = false;
            string posicoes =
                $"{posicao[0] - 1}.{posicao[1]};{posicao[0] + 1}.{posicao[1]};" +
                $"{posicao[0]}.{posicao[1] - 1};{posicao[0]}.{posicao[1] + 1};" +
                $"{posicao[0] - 1}.{posicao[1] - 1};{posicao[0] + 1}.{posicao[1] + 1};" +
                $"{posicao[0] + 1}.{posicao[1] - 1};{posicao[0] - 1}.{posicao[1] + 1}";

            string[] posicoesUnitarias = posicoes.Split(";");

            for (int i = 0; i < 8; i++)
            {
                string[] posicaoSplit = posicoesUnitarias[i].Split(".");
                int[] posicaoParse = { int.Parse(posicaoSplit[0]), int.Parse(posicaoSplit[1]) };
                if (posicaoParse[0] == movimento[0] && posicaoParse[1] == movimento[1])
                {
                    if (posicaoParse[0] > -1 && posicaoParse[1] < 8
                            && posicaoParse[0] > -1 && posicaoParse[1] < 8)
                    {
                        if (casas[posicaoParse[0], posicaoParse[1]].Nome != EnumPecas.Vazio)
                        {
                            if (casas[posicaoParse[0], posicaoParse[1]].Cor != peca.Cor)
                            {
                                return new RetornoRegraDTO(casas[posicaoParse[0], posicaoParse[1]], true);
                            }
                            else
                            {
                                return new RetornoRegraDTO(pecaVazio, false);
                            }
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
            }
            return new RetornoRegraDTO(pecaVazio, false);
        }

        private RetornoRegraDTO RegraCavalo(Pecas[,] casas, Pecas peca, int[] posicao, int[] movimento)
        {
            int parametroLinha = posicao[0] - movimento[0];
            int parametroColuna = posicao[1] - movimento[1];
            if (peca.Cor == EnumCores.Brancas)
            {
                if (parametroLinha == -2)
                {
                    if (parametroColuna == -1 || parametroColuna == 1)
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Pretas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else if (parametroLinha == -1)
                {
                    if (parametroColuna == -2 || parametroColuna == 2)
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Pretas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else if (parametroLinha == 1)
                {
                    if (parametroColuna == -2 || parametroColuna == 2)
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Pretas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else if (parametroLinha == 2)
                {
                    if (parametroColuna == -1 || parametroColuna == 1)
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Pretas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else
                {
                    return new RetornoRegraDTO(pecaVazio, false);
                }
            }
            else
            {
                if (parametroLinha == -2)
                {
                    if (parametroColuna == -1 || parametroColuna == 1)
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Brancas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else if (parametroLinha == -1)
                {
                    if (parametroColuna == -2 || parametroColuna == 2)
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Brancas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else if (parametroLinha == 1)
                {
                    if (parametroColuna == -2 || parametroColuna == 2)
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Brancas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else if (parametroLinha == 2)
                {
                    if (parametroColuna == -1 || parametroColuna == 1)
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                                       && casas[movimento[0], movimento[1]].Cor == EnumCores.Brancas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else
                {
                    return new RetornoRegraDTO(pecaVazio, false);
                }
            }
        }

        private RetornoRegraDTO RegraTorre(Pecas[,] casas, Pecas peca, int[] posicao, int[] movimento)
        {
            int parametroLinha = posicao[0] - movimento[0];
            int parametroColuna = posicao[1] - movimento[1];

            List<string> posicoesPossiveis = new List<string>();
            bool pecasIntermediarias = false;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    if (posicao[1] < movimento[1])
                    {
                        for (int j = posicao[1] + 1; j < movimento[1]; j++)
                        {
                            posicoesPossiveis.Add($"{posicao[0]}.{j}");
                        }
                    }
                    else
                    {
                        for (int j = posicao[1] - 1; j > movimento[1]; j--)
                        {
                            posicoesPossiveis.Add($"{posicao[0]}.{j}");
                        }
                    }
                }
                else if (i == 1)
                {
                    if (posicao[0] < movimento[0])
                    {
                        for (int j = posicao[0] + 1; j < movimento[0]; j++)
                        {
                            posicoesPossiveis.Add($"{j}.{posicao[1]}");

                        }
                    }
                    else
                    {
                        for (int j = posicao[0] - 1; j > movimento[0]; j--)
                        {
                            posicoesPossiveis.Add($"{j}.{posicao[1]}");
                        }
                    }
                }
            }

            foreach (string posicaoFor in posicoesPossiveis)
            {
                string[] posicaoForSplit = posicaoFor.Split(".");
                int[] posicoesForParse = { int.Parse(posicaoForSplit[0]), int.Parse(posicaoForSplit[1]) };
                if (casas[posicoesForParse[0], posicoesForParse[1]].Nome != EnumPecas.Vazio)
                {
                    pecasIntermediarias = true;
                    break;
                }
            }

            if (!pecasIntermediarias)
            {
                if (peca.Cor == EnumCores.Brancas)
                {
                    if ((parametroLinha != 0 && parametroColuna == 0)
                        || (parametroLinha == 0 && parametroColuna != 0))
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Pretas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else
                {
                    if ((parametroLinha != 0 && parametroColuna == 0)
                        || (parametroLinha == 0 && parametroColuna != 0))
                    {
                        if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                        {
                            return new RetornoRegraDTO(pecaVazio, true);
                        }
                        else if (casas[movimento[0], movimento[1]].Nome != EnumPecas.Vazio
                                && casas[movimento[0], movimento[1]].Cor == EnumCores.Brancas)
                        {
                            return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                        }
                        else
                        {
                            return new RetornoRegraDTO(pecaVazio, false);
                        }
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
            }
            else
            {
                return new RetornoRegraDTO(pecaVazio, false);
            }
        }

        private RetornoRegraDTO RegraBispo(Pecas[,] casas, Pecas peca, int[] posicao, int[] movimento)
        {
            int subLinha = posicao[0] - movimento[0];
            int subColuna = posicao[1] - movimento[1];
            if (subLinha == subColuna || -1 * subLinha == subColuna)
            {
                List<string> posicoesPossiveis = new List<string>();
                bool pecasIntermediarias = false;

                if (posicao[0] > movimento[0] && posicao[1] > movimento[1])
                {
                    int quantidade = subLinha;
                    posicoesPossiveis = LoopForBispo(casas, posicoesPossiveis, posicao, -1, -1,  quantidade);
                }
                if (posicao[0] < movimento[0] && posicao[1] < movimento[1])
                {
                    int quantidade = -subLinha;
                    posicoesPossiveis = LoopForBispo(casas, posicoesPossiveis, posicao, +1, +1, quantidade);
                }
                if (posicao[0] > movimento[0] && posicao[1] < movimento[1])
                {
                    int quantidade = subLinha;
                    posicoesPossiveis = LoopForBispo(casas, posicoesPossiveis, posicao, -1, +1, quantidade);
                }
                if (posicao[0] < movimento[0] && posicao[1] > movimento[1])
                {
                    int quantidade = -subLinha;
                    posicoesPossiveis = LoopForBispo(casas, posicoesPossiveis, posicao, +1, -1, quantidade);
                }

                foreach (string pecaFor in posicoesPossiveis)
                {
                    string[] pecaForSplit = pecaFor.Split(".");
                    int[] pecaForParse = { int.Parse(pecaForSplit[0]), int.Parse(pecaForSplit[1]) };
                    if (casas[pecaForParse[0], pecaForParse[1]].Nome != EnumPecas.Vazio)
                    {
                        pecasIntermediarias = true;
                        break;
                    }
                }
                if (!pecasIntermediarias)
                {
                    if (casas[movimento[0], movimento[1]].Nome == EnumPecas.Vazio)
                    {
                        return new RetornoRegraDTO(pecaVazio, true);
                    }
                    else if (casas[movimento[0], movimento[1]].Cor != peca.Cor)
                    {
                        return new RetornoRegraDTO(casas[movimento[0], movimento[1]], true);
                    }
                    else
                    {
                        return new RetornoRegraDTO(pecaVazio, false);
                    }
                }
                else
                {
                    return new RetornoRegraDTO(pecaVazio, false);
                }
            }
            else
            {
                return new RetornoRegraDTO(pecaVazio, false);
            }
        }

        public List<string> LoopForBispo(Pecas[,] casas, List<string> posicoesPossiveis, int[] posicaoAtual, int parametroLinha, int parametroColuna, int quantidade)
        {
            for (int i = 1; i < quantidade; i++)
            {
                int linha = posicaoAtual[0] + (parametroLinha * i);
                int coluna = posicaoAtual[1] + (parametroColuna * i);
                if (casas[linha, coluna].Nome != EnumPecas.Vazio)
                {
                    posicoesPossiveis.Add($"{linha}.{coluna}");
                }
            }
            return posicoesPossiveis;
        }

        private RetornoRegraDTO RegraRainha(Pecas[,] casas, Pecas peca, int[] posicao, int[] movimento)
        {
            RetornoRegraDTO verificacaoUm = RegraTorre(casas, peca, posicao, movimento);
            RetornoRegraDTO verificacaoDois = RegraBispo(casas, peca, posicao, movimento);
            if (verificacaoUm.Autorizado)
            {
                return verificacaoUm;
            }
            else if (verificacaoDois.Autorizado)
            {
                return verificacaoDois;
            }
            else
            {
                return new RetornoRegraDTO(pecaVazio, false);
            }
        }

        private bool JogadorAtual(Pecas peca, Jogador jogador)
        {
            if (jogador.Cor == peca.Cor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool XequeReiDiagonais(Pecas[,] casas, Pecas pecaRei, int[] posicaoRei)
        {
            List<string> posicaoPecasGerandoXeque = new List<string>();
            bool reiXeque = false;

            posicaoPecasGerandoXeque = LoopForReiXequeDiagonais(casas, posicaoPecasGerandoXeque, posicaoRei, -1, -1);
            posicaoPecasGerandoXeque = LoopForReiXequeDiagonais(casas, posicaoPecasGerandoXeque, posicaoRei, -1, +1);
            posicaoPecasGerandoXeque = LoopForReiXequeDiagonais(casas, posicaoPecasGerandoXeque, posicaoRei, +1, -1);
            posicaoPecasGerandoXeque = LoopForReiXequeDiagonais(casas, posicaoPecasGerandoXeque, posicaoRei, +1, +1);

            foreach (string pecaFor in posicaoPecasGerandoXeque)
            {
                string[] pecaForSplit = pecaFor.Split(".");
                int[] pecaForParse = { int.Parse(pecaForSplit[0]), int.Parse(pecaForSplit[1]) };
                if (pecaRei.Cor != casas[pecaForParse[0], pecaForParse[1]].Cor)
                {
                    if (casas[pecaForParse[0], pecaForParse[1]].Nome == EnumPecas.Bispo
                        || casas[pecaForParse[0], pecaForParse[1]].Nome == EnumPecas.Rainha)
                    {
                        reiXeque = true;
                        break;
                    }
                    else if (casas[pecaForParse[0], pecaForParse[1]].Nome == EnumPecas.Peao)
                    {
                        if (RegraPeao(casas, casas[pecaForParse[0], pecaForParse[1]], pecaForParse, posicaoRei).Autorizado)
                        {
                            reiXeque = true;
                            break;
                        }
                    }
                    else if (casas[pecaForParse[0], pecaForParse[1]].Nome == EnumPecas.Rei)
                    {
                        if (RegraRei(casas, casas[pecaForParse[0], pecaForParse[1]], pecaForParse, posicaoRei).Autorizado)
                        {
                            reiXeque = true;
                            break;
                        }
                    }
                }
            }
            return reiXeque;
        }
        public List<string> LoopForReiXequeDiagonais(Pecas[,] casas, List<string> posicaoPecasGerandoXeque, int[] posicaoRei, int parametroLinha, int parametroColuna)
        {
            for (int i = 1; i < 9; i++)
            {
                int linha = posicaoRei[0] + (parametroLinha * i);
                int coluna = posicaoRei[1] + (parametroColuna * i);
                if (linha < 8 && linha >= 0 && coluna < 8 && coluna >= 0)
                {
                    if (casas[linha, coluna].Nome != EnumPecas.Vazio)
                    {
                        posicaoPecasGerandoXeque.Add($"{linha}.{coluna}");
                        return posicaoPecasGerandoXeque;
                    }
                }
                else
                {
                    return posicaoPecasGerandoXeque;
                }
            }
            return posicaoPecasGerandoXeque;
        }

        private bool XequeReiMovimentoL(Pecas[,] casas, Pecas pecaRei, int[] posicaoRei)
        {
            bool reiXeque = false;
            string posicoes =
                $"{posicaoRei[0] - 1}.{posicaoRei[1] - 2};{posicaoRei[0] - 1}.{posicaoRei[1] + 2};" +
                $"{posicaoRei[0] - 2}.{posicaoRei[1] - 1};{posicaoRei[0] - 2}.{posicaoRei[1] + 1};" +
                $"{posicaoRei[0] + 1}.{posicaoRei[1] - 2};{posicaoRei[0] + 1}.{posicaoRei[1] + 2};" +
                $"{posicaoRei[0] + 2}.{posicaoRei[1] - 1};{posicaoRei[0] + 2}.{posicaoRei[1] + 1}";

            string[] posicoesUnitarias = posicoes.Split(";");

            for (int i = 0; i < 8; i++)
            {
                string[] posicaoSplit = posicoesUnitarias[i].Split(".");
                int[] posicaoParse = { int.Parse(posicaoSplit[0]), int.Parse(posicaoSplit[1]) };
                if (posicaoParse[0] > -1 && posicaoParse[0] < 8
                    && posicaoParse[1] > -1 && posicaoParse[1] < 8)
                {
                    if (casas[posicaoParse[0], posicaoParse[1]].Nome == EnumPecas.Cavalo)
                    {
                        if (casas[posicaoParse[0], posicaoParse[1]].Cor != pecaRei.Cor)
                        {
                            reiXeque = true;
                            break;
                        }
                    }
                }
            }
            return reiXeque;
        }

        private bool XequeReiHorizontalVertical(Pecas[,] casas, Pecas pecaRei, int[] posicaoRei)
        {
            List<string> posicaoPecasGerandoXeque = new List<string>();
            bool reiXeque = false;
            int j;
            int h;

            for (j = posicaoRei[0] + 1; j < 8; j++)
            {
                if (casas[j, posicaoRei[1]].Nome != EnumPecas.Vazio)
                {
                    posicaoPecasGerandoXeque.Add($"{j}.{posicaoRei[1]}");
                    j = 8; //Break
                }
            }
            for (h = posicaoRei[0] - 1; h > -1; h--)
            {
                if (casas[h, posicaoRei[1]].Nome != EnumPecas.Vazio)
                {
                    posicaoPecasGerandoXeque.Add($"{h}.{posicaoRei[1]}");
                    h = -1; //Break
                }
            }
            for (j = posicaoRei[1] + 1; j < 8; j++)
            {
                if (casas[posicaoRei[0], j].Nome != EnumPecas.Vazio)
                {
                    posicaoPecasGerandoXeque.Add($"{posicaoRei[0]}.{j}");
                    j = 8; //Break
                }
            }
            for (h = posicaoRei[1] - 1; h > -1; h--)
            {
                if (casas[posicaoRei[0], h].Nome != EnumPecas.Vazio)
                {
                    posicaoPecasGerandoXeque.Add($"{posicaoRei[0]}.{h}");
                    h = -1; //Break
                }
            }

            foreach (string pecaFor in posicaoPecasGerandoXeque)
            {
                string[] pecaForSplit = pecaFor.Split(".");
                int[] pecaForParse = { int.Parse(pecaForSplit[0]), int.Parse(pecaForSplit[1]) };
                if (pecaRei.Cor != casas[pecaForParse[0], pecaForParse[1]].Cor)
                {
                    if (casas[pecaForParse[0], pecaForParse[1]].Nome == EnumPecas.Torre
                        || casas[pecaForParse[0], pecaForParse[1]].Nome == EnumPecas.Rainha)
                    {
                        reiXeque = true;
                        break;
                    }
                    else if (casas[pecaForParse[0], pecaForParse[1]].Nome == EnumPecas.Rei)
                    {
                        if (RegraRei(casas, casas[pecaForParse[0], pecaForParse[1]], pecaForParse, posicaoRei).Autorizado)
                        {
                            reiXeque = true;
                            break;
                        }
                    }
                }
            }
            return reiXeque;
        }

        public bool XequeRei(Pecas[,] casas, Jogador jogadorAtual)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (casas[i, j].Nome == EnumPecas.Rei)
                    {
                        if (jogadorAtual.Cor == casas[i, j].Cor)
                        {
                            int[] posicaoRei = { i, j };
                            if (XequeReiHorizontalVertical(casas, casas[i, j], posicaoRei)
                                || XequeReiMovimentoL(casas, casas[i, j], posicaoRei)
                                || XequeReiDiagonais(casas, casas[i, j], posicaoRei))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}























