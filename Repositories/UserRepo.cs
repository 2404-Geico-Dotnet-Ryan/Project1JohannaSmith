namespace ProjectOne;
using System.Data.SqlClient;
class UserRepo
{
    private readonly string _connectionString;
    public UserRepo(string connString)
    {
        _connectionString = connString;
    }
    //  UserStorage userStorage = new();

    //add, get-one, get-all, update, and delete

    public User AddUser(User u)
    {
        //Set up DB Connection
        using SqlConnection connection = new(_connectionString);
        connection.Open();

        //Create the SQL String
        string sql = "INSERT INTO dbo.[User] OUTPUT inserted.* VALUES (@Username, @Password, @FirstName, @LastName)";

        //Set up SqlCommand Object and use its methods to modify the Parameterized Values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Username", u.Username);
        cmd.Parameters.AddWithValue("@Password", u.Password);
        cmd.Parameters.AddWithValue("@FirstName", u.FirstName);
        cmd.Parameters.AddWithValue("@LastName", u.LastName);

        // u.UserId = userStorage.idCounter++; //incrementing the value afterwards to prep it for the next time it's needed. 

        //Execute the Query
        using var reader = cmd.ExecuteReader();

        //Extract the results
        if (reader.Read())
        {
            User newUser = BuildUser(reader);
            return newUser;
        }
        else
        {
            return null;
        }

        //Add the movie into our collections. 
        // userStorage.users.Add(u.UserId, u);
        // return u;
    }

    public User? GetUser(int userId)

    {
        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.[User] WHERE UserId = @UserId";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("UserId", userId);

            //Execute the Query 
            using var reader = cmd.ExecuteReader();

            //Extract the Results
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
        // if (userStorage.users.ContainsKey(id))
        // {
        //     User selectedUser = userStorage.users[id];
        //     return selectedUser;
        // }
        // else 
        // {
        //     System.Console.WriteLine("Invalid User ID - Please Try Again");
        //     return null;
        // }
        // return null;
    }
    public List<User>? GetAllUser()
    {
        // return userStorage.users.Values.ToList();
        List<User> users = [];
        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.[User]";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);

            //Execute the Query
            using var reader = cmd.ExecuteReader(); //flexing options here 

            //Extract the Results
            while (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                User newUser = BuildUser(reader);

                //don't return! Instead add to list
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

            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "UPDATE dbo.[User] SET Username = @Username, Password = @Password, FirstName = @FirstName, LastName = @LastName OUTPUT inserted.* WHERE UserId = @UserId";

            //Set up SqlCommand Object and use its methods to modify the Parameterized Values
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@UserId", updatedUser.UserId);
            cmd.Parameters.AddWithValue("@Username", updatedUser.Username);
            cmd.Parameters.AddWithValue("@Password", updatedUser.Password);
            cmd.Parameters.AddWithValue("@FirstName", updatedUser.FirstName);
            cmd.Parameters.AddWithValue("@LastName", updatedUser.LastName);


            //Execute the Query
            //cmd.ExecuteNonQuery(); //This executes a non-select SQL statement (inserts, updates, deletes)

            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //If Read() found data, then extract it.
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
        //Assuming that the ID is consistent with an ID that exists, then we just have to update the value (aka Movie Object for our scenario) for said ID (key)
        // try
        // {

        //     // userStorage.users[updatedUser.UserId] = updatedUser;
        //     return updatedUser;
        // }
        // catch (Exception)//can name the exception or, since we aren't printing it (or doing anything with it), we can remove the exception name.
        // {
        //     System.Console.WriteLine("Invalid User ID - Please Try Again");
        //     return null;
        // }

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
        // //If we have the ID -> then simply Remove it from storage
        // bool didRemove = userStorage.users.Remove(u.UserId);
        // if (didRemove)
        // {
        //     //now we will return the movie that got deleted
        //     return u;
        // }
        // else
        // {
        // System.Console.WriteLine("Invalid User ID - Please Try Again");
        // return null;
        // }

    }

    //Helper Method
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