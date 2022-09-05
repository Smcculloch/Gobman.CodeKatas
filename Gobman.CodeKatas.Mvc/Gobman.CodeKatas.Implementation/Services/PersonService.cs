using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using Gobman.CodeKatas.Abstractions.Contracts;
using Gobman.CodeKatas.Abstractions.Services;
using Gobman.CodeKatas.Database;
using System.Configuration;

namespace Gobman.CodeKatas.Implementation.Services
{
    public class PersonService : IPersonService
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["GobmanCodeKatas"].ToString();
            con = new SqlConnection(constring);
        }
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
            connection();
            Guid g = Guid.NewGuid();
            carrier.PersonId = g;

            SqlCommand cmd = new SqlCommand("Create", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonId", carrier.PersonId);
            cmd.Parameters.AddWithValue("@FirstN", carrier.FirstName);
            cmd.Parameters.AddWithValue("@LastN", carrier.LastName);
            cmd.Parameters.AddWithValue("@PhoneN", carrier.PhoneNumber);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            throw new NotImplementedException();
        }


        public bool Update(PersonCarrier carrier)
        {
            connection();
            SqlCommand cmd = new SqlCommand("Update", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonId", carrier.PersonId);
            cmd.Parameters.AddWithValue("@FirstN", carrier.FirstName);
            cmd.Parameters.AddWithValue("@LastN", carrier.LastName);
            cmd.Parameters.AddWithValue("@PhoneN", carrier.PhoneNumber);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;

            throw new NotImplementedException();
        }

        public void Delete(Guid personId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", personId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

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
