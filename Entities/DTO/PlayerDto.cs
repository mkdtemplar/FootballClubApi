using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;

namespace Entities.DTO;

public class PlayerDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("PlayerId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "First name field is required")]
    [MaxLength(200, ErrorMessage = "First name max length 200 characters")]
    [Column("First Name", TypeName = "nvarchar(200)")]
    public string? FirstName { get; set; }


    [Required(ErrorMessage = "Last nme is required")]
    [MaxLength(400, ErrorMessage = "Max length of Last name is 400 characters")]
    [Column("Last Name", TypeName = "nvarchar(400)")]
    public string? LastName { get; set; }
    

    [Required(ErrorMessage = "Date of birth is required")]
    [Column("Date of Birth", TypeName = "datetime")]
    public DateTime? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Signing date is required.")]
    [Column("Signing Date", TypeName = "datetime")]
    public DateTime? SigningDate { get; set; }

    [Required(ErrorMessage = "Rank field is required")]
    [Column("Rank")]
    public int Rank { get; set; }

    [Required(ErrorMessage = "Field Total goals is required")]
    [Column("TotalGoals")]
    public int TotalGoals { get; set; }

    [ForeignKey(nameof(Club))]
    public int ClubId { get; set; }

}
