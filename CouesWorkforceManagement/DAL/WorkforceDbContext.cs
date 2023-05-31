using CouesWorkforceManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace CouesWorkforceManagement.DAL
{
    public class WorkforceDbContext : DbContext
    {
        public WorkforceDbContext(DbContextOptions<WorkforceDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table names
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<WorkingHours>().ToTable("WorkingHours");
            modelBuilder.Entity<Salary>().ToTable("Salaries");

            // Configure relationships
            //modelBuilder.Entity<WorkingHours>()
            //    .HasOne(w => w.EmployeeId)
            //    .WithMany(e => e.WorkingHours)
            //    .HasForeignKey(w => w.EmployeeId);

            //modelBuilder.Entity<Salary>()
            //    .HasOne(s => s.Employee)
            //    .WithMany(e => e.Salaries)
            //    .HasForeignKey(s => s.EmployeeId);
        }
    }

}


