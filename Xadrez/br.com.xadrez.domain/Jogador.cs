using Xadrez.br.com.xadrez.enums;

namespace Xadrez.br.com.xadrez.domain
{
    public class Jogador
    {
        public string Nome{ get; set; }
        public EnumCores Cor { get; set; }

        public Jogador(string nome, EnumCores cor)
        {
            Nome = nome;
            Cor = cor;
        }
    }
}
