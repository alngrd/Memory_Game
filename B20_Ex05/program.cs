using System.Windows.Forms;

namespace B20_Ex05
{
    class program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            AppRunner MemoryGame = new AppRunner();
            MemoryGame.RunGame();
        }
    }
}
