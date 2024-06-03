namespace ProjectOne;

class SavedTripService
{
   SavedTripRepo savedTrRepo;
    TripRepo tripRepo;
    UserRepo ur;
   UserService us;
   public SavedTripService(SavedTripRepo savedTrRepo)
   {
      this.savedTrRepo = savedTrRepo;
   }
   public void SaveUserTrip(int userId, int tripId, string location, int maxBudget, string travelType, string climatePref, bool passportStatus, string includedActivities)
   {
      savedTrRepo.SaveTrip(new SavedTrip {UserId = userId, TripId = tripId, Location = location, MaxBudget = maxBudget, TravelType = travelType, ClimatePref = climatePref, PassportStatus = passportStatus, IncludedActivities =includedActivities });
   }  
   public List<SavedTrip> GetUserSavedTrips(User user)
   {
      return savedTrRepo.GetSavedTrips(user.UserId);
   }
}