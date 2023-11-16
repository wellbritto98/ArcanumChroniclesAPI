using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuariosApi.Models
{
    [Table("FatherBackground")]
    public class FatherBackground
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}