using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gobman.CodeKatas.Database
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }

        public Guid? AddressId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public virtual Address Address { get; set; }
    }
}
