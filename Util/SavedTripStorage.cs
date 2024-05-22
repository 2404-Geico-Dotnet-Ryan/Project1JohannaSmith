namespace ProjectOne;
class SavedTripStorage : TripStorage 

{
    UserRepo ur;
    public SavedTripStorage(UserRepo ur)
    {
        this.ur = ur;
    }
     public Dictionary<int, SavedTrip> savedTrips = [];
     public int tripIdCounter = 1;
     

     public SavedTripStorage()
     {
        // SavedTrip trip1 = new();
        // savedTrips.Add(tripIdCounter++, trip1);
        // ur.GetUser(1);
     }
}