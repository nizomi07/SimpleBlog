using System.Security.Claims;
using SimpleBlogMVC.Models.Entities;

namespace SimpleBlogMVC.DTOs;

public class LoginResponseDTO
{
    public User User { get; set; }
    public List<Claim> Claims { get; set; }
}