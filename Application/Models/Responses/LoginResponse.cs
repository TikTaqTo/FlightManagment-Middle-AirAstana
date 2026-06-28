namespace Application.Models.Responses;

public class LoginResponse
{
    public string accessToken { get; set; }
    public int expiresIn { get; set; }
    public string role { get; set; }
}