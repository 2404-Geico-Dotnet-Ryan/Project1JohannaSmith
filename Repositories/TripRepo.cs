namespace ProjectOne;
using System.Data.SqlClient;
class TripRepo
{
    private readonly string _connectionString;
    UserRepo ur;
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
}