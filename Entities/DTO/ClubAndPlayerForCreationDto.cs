using System.ComponentModel.DataAnnotations;

namespace Entities.DTO;

public class ClubAndPlayerForCreationDto
{
    [Required(ErrorMessage = "Street field is required")]
    [MaxLength(400, ErrorMessage = "Max length of street field is 400 characters")]
    public string? Street { get; set; }

    [Required(ErrorMessage = "City field is required")]
    [MaxLength(400, ErrorMessage = "Max length of city field is 400 characters")]
    public string? City { get; set; }

    [Required(ErrorMessage = "Country is mandatory field")]
    [MaxLength(400, ErrorMessage = "Max length of country field is 400 characters")]
    public string? Country { get; set; }

    public IEnumerable<PlayerForCreationDto>? Player { get; set; }
}