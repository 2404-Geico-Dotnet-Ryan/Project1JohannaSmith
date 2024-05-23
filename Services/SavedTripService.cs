namespace ProjectOne;

class SavedTripService
{
   SavedTripRepo savedTrRepo;
#pragma warning disable IDE0044 // Add readonly modifier
    TripRepo tripRepo;
#pragma warning restore IDE0044 // Add readonly modifier
    UserRepo ur;
   UserService us;
   public SavedTripService(SavedTripRepo savedTrRepo)
   {
      this.savedTrRepo = savedTrRepo;
   }
   public void SaveUserTrip(int userId, int tripId, string location, string travelType, string climatePref, bool passportStatus, string includedActivities)
   {
      savedTrRepo.SaveTrip(new SavedTrip {UserId = userId, TripId = tripId,  Location = location, TravelType = travelType, ClimatePref = climatePref, PassportStatus = passportStatus, IncludedActivities =includedActivities });
   }  
   public List<SavedTrip> GetUserSavedTrips(User user)
   {
      return savedTrRepo.GetSavedTrips(user.UserId);
   }
}