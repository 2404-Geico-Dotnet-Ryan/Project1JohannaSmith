class TripStorage
{

    public Dictionary<string, Trip> trips = [];

    public TripStorage()
    {
    Trip trip1 = new("Carribbean", 3000, "Cruise", "Warm", true, "Swimming, Snorkeling, Water Sports, Hiking");
    Trip trip2 = new("Florida", 5000, "Air", "Warm", false, "Riding Rollercoasters, Seeing Shows, Enjoying Water Parks");
    Trip trip3 = new("Alaska", 7000, "Cruise", "Cool", false, "Whale Watching, Observing Glaciers, Nature Hike, Cultural Excursions");
    Trip trip4 = new("Europe", 10000, "Train", "Cool", true, "Exploring Ancient Ruins, Visiting Iconic Landmarks, Immersing in Art and Culture");
    Trip trip5 = new("South America", 5000, "Air", "Warm", true, "Zip-Lining forest canopies, Sandboarding Dunes, White-water Rafting");
    Trip trip6 = new("Asia", 7000, "Air", "Warm", true, "Attending Traditional Festivals, Learning Ancient Arts and Crafts, Visiting Historic Temples, Exploring Local Markets");
    Trip trip7 = new("Africa", 1000, "Air", "Warm", true, "Safari Drives in National Parks, Guided Walks to observe wildlife up close, Boat Rides up rivers, Visit Conservation Centers");
    }
}

