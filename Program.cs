using System.Drawing;
using System.Collections.Generic;

namespace Assignment1;
class Program
{
    static void Main(string[] args)
    {
        Game currentGame = Launcher.ChooseGame();
        Help.GameHelp();
        currentGame.NewOrLoad(Launcher.NewOrLoad(), currentGame);
        Console.WriteLine("The game ends! Thank you for playing!");
        Console.ReadKey();
    }

}

