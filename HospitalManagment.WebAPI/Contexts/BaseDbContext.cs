using HospitalManagment.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.WebAPI.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost, 1433; Database=Hospital_db; User=sa; Password=admin123456789; TrustServerCertificate = true");
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)  // Appointment'ın bir Doctor'u var
            .WithMany(d => d.Appointments) // Bir Doctor'un birden fazla randevusu var
            .HasForeignKey(a => a.DoctorId); // Foreign key olarak DoctorId kullan

        base.OnModelCreating(modelBuilder);
    }
}
