class TripStorage
{

    public Dictionary<string, Trip> trips = [];
    public Dictionary<int, Users> userInfo = [];
    public int userId = 1;

    public int UserInfo()
    {
        Users user1 = new();
        return userId++;
    }

    public TripStorage()
    {
    Trip trip1 = new("Carribbean", 3000, "Cruise", "Warm", true, "Swimming, Snorkeling");
    Trip trip2 = new("Florida", 5000, "Air", "Warm", false, "Visit Theme Park, Riding Rollercoasters");
    Trip trip3 = new("Alaska", 7000, "Cruise", "Cool", false, "Observing Glaciers, Nature Hike");
    Trip trip4 = new("Europe", 10000, "Train", "Cool", true, "Exploring Ancient Ruins, Immersing in Art and Culture");
    Trip trip5 = new("South America", 5000, "Air", "Warm", true, "Surfing, Hiking");
    Trip trip6 = new("Asia", 7000, "Air", "Warm", true, "Visiting Historic Temples, Exploring Local Markets");
    Trip trip7 = new("Africa", 1000, "Air", "Warm", true, "Guided Walks to observe wildlife up close, Visit Conservation Centers");


    // List<string> allTrips = new();
    //     allTrips.Add("Tropical Beaches in the Carribbean");
    //     allTrips.Add("Kid-centered Theme Parks in Florida");
    //     allTrips.Add("All-inclusive Cruises to Alaska");
    //     allTrips.Add("Historic Destinations in Europe");
    //     allTrips.Add("Adventurous Tours in South America");
    //     allTrips.Add("Cultural Immersions in Asia");
    //     allTrips.Add("Animal Encounters in Africa");
    //     System.Console.WriteLine("We offer trips to: ");
    //     System.Console.WriteLine(string.Join(", ", allTrips));
    }
}

