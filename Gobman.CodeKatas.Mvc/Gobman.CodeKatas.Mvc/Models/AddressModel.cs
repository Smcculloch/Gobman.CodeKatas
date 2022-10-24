using System;
using Gobman.CodeKatas.Database;

namespace Gobman.CodeKatas.Mvc.Models
{
    public class AddressModel
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