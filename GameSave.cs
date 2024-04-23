using System;
using System.IO;

namespace Assignment1
{
	public class GameSave
	{
        public string Board { get; set; }
        public string PlayerScore1 { get; set; }
        public string PlayerScore2 { get; set; }
        public string CurrentPlayerID { get; set; }
        public string GameMode { get; set; }

        public GameSave()
		{

        }

		public static void SaveGame(char[,] board, Player player1, Player player2, int currentPlayerID)
        {
            const char DELIM = ',';
            const string FILENAME = "GameSaves.txt";

            GameSave save1 = new GameSave();
            FileStream outFile = new FileStream(FILENAME, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);

            // Convert the board array to a string representation
            string boardString = BoardToString(board);
            save1.Board = boardString;
            save1.PlayerScore1 = Convert.ToString(player1.PlayerScore);
            save1.PlayerScore2 = Convert.ToString(player2.PlayerScore);
            save1.CurrentPlayerID = Convert.ToString(currentPlayerID);

            if(player2 is HumanPlayer)
            {
                save1.GameMode = "H";
            }
            else
            {
                save1.GameMode = "A";
            }

            writer.WriteLine(save1.Board + DELIM + save1.PlayerScore1 + DELIM + save1.PlayerScore2
                + DELIM + save1.CurrentPlayerID + DELIM + save1.GameMode);
            writer.Close();
            outFile.Close();
        }

        public static (char[,], int, int, int, char) ReadSaveGame()
        {
            const char DELIM = ',';
            const string FILENAME = "GameSaves.txt";
            GameSave save1 = new GameSave();
            FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            string recordIn;
            string[] fields;
            recordIn = reader.ReadLine();
            fields = recordIn.Split(DELIM);
            save1.Board = fields[0];
            save1.PlayerScore1 = fields[1];
            save1.PlayerScore2 = fields[2];
            save1.CurrentPlayerID = fields[3];
            save1.GameMode = fields[4];

            reader.Close();
            inFile.Close();

            return (StringToBoard(save1.Board), Convert.ToInt32(save1.PlayerScore1),
                Convert.ToInt32(save1.PlayerScore2), Convert.ToInt32(save1.CurrentPlayerID),
                Convert.ToChar(save1.GameMode));
        }

        // Converts the board array to a string representation
        public static string BoardToString(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            string boardString = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    boardString += board[i, j];
                }
            }

            return boardString;
        }

        public static char[,] StringToBoard(string boardString)
        {
            int gridSize = (int)Math.Sqrt(boardString.Length);
            char[,] board = new char[gridSize, gridSize];
            int index = 0;

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    board[i, j] = boardString[index];
                    index++;
                }
            }

            return board;
        }
    }
}

