namespace ProjectOne;
class UserService
{
    UserRepo ur;
    public UserService(UserRepo ur)
    {
        this.ur = ur;
    }
    public User? RegisterUser(User u)
    {
        List<User> allUsers = ur.GetAllUser();
        {
            foreach(User user in allUsers)
            {
                if(user.Username == u.Username)
                {
                    System.Console.WriteLine("That username is already taken, please try again:");
                    return null; 
                }
            }
        }
        return ur.AddUser(u);
    }
    public User? LoginUser(string username, string password)
    {
        List<User> allUsers = ur.GetAllUser();
        foreach (User user in allUsers)
        {
            if(user.Username == username && user.Password == password)
            {
                return user;
            }
        }
        System.Console.WriteLine("The username/password combo is invalid, try again or press 0 to exit:");
        return null; 
    }

    
}