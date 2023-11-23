using Xadrez.br.com.xadrez.enums;

namespace Xadrez.br.com.xadrez.domain
{
    public class Pecas
    {
        public string Id { get; set; }
        public EnumPecas Nome { get; set; }
        public EnumCores Cor { get; set; }

        public Pecas()
        {

        }

        public Pecas(EnumPecas nome)
        {
            Nome = nome;
        }

        public Pecas(string id, EnumPecas nome, EnumCores cor)
        {
            Id = id;
            Nome = nome;
            Cor = cor;
        }

        public Pecas[,] CriacaoPecas(Pecas[,] casas)
        {
            //Peões
            List<int> posicaoLinha = new List<int> { 1, 6 };
            List<int> posicaoColuna = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
            casas = ObjetoPeca(casas, posicaoLinha, posicaoColuna, EnumPecas.Peao, "P", 8);
            //Torres
            posicaoLinha = new List<int> { 0, 7 };
            posicaoColuna = new List<int> { 0, 7 };
            casas = ObjetoPeca(casas, posicaoLinha, posicaoColuna, EnumPecas.Torre, "T", 2);
            //Bispo
            posicaoLinha = new List<int> { 0, 7 };
            posicaoColuna = new List<int> { 2, 5 };
            casas = ObjetoPeca(casas, posicaoLinha, posicaoColuna, EnumPecas.Bispo, "B", 2);
            //Cavalo
            posicaoLinha = new List<int> { 0, 7 };
            posicaoColuna = new List<int> { 1, 6 };
            casas = ObjetoPeca(casas, posicaoLinha, posicaoColuna, EnumPecas.Cavalo, "C", 2);
            //Rei
            posicaoLinha = new List<int> { 0, 7 };
            posicaoColuna = new List<int> { 3 };
            casas = ObjetoPeca(casas, posicaoLinha, posicaoColuna, EnumPecas.Rei, "K", 1);
            //Rainha
            posicaoLinha = new List<int> { 0, 7 };
            posicaoColuna = new List<int> { 4 };
            casas = ObjetoPeca(casas, posicaoLinha, posicaoColuna, EnumPecas.Rainha, "Q", 1);
            //Vazios
            return ObjetoVazio(casas);
        }

        public Pecas[,] ObjetoPeca(Pecas[,] casas, List<int> posicaoLinha,
                List<int> posicaoColuna, EnumPecas tipo, string codigo, int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                string id = $"B{codigo}";
                Pecas peca = new Pecas(id, tipo, EnumCores.Brancas);
                casas[posicaoLinha[0], posicaoColuna[i]] = peca;
            }
            for (int i = 0; i < quantidade; i++)
            {
                string id = $"P{codigo}";
                Pecas peca = new Pecas(id, tipo, EnumCores.Pretas);
                casas[posicaoLinha[1], posicaoColuna[i]] = peca;
            }
            return casas;
        }

        public Pecas[,] ObjetoVazio(Pecas[,] casas)
        {
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Pecas peca = new Pecas(EnumPecas.Vazio);
                    casas[i, j] = peca;
                }
            }
            return casas;
        }
    }
}












