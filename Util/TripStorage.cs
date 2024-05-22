namespace ProjectOne;
class TripStorage
{

    public Dictionary<string, Trip> trips = [];
    

    public TripStorage()
    {
    Trip trip1 = new(1, "Carribbean", 3000, "Cruise", "Warm", true, "Swimming, Snorkeling");
    Trip trip2 = new(2, "Florida", 5000, "Air", "Warm", false, "Visit Theme Park, Riding Rollercoasters");
    Trip trip3 = new(3, "Alaska", 7000, "Cruise", "Cool", false, "Observing Glaciers, Nature Hike");
    Trip trip4 = new(4, "Europe", 10000, "Train", "Cool", true, "Exploring Ancient Ruins, Immersing in Art and Culture");
    Trip trip5 = new(5, "South America", 5000, "Air", "Warm", true, "Surfing, Hiking");
    Trip trip6 = new(6, "Asia", 7000, "Air", "Warm", true, "Visiting Historic Temples, Exploring Local Markets");
    Trip trip7 = new(7, "Africa", 1000, "Air", "Warm", true, "Guided Walks to observe wildlife up close, Visit Conservation Centers");

    trips.Add("Carribbean", trip1);
    trips.Add("Florida", trip2);
    trips.Add("Alaska", trip3);
    trips.Add("Europe", trip4);
    trips.Add("South America", trip5);
    trips.Add("Asia", trip6);
    trips.Add("Africa", trip7);



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

