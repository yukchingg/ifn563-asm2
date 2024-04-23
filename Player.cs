using System;
namespace Assignment1
{
	public abstract class Player
	{
        public int PlayerID { get; set; }
        public int PlayerScore { get; set; }

        public Player() { }
        public Player(int ID, int score)
		{
            PlayerID = ID;
            PlayerScore = score;
		}

        public abstract string SelectAction(Player currentPlayer);
        public abstract char ChooseToken(Player currentPlayer);
        public abstract void MakeMove(out int currentMoveRow, out int currentMoveCol, Player currentPlayer, char token, char[,] board);
        
	}

    public class HumanPlayer : Player
    {
        public HumanPlayer() : base() { }
        public HumanPlayer(int ID, int score) : base(ID, score) { }

        public override string SelectAction(Player currentPlayer)
        {
            string userAction;
            Console.WriteLine("\nPlayer " + currentPlayer.PlayerID + ", Please choose action:" +
                "\nM: Make a move" +
                "\nS: Save the game" +
                "\nU: Undo your last step and redo" +
                "\nQ: Quit Game" +
                "\nH: Help");

            userAction = Console.ReadLine().ToUpper();
            do
            {
                if (userAction != "M" && userAction != "S" && userAction != "U" && userAction != "Q" && userAction != "H")
                {
                    Console.WriteLine("Invalid input. Please choose again!");
                    Console.WriteLine("Player " + currentPlayer.PlayerID + ", Please choose action:" +
                     "\n M: Make a move" +
                     "\nS: Save the game" +
                     "\nU: Undo your last step and redo" +
                     "\nQ: Quit Game" +
                     "\nH: Help");
                    userAction = Console.ReadLine().ToUpper();
                }
                else break;
            }
            while (true);
            return userAction;
        }

        public override char ChooseToken(Player currentPlayer)
        {
            char userInput;
            Console.WriteLine("\nPlayer " + currentPlayer.PlayerID + ", Please choose the token you want to place: S or O");
            userInput = Convert.ToChar(Console.ReadLine().ToUpper());
            do
            {
                if (userInput != 'S' && userInput != 'O')
                {
                    Console.WriteLine("Invalid input. Please choose again!");
                    Console.WriteLine("Please choose the token you want to place: S or O");
                    userInput = Convert.ToChar(Console.ReadLine().ToUpper());
                }
                else break;
            }
            while (true);
            return userInput;
        }

        public override void MakeMove(out int currentMoveRow, out int currentMoveCol,Player currentPlayer, char token, char[,] board)
        {
            {

                do
                {
                    Console.WriteLine("\nPlayer " + currentPlayer.PlayerID + ", Please enter the row and column of your move (1-3)");
                    currentMoveRow = int.Parse(Console.ReadLine()) - 1;
                    currentMoveCol = int.Parse(Console.ReadLine()) - 1;
                    if (currentMoveRow >= 0 && currentMoveRow <= 2 && currentMoveCol >= 0 && currentMoveCol <= 2)
                    {
                        if (board[currentMoveRow, currentMoveCol] == ' ')
                        {
                            board[currentMoveRow, currentMoveCol] = token;
                            //moves++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That space is already occupied. Please choose another.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    }
                } while (true);

            }

        }

    }

    public class ComputerPlayer: Player
	{
        public ComputerPlayer() : base() { }
        public ComputerPlayer(int ID, int score) : base(ID, score) { }

        public override string SelectAction(Player currentPlayer)
        {
            //Computer only makes move
            return "M";
        }

        public override char ChooseToken(Player currentPlayer)
        {
            //Randomly choose a token
            Random randomToken = new Random();
            int randomNumber = randomToken.Next(2); 

            if (randomNumber == 0)
            {
                return 'O';
            }
            else
            {
                return 'S';
            }
        }

        public override void MakeMove(out int currentMoveRow, out int currentMoveCol, Player currentPlayer, char token, char[,] board)
        {
            Random random = new Random();

            do
            {
                currentMoveRow = random.Next(0, board.GetLength(0));
                currentMoveCol = random.Next(0, board.GetLength(1));

                if (board[currentMoveRow, currentMoveCol] == ' ')
                {
                    board[currentMoveRow, currentMoveCol] = token;
                    Console.WriteLine("\nAI has made an move!");
                    break;
                }
            } while (true);
        }
    }
}

