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
            PlayerInfoModel activePlayer = CreatePlayer("Player 1");
            PlayerInfoModel opponent = CreatePlayer("Player 2");
            PlayerInfoModel winner = null;

            do
            {
                //Display grid of activePlayer on where they fired
                DisplayShotGrid(activePlayer);
                //Ask activePlayer for point
                //Determine if it is a valid shot
                //Determine shot results
                RecordPlayerShot(activePlayer);
                //Determine if the game is over
                //If game is over, set activePlayer as winner
                //else, swap positions (activePlayer to opponent)

            } while (winner == null);
            
            Console.ReadLine();
        }

        private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            //Asks for a shot (we ask for "B2")
            //Determine what row and column that is
            //Determine if that is not a valid 
            //Go back to the beginning if not a valid shot
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrid[0].SpotLetter;
            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }
                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.WriteLine($"{gridSpot.SpotLetter}{gridSpot.SpotNumber}");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.WriteLine("X");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.WriteLine("O");
                }
                else
                {
                    Console.WriteLine("?");
                }
            }
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