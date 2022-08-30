using System;
using System.Data.Entity.Migrations;

namespace Gobman.CodeKatas.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<KataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var personId = new Guid("c1ecbeee-a67a-4a66-9744-6a45b27c706b");
            var someoneElsePersonId = new Guid("42ef2656-23ee-4233-b700-fe0ce24c4766");
            var addressId = new Guid("dc75dd0c-b2d6-4601-b87b-c8f8b83113a9");

            context.Addresses.AddOrUpdate(new Address
            {
                AddressId = addressId,
                StreetAddress1 = "Trädgårdsgatan 5",
                PostalCode = "553 16",
                City = "Jönköping",
                Country = "Sweden"
            });

            context.Persons.AddOrUpdate(new Person
            {
                PersonId = personId,
                FirstName = "Stephen",
                LastName = "McCulloch",
                PhoneNumber = "0707887543",
                AddressId = addressId
            });

            context.Persons.AddOrUpdate(new Person
            {
                PersonId = someoneElsePersonId,
                FirstName = "Anders",
                LastName = "Johansson",
                PhoneNumber = "0707654321",
                AddressId = addressId
            });
        }
    }
}
