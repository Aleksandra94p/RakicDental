using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RakicDental.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
       

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Treatment>(entity =>
        {
            entity.Property(t => t.Price)
                  .HasPrecision(18, 2);
             });

            modelBuilder.Entity<Dentist>().HasData(
                new Dentist() {Id = 1, Name = "Ljubomir", LastName = "Rakić", Specialization = "Oralni hirurg" },
                 new Dentist() {Id = 2, Name = "Jasmina", LastName = "Rakić", Specialization = "Protetičar" },
                  new Dentist() {Id = 3, Name = "Boris", LastName = "Vrhovac", Specialization = "Ortodont" }
                );

            
            modelBuilder.Entity<Patient>().HasData(
                
                new Patient() { Id = 1, Name = "Aleksandra", LastName = "Petrovic", PhoneNumber = "0693149760" },
                 new Patient() { Id = 2, Name = "Anamarija", LastName = "Topic", PhoneNumber = "0631102998" }
                );

            
            modelBuilder.Entity<Treatment>().HasData(
                new Treatment() {Id = 1, Name = "Uklanjanje kamenca", Price = 3000.00m, PatientId = 1, DentistId = 1},
                new Treatment() {Id = 2, Name = "Vadjenje zuba", Price = 3000.00m, PatientId = 2, DentistId = 2 }
                );


            base.OnModelCreating(modelBuilder);
        }


    }
}
