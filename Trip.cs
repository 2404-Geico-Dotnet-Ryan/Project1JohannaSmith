class Trip
{
    public string? Location { get; set; }
    public double Cost { get; set; }
    public string? TravelType { get; set; }
    public string? Climate { get; set; }
    public bool NeedsPassport { get; set; }
    public string? Activities { get; set; }

    public Trip()
    {

    }

    public Trip(string location, double cost, string travelType, string climate, bool needsPassport, string activities)
    {
        Location = location;
        Cost = cost;
        TravelType = travelType;
        Climate = climate;
        NeedsPassport = needsPassport;
        Activities = activities;
    }

}