using Xadrez.br.com.xadrez.services;

namespace Xadrez.br.com.xadrez.main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MenuService menu = new MenuService();
            menu.MenuInicio();
        }
    }
}
