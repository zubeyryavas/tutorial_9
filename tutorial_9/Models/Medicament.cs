using System.ComponentModel.DataAnnotations;

namespace tutorial_9.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
    [Required]
    [MaxLength(100)]
    public string Type { get; set; }
    public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
}