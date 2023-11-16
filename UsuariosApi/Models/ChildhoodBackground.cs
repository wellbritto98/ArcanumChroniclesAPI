using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("ChildhoodBackground")]
public class ChildhoodBackground
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    public virtual ICollection<Character> Characters { get; set; }
}
