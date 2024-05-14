class UserRepo
{
     UserStorage userStorage = new();

    //add, get-one, get-all, update, and delete

    public User AddUser(User u)
    {
        u.UserId = userStorage.idCounter++; //incrementing the value afterwards to prep it for the next time it's needed. 

        //Add the movie into our collections. 
        userStorage.users.Add(u.UserId, u);
        return u;
    }

    public User? GetUser(int id)
    
    {
        if (userStorage.users.ContainsKey(id))
        {
            User selectedUser = userStorage.users[id];
            return selectedUser;
        }
        else 
        {
            System.Console.WriteLine("Invalid User ID - Please Try Again");
            return null;
        }
    }
    public List<User> GetAllUser()
    {
        return userStorage.users.Values.ToList();
    }

    public User? UpdateUser(User updatedUser)
    {
        //Assuming that the ID is consistent with an ID that exists, then we just have to update the value (aka Movie Object for our scenario) for said ID (key)
        try
        {

            userStorage.users[updatedUser.UserId] = updatedUser;
            return updatedUser;
        }
        catch (Exception)//can name the exception or, since we aren't printing it (or doing anything with it), we can remove the exception name.
        {
            System.Console.WriteLine("Invalid User ID - Please Try Again");
            return null;
        }
    }
    public User? DeleteUser(User u)
    {
        

        //If we have the ID -> then simply Remove it from storage
        bool didRemove = userStorage.users.Remove(u.UserId);
        if (didRemove)
        {
            //now we will return the movie that got deleted
            return u;
        }
        else
        {
        System.Console.WriteLine("Invalid User ID - Please Try Again");
        return null;
        }

    } 
}