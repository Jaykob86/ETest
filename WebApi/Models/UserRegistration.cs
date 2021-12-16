using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class UserRegistration : IValidatableObject
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 6)]
    public string Password { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(Birthday == DateTime.MinValue) yield return new ValidationResult("Birthday date is required");
        if(Birthday.Year > DateTime.UtcNow.Year) yield return new ValidationResult("Birthday cannot be in future");
    }
}
