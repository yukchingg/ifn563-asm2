using System;
namespace Assignment1
{
	public class GamingBoard
	{
		public int GridSize{ get; set; }

		public GamingBoard()
		{
		}

        public static void DisplayBoard(Player player1, Player player2, char[,] board)
        {
            Console.WriteLine("\nPlayer 1 score: {0}", player1.PlayerScore);
            Console.WriteLine("Player 2 score: {0}", player2.PlayerScore);
            Console.WriteLine("\n     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |      ");
            Console.WriteLine("\n______________________________ ");

        }


        public static bool ScoringDetect(int row, int col,Player currentPlayer, char[,] board)
        {
            int roundScore = 0;

            //Check horizontally
            if (
             board[row, 0] == 'S' && board[row, 1] == 'O' && board[row, 2] == 'S')
            {
                roundScore++;
            }

            // Check vertically
            if (
                board[0, col] == 'S' && board[1, col] == 'O' && board[2, col] == 'S')
            {
                roundScore++;
            }

            // Check diagonally (top-left to bottom-right)
            if (row == col && board[0, 0] == 'S' && board[1, 1] == 'O' && board[2, 2] == 'S')
            {
                roundScore++;
            }

            // Check diagonally (top-left to bottom-right)
            if (((row == 0 && col == 2) || (row == 1 && col == 1) || (row == 2 && col == 0))
               && board[2, 0] == 'S' && board[1, 1] == 'O' && board[0, 2] == 'S')
            {
                roundScore++;
            }

            if (roundScore != 0)
            {
                currentPlayer.PlayerScore += roundScore;
                Console.WriteLine("\nPlayer " + currentPlayer.PlayerID + " has scored " + roundScore + "!");
                Console.WriteLine("Player " + currentPlayer.PlayerID + " has gained an extra turn!");
                return true;
            }

            return false;

        }

        public static bool CheckEnd(int gridsize, char[,] board)
        {
            for (int i = 0; i < gridsize; i++)
            {
                for (int j = 0; j < gridsize; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void CheckWin(Player[] players)
        {
            if (players[0].PlayerScore > players[1].PlayerScore)
            {
                Console.WriteLine("\nCongratulations! Player {0} has won the game!", players[0].PlayerID);
            }

            else if (players[0].PlayerScore < players[1].PlayerScore)
            {
                Console.WriteLine("\nCongratulations! Player {0} has won the game!", players[1].PlayerID);
            }

            else
            {
                Console.WriteLine("\nThe game is draw. GG!");
            }
        }
    }

}

