using Microsoft.EntityFrameworkCore;

namespace cw6.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DB-MSSQL16; Database=2019SBD; Trusted_Connection=TRUE")
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription_Medicament>().HasKey(nameof(Prescription_Medicament.IdMedicament), nameof(Prescription_Medicament.IdPrescription));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Alek", LastName = "Pieturszka", Email = "pietr@wp.pl"},
                    new Doctor { IdDoctor = 2, FirstName = "Patryk", LastName = "Fikolek", Email = "fikolek@wp.pl"}
                    );
            });
            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasData(
                    new Medicament { IdMedicament = 1, Name = "Pawulon", Description = "przeciwbolowy", Type = "dobry"},
                    new Medicament { IdMedicament = 2, Name = "Ibuprom", Description = "przeciwbolowy", Type = "Taki sobie"}
                    );
            });
            modelBuilder.Entity<Patient>(p =>
            {
                p.HasData(
                    new Patient { IdPatient = 1, FirstName = "Pawel", LastName = "Superor", BirthDate = System.DateTime.UtcNow},
                    new Patient { IdPatient = 2, FirstName = "Michal", LastName = "Falek", BirthDate = System.DateTime.UtcNow}
                    );
            });
            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasData(
                    new Prescription { IdPrescription = 1, Date = System.DateTime.UtcNow, DueDate = System.DateTime.UtcNow, IdPatient = 1, IdDoctor = 1 },
                    new Prescription { IdPrescription = 2, Date = System.DateTime.UtcNow, DueDate = System.DateTime.UtcNow, IdPatient = 2, IdDoctor = 1 }
                    );
            });
            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasData(
                    new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 100, Details = "Lek wazny miesiac"},
                    new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 5, Details = "Lek wazny rok"}
                    );
            });

        }



    }
}
