using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    [Required]
    [Display(Name = "Full Name")]
    public string Name { get; set; }

    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string Phone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
