using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }  // Store hashed password, never store plain text
}
