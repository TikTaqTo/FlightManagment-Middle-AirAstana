using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Abstractions;

public interface IAuthService
{
    public LoginResponse? Login(LoginRequest request);
    public bool FirstInitiazlie();
}