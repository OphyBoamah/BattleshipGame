using System;
using System.Reflection;
using BattleShipLiteLibrary;
using BattleShipLiteLibrary.Models;
using Microsoft.SqlServer.Server;

namespace BattleshipLite
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WelcomeMessage();
            PlayerInfoModel player1 = CreatePlayer("Player 1");
            PlayerInfoModel player2 = CreatePlayer("Player 2");
            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Hello Everyone. Welcome to Battleship Lite Game");
            Console.WriteLine("Created and coded by OphyBoamah");
            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();
            Console.WriteLine($"Player information for {playerTitle}");
            //Ask the user for their name
            output.UsersName = AskForUsersName();
            //Load up the shot grid
             GameLogic.InitializeGrid(output);
            //Ask the user for their 5 ship placement
            PlaceShips(output);
            //Clear
            return output;
        }

        private static string AskForUsersName()
        {
            Console.Write("What is your name? \n");
            string output = Console.ReadLine();

            return output;
        }

        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.WriteLine($"Where do you want to place your next ship? {model.ShipLocations.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(model, location);

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again");
                }
            } while (model.ShipLocations.Count < 5);
        }
    }
}