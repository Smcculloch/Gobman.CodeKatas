using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using Gobman.CodeKatas.Abstractions.Contracts;
using Gobman.CodeKatas.Abstractions.Services;
using Gobman.CodeKatas.Database;

namespace Gobman.CodeKatas.Implementation.Services
{
    public class PersonService : IPersonService
    {

        private readonly KataContext _context;

        public PersonService(KataContext context)
        {
            _context = context;
        }

        public IList<PersonCarrier> GetAll()
        {
            return _context.Persons
                           .Select(ProjectCarrierModel)
                           .ToList();
        }

        public PersonCarrier Get(Guid personId)
        {
            return ProjectCarrierModel(_context.Persons.Find(personId));
        }

        public Guid Create(PersonCarrier carrier)
        {
            var person = new Person
            {
                PersonId = Guid.NewGuid(),
                FirstName = carrier.FirstName,
                LastName = carrier.LastName,
                PhoneNumber = carrier.PhoneNumber
            };

            _context.Persons.Add(person);
            _context.SaveChanges();

            return (Guid)person.PersonId;
        }


        public void Update(PersonCarrier carrier)
        {
            var person = new Person
            {
                PersonId = carrier.PersonId,
                FirstName = carrier.FirstName,
                LastName = carrier.LastName,
                PhoneNumber = carrier.PhoneNumber
            };

            _context.Persons.AddOrUpdate(person);
            _context.SaveChanges();
        }

        public void Delete(Guid personId)
        {
            var person = _context.Persons.Find(personId);   

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    

        public Guid CreateAddress(AddressCarrier carrier)
        {
            //Create only?
            throw new NotImplementedException();
        }

        public void SetAddress(Guid personId, Guid addressId)
        {
            //What's this for?
            //Using both person/address ID's.
            throw new NotImplementedException();
        }

        private PersonCarrier ProjectCarrierModel(Person person)
        {
            return new PersonCarrier
            {
                PersonId = (Guid)person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Addresses = person.Addresses != null
                    ? person.Addresses
                            .Select(a => new AddressCarrier
                            {
                                AddressId = a.AddressId,
                                StreetAddress1 = a.StreetAddress1,
                                StreetAddress2 = a.StreetAddress2,
                                PostalCode = a.PostalCode,
                                City = a.City,
                                Country = a.Country
                            })
                            .ToArray()
                    : Array.Empty<AddressCarrier>()
            };
        }
    }
}
