using System;
namespace Assignment1
{
	public class Help
	{
		public Help()
		{
		}

        public static void Intro()
        {
            Console.WriteLine("\nSOS gmae Introduction:" +
                "\n" +
                "\nTwo players take turns to add either an S or an Oon a 3x3 board." +
                "\n If a player makes the sequence SOS vertically, horizontally or diagonally," +
                "\n they get a point and also take another turn." +
                "\n Once the grid has been filled up, the winner is the player who has more points." +
                "\n__________________________________________________________________");
        }

        public static void GameTutorial()
        {
            Console.WriteLine("\nSOS game Tutorial:" +
                "\n" +
                "\n1. At the start of the game, you can choose human mode or AI mode." +
                "\n2. At the start of your turn, you can choose your actions shown by system." +
                "\n3. If you choose to move, you should choose your token between \"S\" and \"O\" ." +
                "\n4. Afterwards, you have to choose the box to place the token." +
                "\n   First, insert the row you want to place." +
                "\n   Second, insert the column you want to place." +
                "\n" +
                "\n     |     |      " +
                "\n     |     |   S  < Row1" +
                "\n_____|_____|_____ " +
                "\n     |     |      " +
                "\n     |     |      " +
                "\n_____|_____|_____ " +
                "\n     |     |      " +
                "\n  O  |     |      " +
                "\n     |     |      " +
                "\n   ^" +
                "\nColumn1" +
                "\n" +
                "\n\"S\" is row 1, col 3" +
                "\n\"O\" is row 3, col 1 " +
                "\n5. If you score, gain an extra turn." +
                "\n__________________________________________________________________");
        }

        public static void GameRule()
        {
            Console.WriteLine("\nSOS game rule:" +
                "\n" +
                "\n1. You cannot place symbols on the box that is already occupied." +
                "\n2. You can only place \"S\" or \"O\" symbol." +
                "\n3. You can enable undo and redo function at the start of your turn." +
                "\n__________________________________________________________________");
        }

        public static void GameHelp()
        {
            Intro();
            GameTutorial();
            GameRule();
        }

    }

}

