namespace ProjectOne;
using System.Data.SqlClient;
class UserRepo
{
    private readonly string _connectionString;
    public UserRepo(string connString)
    {
        _connectionString = connString;
    }
    public User? AddUser(User u)
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "INSERT INTO dbo.[User] OUTPUT inserted.* VALUES (@Username, @Password, @FirstName, @LastName)";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Username", u.Username);
        cmd.Parameters.AddWithValue("@Password", u.Password);
        cmd.Parameters.AddWithValue("@FirstName", u.FirstName);
        cmd.Parameters.AddWithValue("@LastName", u.LastName);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            User? newUser = BuildUser(reader);
            return newUser;
        }
        else
        {
            return null;
        }
    }
    public User? GetUser(int userId)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            string sql = "SELECT * FROM dbo.[User] WHERE UserId = @UserId";
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("UserId", userId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User newUser = BuildUser(reader);
                return newUser;
            }
            return null;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }
    public List<User>? GetAllUser()
    {
        List<User> users = [];
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            string sql = "SELECT * FROM dbo.[User]";
            using SqlCommand cmd = new(sql, connection);
            using var reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                User newUser = BuildUser(reader);
                users.Add(newUser);
            }
            return users;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }
    public User? UpdateUser(User updatedUser)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            string sql = "UPDATE dbo.[User] SET Username = @Username, Password = @Password, FirstName = @FirstName, LastName = @LastName OUTPUT inserted.* WHERE UserId = @UserId";
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@UserId", updatedUser.UserId);
            cmd.Parameters.AddWithValue("@Username", updatedUser.Username);
            cmd.Parameters.AddWithValue("@Password", updatedUser.Password);
            cmd.Parameters.AddWithValue("@FirstName", updatedUser.FirstName);
            cmd.Parameters.AddWithValue("@LastName", updatedUser.LastName);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User newUser = BuildUser(reader);
                return newUser;
            }
            return null;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }
    public User? DeleteUser(User u)
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();
        string sql = "DELETE FROM dbo.[User] OUTPUT deleted.* WHERE UserId = @UserId";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", u.UserId);
        using var reader = cmd.ExecuteReader();
        if(reader.Read())
        {
            User newUser = BuildUser(reader);
            return newUser;
        }
        else 
        {
            return null;
        }
    }
    private static User BuildUser(SqlDataReader reader)
    {
        User newUser = new();
        newUser.UserId = (int)reader["UserId"];
        newUser.Username = (string)reader["Username"];
        newUser.Password = (string)reader["Password"];
        newUser.FirstName = (string)reader["FirstName"];
        newUser.LastName = (string)reader["LastName"];
        return newUser;
    }
}