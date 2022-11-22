using System.ComponentModel.DataAnnotations.Schema;

namespace LoL.Data.Enities;
[Table("Champion")]
public class Champion
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Hp { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Manna { get; set; }

    [Required]
    [ForeignKey("Role")]
    public int RoleId { get; set; }

    [Required]
    public DateTime DateOfRelease { get; set; }   

    public virtual Role Role { get; set; }
}
