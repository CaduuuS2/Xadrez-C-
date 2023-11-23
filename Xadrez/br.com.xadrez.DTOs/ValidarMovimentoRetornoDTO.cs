
using Xadrez.br.com.xadrez.domain;

namespace Xadrez.br.com.xadrez.DTOs
{
    internal class ValidarMovimentoRetornoDTO
    {
        public Pecas[,] Casas { get; set; }
        public bool Autorizado { get; set; }

        public bool ReiXeque { get; set; }

        public ValidarMovimentoRetornoDTO(Pecas[,] casas, bool autorizado, bool reiXeque)
        {
            Casas = casas;
            Autorizado = autorizado;
            ReiXeque = reiXeque;
        }
    }
}
