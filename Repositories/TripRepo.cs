namespace ProjectOne;
using System.Data.SqlClient;
class TripRepo
{
    private readonly string _connectionString;
#pragma warning disable IDE0044 // Add readonly modifier
    UserRepo ur;
#pragma warning restore IDE0044 // Add readonly modifier

    public TripRepo(string connString)
    {
        _connectionString = connString;
    }
    public List<Trip> GetTrips()
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "SELECT * FROM Trip";
        using SqlCommand cmd = new(sql, connection);
        using var reader = cmd.ExecuteReader();        
        {
            List<Trip> trips = new List<Trip>();
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
                trips.Add(trip);
            }
            return trips;
        }        
    }
    public List<Trip> FilteredTrips(int id, string location, double maxBudget, string travelType, string climate, bool needsPassport, string includedActivities)
    {
        List<Trip> filteredTrips = new List<Trip>();
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "SELECT * FROM Trip WHERE MaxBudget <= @MaxBudget AND Climate = @ClimatePref AND needsPassport = @PassportStatus AND TravelType = @TravelType";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Parameters.AddWithValue("@Location", location);
        cmd.Parameters.AddWithValue("@MaxBudget", maxBudget);
        cmd.Parameters.AddWithValue("@TravelType", travelType);
        cmd.Parameters.AddWithValue("@Climate", climate);
        cmd.Parameters.AddWithValue("@NeedsPassport", needsPassport);
        cmd.Parameters.AddWithValue("@IncludedActivities", includedActivities);
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
            filteredTrips.Add(trip);
        }
        return filteredTrips;
    }
    public Trip? AddTrip(Trip t)
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Id", t.Id);
        cmd.Parameters.AddWithValue("@Location", t.Location);
        cmd.Parameters.AddWithValue("@Cost", t.MaxBudget);
        cmd.Parameters.AddWithValue("@TravelType", t.TravelType);
        cmd.Parameters.AddWithValue("@Climate", t.Climate);
        cmd.Parameters.AddWithValue("@NeedsPassport", t.NeedsPassport);
        cmd.Parameters.AddWithValue("@IncludedActivities", t.IncludedActivities);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return t;
        }
        else
        {
            return null;
        }
    }
    public Trip? TripFilter()
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "";
        using SqlCommand cmd = new(sql, connection);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Trip trip = new();
            trip.Id = (int)reader["Id"];
            trip.Location = (string)reader["Location"];
            trip.Climate = (string)reader["Climate"];
            trip.TravelType = (string)reader["TravelType"];
            trip.NeedsPassport = (bool)reader["NeedsPassport"];
            trip.MaxBudget = (int)reader["MaxBudget"];
            trip.IncludedActivities = (string)reader["IncludedActivities"];
            return trip;
        }
        return null;
    }
}