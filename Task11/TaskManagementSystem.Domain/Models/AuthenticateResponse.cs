using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Domain.Models;


public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        Fullname = user.FullName;
        Email = user.Email;
        Role = user.Role.Name;
        Token = token;
    }
}