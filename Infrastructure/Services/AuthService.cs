using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Abstractions;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entity;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class AuthService(ApplicationContext dbContext) : IAuthService
{
    public ApplicationContext DbContext { get; set; } = dbContext;

    public LoginResponse? Login(LoginRequest request)
    {
        var currentUser = DbContext.Users.Include(user => user.Role)
            .FirstOrDefault(x => x.Username == request.username && x.Password == BCrypt.Net.BCrypt.HashPassword(request.password));

        if (currentUser == null)
            return null;
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, currentUser.Username),
            new Claim(ClaimTypes.Role, currentUser.Role?.Name  ?? "" ),
        };
        
        var jwt = new JwtSecurityToken(
            issuer: "MyAuthServer",
            audience: "MyAuthClient",
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey("secretKey"u8.ToArray()), SecurityAlgorithms.HmacSha256));
        
        var handler = new JwtSecurityTokenHandler();
        
        return new LoginResponse()
        {
            accessToken = handler.WriteToken(jwt),
            role = jwt.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Role)
                ?.Value ?? "",
            expiresIn = (int)(jwt.ValidTo - DateTime.UtcNow).TotalSeconds
        };
    }

    public bool FirstInitiazlie()
    {
        var baseRoles = new List<Role>
        {
            new(){ Name = "Admin" },
            new(){ Name = "Manager" },
            new(){ Name = "User" }
        };
        
        DbContext.Roles.AddRange(baseRoles);
        
        var baseUsers = new List<User>()
        {
            new ()
            {
                Id = Guid.NewGuid(),
                Username = "admin@demo.local",
                Password = BCrypt.Net.BCrypt.HashPassword("P@ssw0rd!1"),
                RoleId = baseRoles[0].Id,
                Role = baseRoles[0]
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Username = "manager@demo.local",
                Password = BCrypt.Net.BCrypt.HashPassword("P@ssw0rd!1"),
                RoleId = baseRoles[1].Id,
                Role = baseRoles[1]
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Username = "user@demo.local",
                Password = BCrypt.Net.BCrypt.HashPassword("P@ssw0rd!1"),
                RoleId =  baseRoles[2].Id,
                Role = baseRoles[2]
            },
        };
        
        DbContext.Users.AddRange(baseUsers);
        
        DbContext.SaveChanges();

        return true;
    }
}