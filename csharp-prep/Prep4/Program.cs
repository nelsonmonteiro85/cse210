using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter a number (enter 0 to finish): ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }

        int total = numbers.Sum();

        double average = numbers.Average();

        int maxNumber = numbers.Max();

        Console.WriteLine("The sum is: " + total);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + maxNumber);
    }
}