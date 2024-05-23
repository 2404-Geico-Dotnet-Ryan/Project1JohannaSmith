using System.Reflection.Metadata.Ecma335;

namespace ProjectOne;
class TripService
{
    TripRepo tripRepo;
    public TripService(TripRepo tripRepo)
    {
        this.tripRepo = tripRepo;
    }
    public List<Trip> FilterTrips(double maxBudget, string climate, bool needsPassport, string travelType)
    {
        var trips = tripRepo.GetTrips().Where(t => t.MaxBudget <= maxBudget);
        if (climate.ToLower() != "any")
        {
        trips = trips.Where(t => t.Climate == climate); 
        }       
        if (needsPassport == false)
        {
            trips = trips.Where(t => t.NeedsPassport == needsPassport);
        }
        if (travelType.ToLower() != "any")
        {
            trips = trips.Where(t => t.TravelType == travelType);
        }
        return trips.ToList();
    }
}