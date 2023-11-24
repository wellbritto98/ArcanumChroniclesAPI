using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuariosApi.Models;

public class Name
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string NameChar { get; set; }
    
    [Required]
    [StringLength(1)]
    public string Gender { get; set; }
    
    
    
    
}