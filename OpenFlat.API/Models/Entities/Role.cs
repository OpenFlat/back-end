using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenFlat.API.Models.Entities.Base;

namespace OpenFlat.API.Models.Entities
{
    [Table("ROLES")]
    public class Role: BaseIdentityEntity
    {
        [Required]
        [MaxLength(100)]
        [Column("NAME")]
        public string Name { get; set; }
        [MaxLength(255)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}
