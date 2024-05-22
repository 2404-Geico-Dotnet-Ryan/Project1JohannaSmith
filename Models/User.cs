namespace ProjectOne;
class User
{
    public int UserId { get; set; } 
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public double MaxBudget { get; set; }
    // public string Role { get; set; }
    
    public Dictionary<int, User> userInfo = [];
    public int userId = 1;

    public int UserInfo()
    {
        User user1 = new();
        return userId++;
    }


    public User()
    {
        Username = "";
        Password = "";
        FirstName = "";
        LastName = "";
        // Role = "";
    }

    public User(int userId, string username, string password, string firstName, string lastName)
    {
        UserId = userId;
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;                
    }

    public override string ToString()
    {
        return $"{{UserId: {UserId},FirstName: {FirstName}, LastName: {LastName}}}";;
    }
}