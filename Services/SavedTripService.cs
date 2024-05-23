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

   public void SaveUserTrip(int userId, int tripId)
   {
      savedTrRepo.SaveTrip(new SavedTrip { UId = userId, TripId = tripId });
   }
   // public Trip? TripGetter()
   // {
   //    foreach (var )
   //    return null;
      
   // }



}