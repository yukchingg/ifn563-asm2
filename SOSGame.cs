using System;
namespace Assignment1
{

    public class SOSGame : Game
    {
        public override Player[] CreatePlayers(bool computerPlayerExist)
        {
            Player[] players = new Player[2];

            //First player must be Human player
            players[0] = new HumanPlayer(1, 0);

            if (computerPlayerExist == true)
            {
                players[1] = new ComputerPlayer(2, 0);
            }

            else
            {
                players[1] = new HumanPlayer(2, 0);
            }

            return players;
        }

        public override char[,] CreateGrid(int gridSize)
        {
            char[,] board = new char[gridSize, gridSize];
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    board[i, j] = ' ';
                }
            }
            return board;
        }

        public override void NewOrLoad(bool loadGame, Game game)
        {
            
            if (loadGame == true)
            {
                LoadGame(game);
            }

            else
            {
                StartNewGame(game);
            }
        }

        public override void StartNewGame(Game game1)
        {
            // Set up the game
            int gridSize = 3;

            bool isComputerPlayer = Launcher.HumanOrAI();
            Player[] players = game1.CreatePlayers(isComputerPlayer);
            char[,] board = game1.CreateGrid(gridSize);
            GamingBoard.DisplayBoard(players[0], players[1], board);

            // Start the game loop
            PlayGame(players, board);
        }

        public override void LoadGame(Game game1)
        {
            var saveInfo = GameSave.ReadSaveGame();
            char[,] board = saveInfo.Item1;
            //Create player according to the save file
            Player[] players = game1.CreatePlayers(saveInfo.Item5 == 'A');
            //Allocate the player score
            players[0].PlayerScore = saveInfo.Item2;
            players[1].PlayerScore = saveInfo.Item3;
            GamingBoard.DisplayBoard(players[0], players[1], board);
            PlayGame(players, board, saveInfo.Item4 - 1);
        }

        public override void PlayGame(Player[] players, char[,] board, int startPlayerID = 0)
        {
            Stack<TurnRecord> gameHistory = new Stack<TurnRecord>();
            int gridSize = board.GetLength(0);
            string userAction;
            int currentMoveRow, currentMoveCol;
            bool currentGameEnd = false;
            bool extraTurn = false;
            bool turnStartAgain;
            Player currentPlayer = players[startPlayerID];
            TurnRecord.SaveMove(board, players[0], players[1], gameHistory);
            while (!currentGameEnd)
            {
                //Make a move
                turnStartAgain = false;
                userAction = currentPlayer.SelectAction(currentPlayer);
                if (userAction == "M")
                {
                    //Human player makes a move and the system validates the move, AI player makes a random move
                    currentPlayer.MakeMove(out currentMoveRow, out currentMoveCol, currentPlayer, currentPlayer.ChooseToken(currentPlayer), board);

                    //Save the move in stack automatically
                    TurnRecord.SaveMove(board, players[0], players[1], gameHistory);

                    //Check if the player scored and eligible for an extra turn
                    extraTurn = GamingBoard.ScoringDetect(currentMoveRow, currentMoveCol, currentPlayer, board);

                    //Display the player scores and the grid 
                    GamingBoard.DisplayBoard(players[0], players[1], board);

                    //Check if the game ended
                    currentGameEnd = GamingBoard.CheckEnd(gridSize, board);
                    if (currentGameEnd == true)
                    {
                        GamingBoard.CheckWin(players);
                    }
                }

                //Undo a move
                else if (userAction == "U")
                {
                     var undoInfo = TurnRecord.UndoMove(board, players[0], players[1], gameHistory);

                     board = undoInfo.Item1;
                     players[0].PlayerScore = undoInfo.Item2;
                     players[1].PlayerScore = undoInfo.Item3;
                     GamingBoard.DisplayBoard(players[0], players[1], board);
                     TurnRecord turnHistory = new TurnRecord(board, players[0].PlayerScore, players[1].PlayerScore);
                     gameHistory.Push(turnHistory);
                     extraTurn = true;
                }

                //save
                else if (userAction == "S")
                {
                    GameSave.SaveGame(board, players[0], players[1],currentPlayer.PlayerID);
                    currentGameEnd = true;
                }

                //help
                else if (userAction == "H")
                {
                    Help.GameHelp();
                    turnStartAgain= true;
                    GamingBoard.DisplayBoard(players[0], players[1], board);
                }

                //quit
                else
                {
                    currentGameEnd = true;
                }

                // Switch to the next player
                if (extraTurn == false && turnStartAgain ==false)
                {
                    currentPlayer = (currentPlayer == players[0]) ? players[1] : players[0];
                }

            }
        }
    }
}

