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
            var addressId2 = new Guid("dc25dd0c-b2d6-4601-b87b-c8f8b83113a9");
            var addressId3 = new Guid("dc25d10c-b2d6-4601-b87b-c8f8b83113a9");
            var addressId4 = new Guid("dc25ddfd-b2d6-4601-b87b-c8f8b83113a9");
            var addressId5 = new Guid("dc25ccfd-b2d6-4601-b87b-c8f8b83113a9");


            var address = new Address
            {
                AddressId = addressId,
                StreetAddress1 = "Trädgårdsgatan 5",
                PostalCode = "553 16",
                City = "Jönköping",
                Country = "Sweden",
                PersonId = personId,
            };

            var address2 = new Address
            {
                AddressId = addressId2,
                StreetAddress1 = "Cat Street 3",
                PostalCode = "553 16",
                City = "Jönköping",
                Country = "Sweden",
                PersonId = personId,
            };

            context.Addresses.AddOrUpdate(address);
            context.Addresses.AddOrUpdate(address2);

            var person = new Person
            {
                PersonId = personId,
                FirstName = "Stephen",
                LastName = "McCulloch",
                PhoneNumber = "0707887543",
                Addresses = new[] { address, address2 }
            };
            
            context.Persons.AddOrUpdate(person);

            var address3 = new Address
            {
                AddressId = addressId3,
                StreetAddress1 = "Drottninggatan 4",
                PostalCode = "783 16",
                City = "Stockholm",
                Country = "Sweden",
                PersonId = someoneElsePersonId,
            };

            var address4 = new Address
            {
                AddressId = addressId4,
                StreetAddress1 = "Kungsgatan 10",
                PostalCode = "533 16",
                City = "Göteborg",
                Country = "Sweden",
                PersonId = someoneElsePersonId,
            };

            var address5 = new Address
            {
                AddressId = addressId5,
                StreetAddress1 = "Spacegatan 61",
                PostalCode = "952 45",
                City = "Malmö",
                Country = "Sweden",
                PersonId = someoneElsePersonId,
            };

            context.Addresses.AddOrUpdate(address3);
            context.Addresses.AddOrUpdate(address4);
            context.Addresses.AddOrUpdate(address5);

            var person2 = new Person
            {
                PersonId = someoneElsePersonId,
                FirstName = "Anders",
                LastName = "Johansson",
                PhoneNumber = "0707654321",
                Addresses = new[] { address3, address4, address5 }
            };

            context.Persons.AddOrUpdate(person2);
        }
    }
}
