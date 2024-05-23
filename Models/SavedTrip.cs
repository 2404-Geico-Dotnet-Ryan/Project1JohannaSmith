namespace ProjectOne;
class SavedTrip 
{
    public int TripId { get; set; }
    public int UId { get; set; } 
    public int UserId { get; set; } 
    public string? Season { get; set; }
    public string? Location { get; set; }
    public double MaxBudget { get; set; }
    public int NumOfTravelers { get; set; }
    public string? TravelType { get; set; }
    public string? ClimatePref { get; set; }
    public bool PassportStatus { get; set; }
    public string? IncludedActivities { get; set; }

    public SavedTrip()
    {

    }

    public SavedTrip(int userId, int tripId, string location, double maxBudget, int numOfTravelers, string travelType, string climatePref, bool passportStat, string includedActivities)
    {
        TripId = tripId;
        UserId = userId;
        Location = location;
        MaxBudget = maxBudget;
        NumOfTravelers = numOfTravelers;
        TravelType = travelType;
        ClimatePref = climatePref;
        PassportStatus = passportStat;
        IncludedActivities = includedActivities;
    }

    public override string ToString()
    {
        return $"{{ Trip Option: {TripId},Location: {Location},MaxBudget: {MaxBudget}, TravelType: {TravelType}, Climate: {ClimatePref}, NeedsPassport: {PassportStatus}, IncludedActivities: {IncludedActivities}}}";
    }

}
