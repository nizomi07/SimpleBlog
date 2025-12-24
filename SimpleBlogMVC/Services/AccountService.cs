using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SimpleBlogMVC.DTOs;
using SimpleBlogMVC.Models.Entities;

namespace SimpleBlogMVC.Services;

public class AccountService(UserManager<User> userManager, SignInManager<User> signInManager) : IAccountService
{
    public async Task<Response<LoginResponseDTO>> LoginAsync(LoginDTO loginDto)
    {
        var user = await userManager.FindByNameAsync(loginDto.Username);
        if (user is not null)
        {
            var isValidPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (isValidPassword)
            {
                var claims = new List<Claim>()
                {
                    new (ClaimTypes.Name, user.UserName!),
                    new (ClaimTypes.Email, user.Email!),
                    new ("FirstName", user.FirstName)
                };
                
                await signInManager.SignInWithClaimsAsync(user, true, claims);
                return new Response<LoginResponseDTO>(new LoginResponseDTO()
                {
                    User = user,
                    Claims = claims
                });
            }
            else
            {
                return new Response<LoginResponseDTO>(HttpStatusCode.BadRequest, "password is incorrect");
            }
        }
        return new Response<LoginResponseDTO>(HttpStatusCode.BadRequest, "login or password is incorrect");
    }
    
    public async Task<Response<RegisterDTO>> RegisterAsync(RegisterDTO model)
    {
        var mapped = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Username,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
        var response = await userManager.CreateAsync(mapped,model.Password);
        if (response.Succeeded)
            return new Response<RegisterDTO>(model);
        else return new Response<RegisterDTO>(HttpStatusCode.BadRequest, response.Errors.Select(e=>e.Description).ToList());

    }
}