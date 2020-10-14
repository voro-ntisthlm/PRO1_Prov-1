using System;

namespace Battleship
{
    class Program
    {

        static void Main(string[] args)
        {
            bool isRunning = true;
            int xWidth = 10;
            int shipCord;


            //This will generate the ship on a random position of 0 to 10 and 
            shipCord = GenerateMap();

            while(isRunning){
                int playerCord = InputHandler();
                
                if(ValidateHit(shipCord, playerCord, xWidth)){
                    Console.Write("Play again? [n/Y]: ");

                    //This will only check if the user typed in n or no and will then exit the program by setting the "isRunning" variable to false.
                    switch(Console.ReadLine().ToLower()){
                        case "n":
                        case "no":
                            isRunning = false;
                        break;
                    }
                }

            }    
        }

        static int InputHandler(){
            //This will create an array of args
            string[] args;
            int playerCord = 0;

            Console.WriteLine("Type a whole number between [0 to 10]:");
            args = Console.ReadLine().Split(" ");


            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                case "-gen":
                    //This will regenerate the map ie, the ship position.
                    GenerateMap();
                    Console.WriteLine("New location generated");
                    break;
                default:

                    try
                    {
                        playerCord = int.Parse(args[i]);

                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Number not detected, please enter a number or a valid command.");
                    }


                    break;
                }

            }

            return playerCord;
            
        }

        static bool ValidateHit(int _shipCord, int _playerCord, int _xWidth){
            
            if (_playerCord <= _xWidth && _playerCord >= 0 && _shipCord == _playerCord)
            {
                Console.WriteLine("HIT!\n");
                return true;
            }
            else if(_playerCord > _xWidth || _playerCord < 0 )
            {
                Console.WriteLine("Please enter a cordinate within the valid range.");
                return false;
            }
            else{
                Console.WriteLine("MISS!\n");
                return false;        
            }    
        }

        static int GenerateMap(){
            //This will generate the size of the "map" and will also place the ship at a cordinate.

            Random rng = new Random();

            return rng.Next(0,10);
        }
        
    }
}
