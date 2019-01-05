using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenFlat.API.Models.Entities.Base;
using OpenFlat.API.Models.Enums;

namespace OpenFlat.API.Models.Entities
{
    [Table("USERS")]
    public class User: BaseIdentityEntity
    {
        [Required]
        [MaxLength(60)]
        [Column("USER_NAME")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(60)]
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Required]
        [MaxLength(60)]
        [Column("NAME")]
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        [Column("SURNAME")]
        public string Surname { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("EMAIL")]
        public string Email { get; set; }
        [MaxLength(10)]
        [Column("PHONE_MOBILE")]
        public string PhoneMobile { get; set; }
        [MaxLength(10)]
        [Column("PHONE_HOME")]
        public string PhoneHome { get; set; }
        [MaxLength(10)]
        [Column("PHONE_OFFICE")]
        public string PhoneOffice { get; set; }
        [Column("BIRTH_DATE")]
        public DateTime? BirthDate { get; set; }
        [Column("GENDER")]
        public GenderType? Gender { get; set; }
    }
}
