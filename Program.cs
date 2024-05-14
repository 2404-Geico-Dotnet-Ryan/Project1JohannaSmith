using System;


class Program
{
    static TripService ts = new();
    static UserService us = new();
    //This was just my starting point when I was brainstorming 
    static void Main(string[] args)
    {
        
        System.Console.WriteLine("Thank you for choosing Project One Travel Company!");
        System.Console.WriteLine("We look forward to working with you to plan your dream getaway!");
        UserMenu();
        // UserLogin();
        FilteringQuestions();
        
        // Season();
        
    }

    private static void FilteringQuestions()
    {
        System.Console.WriteLine("Let's get started with a few questions.");
    }

    private static void UserMenu()
    {
        System.Console.WriteLine("Do you have an account? Please Pick an Option Down Below:");
        System.Console.WriteLine("=================================================================");
        System.Console.WriteLine("[1] I am a new User.");
        System.Console.WriteLine("[2] I have already created a Username and Password.");
        int input = int.Parse(Console.ReadLine() ?? "0");
        input = ValidateCmd(input, 2);
    }
    private static void NewUser(int input)
    {
        switch (input)
        {
            case 1:
            {
                // CreateNew();  //I also want this user to be logged in
                break;
            }
            case 2:
            {
                // LoginUser();
                break;
            }
        }
    }
    // private static void CreateNew()
    // {
    //     while (true)
    //     {
    //         System.Console.WriteLine("Ok, let's create your User Profile.");
    //         System.Console.WriteLine("Please enter a Username:");
    //         u.username = new(Console.ReadLine()); 
    //         if (username == null) return;
            
            
    //     }
    // }

    public static string Season()
    {
        System.Console.WriteLine("When are you planning to travel? We have trips available for spring, summer, fall, and winter. Please enter a season, or you could say Any.");
        string season = Console.ReadLine() ?? "";
        return season;
    }
    //Generic Command Input Validator - assume 1-maxOption are the number of options. and 0 is an option to quit.
    private static int ValidateCmd(int cmd, int maxOption)
    {
        while (cmd < 0 || cmd > maxOption)
        {
            System.Console.WriteLine("Invalid Command - Please Enter a command 1-" + maxOption + "; or 0 to Quit");
            cmd = int.Parse(Console.ReadLine() ?? "0");
        }

        //if input was already valid - it skips the if statement and just returns the value.
        return cmd;
    }
}

