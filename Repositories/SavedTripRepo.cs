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
        string sql = "INSERT INTO SavedTrip (UserId, TripId, Location, TravelType, ClimatePref, PassportStatus, IncludedActivities) VALUES (@UserId, @TripId, @Location, @TravelType, @ClimatePref, @PassportStatus, @IncludedActivities)";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", savedTrip.UserId);
        cmd.Parameters.AddWithValue("@TripId", savedTrip.TripId);
        cmd.Parameters.AddWithValue("@Location", savedTrip.Location);
        cmd.Parameters.AddWithValue("@TravelType", savedTrip.TravelType);
        cmd.Parameters.AddWithValue("@ClimatePref", savedTrip.ClimatePref);
        cmd.Parameters.AddWithValue("@PassportStatus", savedTrip.PassportStatus);
        cmd.Parameters.AddWithValue("@IncludedActivities", savedTrip.IncludedActivities);
        cmd.ExecuteNonQuery();
    } 
   public List<SavedTrip> GetSavedTrips(int userId)
    {
        List<SavedTrip> savedTrips = new List<SavedTrip>();
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "SELECT * FROM SavedTrip WHERE UserId = @UserId";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", userId);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            SavedTrip savedTrip = new();
            savedTrip.UId = (int)reader["UId"];
            savedTrip.TripId = (int)reader["TripId"];
            savedTrip.UserId = (int)reader["UserId"];
            savedTrip.Location = (string)reader["Location"];
            // savedTrip.Season = (string)reader["Season"];
            savedTrip.ClimatePref = (string)reader["ClimatePref"];
            // savedTrip.NumOfTravelers = (int)reader["NumOfTravelers"];
            savedTrip.TravelType = (string)reader["TravelType"];
            savedTrip.PassportStatus = (bool)reader["PassportStatus"];
            // savedTrip.MaxBudget = (int)reader["MaxBudget"];
            savedTrips.Add(savedTrip);
        }
        return savedTrips;
    }
}