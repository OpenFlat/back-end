using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenFlat.API.Models.Entities.Base;

namespace OpenFlat.API.Models.Entities
{
    [Table("USER_ROLES")]
    public class UserRole: BaseIdentityEntity
    {
        [Required]
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Required]
        [Column("ROLE_ID")]
        public int RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }        
    }
}
