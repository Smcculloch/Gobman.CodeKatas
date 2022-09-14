using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gobman.CodeKatas.Database
{
    public class Address
    {
        public Guid AddressId { get; set; }

        public Guid? PersonId { get; set; }

        public virtual Person Person { get; set; } 
        
        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
