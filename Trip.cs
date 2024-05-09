class Trip : AddOnActivities
{
    public string? Location { get; set; }
    public double Cost { get; set; }
    public string? TravelType { get; set; }
    public string? Climate { get; set; }
    public bool NeedsPassport { get; set; }
    public string? AddOnActivities { get; set; }

    public Trip()
    {

    }

    public Trip(string location, double cost, string travelType, string climate, bool needsPassport, string addOnActivities)
    {
        Location = location;
        Cost = cost;
        TravelType = travelType;
        Climate = climate;
        NeedsPassport = needsPassport;
        AddOnActivities = addOnActivities;
    }

    public override string ToString()
    {
        return $"{{Location: {Location},Cost: {Cost}, TravelType: {TravelType}, Climate: {Climate}, NeedsPassport: {NeedsPassport}, AddOnActivities: {AddOnActivities}}}";;
    }

}