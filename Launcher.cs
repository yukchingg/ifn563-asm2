using System;
namespace Assignment1
{
	public class Launcher
	{
		public Launcher()
		{
		}

        public static Game ChooseGame()
        {
            string GameCode;

            Console.WriteLine("Please select the game: " +
                "\n S: SOS Game" +
                "\n C: Connect four");
            GameCode = Console.ReadLine().ToUpper();

            while (true)
            {
                if (GameCode == "S")
                {
                    Game game1 = new SOSGame();
                    return game1;
                }

                else if (GameCode == "C")
                {
                    Console.WriteLine("The game is under development. Please play SOS game first^^");
                    Game game1 = new SOSGame();
                    return game1;
                }

                else
                {
                    Console.WriteLine("Invalid input. Please try again!");
                    Console.WriteLine("Please select the game: " +
                    "\n S: SOS Game" +
                    "\n C: Connect four");
                    GameCode = Console.ReadLine().ToUpper();
                }
            }          
        }

        public static bool NewOrLoad()
        {
            
            Console.WriteLine("Do you want to load a saved game?" +
                "\nY: Yes N: No");
            string userInput = Console.ReadLine().ToUpper();

            while (true)
            {
                if (userInput == "Y")
                {
                    return true;
                }

                else if (userInput == "N")
                {
                    return false;
                }

                else
                {
                    Console.WriteLine("Valid Input! Please choose again!");
                    Console.WriteLine("Do you want to load a saved game?" +
                    "\nY: Yes N: No");
                    userInput = Console.ReadLine().ToUpper();
                }
            }

        }

        //In future development, it is assumed that not every game has AI mode.
        //Therefore, I have put the method running in the SOS game class instead
        //of encapsulate it with ChooseGame().
        public static bool HumanOrAI()
        {
            string userInput;
            Console.WriteLine("Please choose the mode:" +
                "\nHuman: 0 \nAI: 1");
            userInput = Console.ReadLine();

            while (true)
            {
                if (userInput != "0" && userInput != "1")
                {
                    Console.WriteLine("Invalid Input!");
                    Console.WriteLine("Please choose the mode:" +
                    "Human: 0, AI: 1");
                    userInput = Console.ReadLine();
                }
                else
                {
                    return userInput == "1"; 
                }
            }
        }

    }

}

