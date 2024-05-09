class Users
{
    public int UserId { get; set; } 
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public string Password { get; set; }
    


    public Users()
    {
       
    }

    public Users(int userId, string password, string firstName, string lastName, string UserName)
    {
        UserId = userId;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        UserName = string.Join(" ", firstName + lastName);
    }

    public override string ToString()
    {
        return $"{{UserId: {UserId},FirstName: {FirstName}, LastName: {LastName}}}";;
    }
}