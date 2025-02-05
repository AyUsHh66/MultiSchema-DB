using Microsoft.EntityFrameworkCore;
using MultiSchemaDB_Project.Models;

namespace MultiSchemaDB_Project.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options) { }

        public DbSet<Schema1Customer> Schema1Customer { get; set; }
        public DbSet<Schema2Customer> Schema2Customer { get; set; }
        public DbSet<Schema3Customer> Schema3Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map Schema1.Customer
            modelBuilder.Entity<Schema1Customer>(entity =>
            {
                entity.ToTable("Customer", "Schema1");
                entity.HasKey(c => c.CustomerID);

                entity.Property(c => c.CustomerID).HasColumnName("CustomerID");
                entity.Property(c => c.FirstName).HasColumnName("FirstName");
                entity.Property(c => c.LastName).HasColumnName("LastName");
                entity.Property(c => c.Email).HasColumnName("Email");
            });

            // Map Schema2.Customer
            modelBuilder.Entity<Schema2Customer>(entity =>
            {
                entity.ToTable("Customer", "Schema2");
                entity.HasKey(c => c.CustomerID);

                entity.Property(c => c.CustomerID).HasColumnName("CustomerID");
                entity.Property(c => c.FullName).HasColumnName("FullName");
                entity.Property(c => c.Email).HasColumnName("Email");
                entity.Property(c => c.Phone).HasColumnName("Phone");
            });

            // Map Schema3.Customer
            modelBuilder.Entity<Schema3Customer>(entity =>
            {
                entity.ToTable("Customer", "Schema3");
                entity.HasKey(c => c.CustomerID);

                entity.Property(c => c.CustomerID).HasColumnName("CustomerID");
                entity.Property(c => c.CompanyName).HasColumnName("CompanyName");
                entity.Property(c => c.ContactPerson).HasColumnName("ContactPerson");
                entity.Property(c => c.Email).HasColumnName("Email");
                entity.Property(c => c.Address).HasColumnName("Address");
            });
        }
    }
}
