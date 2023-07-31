namespace Blogosphere.WebApi.DTOs;


public record UserDto(int Id, string Username, string Password, string? FirstName, string? LastName, string? Token)
{
    public UserDto() : this(default, default, default, default, default, default)
    {
    }
}
public record CreateUserDto(string Username, string Password, string? FirstName, string? LastName);
public record UpdateUserDto(int Id, string Username, string Password, string? FirstName, string? LastName);

