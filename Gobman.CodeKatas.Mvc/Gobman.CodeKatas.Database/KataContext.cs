using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gobman.CodeKatas.Database
{
    public class KataContext: DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public KataContext(): base("GobmanCodeKatas")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
