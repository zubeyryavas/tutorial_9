using Microsoft.EntityFrameworkCore;
using tutorial_9.Models;

namespace tutorial_9.Context
{
    public class HospitalDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public HospitalDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public HospitalDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultDbCon"));
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Medicament>(e =>
            {
                e.HasData(new Medicament
                {
                    IdMedicament = 1,
                    Name = "xD",
                    Description = "xD",
                    Type = "xD"
                });
            });
            modelBuilder.Entity<Patient>(e =>
            {
                e.HasData(new Patient
                {
                    IdPatient = 1,
                    FirstName = "xD",
                    LastName = "xD",
                    BirthDate = new DateTime(2001, 6, 29)
                });
            });
            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasData(new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "xD",
                    LastName = "xD",
                    Email = "xD"
                });
            });
            modelBuilder.Entity<Prescription>(e =>
            {
                e.HasData(new Prescription
                {
                    IdPrescription = 1,
                    Date = new DateTime(2022, 5, 20),
                    DueDate = new DateTime(2022, 5, 23),
                    IdPatient = 1,
                    IdDoctor = 1
                });
            });
            modelBuilder.Entity<Prescription_Medicament>(e =>
            {
                e.HasData(new Prescription_Medicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 5,
                    Details = "xD"
                });
            });
        }
    }
}
