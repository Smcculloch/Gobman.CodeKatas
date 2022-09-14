using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gobman.CodeKatas.Database
{
    public class KataContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public KataContext() : base("GobmanCodeKatas")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Person>().HasKey(p => p.PersonId);
            modelBuilder.Entity<Person>().Property(p => p.FirstName).HasColumnType("nvarchar").HasMaxLength(200);
            modelBuilder.Entity<Person>().Property(p => p.LastName).HasColumnType("nvarchar").HasMaxLength(200);
            modelBuilder.Entity<Person>().Property(p => p.PhoneNumber).HasColumnType("nvarchar").HasMaxLength(15);
            modelBuilder.Entity<Person>().HasMany(p => p.Addresses).WithRequired(a => a.Person).HasForeignKey(a => a.PersonId);

            modelBuilder.Entity<Address>().HasKey(a => a.AddressId);
            modelBuilder.Entity<Address>().Property(a => a.StreetAddress1).HasColumnType("nvarchar").HasMaxLength(200);
            modelBuilder.Entity<Address>().Property(a => a.StreetAddress2).HasColumnType("nvarchar").HasMaxLength(200);
            modelBuilder.Entity<Address>().Property(a => a.PostalCode).HasColumnType("nvarchar").HasMaxLength(50);
            modelBuilder.Entity<Address>().Property(a => a.City).HasColumnType("nvarchar").HasMaxLength(50);
            modelBuilder.Entity<Address>().Property(a => a.Country).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
