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

    public void SaveTrip(SavedTrip savedTrip)
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "INSERT INTO SavedTrip (UserId, TripId) VALUES (@UserId, @TripId)";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", savedTrip.UId);
        cmd.Parameters.AddWithValue("@TripId", savedTrip.TripId);
        cmd.ExecuteNonQuery();
    }
    public SavedTrip? CreateTrip(int userId, Trip trip)
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "INSERT INTO SavedTrip (TripId, UId, Season, Location, MaxBudget, NumOfTravelers, TravelType, ClimatePref, PassportStatus, AddOnActivities) VALUES (@TripId, @UId, @Season, @Location, @MaxBudget, @NumOfTravelers, @TravelType, @ClimatePref, @PassportStatus, @AddOnActivities)";
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
            savedTrip.MaxBudget = (int)reader["MaxBudget"];    
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
    // public List<SavedTrip> GetFilteredTrips(int UId, double cost, bool passportStatus, string travelType, string climatePref)
    // {
    //     List<SavedTrip> filteredTrips = new List<SavedTrip>();
    //     using SqlConnection connection = new(_connectionString);
    //     connection.Open();
    //     string sql = "";
    // }
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
            trip.MaxBudget = (int)reader["MaxBudget"];
            trip.IncludedActivities = (string)reader["IncludedActivities"];
            savedTrips.Add(trip);
        }
        return savedTrips;
    }

   
}