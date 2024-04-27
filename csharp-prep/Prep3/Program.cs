using System;

class Program
{
    static void Main(string[] args)
    {
        // For Parts 1 and 2, where the user specifies the number...
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        
        // Uncomment the above line and comment out the below random number generation for parts 1 and 2
        
        bool playAgain = true;

        while (playAgain)
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int numberOfGuesses = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }                    

            Console.WriteLine($"Number of guesses: {numberOfGuesses}");

            string playAgainInput = "";
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write("Do you want to play again? (yes/no): ");
                playAgainInput = Console.ReadLine().ToLower();
                if (playAgainInput == "yes" || playAgainInput == "no")
                {
                    isValidInput = true;
                }
                else{
                    Console.WriteLine("Please enter 'yes' or 'no'.");
                }
            }

            playAgain = playAgainInput == "yes";
        }
    }
}