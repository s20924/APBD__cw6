using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cw6.Models
{
    public class Doctor
    {
        public Doctor(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public Doctor(int id, string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public Doctor() { }

        [Key]
        public int IdDoctor { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
