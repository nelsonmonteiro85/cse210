using System;

class Program
{
    static void Main(string[] args)
    {
        // This is prep 2
        Console.Write("Enter your grade in percentage: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int percentage))
        {
            char letter;
            char sign = ' ';

            if (percentage >= 90)
            {
                letter = 'A';
            }
            else if (percentage >= 80)
            {
                letter = 'B';
            }
            else if (percentage >= 70)
            {
                letter = 'C';
            }
            else if (percentage >= 60)
            {
                letter = 'D';
            }
            else
            {
                letter = 'F';
            }

            if (percentage >= 60 && percentage <= 100)
            {
                int lastDigit = percentage % 10;
                if (lastDigit >= 7)
                {
                    sign = '+';
                }
                else if (lastDigit < 3 && letter != 'F')
                {
                    sign = '-';
                }
            }

            if (percentage >= 70)
            {
                Console.WriteLine($"Congratulations! You passed the course with {letter}!");
            }
            else
            {
                Console.WriteLine("You didn't pass this time, but don't give up.");
            }

            Console.WriteLine($"Your letter grade is: {letter}{sign}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer percentage.");
            // Allow the user to retry
            Main(args);
        }
    }
}