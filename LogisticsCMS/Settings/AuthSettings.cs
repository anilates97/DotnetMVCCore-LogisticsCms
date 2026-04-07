using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Settings;

public class AuthSettings
{
    [Required]
    public string Username { get; set; } = "admin";

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public string DisplayName { get; set; } = "Admin";
}
