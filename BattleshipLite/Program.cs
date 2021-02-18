using System;
using BattleShipLiteLibrary.Models;
using Microsoft.SqlServer.Server;

namespace BattleshipLite
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WelcomeMessage();
            Console.WriteLine("Try test 1");
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Hello Everyone. Welcome to Battleship Lite Game");
            Console.WriteLine("Created and coded by OphyBoamah");
        }

        private static PlayerInfoModel CreatePlayer()
        {
            PlayerInfoModel output = new PlayerInfoModel();
            
            //Ask the user for their name
            //Load up the shot grid
            //Ask the user for their 5 ship placement
            //Clear
            
        }

        private static string AskForUsersName()
        {
            Console.Write("What is your name? \n");
            string output = Console.ReadLine();

            return output;
        }
    }
}