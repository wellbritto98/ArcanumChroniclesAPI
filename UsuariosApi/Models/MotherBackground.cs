namespace UsuariosApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("MotherBackground")]
    public class MotherBackground
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

    [Required]
    [StringLength(1000)]
        public string Description { get; set; }

    public virtual ICollection<Character> Characters { get; set; }
}

