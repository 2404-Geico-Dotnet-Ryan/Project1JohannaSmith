namespace ProjectOne;
class TripService
{
    TripRepo tripRepo;
    public TripService(TripRepo tripRepo)
    {
        this.tripRepo = tripRepo;
    }
    public List<Trip> FilterTrips(double maxBudget)
    {
        return tripRepo.GetTrips().Where(t => t.MaxBudget <= maxBudget).ToList();
    }


}
//maxBudget
//&& t.NeedsPassport == needsPassport && t.Climate == climate