
using System.ComponentModel;

namespace Xadrez.br.com.xadrez.enums
{
    public enum EnumPecas
    {
        [Description("Peão")]
        Peao = 0,
        [Description("Cavalo")]
        Cavalo = 1,
        [Description("Torre")]
        Torre = 2,
        [Description("Bispo")]
        Bispo = 3,
        [Description("Rainha")]
        Rainha = 4,
        [Description("Rei")]
        Rei = 5,
        [Description("Vazio")]
        Vazio = 6
    }
}
