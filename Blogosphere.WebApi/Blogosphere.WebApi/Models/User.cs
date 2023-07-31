namespace Blogosphere.WebApi.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Token { get; set; }
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public User(int id, string username, string password, string? firstName, string? lastName)
    {
        Id = id;
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }

    public User(string username, string password, string? firstName, string? lastName)
    {
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }
    public User()
    {     
    }
}
