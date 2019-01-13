using System;
using System.ComponentModel.DataAnnotations.Schema;
using OpenFlat.API.Attributes;

namespace OpenFlat.API.Models.Entities.Base
{
    public abstract class BaseRecordEntity: BaseIdentityEntity
    {
        [Column("ADD_USER_ID")]
        public int AddUserId { get; set; }
        [Column("ADD_TIME")]
        public DateTime AddTime { get; set; }    
        [Column("UPD_USER_ID")]
        public int? UpdUserId { get; set; } 
        [Column("UPD_TIME")]
        public DateTime? UpdTime { get; set; }
        [Column("DEL_USER_ID")]
        public int? DelUserId { get; set; }
        [Column("DEL_TIME")]
        public DateTime? DelTime { get; set; }
        public bool? Deleted { get; set; }
    }
}
