namespace ProjectOne;

class Trip 
{
    public int Id { get; set; }
    public string? Location { get; set; }
    public double Cost { get; set; }
    public string? TravelType { get; set; }
    public string? Climate { get; set; }
    public bool NeedsPassport { get; set; }
    public string? IncludedActivities { get; set; }

    public Trip()
    {

    }

    public Trip(int id, string location, double cost, string travelType, string climate, bool needsPassport, string includedActivities)
    {
        Id = id;
        Location = location;
        Cost = cost;        
        TravelType = travelType;
        Climate = climate;
        NeedsPassport = needsPassport;
        IncludedActivities = includedActivities;
    
    }

    public override string ToString()
    {
        return $"{{Id: {Id},Location: {Location},Cost: {Cost}, TravelType: {TravelType}, Climate: {Climate}, NeedsPassport: {NeedsPassport}}}";
    }

}
