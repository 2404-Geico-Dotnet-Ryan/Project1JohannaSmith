using System;
using System.Linq;
using System.Linq.Expressions;
namespace ProjectOne;



class Program
{
    static SavedTripService savedts;
    static UserService us; 
    static TripService tripService;
    static User? currentUser = null;
    static SavedTripRepo savedTrRepo;
    static void Main(string[] args)
    {
        string path = @"C:\Users\U88AFG\Revature\Project-app-db.txt";
        string connectionString = File.ReadAllText(path);
        UserRepo ur = new(connectionString);
        us = new(ur);
        TripRepo tripRepo = new TripRepo(connectionString);
        tripService = new TripService(tripRepo);
        savedTrRepo = new SavedTripRepo(connectionString);
        savedts = new SavedTripService(savedTrRepo);
        //Testing 
        //User newUser = new(0, "test3", "pass", "please", "work");
        // ur.AddUser(newUser);
        //System.Console.WriteLine("Added User" + ur.AddUser(newUser));

        //Testing get 1, update, delete

        // User u = ur.GetUser(3) ?? new();
        // System.Console.WriteLine("Get User" + u);
        // u.Password += "000";
        // System.Console.WriteLine("Updated User: " + ur.UpdateUser(u));
        // System.Console.WriteLine("Deleted User: " + ur.DeleteUser(u));
        System.Console.WriteLine("Thank you for choosing Project One Travel Company!");
        System.Console.WriteLine("We look forward to working with you to plan your dream getaway!");
        UserMenu();
        // FilteringQuestions();


    }



    private static void UserMenu()
    {
        System.Console.WriteLine("Do you have an account? Please Pick an Option Down Below:");
        System.Console.WriteLine("=================================================================");
        System.Console.WriteLine("[1] I am a new User.");
        System.Console.WriteLine("[2] I have already created a Username and Password.");
        int input = int.Parse(Console.ReadLine() ?? "0");
        input = ValidateCmd(input, 2);

        switch (input)
        {
            case 1:
                NewUser(); break;
            case 2:
                CurrentUser(); break;
        }
    }

    private static void CurrentUser()
    {
        while (currentUser == null)
        {
            System.Console.WriteLine("Please enter your Username: ");
            string username = Console.ReadLine() ?? "";

            System.Console.WriteLine("Thank you- please enter your password: ");
            string password = Console.ReadLine() ?? "";

            currentUser = us.LoginUser(username, password);
            if (currentUser == null)
            System.Console.WriteLine("Hmm, something went wrong- let's try again, or press 0 to quit."); //need to add functionality to quit
        }
        FilteringQuestions();
    }

    // private static void NewUser(int input)
    // {
    //     switch (input)
    //     {
    //         case 1:
    //             {
    //                 // CreateNew();  //I also want this user to be logged in
    //                 break;
    //             }
    //         case 2:
    //             {
    //                 // LoginUser();
    //                 break;
    //             }
    //     }
    // }
    // private static void CreateNew()
    // {
    //     bool newUser= true;
    //     while (newUser ==true)

    //     {
    //         System.Console.WriteLine("Ok, let's create your User Profile.");
    //         System.Console.WriteLine("Please enter a Username:");
    //         u.username = new(Console.ReadLine()); 
    //         if (username == null) return;


    //     }
    // }

    private static void NewUser()
    {
        System.Console.WriteLine("Welcome! Let's create your User Profile. Please enter your first name: ");
        string firstName = Console.ReadLine() ?? "";
        //add validation for text only

        System.Console.WriteLine("Thanks! Now please enter your last name:");
        string lastName = Console.ReadLine() ?? "";
        //add validation for text only

        System.Console.WriteLine("Perfect! Please enter a Username:");
        string username = Console.ReadLine() ?? "";

        //add validation for unique username

        System.Console.WriteLine("Thank you! Let's create your Password:");
        string password = Console.ReadLine() ?? "";

        //add validation 

        User? newUser = new(0, username, password, firstName, lastName);
        newUser = us.RegisterUser(newUser);
        System.Console.WriteLine();
        if (newUser != null)
        {
            System.Console.WriteLine("Now that we have your account registered, we can get started on planning your trip!");

        }

        FilteringQuestions();
    }


    private static void FilteringQuestions()
    {
        System.Console.WriteLine("====== Let's get started with a few questions! ======");
        {
        User user = us.LoginUser(currentUser.Username, currentUser.Password);
        // double maxBudget = currentUser.MaxBudget;
        // Season();
        var maxBudget = Budget(currentUser);
        // NumOfTravelers();
        // DepLocation();
        // TravelType();
        // PassportStatus();
        // ClimatePref();
        var filteredTrips = tripService.FilterTrips(maxBudget);
        foreach (var trip in filteredTrips)
        {
            savedts.SaveUserTrip(currentUser.userId, trip.Id); 
        }
        }
        // ChildStatus();
        // CreateTrip();
    }

    // private static void CreateTrip()
    // {
    //     if (
    // }

    // public static bool ChildStatus()
    // {
    //     System.Console.WriteLine("Will you be traveling with any children? Other than your own inner child, of course!");
    //     string cs = Console.ReadLine() ?? "".Trim();
    //     bool childStatus = cs.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
    //     return childStatus;
    //     //Add input validation

    // }

    public static string ClimatePref()
    {
        System.Console.WriteLine("Now, would you prefer to travel to a warm or cool climate? Any is always an option!");
        string climate = "";
        bool valid = false;

        while (valid == false)
        {
            {
                if (climate == "warm" || climate == "cool" || climate == "any")
                {
                    valid = true;                   
                    break;
                }
                else valid = false;
            }
            System.Console.WriteLine("Please enter your climate preference: ");
            climate = Console.ReadLine() ?? "".Trim();
            climate = climate.ToLower();
            {
                if (climate == "warm" || climate == "cool" || climate == "any")
                {
                    valid = true;
                    break;
                }
                else valid = false;
            }
            if (valid == false)
            {
                System.Console.WriteLine("Hmm- give it another go, please enter 'warm', 'cool', or 'any':");
                climate = Console.ReadLine() ?? "".Trim();
                climate = climate.ToLower();
            }
        }
        
        return climate;
        //Add filtering
    }

    public static bool PassportStatus()
    {
        System.Console.WriteLine("Do all travelers have a valid Passport, or will you at the time of travel?");                  
        bool valid = false;
        string ps = "";
        bool passportStat = false;
        while (valid == false)
        {
            {
                System.Console.WriteLine("Please enter Yes or No: ");
                ps = Console.ReadLine() ?? "".Trim();
                ps = ps.ToLower();
                // passportStat = ps.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
                if (ps == "yes")
                {
                    valid = true;
                    passportStat = true;
                    break;
                }
                else if (ps == "no")
                {
                    valid = true;
                    passportStat = false;
                    break;
                }
                if (ps != "yes" || ps != "no")
                {
                    valid = false;
                    System.Console.WriteLine("Try again.");
                }
            }
        
        }
        System.Console.WriteLine(passportStat);
        System.Console.WriteLine("OK!");
        return passportStat;
        //Add filtering
    }

    public static string TravelType()
    {
        System.Console.WriteLine("Halfway done! Do you have a preference on the type of travel?");
        System.Console.WriteLine("We offer travel by Air, Train, or Cruise.");
        string travelType = "";
        bool valid = false;
        while (valid == false)
        {
            if (travelType == "air" || travelType == "train" || travelType == "cruise" || travelType == "any")
                {
                    valid = true;
                    break;
                }
                else valid = false;
            System.Console.WriteLine("Please enter a type of travel, or you could say Any:");
            travelType = Console.ReadLine() ?? "".Trim();
            travelType = travelType.ToLower();
            if (travelType == "air" || travelType == "train" || travelType == "cruise" || travelType == "any")
                {
                    valid = true;
                    break;
                }
                else valid = false;
            if (valid == false)
            {
                System.Console.WriteLine("I'm sorry, I didn't catch that. Please enter 'air', 'train', 'cruise', or 'any':");
                travelType = Console.ReadLine() ?? "".Trim();
                travelType = travelType.ToLower();

            }
        }
        System.Console.WriteLine("Excellent!");
        return travelType;
        //Add input validation
        //Add filtering
    }

    public static string DepLocation()
    {
        System.Console.WriteLine("What is your departure location?");
        string location = Console.ReadLine() ?? "".Trim();
        if (String.IsNullOrEmpty(location))
        {
            System.Console.WriteLine("Oops- give it another try, please enter your departure location: ");
            location = Console.ReadLine() ?? "".Trim();
        }
        else
        {
            System.Console.WriteLine("Ok! We can definitely work with that.");
        }
        return location;

    }

    public static int NumOfTravelers()
    {
        int travelers = 0;
        while (travelers == 0)
        {
            try
            {
                System.Console.WriteLine("How many people will be traveling, including yourself?");
                travelers = int.Parse(Console.ReadLine() ?? "0");
                if (travelers < 1)
                {
                    System.Console.WriteLine("Please include yourself! We need at least one person to plan your trip:");
                    travelers = int.Parse(Console.ReadLine() ?? "0");
                }
            }
            catch (FormatException ex)
            {
                System.Console.WriteLine("Something went wrong- please enter a number such as '2':");
                travelers = 0;
            }

            if (travelers == 1 || travelers > 1)
            {
                System.Console.WriteLine("Sounds fun!");
            }
        }

        return travelers;
    }

    public static double Budget(User currentUser)
    {
        System.Console.WriteLine("That's great! We will be sure to find something that fits your needs!");
        System.Console.WriteLine("Now- what budget are you working with?");
        double maxBudget = 1;
        bool keepGoing = true;
        while (keepGoing == true)
        {

            while (maxBudget == 1)
            {

                try
                {
                    System.Console.WriteLine("We have trips availabe starting at 3000. Please enter a maximum budget amount, or press '0' to quit:");
                    maxBudget = double.Parse(Console.ReadLine() ?? "0");
                    if (maxBudget == 0)
                    {
                        System.Console.WriteLine("Thank you, have a nice day!");
                        keepGoing = false;
                        break;
                    }
                    if (maxBudget < 3000)
                    {
                        // System.Console.WriteLine("At this time, we don't offer trips for less than 3000. Please enter an amount greater than 3000 to continue: ");
                        maxBudget = 1;
                    }
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine("Something went wrong.");
                    maxBudget = 1;
                }
            }
            if (maxBudget == 3000 || maxBudget > 3000)
            {
                System.Console.WriteLine("We can work with that!");
                keepGoing = false;
            }
        }

        return maxBudget;
        //Add filtering
    }

    public static string Season()
    {
        System.Console.WriteLine("When are you planning to travel?");
        System.Console.WriteLine("We have trips available for spring, summer, fall, and winter.");
        string season = "";
        bool valid = false;
        while (valid == false)
        {
            {
                if (season == "spring" || season == "summer" || season == "fall" || season == "winter" || season == "any")
                {
                    valid = true;
                    break;
                }
                else valid = false;
            }
            System.Console.WriteLine("Please enter a season, or you could say Any:");
            season = Console.ReadLine() ?? "".Trim();
            season = season.ToLower();
            {
                if (season == "spring" || season == "summer" || season == "fall" || season == "winter" || season == "any")
                {
                    valid = true;
                    break;
                }
                else valid = false;
            }
            if (valid == false)
            {
                System.Console.WriteLine("I'm sorry, I didn't catch that. Please enter 'spring', 'summer', 'fall', 'winter', or 'any':");
                season = Console.ReadLine() ?? "".Trim();
                season = season.ToLower();

            }
        }
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

