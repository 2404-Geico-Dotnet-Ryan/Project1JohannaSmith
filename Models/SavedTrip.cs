namespace ProjectOne;
class SavedTrip : AddOnActivities
{
    public int TripId { get; set; }
    public int UId { get; set; }  
    public string? Season { get; set; }
    public string? Location { get; set; }
    public double MaxBudget { get; set; }
    public int NumOfTravelers { get; set; }
    public string? TravelType { get; set; }
    public string? ClimatePref { get; set; }
    public bool PassportStatus { get; set; }
    public string? AddOnActivities { get; set; }

    public SavedTrip()
    {

    }

    public SavedTrip(int tripId, int uId, string location, double maxBudget, int numOfTravelers, string travelType, string climatePref, bool passportStat, string addOnActivities)
    {
        TripId = tripId;
        UId = uId;
        Location = location;
        MaxBudget = maxBudget;
        NumOfTravelers = numOfTravelers;
        TravelType = travelType;
        ClimatePref = climatePref;
        PassportStatus = passportStat;
        AddOnActivities = addOnActivities;
    }

    public override string ToString()
    {
        return $"{{ Trip Option: {TripId},Location: {Location},MaxBudget: {MaxBudget}, TravelType: {TravelType}, Climate: {ClimatePref}, NeedsPassport: {PassportStatus}, AddOnActivities: {AddOnActivities}}}";
    }

}
/*
class Trip : AddOnActivities
{
    public string? Season { get; set; }
    public string? Location { get; set; }
    public double Cost { get; set; }
    public int NumOfTravelers { get; set; }
    public string? TravelType { get; set; }
    public string? ClimatePref { get; set; }
    public bool PassportStatus { get; set; }
    public string? AddOnActivities { get; set; }

    public Trip()
    {

    }

    public Trip(string location, double cost, int numOfTravelers, string travelType, string climatePref, bool passportStat, string addOnActivities)
    {
        Location = location;
        Cost = cost;
        NumOfTravelers = numOfTravelers;
        TravelType = travelType;
        ClimatePref = climatePref;
        PassportStatus = passportStat;
        AddOnActivities = addOnActivities;
    }

    public override string ToString()
    {
        return $"{{Location: {Location},Cost: {Cost}, TravelType: {TravelType}, Climate: {ClimatePref}, NeedsPassport: {PassportStatus}, AddOnActivities: {AddOnActivities}}}";
    }

}
*/