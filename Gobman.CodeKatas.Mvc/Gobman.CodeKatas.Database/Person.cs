using System;
using System.Collections.Generic;

namespace Gobman.CodeKatas.Database
{
    public class Person
    {
        public Guid? PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
