using System;

namespace Battleship
{
    class Program
    {

        static void Main(string[] args)
        {
            //Variables
            bool isRunning = true;
            int xWidth = 10;
            int shipCord;
            int playerCord;

            //This will generate the ship on a random position of 0 to 10 and 
            shipCord = GenerateLocation(xWidth);

            while(isRunning){
                playerCord = InputHandler();
                
                if(ValidateHit(shipCord, playerCord, xWidth)){
                    Console.Write("Play again? [n/Y]: ");

                    //This will only check if the user typed in n or no and will then exit the program by setting the "isRunning" variable to false.
                    switch(Console.ReadLine().ToLower()){
                        case "n":
                        case "no":
                            isRunning = false;
                        break;
                    }

                    //If the user contineus to the next round, it will regenerate the position.
                    shipCord = GenerateLocation(xWidth);

                    Console.Clear();
                }

            }    
        }

        static int InputHandler(){
            //This will create an array of args
            string[] args;
            int playerCord = 0;

            Console.WriteLine("Type a whole number between [0 to 10]:");
            args = Console.ReadLine().Split(" ");


            //This will loop through the entire array of inputs, allowing the user/player to chain multiple command or numbers together, however it will only check the last number.
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                case "-splash":
                    Splash();
                    break;
                case "-clr":
                        Console.Clear();
                    break;
                default:

                    //This will try to convert the string to a number and if it cant, it will ask the player to enter a number.
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
            //This will validate the players cordinate, and if it has hit the target. Otherwise it will simply return false;
            if (_playerCord <= _xWidth && _playerCord >= 0 && _shipCord == _playerCord)
            {
                Hit();
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

        static int GenerateLocation(int _xWidth){
            //This will generate the size of the "map" and will also place the ship at a cordinate.
            Random rng = new Random();

            return rng.Next(0,_xWidth);
        }
        

        #region ASCII ART
        static void Hit(){
            Console.WriteLine(@"
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$N*$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$$I::$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$I:::V$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$MN$$$*::::$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$NV*:*$$$$*::::M$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$M*...:N$$$$F****$$M*N$$$$$$$$$$$$$
$$$$$$$$$$$$$$$V.....*$$$$$$I**N$$F::N$$$$$$$$$$$$
$$$$$$$$$$$$$$*....::*$$$$$$$NN$$$*::V$$$$$$$$$$$$
$$$$$$$$$$$$$V::::::::M$$$$$$$$$$$***I$$$$$$$$$$$$
$$$$$$$$$$$$$*::::::::*N$$$$$$$$$$NVI$$$$$$$$$$$$$
$$$$$$$$M$$$$*:::::::::*M$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$F:I$$$$F::::::::::*I$$$$$$$$M$$$$$$$$$$$$$$$
$$$$$V::$$$$$$*::::*******VN$$$$$$N*VN$$$$$$$$$$$$
$$$$M:::M$$$$$$*************F$$$$$$$**VN$$$$$$$$$$
$$$$F:::*$$$$$$$V*************M$$$$$N*:*I$$$$$$$$$
$$$$M::::*M$$$$$$V**************I$$$$I**:VN$$$$$$$
$$$$$*:::**VM$$$$N***************VN$$$***:*M$$$$$$
$$$$$N*:******VN$$F****************M$$V***:*M$$$$$
N$$$$$N*********F$I*****************N$V****:*$$$$$
NV*FN$$NV********VV*****************V$V****::V$$$$
$$I*:VN$$****************************N*****::*$$$$
$$$M::*M$M***************************F****::::M$$$
$$$$*::*$N********************************::::M$$V
$$$F::::NI*******************************:::::$$F:
$$$::::*M*****:::**********************::::::*$I:*
$$V::::*::::::::::**********::::*****::::::::NV::V
$$:::::::::::::::::****::::::::::*::::::::::V*:::N
$N.::::::::::::::::::::::::::::::::::::::::*::::V$
$N..::::::::::::::::::::::::::::::::::::::::::.*$$
$$*...:::::::::::::::::::::::::::::::::::::...:N$$
$$N:..........::::::::::::::::::::::...:.....:N$$$
$$$N*.................:::::.................*N$$$$
$$$$$F:...................................:V$$$$$$
$$$$$$$V*...............................*I$$$$$$$$
$$$$$$$$$MV*:.......................:VI$$$$$$$$$$$
$$$$$$$$$$$$$MFV**::.......:::**VFM$$$$$$$$$$$$$$$
            "
            );
        }
        static void Splash(){
             Console.WriteLine(@"
.............................................
........................................:....
........................:..............::::..
....:.:...:...........................:::....
.....:::...:.....:...........::.....::.......
.......:::..:......::..:..:::.::.::*:........
.........::..:.:....:....::::*::::::.........
..........:::*::::......:..::::::::..........
...........:::**::.:::::*:**:::.:*:..........
............******:::********:::*:...........
.........::*VMFIVV*V*****VVVVVVV*:...........
..::::::::*VIMMNMNMIIIMIIMMMN$NMIV****:::::..
......::::******VVFVVV************:::::::....
             ");
        }
        #endregion

    }

}
