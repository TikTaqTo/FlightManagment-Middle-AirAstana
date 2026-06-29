using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests;

public class LoginRequest
{
    [Required]
    [MinLength(4)]
    [MaxLength(100)]
    public string username { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(100)]
    public string password { get; set; }
}