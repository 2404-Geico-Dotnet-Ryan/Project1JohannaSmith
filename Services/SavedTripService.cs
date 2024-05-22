namespace ProjectOne;

class SavedTripService
{

   SavedTripRepo savedTrRepo;
   public SavedTripService(SavedTripRepo savedTrRepo)
   {
      this.savedTrRepo = savedTrRepo;
   }

   public void SaveUserTrip(int userId, int tripId)
   {
      savedTrRepo.SaveTrip(new SavedTrip { UId = userId, TripId = tripId });
   }



}