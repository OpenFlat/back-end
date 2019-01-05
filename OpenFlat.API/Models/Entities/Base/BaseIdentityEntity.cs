using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFlat.API.Models.Entities.Base
{
    public class BaseIdentityEntity : BaseEntity, IBaseIdentityEntity
    {
        [Key]
        [Required]
        [Column("ID")]
        public int Id { get; set; }
    }
}
