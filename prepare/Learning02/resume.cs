using System;
using System.Collections.Generic; // You need to add this for List<T>

public class Resume
{
    public string _Name;

    // Make sure to initialize your list to a new List before you use it.
    public List<Job> _Jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_Name}");
        Console.WriteLine("Jobs:");

        // Notice the use of the custom data type "Job" in this loop
        foreach (Job job in _Jobs)
        {
            // Corrected method call
            job.DisplayJobInformation();
        }
    }
}
