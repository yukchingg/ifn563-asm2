using System;

namespace Assignment1
{
    public abstract class Game
    {
        public int GameID { get; set; }
        public Game()
        {
        }
        public abstract Player[] CreatePlayers(bool computerPlayerExist);
        public abstract char[,] CreateGrid(int gridSize);
        public abstract void NewOrLoad(bool loadGame, Game game);
        public abstract void StartNewGame(Game game1);
        public abstract void LoadGame(Game game1);
        public abstract void PlayGame(Player[] players, char[,] board, int startPlayerID = 0);

    }

}

