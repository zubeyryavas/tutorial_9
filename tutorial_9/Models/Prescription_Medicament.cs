using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tutorial_9.Models;

public class Prescription_Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    [ForeignKey("IdMedicament")]
    public Medicament Medicament { get; set; }
    public int IdPrescription { get; set; }
    [ForeignKey("IdPrescription")]
    public Prescription Prescription { get; set; }
    public int Dose { get; set; }
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}