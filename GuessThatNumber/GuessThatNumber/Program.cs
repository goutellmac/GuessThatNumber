using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        public static int NumberToGuess; 
        
       
        static void Main(string[] args)
        {
            //initialize and declare input variable
            int input = 0;
            //declare new random object, rng
            Random rng = new Random();
            //make NumberToGuess a random number between 1 and 100
            NumberToGuess = rng.Next(1, 101);
            int NumberOfGuesses = 0;
            //declare boolean to allow user to choose between playing more or not playing
            bool play = true;
            String StringInput = "1";
            
            while (play == true)
            {

                //tell user that the number is between 1 and 100
                Console.WriteLine("The computer has generated a number between 1 and 100.");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("What is the number?");
                
                

                while ((int.Parse(StringInput)) != NumberToGuess)
                {
                    Console.Write("What is the number?");
                    StringInput = Console.ReadLine();

                    //take in user input and test its validity
                    if (ValidateInput(StringInput))
                    {
                        IsGuessTooHigh(int.Parse(StringInput));
                        IsGuessTooLow(int.Parse(StringInput));
                        NumberOfGuesses++;
                        
                    }
                    

                }
                //output to the user various success statements
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("You got it!");
                Console.WriteLine("It took you {0} guesses.", NumberOfGuesses);
                Console.WriteLine("The number is: {0} ", NumberToGuess);
                Console.WriteLine("Please enter the number 1 play again.");
                input = int.Parse(Console.ReadLine());
                Console.ReadKey();

                //allow user opportunity to press 1 to play again, else terminate game loop
                if (input == 1)
                {
                    play = true;
                    //reset guess counter
                    NumberOfGuesses = 0;
                    //randomize number to guess
                    NumberToGuess = rng.Next(1, 101);
                }
                else
                {
                    play = false;
                }
            }


          
        }
        
        public static bool ValidateInput(string userInput)
        {
          
            int userNumber;
            //make sure that the user didnt enter nothing
            if (userInput != null && userInput != string.Empty)
            {

                //if the user entered something then try to parse the string for an integer
                if (int.TryParse(userInput, out userNumber) == true)
                {
                    //make sure the parsed integer is between 1 and 100
                    if (userNumber > 0 && userNumber < 101)
                    {
                        return true;
                    }
                }


            }
            Console.WriteLine("Please enter a valid guess - That is: A number between 1 and 100.");
            return false;
            
            
        }

        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            //Random rng = new Random();
            //NumberToGuess = rng.Next(1, 101);
            
            //purely for testing purposes set the number equal to NumberToGuess
            NumberToGuess = number;


        }

        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            //if the userGuess is equal to the NumberToGuess then return false
            if (userGuess == NumberToGuess)
            {
                return false;
            }
           
            
            //if the userGuess is greater than the NumberToGuess then return true and print a message to the console.
            if (userGuess > NumberToGuess)
            {
                Console.WriteLine("Your guess was HIGHER than the computer's number.");
                Console.WriteLine("-------------------------------------------------");
                return true;
            }
            //you're hot check if the difference between NumberToGuess and userGuess is less than or equal to 5
            if ((NumberToGuess - userGuess) <= 10)
            {
                Console.WriteLine("You're HOT right now!!!");

                Console.WriteLine("-------------------------------------------------");
                return true;
            }
            //by default return false
            else
            {
                return false;
            }
            
        }

        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            //if the userGuess is equal to the NumberToGuess then return false
            if (userGuess == NumberToGuess)
            {
                return false;
            }
            //cold check
            if ((NumberToGuess - userGuess) >= 50 && userGuess < NumberToGuess)
            {
                Console.WriteLine("You're COLD right now!!!");
                Console.WriteLine("Your guess was LOWER than the computer's number.");
                Console.WriteLine("-------------------------------------------------");
                return true;
            }
            //if the userGuess is less than the NumberToGuess return true and print a message to the console.
            else if (userGuess < NumberToGuess)
            {
                Console.WriteLine("Your guess was LOWER than the computer's number.");
                Console.WriteLine("-------------------------------------------------");
                return true;

            }
            //by default return false
            else
            {
                return false;
            }
        }
    }
}
