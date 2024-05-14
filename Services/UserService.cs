class UserService
{
    UserRepo ur = new();

    //Register
    public User? RegisterUser(User u)
    {
        //let's no tlet them register if the role is anything other than "user"
        // if(u.Role != "user")
        // {//reject them
        //     System.Console.WriteLine("invalid role, please try again");
        //     return null;
        // }

        //let's not let them register if the username is already taken
        //get all users
        List<User> allUsers = ur.GetAllUser();
        {
            //Check if our new username matches any of the usernames on all those users.
            foreach(User user in allUsers)
            {
                if(user.Username == u.Username)
                {
                    System.Console.WriteLine("username already taken, please try again");
                    return null; //reject them
                }
            }

            //If we make it this far, then we are saying that the role is good to go and the username is good to go
        }
        return ur.AddUser(u);
    }

    //Login
    public User? LoginUser(string username, string password)
    {
        //Get all users
        List<User> allUsers = ur.GetAllUser();
        //check each one to see if we find a match
        foreach(User user in allUsers)
        {
            //if matching user name and password, they login, return that user
            if(user.Username == username && user.Password == password)
            {
                //yay, login
                return user; //us returning the user will indicate success
            }
        }
        //If we make it this far, we didn't find a match
        System.Console.WriteLine("invalid username/password combo, please try again");
        return null; //reject the login
    }
}