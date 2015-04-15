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
        public static int NumberToGuess = 0; 
        
       
        static void Main(string[] args)
        {
            //initialize and declare input variable
            int input = 0;
            //declare new random object, rng
            Random rng = new Random();
            //make NumberToGuess a random number between 1 and 100
            NumberToGuess = rng.Next(1, 101);
            int NumberOfGuesses = 0;
            bool play = true;
            
            while (play == true)
            {

                //set the NumberToGuess
                SetNumberToGuess(NumberToGuess);
                Console.WriteLine("The computer has generated a number between 1 and 100.");
                while (input != NumberToGuess)
                {
                    Console.Write("What is the number?");
                    input = int.Parse(Console.ReadLine());
                    IsGuessTooHigh(input);
                    IsGuessTooLow(input);
                    NumberOfGuesses++;

                }
                //output to the user various success statements
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
                }
                else
                {
                    play = false;
                }
            }


          
        }
        
        public static bool ValidateInput(string userInput)
        {
            //test for invalid input and store boolean result in variable test
            
            //work on tomorrow... cannot figure this **** out
            //jk figured out tryparse
            int userNumber;
            if (int.TryParse(userInput, out userNumber) == true)
            {
                return true;
            }
            
           
            else
            {
                return false;
            }
            
            
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
            else if (userGuess > NumberToGuess)
            {
                Console.WriteLine("Your guess was HIGHER than the computer's number.");
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
            //if the userGuess is less than the NumberToGuess return true and print a message to the console.
            else if (userGuess < NumberToGuess)
            {
                Console.WriteLine("Your guess was LOWER than the computer's number.");
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
