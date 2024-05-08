using System;

class Program
{
    //This was just my starting point when I was brainstorming 
    static void Main(string[] args)
    {
        System.Console.WriteLine("Thank you for choosing Project One Travel Company! We look forward to working with you to plan your dream getaway!");
        System.Console.WriteLine("Let's get started with a few questions to narrow down which trip works best for you.");
        List<string> allTrips = new();
        allTrips.Add("Tropical Beaches in the Carribbean");
        allTrips.Add("Kid-centered Theme Parks in Florida");
        allTrips.Add("All-inclusive Cruises to Alaska");
        allTrips.Add("Historic Destinations in Europe");
        allTrips.Add("Adventurous Tours in South America");
        allTrips.Add("Cultural Immersions in Asia");
        allTrips.Add("Animal Encounters in Africa");
        System.Console.WriteLine("We offer trips to: ");
        System.Console.WriteLine(string.Join(", ", allTrips));
    }
}

