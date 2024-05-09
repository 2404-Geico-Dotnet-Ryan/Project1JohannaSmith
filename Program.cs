using System;
using System.Security.Cryptography;

class Program
{
    //This was just my starting point when I was brainstorming 
    static void Main(string[] args)
    {
        
        System.Console.WriteLine("Thank you for choosing Project One Travel Company! We look forward to working with you to plan your dream getaway!");
        System.Console.WriteLine("Let's get started with a few questions to narrow down which trip works best for you.");
        Season();
        
    }

    public static string Season()
    {
        System.Console.WriteLine("When are you planning to travel? We have trips available for spring, summer, fall, and winter. Please enter a season, or you could say Any.");
        string season = Console.ReadLine() ?? "";
        return season;
    }
}

