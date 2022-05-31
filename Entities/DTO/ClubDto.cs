using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;

namespace Entities.DTO;

public class ClubDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ClubId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name field is required")]
    [MaxLength(200, ErrorMessage = "Max length of name field is 200 characters")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Owner field is required")]
    [MaxLength(200, ErrorMessage = "Max length of owner field is 200 characters")]
    public string? Owner { get; set; }

    [Required(ErrorMessage = "City field is required")]
    [MaxLength(200, ErrorMessage = "Max length of city field is 200 characters")]
    public string? City { get; set; }

    [Required(ErrorMessage = "Country is mandatory field")]
    [MaxLength(200, ErrorMessage = "Max length of country field is 400 characters")]
    public string? Country { get; set; }

    public IEnumerable<PlayerDto>? Players { get; set; }
}