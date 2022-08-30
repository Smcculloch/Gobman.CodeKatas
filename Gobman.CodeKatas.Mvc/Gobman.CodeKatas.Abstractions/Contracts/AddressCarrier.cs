using System;

namespace Gobman.CodeKatas.Abstractions.Contracts
{
    public class AddressCarrier
    {
        public Guid AddressId { get; set; }

        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
