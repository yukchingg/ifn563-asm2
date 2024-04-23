using System;
namespace Assignment1
{
	public class TurnRecord
	{

        public char[,] Board { get; }
        public int Player1Score { get; }
        public int Player2Score { get; }

        public TurnRecord(char[,] board, int player1Score, int player2Score)
        {
            Board = board.Clone() as char[,];
            Player1Score = player1Score;
            Player2Score = player2Score;
        }

        public static void SaveMove(char[,] board, Player player1, Player player2, Stack<TurnRecord> gameHistory)
        {
            TurnRecord turnHistory = new TurnRecord(board, player1.PlayerScore, player2.PlayerScore);
            gameHistory.Push(turnHistory);
        }

        public static (char[,],int,int) UndoMove(char[,] board, Player player1, Player player2, Stack<TurnRecord> gameHistory)
        {
            {
                TurnRecord turnRecord = gameHistory.Pop();
                while (true)
                {

                    if (gameHistory.Count >= 2)
                    {
                        TurnRecord turnRecord1 = gameHistory.Pop();
                        TurnRecord turnRecord2 = gameHistory.Pop();

                        // Restore the game state
                        board = turnRecord2.Board;
                        player1.PlayerScore = turnRecord2.Player1Score;
                        player2.PlayerScore = turnRecord2.Player2Score;

                        return (board, player1.PlayerScore, player2.PlayerScore);
                    }

                    else
                    {
                        Console.WriteLine("Not enough moves to undo.");
                        return (board, player1.PlayerScore, player2.PlayerScore);
                    }
                }
                
            }

        }
    }
}

