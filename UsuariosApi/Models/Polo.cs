﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Polo")]
public class Polo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [ForeignKey("Region")]
    public int RegionId { get; set; }

    public virtual Region Region { get; set; }

    public virtual ICollection<Company> Companies { get; set; }

    public virtual ICollection<Location> Locations { get; set; }

    public virtual ICollection<Character> Characters { get; set; }
}
