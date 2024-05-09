class TripRepo
{
    TripStorage tripStorage = new();

    public Trip? SaveTrip(string title)
    {
        if (tripStorage.trips.ContainsKey(title))
        {
            Trip savedTrip = tripStorage.trips[title];
            return savedTrip;
        }
        else return null;
    }


}


/*
Data Access Layer - Repository Layer
    - is responsible for data(base) interaction. These objects that we create will perform any amount of retrieval, manipulation, destruction to our data. 
        - These Objects are referred as Data Access Objects: DAOs
*/