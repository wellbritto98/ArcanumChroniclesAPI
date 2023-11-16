using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TypeOfMagic")]
public class TypeOfMagic
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)] // Ajuste conforme a necessidade para o tamanho da descrição
    public string Description { get; set; }

    public virtual ICollection<Character> Characters { get; set; }
}
