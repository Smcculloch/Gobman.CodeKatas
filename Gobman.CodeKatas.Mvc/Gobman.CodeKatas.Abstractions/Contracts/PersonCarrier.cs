using System;

namespace Gobman.CodeKatas.Abstractions.Contracts
{
    public class PersonCarrier
    {
        public Guid PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public AddressCarrier Address { get; set; }
    }
}
