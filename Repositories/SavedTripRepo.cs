namespace ProjectOne;
using System.Data.SqlClient;
class SavedTripRepo
{
    private readonly string _connectionString;
    // SavedTripStorage savedTripStorage = new();
    // TripStorage tripStorage = new();
    UserRepo ur;

    public SavedTripRepo(string connString)
    {
        _connectionString = connString;
    }


    public SavedTrip? CreateTrip(int userId, Trip trip)
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "INSERT INTO SavedTrip (TripId, UId, Season, Location, Cost, NumOfTravelers, TravelType, ClimatePref, PassportStatus, AddOnActivities) VALUES (@TripId, @UId, @Season, @Location, @Cost, @NumOfTravelers, @TravelType, @ClimatePref, @PassportStatus, @AddOnActivities)";
        using SqlCommand cmd = new(sql, connection);
        // cmd.Parameters.AddWithValue();
        // cmd.Parameters.AddWithValue();
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        { 
            SavedTrip savedTrip = new();
            savedTrip.UId = (int)reader["UId"];
            savedTrip.TripId = (int)reader["TripId"];
            savedTrip.Location = (string)reader["Location"];
            savedTrip.Season = (string)reader["Season"];
            savedTrip.ClimatePref = (string)reader["ClimatePref"];
            savedTrip.NumOfTravelers = (int)reader["NumOfTravelers"];
            savedTrip.TravelType = (string)reader["TravelType"];
            savedTrip.PassportStatus = (bool)reader["PassportStatus"];
            savedTrip.Cost = (int)reader["Cost"];    
            return savedTrip;        
        }
        // if (tripStorage.trips.ContainsKey(title))
        // {
        //     Trip savedTrip = tripStorage.trips[title];
        //     return savedTrip;
        // }
        // else 
        return null;
    }
    public List<Trip> GetSavedTrips(int userId)
    {
        List<Trip> savedTrips = new List<Trip>();
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "SELECT * FROM SavedTrip WHERE UserId = @UserId";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", userId);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Trip trip = new();
            trip.Id = (int)reader["Id"];
            trip.Location = (string)reader["Location"];
             trip.Climate = (string)reader["Climate"];
            trip.TravelType = (string)reader["TravelType"];
            trip.NeedsPassport = (bool)reader["NeedsPassport"];
            trip.Cost = (int)reader["Cost"];
            trip.IncludedActivities = (string)reader["IncludedActivities"];
            savedTrips.Add(trip);
        }
        return savedTrips;
    }

    public SavedTrip? AddTrip(SavedTrip trip)
    {
        // trip.TripId = savedTripStorage.tripIdCounter++;
        // savedTripStorage.savedTrips.Add(trip.TripId, trip);
        // // savedTripStorage.savedTrips.cl
        return trip;
    }
}