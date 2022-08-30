﻿using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Update(PersonCarrier carrier)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid personId)
        {
            throw new NotImplementedException();
        }

        public Guid CreateAddress(AddressCarrier carrier)
        {
            throw new NotImplementedException();
        }

        public void SetAddress(Guid personId, Guid addressId)
        {
            throw new NotImplementedException();
        }

        private PersonCarrier ProjectCarrierModel(Person person)
        {
            return new PersonCarrier
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Address = person.AddressId.HasValue
                    ? new AddressCarrier
                    {
                        AddressId = person.Address.AddressId,
                        StreetAddress1 = person.Address.StreetAddress1,
                        StreetAddress2 = person.Address.StreetAddress2,
                        PostalCode = person.Address.PostalCode,
                        City = person.Address.City,
                        Country = person.Address.Country
                    }
                    : null
            };
        }
    }
}