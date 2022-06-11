using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw6.Models
{
    public class Prescription_Medicament
    {
        [Key]
        public int IdMedicament { get; set; }
        [Key]
        public int IdPrescription { get; set; }
        [Required]
        public int Dose { get; set; }
        [Required, MaxLength(100)]
        public string Details { get; set; }
        [ForeignKey("IdMedicament")]
        public virtual Medicament Medicament { get; set; }
        [ForeignKey("IdPrescription")]
        public virtual Prescription Prescription { get; set; }
    }
}
