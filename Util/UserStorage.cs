namespace ProjectOne;
class UserStorage
{
    public Dictionary<int, User> users = [];

    public int idCounter = 1;

    public UserStorage()
    {
        User user1 = new(idCounter, "johasmith", "password1", "Johanna", "Smith"); idCounter++;
        // User user2 = new(); idCounter++;
        // User user3 = new(); idCounter++;

        
        users.Add(user1.UserId, user1);
        // users.Add(user2.UserId, user2);
        // users.Add(user3.UserId, user3);
    }
}