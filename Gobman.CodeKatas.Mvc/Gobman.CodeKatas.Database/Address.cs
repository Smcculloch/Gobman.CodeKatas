using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gobman.CodeKatas.Database
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string StreetAddress1 { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string StreetAddress2 { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string PostalCode { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string City { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
