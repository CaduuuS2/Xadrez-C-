
using Xadrez.br.com.xadrez.domain;

namespace Xadrez.br.com.xadrez.DTOs
{
    public class RetornoRegraDTO
    {
        public Pecas PecaDerrubada { get; set; }
        public bool Autorizado { get; set; }

        public RetornoRegraDTO(Pecas pecaDerrubada, bool autorizado)
        {
            PecaDerrubada = pecaDerrubada;
            Autorizado = autorizado;
        }
    }
}
